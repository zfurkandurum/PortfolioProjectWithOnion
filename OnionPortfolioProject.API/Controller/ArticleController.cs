using Microsoft.AspNetCore.Mvc;
using OnionPortfolioProject.Domain;
using OnionProtfolioProject.Application.DTOs;
using OnionProtfolioProject.Application.Interfaces.Repositories;

namespace OnionPortfolioProject.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class ArticleController : ControllerBase
{
    private readonly IArticleRepository _articleRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ArticleController(IArticleRepository articleRepository, ICategoryRepository categoryRepository)
    {
        _articleRepository = articleRepository;
        _categoryRepository = categoryRepository;
    }
    [HttpGet]
    public async Task<ActionResult<List<ArticleDto>>> GetAllArticles()
    {
        var articles = await _articleRepository.GetAllArticlesAsync();
        return Ok(articles);
    }
    
    [HttpGet("{articleId}")]
    public async Task<IActionResult> GetArticle(Guid articleId)
    {
        var article = await _articleRepository.GetArticleByIdAsync(articleId);
        if (article == null)
        {
            return NotFound();
        }
        return Ok(article);
    }

    [HttpGet("category/{categoryId}")]
    public async Task<ActionResult<List<ArticleDto>>> GetArticleByCategoryId(Guid categoryId)
    {
        var articles = await _articleRepository.GetArticleByCategoryIdAsync(categoryId);
        if (articles == null)
        {
            return NotFound();
        }
        return Ok(articles);
    }

    
    [HttpPost]
    public async Task<IActionResult> CreateArticle(ArticleDto articleDto)
    {
        if (articleDto == null)
        {
            return BadRequest("Article data is null.");
        }

        try
        {
            var addedArticle = await _articleRepository.AddArticleAsync(articleDto);
            return CreatedAtAction(nameof(GetArticle), new { id = addedArticle.Id }, addedArticle);
        }
        catch (Exception ex)
        {
            // Log the exception details
            // e.g., _logger.LogError(ex, "Error creating article");
            return StatusCode(500, "Internal server error");
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateArticle(Guid id, [FromBody] ArticleDto articleDto)
    {
        if (id != articleDto.Id)
        {
            return BadRequest();
        }

        var article = await _articleRepository.UpdateArticleAsync(articleDto);
        if (article == null)
            return NotFound();
        
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArticle(Guid id)
    {
        var result = await _articleRepository.DeleteArticleAsync(id);
        if (!result)
            return NotFound();
        
        return NoContent();
    }
}