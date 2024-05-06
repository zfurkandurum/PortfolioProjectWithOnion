using OnionPortfolioProject.Domain;
using OnionProtfolioProject.Application.Interfaces.Repositories;
using PortfolioProjectOnion.Persistence.Context;

namespace OnionProtfolioProject.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly DataDbContext _context;

    public CategoryRepository(DataDbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Category> GetAllCategories()
    {
        return _context.Categories.ToList();
    }

    public Category GetCategoryById(Guid id)
    {
        return _context.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
    }

    public void AddCategory(Category category)
    {
        _context.Add(category);
    }

    public void UpdateCategory(Category category)
    {
        _context.Update(category);
    }

    public void DeleteCategory(Guid id)
    {
        _context.Remove(id);
    }
}