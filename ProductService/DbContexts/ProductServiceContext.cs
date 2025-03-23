using Microsoft.EntityFrameworkCore;
using ProductService.Entities;

namespace ProductService.DbContexts
{
    public class ProductServiceContext : DbContext
    {
         public DbSet<Product> Products { get; set; }
         public DbSet<Variant> Variants { get; set; }

         public ProductServiceContext(DbContextOptions<ProductServiceContext> options) : base(options)
         {

         }

         //Use to seed the database with dummy data initially 
         //Can be removed when deploying
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<Product>().HasData(
                 new Product("L001", "Dell XPS")
                 {
                     Id = 1,
                     Price = 1500
                 },
                    new Product("L002", "Asus ROG")
                    {
                        Id = 2,
                        Price = 1350
                    }
                 );
             base.OnModelCreating(modelBuilder);
         }

    }
}
