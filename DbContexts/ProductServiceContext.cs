using Microsoft.EntityFrameworkCore;
using ProductService.Entities;

namespace ProductService.DbContexts
{
    //Context defines stucture of the database. In here it defines 2 db tables as Products and Variants
    public class ProductServiceContext : DbContext
    {
         public DbSet<Product> Products { get; set; }
         public DbSet<Variant> Variants { get; set; }

         public ProductServiceContext(DbContextOptions<ProductServiceContext> options) : base(options)
         {

         }

         //Uses to seed the database with dummy data initially 
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
                },new Product("L003", "Apple M3")
                {
                    Id = 3,
                    Price = 2050
                });

             modelBuilder.Entity<Variant>().HasData(
                 new Variant("1Red")
                 {
                     Id = 7,
                     ProductId = 1

                 },
                 new Variant("1Blue")
                 {
                     Id = 8,
                     ProductId = 1

                 },
                 new Variant("2Blue")
                 {
                     Id = 9,
                     ProductId = 2
                 }
             );

             base.OnModelCreating(modelBuilder);
         }

    }
}
