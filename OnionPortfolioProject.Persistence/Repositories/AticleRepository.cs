using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionPortfolioProject.Domain;
using OnionProtfolioProject.Application.DTOs;
using OnionProtfolioProject.Application.Interfaces.Repositories;
using PortfolioProjectOnion.Persistence.Context;

namespace OnionProtfolioProject.Persistence.Repositories;

public class ArticleRepository : IArticleRepository
{
    private readonly DataDbContext _context;
    private readonly IMapper _mapper;

    public ArticleRepository(DataDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<ArticleDto>> GetAllArticlesAsync()
    {
        var articles = await _context.Articles.ToListAsync();
        return _mapper.Map<List<ArticleDto>>(articles);
    }

    public async Task<ArticleDto> GetArticleByIdAsync(Guid id)
    {
        var article = await _context.Articles.FindAsync(id);
        return _mapper.Map<ArticleDto>(article);
    }

    public async Task<List<ArticleDto>> GetArticleByCategoryIdAsync(Guid categoryId)
    {
        var articles = await _context.Articles.Where(a => a.Category.CategoryId == categoryId).ToListAsync();
        return _mapper.Map<List<ArticleDto>>(articles);
    }
    
    public async Task<ArticleDto> AddArticleAsync(ArticleDto articleDto)
    {
        var article = _mapper.Map<Article>(articleDto);

        // Ensure CategoryId exists in the database
        var categoryExists = await _context.Categories.AnyAsync(c => c.CategoryId == articleDto.CategoryId);
        if (!categoryExists)
        {
            throw new ArgumentException("Invalid CategoryId.");
        }

        _context.Articles.Add(article);
        await _context.SaveChangesAsync();

        return _mapper.Map<ArticleDto>(article);
    }

    public async Task<ArticleDto> UpdateArticleAsync(ArticleDto articleDto)
    {
        var article = await _context.Articles.FindAsync(articleDto.Id);
        _mapper.Map(articleDto, article);
        await _context.SaveChangesAsync();
        return _mapper.Map<ArticleDto>(article);
    }

    public async Task<bool> DeleteArticleAsync(Guid id)
    {
        var article = await _context.Articles.FindAsync(id);
        _context.Articles.Remove(article);
        await _context.SaveChangesAsync();
        return true;
    }
}