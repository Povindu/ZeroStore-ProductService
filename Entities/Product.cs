using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(4)]
        public string Tag { get; set; }

        [Required]
        public string Name { get; set; }

        public float Price { get; set; }

        public ICollection<Variant> Variants { get; set; }
            = new List<Variant>();





        public Product(string tag, string name)
        {
            Tag = tag;
            Name = name;
        }


    }
}
