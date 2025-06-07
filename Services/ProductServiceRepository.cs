using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductService.DbContexts;
using ProductService.Entities;
using ProductService.Models;
using ArgumentNullException = System.ArgumentNullException;

namespace ProductService.Services
{
    public class ProductServiceRepository : IProductServiceRepository
    {

        private readonly ProductServiceContext _context;

        public ProductServiceRepository(ProductServiceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }




        //Get all products
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.OrderBy(p => p.Name).ToListAsync();
        }





        // Get a single product
        public async Task<Product?> GetProductAsync(int productId)
        {
            return await _context.Products.Include(p => p.Variants).Where(p => p.Id == productId).FirstOrDefaultAsync();
        }


        public async Task<bool> CheckProductExistsAsync(int productId)
        {
            return await _context.Products.AnyAsync(p => p.Id == productId);
        }


        public void CreateProduct(Product productCreateInfo)
        { 
            // Only add the product in memory, therefore no need of await
            _context.Products.Add(productCreateInfo);
        }


        public async Task<bool> SaveChangesAsync()
        {
            //_context.SaveChangesAsync() returns number of changes done with the DB
            var noOfChanges = await _context.SaveChangesAsync();
            //We check if atleast 1 item has been changed
            var isChanged = noOfChanges >= 1;

            return isChanged;
        }

        public void UpdateProduct( Product productUpdateInfo)
        {
           _context.Products.Update(productUpdateInfo);
        }

        public void DeleteProduct(Product productDeleteInfo)
        {
            _context.Products.Remove(productDeleteInfo);
        }


    }
}
