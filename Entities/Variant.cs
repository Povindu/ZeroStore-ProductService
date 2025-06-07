using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProductService.Entities
{
    public class Variant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        public int ProductId { get; set; }




        public Variant(string name)
        {
            Name = name;
        }

    }
}
