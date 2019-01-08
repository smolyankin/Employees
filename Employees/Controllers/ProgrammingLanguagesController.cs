using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Employees.Context;
using Employees.Models;

namespace Employees.Controllers
{
    /// <summary>
    /// контроллер языков программирования
    /// </summary>
    public class ProgrammingLanguagesController : Controller
    {
        private BaseContext db = new BaseContext();

        // GET: ProgrammingLanguages
        /// <summary>
        /// список языков программирования
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            return View(await db.ProgrammingLanguages.ToListAsync());
        }

        // GET: ProgrammingLanguages/Details/5
        /// <summary>
        /// информация о языках программирования
        /// </summary>
        /// <param name="id">ид языка программирования</param>
        /// <returns></returns>
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
        /// <summary>
        /// создание языка программирования
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProgrammingLanguages/Create
        /// <summary>
        /// создать язык программирования
        /// </summary>
        /// <param name="programmingLanguage">язык программирования</param>
        /// <returns></returns>
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
        /// <summary>
        /// изменение язык программирования
        /// </summary>
        /// <param name="id">ид языка программирования</param>
        /// <returns></returns>
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
        /// <summary>
        /// изменить язык программирования
        /// </summary>
        /// <param name="programmingLanguage">язык программирования</param>
        /// <returns></returns>
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
        /// <summary>
        /// удаление языка программирования
        /// </summary>
        /// <param name="id">ид языка программирования</param>
        /// <returns></returns>
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
        /// <summary>
        /// удалить язык программирования
        /// </summary>
        /// <param name="id">ид языка программирования</param>
        /// <returns></returns>
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
