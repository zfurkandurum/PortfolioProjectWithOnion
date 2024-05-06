using OnionPortfolioProject.Domain;

namespace OnionProtfolioProject.Application.Interfaces.Repositories;

public interface IArticleRepository
{
    IEnumerable<Article> GetAllArticles();
    Article GetArticleById(Guid id);
    IEnumerable<Article> GetArticleByCategoryId(Guid categoryId);
    void AddArticle(Article article);
    void UpdateArticle(Article article);
    void DeleteArticle(Guid id);
}