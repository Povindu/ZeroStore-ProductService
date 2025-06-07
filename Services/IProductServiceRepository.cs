using Microsoft.EntityFrameworkCore;
using ProductService.Entities;
using ProductService.Models;

namespace ProductService.Services
{
    public interface IProductServiceRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product?> GetProductAsync(int productId);
        Task<bool> CheckProductExistsAsync(int productId);
        void CreateProduct(Product productCreateInfo);
        Task<bool> SaveChangesAsync();

        void UpdateProduct( Product productUpdateInfo);
        void DeleteProduct( Product productDeleteInfo);

    }
}
