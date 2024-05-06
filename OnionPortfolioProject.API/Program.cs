using Microsoft.EntityFrameworkCore;
using OnionPortfolioProject.API.Controller;
using OnionProtfolioProject.Application.Interfaces.Repositories;
using OnionProtfolioProject.Application.Mapping;
using OnionProtfolioProject.Persistence.Repositories;
using PortfolioProjectOnion.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<DataDbContext>(options => options.UseSqlServer("Server=localhost, 1433;Database=PortfolioProject;User Id=SA;Password=reallyStrongPwd123;TrustServerCertificate=True;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.MapControllers();

app.Run();