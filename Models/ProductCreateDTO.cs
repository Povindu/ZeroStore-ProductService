using System.ComponentModel.DataAnnotations;

namespace ProductService.Models
{
    public class ProductCreateDTO
    {
        [Required]
        public string Tag { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }

        public ICollection<VariantDTO> Variants { get; set; }
            = new List<VariantDTO>();

    }
}
