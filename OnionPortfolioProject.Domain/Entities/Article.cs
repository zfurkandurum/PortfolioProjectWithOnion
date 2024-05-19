namespace OnionPortfolioProject.Domain;

public class Article
{
    public Guid Id { get; set; }
    public string Header { get; set; }
    public string Content { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}