using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyDemoBlog.Domain;

namespace MyDemoBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        public HomeController(DataManager dataManager, SignInManager<IdentityUser> signInManager)
        {
            this.dataManager = dataManager;
        }
        public IActionResult Index() { 
            return View(dataManager.ArticleRepository.GetAllArticles());
        }
    }
}
