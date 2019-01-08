using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Emplyees.Context;
using Emplyees.Models;

namespace Emplyees.Controllers
{
    public class EmplyeesController : Controller
    {
        private BaseContext db = new BaseContext();

        // GET: Emplyees
        public async Task<ActionResult> Index()
        {
            return View(await db.Emplyees.ToListAsync());
        }

        // GET: Emplyees/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emplyee emplyee = await db.Emplyees.FindAsync(id);
            if (emplyee == null)
            {
                return HttpNotFound();
            }
            return View(emplyee);
        }

        // GET: Emplyees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emplyees/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Surname,Age,Gender,DepartmentId")] Emplyee emplyee)
        {
            if (ModelState.IsValid)
            {
                db.Emplyees.Add(emplyee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(emplyee);
        }

        // GET: Emplyees/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emplyee emplyee = await db.Emplyees.FindAsync(id);
            if (emplyee == null)
            {
                return HttpNotFound();
            }
            return View(emplyee);
        }

        // POST: Emplyees/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Surname,Age,Gender,DepartmentId")] Emplyee emplyee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emplyee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(emplyee);
        }

        // GET: Emplyees/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emplyee emplyee = await db.Emplyees.FindAsync(id);
            if (emplyee == null)
            {
                return HttpNotFound();
            }
            return View(emplyee);
        }

        // POST: Emplyees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Emplyee emplyee = await db.Emplyees.FindAsync(id);
            db.Emplyees.Remove(emplyee);
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
