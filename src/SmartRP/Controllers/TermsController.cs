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
    public class TermsController : Controller
    {
        private SmartRPDbContext db = new SmartRPDbContext();

        // GET: Terms
        public async Task<ActionResult> Index()
        {
            return View(await db.Terms.ToListAsync());
        }

        // GET: Terms/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Term term = await db.Terms.FindAsync(id);
            if (term == null)
            {
                return HttpNotFound();
            }
            return View(term);
        }

        // GET: Terms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Terms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,TermName,StartAt,EndAt,CoordinatorId")] Term term)
        {
            if (ModelState.IsValid)
            {
                db.Terms.Add(term);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(term);
        }

        // GET: Terms/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Term term = await db.Terms.FindAsync(id);
            if (term == null)
            {
                return HttpNotFound();
            }
            return View(term);
        }

        // POST: Terms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,TermName,StartAt,EndAt,CoordinatorId")] Term term)
        {
            if (ModelState.IsValid)
            {
                db.Entry(term).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(term);
        }

        // GET: Terms/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Term term = await db.Terms.FindAsync(id);
            if (term == null)
            {
                return HttpNotFound();
            }
            return View(term);
        }

        // POST: Terms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Term term = await db.Terms.FindAsync(id);
            db.Terms.Remove(term);
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
