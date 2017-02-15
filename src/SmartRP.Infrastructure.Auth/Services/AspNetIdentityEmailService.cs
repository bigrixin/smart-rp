using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SmartRP.Infrastructure.Auth
{
	public class AspNetIdentityEmailService : IIdentityMessageService
	{

		public Task SendAsync(IdentityMessage message)
		{
			// Plug in your email service here to send an email.

			///// if use MS Azure SendGrid  mail service need install reference SendGrid
			var credentialUserName = ConfigurationManager.AppSettings["emailFrom"];
			var sentFrom = ConfigurationManager.AppSettings["emailFrom"];
			var pwd = ConfigurationManager.AppSettings["emailPassword"];
			var SMTP = ConfigurationManager.AppSettings["servidorSMTP"];
			var port = ConfigurationManager.AppSettings["SMTPPort"];

			// Configure the client:
			SmtpClient client = new SmtpClient(SMTP);
			client.EnableSsl = true;    //need change for smtp
			client.Port = Convert.ToInt32(port);           //need change for smtp
			client.DeliveryMethod = SmtpDeliveryMethod.Network;
			client.UseDefaultCredentials = false;
			client.Credentials = new NetworkCredential(credentialUserName, pwd);

			// Create the message:
			var mail = new System.Net.Mail.MailMessage(sentFrom, message.Destination);
			mail.Subject = message.Subject;
			mail.Body = message.Body;

			#region formatter
			string text = string.Format("Welcome! Please click on this link to {0}: {1}", message.Subject, message.Body);
			string html = ""; // "Please confirm your account by clicking this link: <a href=\"" + message.Body + "\">Click me</a><br/>";
			html += HttpUtility.HtmlEncode(@"Welcome! Please click on the or copy the following link on the browser: " + message.Body);
			#endregion

			mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
			mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

			return client.SendMailAsync(mail); //await client.SendMailAsync(mail);   
		}

	}
}