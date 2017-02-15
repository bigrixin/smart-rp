using Microsoft.AspNet.Identity;
using SmartRP.Domain;
using SmartRP.Domain.StudentFunctions;
using SmartRP.Infrastructure;
using SmartRP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SmartRP.Controllers
{
	[Authorize]
	public class InterestController : Controller
	{

		#region Fields

		private readonly IWriteEntities _entities;
	//	private readonly IStudentService _studentService;

		#endregion

          
		#region Ctor

		public InterestController(IWriteEntities entities)
		{
			this._entities = entities;
		}

		#endregion
  /*
		#region Actions

		[HttpGet, Route("insterest")]
		public ActionResult Index()
		{
			InterestViewModel model = new InterestViewModel();

			var student = this.GetLoggedInStudent();
			var interests = student.PostedInterests;

			var jobsVM = new List<InterestViewModel>();
            interests.ToList().ForEach(j =>
			{
				var vm = MapJobToInterestViewModel(j);
				jobsVM.Add(vm);
			});

			return View(jobsVM);
		}

		[HttpGet, Route("insterest/create")]
		public ActionResult Create()
		{
			InterestViewModel model = new InterestViewModel();
			return View(model);
		}

		[HttpPost, Route("insterest/create")]
		[ValidateAntiForgeryToken]
		public ActionResult Create(InterestViewModel model)
		{
			if (ModelState.IsValid)
			{
				var client = this.GetLoggedInStudent();
				Job newJob = this._studentService.PostNewJob(client.ID, model.Title, model.Description, model.SuburbId, model.GenderId, model.ServiceId, model.ServicedAt);

				return RedirectToAction("Details/" + newJob.ID.ToString());
			}

			return View(model);
		}

		[HttpGet, Route("insterest/edit/{id:int}")]
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var client = this.GetLoggedInStudent());
			var job = client.PostedJobs.SingleOrDefault(j => j.ID == id);

			if (job == null)
				return RedirectToAction("Info", "Client");

			InterestViewModel model = MapJobToInterestViewModel(job);

			return View(model);
		}

		[HttpPost, Route("insterest/edit/{id:int}")]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(InterestViewModel model)
		{
			if (ModelState.IsValid)
			{
				var client = this.GetLoggedInStudent();

				this._studentService.EditJob(
						client.ID,
						model.Id,
						model.Title,
						model.Description,
						model.SuburbId,
						model.GenderId,
						model.ServiceId,
						model.ServicedAt
						);

				return RedirectToAction("Details/" + model.Id.ToString());
			}

			return View(model);
		}

		[HttpGet, Route("insterest/details/{id:int}")]
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var client = this.GetLoggedInStudent();
			Job job = client.PostedJobs.SingleOrDefault(j => j.ID == id);

			if (job == null)
				return RedirectToAction("Info", "Client");

			InterestViewModel model = MapJobToInterestViewModel(job);

			return View(model);
		}

		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var client = this.GetLoggedInStudent();
			Job job = client.PostedJobs.Where(j => j.ID == id).SingleOrDefault();

			if (job == null)
				return RedirectToAction("Info", "Client");

			InterestViewModel model = MapJobToInterestViewModel(job);

			return View(model);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			var client = this.GetLoggedInStudent();
			this._studentService.DeleteJob(client.ID, id);

			return RedirectToAction("Index");
		}

		#endregion

        */
		#region Helpers


            /*
		private Student GetLoggedInStudent()
		{
			var aspNetIdentityId = User.Identity.GetUserId();
			var student = this._entities.Single<Student>(c => c.AspNetIdentityId == aspNetIdentityId);

			return student;
		}

		private InterestViewModel MapJobToInterestViewModel(Interest interest)
		{
			InterestViewModel model = new InterestViewModel()
			{
				Id = job.ID,
				Title = job.Title,
				Description = job.Description,
				ServicedAt = job.ServiceAt,
				SuburbId = job.SuburbId,
				GenderId = job.GenderId,
				ServiceId = job.ServiceId
			};
			// model.SuburbList=
			// model.ServiceList=
			// model.GenderList=

			return model;
		}

    */
		#endregion

	}
}