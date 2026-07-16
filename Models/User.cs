using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StockControlApi.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O campo nome está vazio")]
        [MaxLength(200)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Email está vazio")]
        [EmailAddress]
        [MaxLength(200)]
        [MinLength(10)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha está vazio")]
        [MaxLength(100)]
        [MinLength(8)]
        public string PasswordHash { get; set; }

        public bool Active { get; set; } = true;

        [Required(ErrorMessage = "O campo data está vazio")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}
