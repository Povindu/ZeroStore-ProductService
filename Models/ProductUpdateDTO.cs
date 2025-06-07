using System.ComponentModel.DataAnnotations;

namespace ProductService.Models
{
    public class ProductUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        public string Tag { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }

        public ICollection<VariantDTO> Variants { get; set; }
            = new List<VariantDTO>();
    }
}
