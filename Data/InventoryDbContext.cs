using Inventory.Api.Models.Categories;
using Inventory.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Api.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions options ) : base( options )
        { 
            
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Purchases> Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>()
                .HasKey(p => p.ProductID);

            modelBuilder.Entity<Products>()
                .HasOne(p => p.Categories)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryID)
                .IsRequired(false);

            modelBuilder.Entity<Products>()
                .HasOne(p => p.Suppliers)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierID)
                .IsRequired(false);

            modelBuilder.Entity<Categories>()
                .HasKey(c => c.CategoryID);

            modelBuilder.Entity<Suppliers>()
                .HasKey(s => s.SupplierID);

            modelBuilder.Entity<Purchases>()
                .HasKey(p => p.PurchaseID);

            modelBuilder.Entity<Purchases>()
                .HasOne(p => p.Products)
                .WithMany()
                .HasForeignKey(p => p.ProductID);

            modelBuilder.Entity<Purchases>()
                .HasOne(p => p.Suppliers)
                .WithMany()
                .HasForeignKey(p => p.SupplierID);
        }
    }
}
