namespace OnionPortfolioProject.Domain;

public class Category
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public List<Article> Articles { get; set; }
}