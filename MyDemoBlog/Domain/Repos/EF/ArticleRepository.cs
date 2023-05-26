using Microsoft.EntityFrameworkCore;
using MyDemoBlog.Domain.Entities;
using MyDemoBlog.Domain.Repos.Abstract;

namespace MyDemoBlog.Domain.Repos.EF
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AppDbContext dbContext;
        public ArticleRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void DeleteArticle(Guid id)
        {
            dbContext.Articles.Remove(new Article { Id = id});
            dbContext.SaveChanges();
        }

        public IQueryable<Article> GetAllArticles()
        {
            return dbContext.Articles;
        }

        public Article GetArticleByID(Guid id)
        {
            return dbContext.Articles.FirstOrDefault(x => x.Id == id);
        }

        public void SaveArticle(Article article)
        {
            if (article.Id == default)
                dbContext.Entry(article).State = EntityState.Added;
            else
                dbContext.Entry(article).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
