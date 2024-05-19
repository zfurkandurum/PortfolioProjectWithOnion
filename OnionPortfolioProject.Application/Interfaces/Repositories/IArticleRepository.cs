using OnionPortfolioProject.Domain;
using OnionProtfolioProject.Application.DTOs;

namespace OnionProtfolioProject.Application.Interfaces.Repositories;

public interface IArticleRepository
{
    Task<List<ArticleDto>> GetAllArticlesAsync();
    Task<ArticleDto> GetArticleByIdAsync(Guid id);
    Task<List<ArticleDto>> GetArticleByCategoryIdAsync(Guid categoryId);
    Task<ArticleDto> AddArticleAsync(ArticleDto articleDto);
    Task<ArticleDto> UpdateArticleAsync(ArticleDto articleDto);
    Task<bool> DeleteArticleAsync(Guid id);
}