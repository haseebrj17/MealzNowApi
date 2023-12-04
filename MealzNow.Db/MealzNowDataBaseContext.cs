using System.Diagnostics.Metrics;
using MealzNow.Db.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;

public class MealzNowDataBaseContext : DbContext
{
    public MealzNowDataBaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<SuperAdmin> SuperAdmins { get; set; }
    public DbSet<FranchiseUser> FranchiseUsers { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Countries> Country { get; set; }
    public DbSet<Franchise> Franchises { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Packages> Packages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos(
            "https://mealznowcdb.documents.azure.com:443/",
            "SEONv3ty9lriwa53UbtOIyUruLEW8000TIHM0uGBKqTQ9ChAp5TbX2nBtAIhaMngnm4475znExM3ACDb5UbnlA==",
            "MealzNowDB"
        );
    }

    public async Task InitializeDatabaseAsync()
    {
        await this.Database.EnsureCreatedAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SuperAdmin>().HasKey(e => e.EmailAddress);
        modelBuilder.Entity<SuperAdmin>().ToContainer("SuperAdmins").HasPartitionKey(s => s.EmailAddress);

        modelBuilder.Entity<FranchiseUser>().HasKey(e => e.EmailAddress);
        modelBuilder.Entity<FranchiseUser>().ToContainer("FranchiseUsers").HasPartitionKey(u => u.EmailAddress);

        modelBuilder.Entity<Client>().HasKey(e => e.EmailAddress);
        modelBuilder.Entity<Client>().ToContainer("Clients").HasPartitionKey(c => c.EmailAddress);

        modelBuilder.Entity<Countries>().HasKey(e => e.Id);
        modelBuilder.Entity<Countries>().ToContainer("Country").HasPartitionKey(c => c.Id);

        modelBuilder.Entity<Franchise>().HasKey(e => e.ClientId);
        modelBuilder.Entity<Franchise>().ToContainer("Franchises").HasPartitionKey(f => f.ClientId);

        modelBuilder.Entity<Product>().HasKey(e => e.CategoryId);
        modelBuilder.Entity<Product>().ToContainer("Products").HasPartitionKey(p => p.CategoryId);

        modelBuilder.Entity<Order>().HasKey(e => e.FranchiseId);
        modelBuilder.Entity<Order>().ToContainer("Orders").HasPartitionKey(o => o.FranchiseId);

        modelBuilder.Entity<Category>().HasKey(e => e.FranchiseId);
        modelBuilder.Entity<Category>().ToContainer("Categories").HasPartitionKey(c => c.FranchiseId);

        modelBuilder.Entity<Customer>().HasKey(e => e.EmailAddress);
        modelBuilder.Entity<Customer>().ToContainer("Customers").HasPartitionKey(c => c.EmailAddress);

        modelBuilder.Entity<Packages>().HasKey(e => e.FranchiseId);
        modelBuilder.Entity<Packages>().ToContainer("Packages").HasPartitionKey(p => p.FranchiseId);
    }
}