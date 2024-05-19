using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnionPortfolioProject.Domain;
using OnionProtfolioProject.Application.DTOs;
using OnionProtfolioProject.Application.Interfaces.Repositories;
using PortfolioProjectOnion.Persistence.Context;

namespace OnionPortfolioProject.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly DataDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;
     
    public CategoryController(DataDbContext context, IMapper mapper, ICategoryRepository categoryRepository)
    {
        _context = context;
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetCategoryById(Guid id)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(id);
        if (category == null)
            return NotFound();
        return category;
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>> GetAllCategories()
    {
        var categories = await _categoryRepository.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDto>> AddCategory(CategoryDto category)
    {
        var addedCategory = await _categoryRepository.AddCategoryAsync(category);
        return CreatedAtAction(nameof(GetCategoryById), new { id = Guid.NewGuid() }, addedCategory);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(Guid id, CategoryDto category)
    {
        if (id != category.CategoryId)
            return BadRequest();

        var updatedCategory = await _categoryRepository.UpdateCategoryAsync(category);
        if (updatedCategory == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var result = await _categoryRepository.DeleteCategoryAsync(id);
        if (!result)
            return NotFound();

        return Ok();
    }
}
