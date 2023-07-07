using Microsoft.AspNetCore.Mvc;
using MyDemoBlog.Domain;
using MyDemoBlog.Domain.Repos.EF;

namespace MyDemoBlog.Controllers
{
    public class HomeController : Controller
    {
        DataManager dataManager;
        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public IActionResult Index()
        {
            return View(dataManager.ArticleRepository.GetAllArticles());
        }
    }
}
