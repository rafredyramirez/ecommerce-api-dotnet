using System.ComponentModel.DataAnnotations;

namespace ApiEcommerce.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
