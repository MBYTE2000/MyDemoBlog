using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyDemoBlog.Domain;
using MyDemoBlog.Domain.Entities;
using MyDemoBlog.Domain.Repos.EF;

namespace MyDemoBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public HomeController(DataManager dataManager, SignInManager<IdentityUser> signInManager)
        {
            this.dataManager = dataManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
                ViewBag.IsSignIn = signInManager.IsSignedIn(HttpContext.User);
                return View(dataManager.ArticleRepository.GetAllArticles());
        }

        public IActionResult View(string id) 
        {
            Article article = dataManager.ArticleRepository.GetArticleByID(new Guid(id));
            ViewBag.Author = "ToDo";
            return View(article);
        }
    }
}
