using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SmartRP.Infrastructure.Auth.EntityFramework;
using System;
using System.Data.Entity;
using System.Web;

namespace SmartRP.Infrastructure.Auth
{
	public class AspNetIdentityModule : Autofac.Module
	{

		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			// register ASP.NET Identity store
			builder
				.RegisterType<AspNetIdentityDbInitializer>()
				.As<IDatabaseInitializer<AspNetIdentityDbContext>>();

			builder
				.RegisterType<AspNetIdentityDbContext>()
				.As<DbContext>()
				.InstancePerLifetimeScope();

			// register OWIN Authentication context
			builder
				.Register(c => HttpContext.Current.GetOwinContext().Authentication)
				.As<IAuthenticationManager>();

			// register UserStore as is
			builder.RegisterType<UserStore<IdentityUser>>().As<IUserStore<IdentityUser>>();

			// register UserManager as is, with a number of configurations
			builder.Register(c =>
				{
					var userManager = new UserManager<IdentityUser>(c.Resolve<IUserStore<IdentityUser>>());

					// configure validation logic for usernames
					userManager.UserValidator = new UserValidator<IdentityUser>(userManager)
					{
						AllowOnlyAlphanumericUserNames = false,
						RequireUniqueEmail = true
					};

#if !DEBUG
					// configure validation logic for passwords
					userManager.PasswordValidator = new PasswordValidator
					{
						RequiredLength = 6,
						RequireNonLetterOrDigit = true,
						RequireDigit = true,
						RequireLowercase = true,
						RequireUppercase = true,
					};				
#endif

					// configure user lockout defaults
					userManager.UserLockoutEnabledByDefault = true;
					userManager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(15);
					userManager.MaxFailedAccessAttemptsBeforeLockout = 5;

					// - register two factor authentication providers
					// - this application uses Phone and Emails as a step of receiving a code for verifying the user
					// - you can write your own provider and plug it in here
					userManager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<IdentityUser>
					{
						MessageFormat = "Your security code is {0}"
					});
					userManager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<IdentityUser>
					{
						Subject = "Security Code",
						BodyFormat = "Your security code is {0}"
					});

					// configure email service
					userManager.EmailService = new AspNetIdentityEmailService();

					// configure sms service
					userManager.SmsService = new AspNetIdentitySmsService();

					// configure data protection provider
					userManager.UserTokenProvider = new TotpSecurityStampBasedTokenProvider<IdentityUser, string>();

					return userManager;
				})
				.As<UserManager<IdentityUser>>()
				.As<UserManager<IdentityUser, string>>();

			// register RoleStore as is
			builder.RegisterType<RoleStore<IdentityRole>>().As<IRoleStore<IdentityRole, string>>();

			// register RoleManager as is
			builder.RegisterType<RoleManager<IdentityRole>>()
				.As<RoleManager<IdentityRole>>()
				.As<RoleManager<IdentityRole, string>>();

			// register SignInManager as is
			builder.RegisterType<SignInManager<IdentityUser, string>>().AsSelf();
		}

	}
}