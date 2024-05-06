using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PortfolioProjectOnion.Persistence.Context;

namespace OnionProtfolioProject.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataDbContext>
{
    public DataDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<DataDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseSqlServer("Server=localhost, 1433;Database=OnionArcPortfolioProject;User Id=SA;Password=reallyStrongPwd123;TrustServerCertificate=True;");
        return new DataDbContext(dbContextOptionsBuilder.Options);
    }
}