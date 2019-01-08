using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Employees.Context;
using Employees.Models;

namespace Employees.Controllers
{
    /// <summary>
    /// контроллер сотрудников
    /// </summary>
    public class EmployeesController : Controller
    {
        private BaseContext db = new BaseContext();

        // GET: Employees
        /// <summary>
        /// список сотрудников
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            var Employees = db.Employees.Include(e => e.Department).Include(e => e.ProgrammingLanguage);
            return View(await Employees.ToListAsync());
        }

        // GET: Employees/Add
        /// <summary>
        /// добавление сотрудника
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Title");
            ViewBag.ProgrammingLanguageId = new SelectList(db.ProgrammingLanguages, "Id", "Title");
            return View();
        }

        // POST: Employees/Create
        /// <summary>
        /// добавить сотрудника
        /// </summary>
        /// <param name="Employee">сотрудник</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add([Bind(Include = "Id,Name,Surname,Age,Gender,DepartmentId,ProgrammingLanguageId")] Employee Employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(Employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Title", Employee.DepartmentId);
            ViewBag.ProgrammingLanguageId = new SelectList(db.ProgrammingLanguages, "Id", "Title", Employee.ProgrammingLanguageId);
            return View(Employee);
        }

        // GET: Employees/Edit/5
        /// <summary>
        /// изменение сотрудника
        /// </summary>
        /// <param name="id">ид сотрудника</param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee Employee = await db.Employees.FindAsync(id);
            if (Employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Title", Employee.DepartmentId);
            ViewBag.ProgrammingLanguageId = new SelectList(db.ProgrammingLanguages, "Id", "Title", Employee.ProgrammingLanguageId);
            return View(Employee);
        }

        // POST: Employees/Edit/5
        /// <summary>
        /// изменить сотрудника
        /// </summary>
        /// <param name="Employee">сотрудник</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Surname,Age,Gender,DepartmentId,ProgrammingLanguageId")] Employee Employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Title", Employee.DepartmentId);
            ViewBag.ProgrammingLanguageId = new SelectList(db.ProgrammingLanguages, "Id", "Title", Employee.ProgrammingLanguageId);
            return View(Employee);
        }

        // GET: Employees/Delete/5
        /// <summary>
        /// удаление сотрудника
        /// </summary>
        /// <param name="id">ид сотрудника</param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee Employee = await db.Employees.FindAsync(id);
            if (Employee == null)
            {
                return HttpNotFound();
            }
            return View(Employee);
        }

        // POST: Employees/Delete/5
        /// <summary>
        /// удалить сотрудника
        /// </summary>
        /// <param name="id">ид сотрудника</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Employee Employee = await db.Employees.FindAsync(id);
            db.Employees.Remove(Employee);
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

        /// <summary>
        /// автоподстановка имен сотрудников
        /// </summary>
        /// <param name="s">запрос</param>
        /// <returns></returns>
        public ActionResult AutocompleteName(string s)
        {
            var models = db.Employees.Where(x => x.Name.Contains(s))
                .Select(x => new { value = x.Name })
                .Distinct();

            return Json(models, JsonRequestBehavior.AllowGet);
        }
    }
}
