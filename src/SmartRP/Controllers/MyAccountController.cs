using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartRP.Domain;
using SmartRP.Infrastructure.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SmartRP.Controllers
{
    [Authorize]
    public class MyAccountController : Controller
    {
        #region Fields

        private readonly UserManager<IdentityUser> _userManager;
        private UserManager<IdentityUser> UserManager
        {
            get
            {
                return this._userManager;
            }
        }

        private readonly RoleManager<IdentityRole> _roleManager;
        private RoleManager<IdentityRole> RoleManager
        {
            get
            {
                return this._roleManager;
            }
        }

        private readonly IUserService _userService;
        #endregion

        #region Ctor

        public MyAccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IUserService userService)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._userService = userService;
        }

        #endregion

        #region Actions
        private string getUserType(IdentityUser aspNetUser)
        {
            //One user can only sign in one role, the first one will be considered.
            //may need change later
            var roleId = aspNetUser.Roles.First().RoleId;
            string userType = this._roleManager.FindById(roleId).Name;
            return userType;
        }

        // GET: MyAccount
        public ActionResult Index()
        {
            var aspNetUser = this._userManager.FindById(User.Identity.GetUserId());
            string userType = getUserType(aspNetUser);

            if (userType == "Admin")
                return RedirectToAction("Info", "Manage", new { usertype = userType });
            else
                return RedirectToAction("Info", userType, new { usertype = userType });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ViewUsers()
        {
            var users = this._userService.GetAllUser();
            return View(users);
        }

        // GET: MyAccount/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = this._userService.FindUser(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        #endregion
    }
}
