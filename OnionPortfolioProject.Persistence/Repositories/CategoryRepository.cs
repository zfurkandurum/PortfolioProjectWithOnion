using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionPortfolioProject.Domain;
using OnionProtfolioProject.Application.DTOs;
using OnionProtfolioProject.Application.Interfaces.Repositories;
using PortfolioProjectOnion.Persistence.Context;

namespace OnionProtfolioProject.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly DataDbContext _context;
    private readonly IMapper _mapper;

    public CategoryRepository(DataDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<CategoryDto> GetCategoryByIdAsync(Guid id)
    {
        var category = await _context.Categories.FindAsync(id);
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<List<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _context.Categories.ToListAsync();
        return _mapper.Map<List<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> AddCategoryAsync(CategoryDto category)
    {
        var categoryEntity = _mapper.Map<Category>(category);
        _context.Categories.Add(categoryEntity);
        await _context.SaveChangesAsync();
        return _mapper.Map<CategoryDto>(categoryEntity);
    }

    public async Task<CategoryDto> UpdateCategoryAsync(CategoryDto category)
    {
        var categoryEntity = await _context.Categories.FindAsync(category.CategoryId);
        
        _mapper.Map(category, categoryEntity);

        await _context.SaveChangesAsync();
        return _mapper.Map<CategoryDto>(categoryEntity);
    }

    public async Task<bool> DeleteCategoryAsync(Guid id)
    {
        var category = await _context.Categories.FindAsync(id);
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return true;
    }
}