using eShopping.API.Domain.Entities;

namespace eShopping.API.Infrastructure.Persistence.DbContext;

using Microsoft.EntityFrameworkCore ;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    
    /*
         * The method is used for centralized and automated entity configuration.
         * Instead of configuring entities directly in the DbContext class or relying on modelBuilder.Entity<TEntity>().Property(...) calls,
        * developers can create separate configuration classes for each entity.
    */
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Money as an owned type
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}