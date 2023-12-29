using System;
using MealzNow.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace MealzNow.Db
{
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
            => optionsBuilder.UseCosmos(
                "AccountEndpoint=https://mealznowcdb.documents.azure.com:443/;AccountKey=ZUr2bcfSjsQSjuhfpS6XtWjcUYKWYGXhe3SoA2okp0pcjiTq7Oej56L2OuvOFwEaKZ032OZi2QMzACDbL9fXVQ==;",
                databaseName: "MealzNowDB"
        );

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SuperAdmin>().HasKey(e => e.Id);
            modelBuilder.Entity<SuperAdmin>().ToContainer("SuperAdmins").HasPartitionKey(s => s.EmailAddress).HasNoDiscriminator();

            modelBuilder.Entity<FranchiseUser>().HasKey(e => e.Id);
            modelBuilder.Entity<FranchiseUser>().ToContainer("FranchiseUsers").HasPartitionKey(u => u.FranchiseId).HasNoDiscriminator();

            modelBuilder.Entity<Client>().HasKey(e => e.Id);
            modelBuilder.Entity<Client>().ToContainer("Clients").HasPartitionKey(c => c.EmailAddress).HasNoDiscriminator();

            modelBuilder.Entity<Countries>().HasKey(e => e.Id);
            modelBuilder.Entity<Countries>().ToContainer("Country").HasPartitionKey(c => c.Id).HasNoDiscriminator();

            //modelBuilder.Entity<Franchise>().HasKey(e => e.Id);
            //modelBuilder.Entity<Franchise>().ToContainer("Franchises").HasPartitionKey(f => f.ClientId).HasNoDiscriminator();

            modelBuilder.Entity<Franchise>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToContainer("Franchises");
                entity.HasPartitionKey(f => f.ClientId);
                entity.HasNoDiscriminator();

                entity.OwnsMany(f => f.FranchiseTimings, ft =>
                {
                    ft.WithOwner().HasForeignKey("FranchiseId");
                    ft.HasKey("Id");

                    ft.OwnsMany(t => t.ServingTimings, st =>
                    {
                        st.WithOwner().HasForeignKey("ServingTimingsId");
                        st.HasKey("Id");

                        st.OwnsMany(s => s.ServingTime, time =>
                        {
                            time.WithOwner().HasForeignKey("ServingTimingsId");
                            time.HasKey("Id");
                        });
                    });
                });

                entity.OwnsMany(f => f.FranchiseHolidays, fh =>
                {
                    fh.WithOwner().HasForeignKey("FranchiseId");
                    fh.HasKey("Id");
                });

                entity.OwnsMany(f => f.DishOfDay, dd =>
                {
                    dd.WithOwner().HasForeignKey("FranchiseId");
                    dd.HasKey("Id");
                });

                entity.OwnsMany(f => f.Banner, b =>
                {
                    b.WithOwner().HasForeignKey("FranchiseId");
                    b.HasKey("Id");
                });

                entity.OwnsMany(f => f.FranchiseSetting, fs =>
                {
                    fs.WithOwner().HasForeignKey("FranchiseId");
                    fs.HasKey("Id");
                    fs.OwnsMany(s => s.MealsPerDay);
                    fs.OwnsMany(s => s.ServingDays);
                });

                entity.OwnsMany(f => f.ProductOutline, po =>
                {
                    po.WithOwner().HasForeignKey("FranchiseId");
                    po.HasKey("Id");
                    po.OwnsMany(p => p.ProductInclusion);
                });
            });

            modelBuilder.Entity<Product>().HasKey(e => e.Id);
            modelBuilder.Entity<Product>().ToContainer("Products").HasPartitionKey(p => p.CategoryId).HasNoDiscriminator();

            modelBuilder.Entity<Order>().HasKey(e => e.Id);
            modelBuilder.Entity<Order>().ToContainer("Orders").HasPartitionKey(o => o.FranchiseId).HasNoDiscriminator();

            modelBuilder.Entity<Category>().HasKey(e => e.Id);
            modelBuilder.Entity<Category>().ToContainer("Categories").HasPartitionKey(c => c.FranchiseId).HasNoDiscriminator();

            modelBuilder.Entity<Customer>().HasKey(e => e.Id);
            modelBuilder.Entity<Customer>().ToContainer("Customers").HasPartitionKey(c => c.EmailAddress).HasNoDiscriminator();

            modelBuilder.Entity<Packages>().HasKey(e => e.Id);
            modelBuilder.Entity<Packages>().ToContainer("Packages").HasPartitionKey(p => p.FranchiseId).HasNoDiscriminator();
        }
    }
}