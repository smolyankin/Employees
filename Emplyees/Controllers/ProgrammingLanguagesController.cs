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
    public class ProgrammingLanguagesController : Controller
    {
        private BaseContext db = new BaseContext();

        // GET: ProgrammingLanguages
        public async Task<ActionResult> Index()
        {
            return View(await db.ProgrammingLanguages.ToListAsync());
        }

        // GET: ProgrammingLanguages/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgrammingLanguage programmingLanguage = await db.ProgrammingLanguages.FindAsync(id);
            if (programmingLanguage == null)
            {
                return HttpNotFound();
            }
            return View(programmingLanguage);
        }

        // GET: ProgrammingLanguages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProgrammingLanguages/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title")] ProgrammingLanguage programmingLanguage)
        {
            if (ModelState.IsValid)
            {
                db.ProgrammingLanguages.Add(programmingLanguage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(programmingLanguage);
        }

        // GET: ProgrammingLanguages/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgrammingLanguage programmingLanguage = await db.ProgrammingLanguages.FindAsync(id);
            if (programmingLanguage == null)
            {
                return HttpNotFound();
            }
            return View(programmingLanguage);
        }

        // POST: ProgrammingLanguages/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title")] ProgrammingLanguage programmingLanguage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programmingLanguage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(programmingLanguage);
        }

        // GET: ProgrammingLanguages/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgrammingLanguage programmingLanguage = await db.ProgrammingLanguages.FindAsync(id);
            if (programmingLanguage == null)
            {
                return HttpNotFound();
            }
            return View(programmingLanguage);
        }

        // POST: ProgrammingLanguages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            ProgrammingLanguage programmingLanguage = await db.ProgrammingLanguages.FindAsync(id);
            db.ProgrammingLanguages.Remove(programmingLanguage);
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
