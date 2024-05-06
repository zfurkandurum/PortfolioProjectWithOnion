using Microsoft.AspNetCore.Mvc;
using OnionPortfolioProject.Domain;
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
    public IActionResult GetAllArticles()
    {
        var articles = _articleRepository.GetAllArticles();
        return Ok(articles);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetArticle(Guid id)
    {
        var article = _articleRepository.GetArticleById(id);
        if (article == null)
        {
            return NotFound();
        }
        return Ok(article);
    }
    
    [HttpPost]
    public IActionResult CreateArticle([FromBody] Article article)
    {
        _articleRepository.AddArticle(article);
        return CreatedAtAction(nameof(GetArticle), new { id = article.Id }, article);
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateArticle(Guid id, [FromBody] Article article)
    {
        if (id != article.Id)
        {
            return BadRequest();
        }

        _articleRepository.UpdateArticle(article);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteArticle(Guid id)
    {
        _articleRepository.DeleteArticle(id);
        return NoContent();
    }
}