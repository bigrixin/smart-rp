using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartRP.Domain;
using SmartRP.Infrastructure.Data;

namespace MyAbilityFirst.Controllers
{
    public class InterestsController : Controller
    {
        private SmartRPDbContext db = new SmartRPDbContext();

        // GET: Interests
        public async Task<ActionResult> Index()
        {
            return View(await db.Interests.ToListAsync());
        }

        // GET: Interests/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interest interest = await db.Interests.FindAsync(id);
            if (interest == null)
            {
                return HttpNotFound();
            }
            return View(interest);
        }

        // GET: Interests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Interests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Title,Description,StudentId,SupervisorId,ProjectId,CreatedAt,UpdatedAt")] Interest interest)
        {
            if (ModelState.IsValid)
            {
                db.Interests.Add(interest);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(interest);
        }

        // GET: Interests/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interest interest = await db.Interests.FindAsync(id);
            if (interest == null)
            {
                return HttpNotFound();
            }
            return View(interest);
        }

        // POST: Interests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Title,Description,StudentId,SupervisorId,ProjectId,CreatedAt,UpdatedAt")] Interest interest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interest).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(interest);
        }

        // GET: Interests/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interest interest = await db.Interests.FindAsync(id);
            if (interest == null)
            {
                return HttpNotFound();
            }
            return View(interest);
        }

        // POST: Interests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Interest interest = await db.Interests.FindAsync(id);
            db.Interests.Remove(interest);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
