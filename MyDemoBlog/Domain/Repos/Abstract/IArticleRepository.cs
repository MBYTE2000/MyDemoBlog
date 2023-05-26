using MyDemoBlog.Domain.Entities;

namespace MyDemoBlog.Domain.Repos.Abstract
{
    public interface IArticleRepository
    {
        IQueryable<Article> GetAllArticles();
        void SaveArticle(Article article);
        Article GetArticleByID(Guid id);
        void DeleteArticle(Guid id);
    }
}
