using System.ComponentModel.DataAnnotations;

namespace ApiEcommerce.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public DateTime CreationDate { get; set; }
    }
}
 