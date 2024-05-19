using OnionPortfolioProject.Domain;
using OnionProtfolioProject.Application.DTOs;

namespace OnionProtfolioProject.Application.Interfaces.Repositories;

public interface ICategoryRepository
{
    Task<CategoryDto> GetCategoryByIdAsync(Guid id);
    Task<List<CategoryDto>> GetAllCategoriesAsync();
    Task<CategoryDto> AddCategoryAsync(CategoryDto category);
    Task<CategoryDto> UpdateCategoryAsync(CategoryDto category);
    Task<bool> DeleteCategoryAsync(Guid id);
}