using Microsoft.AspNetCore.Mvc;

namespace MyDemoBlog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
