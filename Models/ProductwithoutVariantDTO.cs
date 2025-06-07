using ProductService.Entities;
using System.Diagnostics.Contracts;

namespace ProductService.Models
{
    public class ProductwithoutVariantDTO
    {
        public string Tag { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }


    }
}
