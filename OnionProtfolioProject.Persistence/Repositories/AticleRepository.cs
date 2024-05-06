using OnionPortfolioProject.Domain;
using OnionProtfolioProject.Application.Interfaces.Repositories;
using PortfolioProjectOnion.Persistence.Context;

namespace OnionProtfolioProject.Persistence.Repositories;

public class AticleRepository : IArticleRepository
{
    private readonly DataDbContext _context;

    public AticleRepository(DataDbContext context)
    {
        _context = context;
    }


    public IEnumerable<Article> GetAllArticles()
    {
        return _context.Articles.ToList();
    }

    public Article GetArticleById(Guid id)
    {
        return _context.Articles.Where(a => a.Id == id).FirstOrDefault();
    }

    public IEnumerable<Article> GetArticleByCategoryId(Guid categoryId)
    {
        return _context.Articles.Where(a => a.Categories.Any(c => categoryId == categoryId));
    }

    public void AddArticle(Article article)
    {
        _context.Add(article);
    }

    public void UpdateArticle(Article article)
    {
        _context.Update(article);
    }

    public void DeleteArticle(Guid id)
    {
        _context.Remove(id);
    }
}