using SmartRP.Infrastructure;
using System.Web.Mvc;

namespace SmartRP.Controllers
{
    [Authorize(Roles = "Supervisor")]
    public class SupervisorController : Controller
    {
        #region Fields

        private readonly IWriteEntities _entities;

        #endregion

        #region Ctor

        public SupervisorController(IWriteEntities entities)
        {
            this._entities = entities;
        }

        #endregion

        #region Actions
        public ActionResult Info(string usertype)
        {
            ViewBag.UserEmail = User.Identity.Name;

            ViewBag.TypeOfUser = usertype;
            return View();
        }
        // GET: Supervisor
        public ActionResult Index()
        {
            return View();
        }

        #endregion
    }
}