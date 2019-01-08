using System.Web.Mvc;

namespace Employees.Controllers
{
    /// <summary>
    /// главный контроллер
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// главная страница
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}