using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnionPortfolioProject.Domain;

namespace PortfolioProjectOnion.Persistence.Context;

public class DataDbContext : IdentityDbContext<WhoAmI, IdentityRole<Guid>, Guid>
{
    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) 
    {
    }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Link> Links { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<WhoAmI> WhoAmIs { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Article>()
            .HasKey(a => a.Id);
        modelBuilder.Entity<Category>()
            .HasKey(c => c.CategoryId);
        modelBuilder.Entity<Skill>()
            .HasKey(s => s.Id);
        modelBuilder.Entity<Link>()
            .HasKey(l => l.Id);
        modelBuilder.Entity<WhoAmI>()
            .HasKey(w => w.Id);

        modelBuilder.Entity<Article>()
            .HasOne(a => a.Category)
            .WithMany(c => c.Articles)
            .HasForeignKey(a => a.CategoryId);
    }   
}