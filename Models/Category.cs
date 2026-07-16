using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StockControlApi.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }

        [Required(ErrorMessage = "O campo nome está vazio")]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string? Description { get; set; }

        public bool Active { get; set; } = true;

        [Required(ErrorMessage = "O campo Data está vazio")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
    }
}
