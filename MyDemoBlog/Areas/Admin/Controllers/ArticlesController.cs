using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDemoBlog.Domain;
using MyDemoBlog.Domain.Entities;

namespace MyDemoBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticlesController : Controller
    {
        private readonly DataManager dataManager;
        public ArticlesController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticlesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticlesController/Edit/5
        public ActionResult Edit(string id)
        {
            Article article = dataManager.ArticleRepository.GetArticleByID(new Guid(id));
            return View(article);
        }

        //POST: ArticlesController/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Article model)
        {
            if (ModelState.IsValid)
            {
                model.Id = new Guid(id);
                dataManager.ArticleRepository.SaveArticle(model);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: ArticlesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArticlesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
