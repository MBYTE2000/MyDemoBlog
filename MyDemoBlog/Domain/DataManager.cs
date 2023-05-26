using MyDemoBlog.Domain.Repos.Abstract;

namespace MyDemoBlog.Domain
{
    public class DataManager
    {
        public IArticleRepository ArticleRepository { get; set; }

        public DataManager(IArticleRepository repository)
        {
            ArticleRepository = repository;
        }
    }
}
