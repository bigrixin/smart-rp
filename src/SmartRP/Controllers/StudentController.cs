using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SmartRP.Infrastructure;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SmartRP.Controllers
{
	[Authorize(Roles = "Student")]
	public class StudentController : Controller
	{

		#region Fields

		private readonly UserManager<IdentityUser> _userManager;
		private readonly IWriteEntities _entities;

		#endregion

		#region Ctor

		public StudentController(UserManager<IdentityUser> userManager, IWriteEntities entities)
		{
			this._userManager = userManager;
			this._entities = entities;
		}

		#endregion

		#region Actions

		public async Task<ActionResult> Info()
		{
			var loggedInUserId = User.Identity.GetUserId();
			var emailVerified = await this._userManager.IsEmailConfirmedAsync(loggedInUserId);
            this._userManager.GetRoles(loggedInUserId).Count.ToString();
			@ViewBag.UserEmail = User.Identity.Name;
			@ViewBag.EmailVerified = emailVerified;

			// is this needed? TypeOfUser will always be 'Client' since this is ClientController
			//ViewBag.TypeOfUser = "Client";

			return View();
		}

		#endregion

	}
}