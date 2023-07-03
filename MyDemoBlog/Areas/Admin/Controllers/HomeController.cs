using Microsoft.AspNetCore.Mvc;
using MyDemoBlog.Domain;

namespace MyDemoBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        DataManager _dataManager;
        public HomeController(DataManager dataManager)
        {
                _dataManager = dataManager;
        }
        public IActionResult Index()
        {
            return View(_dataManager.ArticleRepository);
        }
    }
}
