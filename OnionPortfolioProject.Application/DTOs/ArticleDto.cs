using OnionPortfolioProject.Domain;

namespace OnionProtfolioProject.Application.DTOs;

public class ArticleDto
{
    public Guid Id { get; set; }
    public string Header { get; set; }
    public string Content { get; set; }
    public Guid CategoryId { get; set; }
}