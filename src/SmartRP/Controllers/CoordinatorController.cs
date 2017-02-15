using SmartRP.Infrastructure;
using System.Web.Mvc;

namespace MyAbilityFirst.Controllers
{
    [Authorize(Roles = "Coordinator")]
    public class CoordinatorController : Controller
    {
        // GET: Coordinator

        #region Fields

        private readonly IWriteEntities _entities;

        #endregion

        #region Ctor

        public CoordinatorController(IWriteEntities entities)
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