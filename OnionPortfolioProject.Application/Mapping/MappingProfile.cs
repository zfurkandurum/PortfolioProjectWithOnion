using AutoMapper;
using OnionPortfolioProject.Domain;
using OnionProtfolioProject.Application.DTOs;

namespace OnionProtfolioProject.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<Article, ArticleDto>();
        
        CreateMap<CategoryDto, Category>();
        CreateMap<ArticleDto, Article>();
    }
}