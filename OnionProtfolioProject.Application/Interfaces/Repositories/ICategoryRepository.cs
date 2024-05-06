using OnionPortfolioProject.Domain;

namespace OnionProtfolioProject.Application.Interfaces.Repositories;

public interface ICategoryRepository
{
    IEnumerable<Category> GetAllCategories();
    Category GetCategoryById(Guid id);
    void AddCategory(Category category);
    void UpdateCategory(Category category);
    void DeleteCategory(Guid id);
}