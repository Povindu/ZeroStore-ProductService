namespace ProductService.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }

        public int NumberOfVariants
        {
            get
            {
                return Variants.Count;
            }
        }

        public ICollection<VariantDTO> Variants { get; set; }
            = new List<VariantDTO>();



    }
}
