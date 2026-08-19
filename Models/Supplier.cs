using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StockControlApi.Models
{
    [Index(nameof(Cnpj), IsUnique = true)]
    public class Supplier
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }
        
        [Required(ErrorMessage = "O Campo nome está vazio")]
        [MaxLength(200, ErrorMessage = "Máximo de 200 caracteris")]    
        [MinLength(3, ErrorMessage = "Mínimo de 3 Caracteris")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "Máximo de 200 caracteris")]    
        [MinLength(3, ErrorMessage = "Mínimo de 3 Caracteris")]
        public string? TrandName { get; set; }

        [Required(ErrorMessage = "CNPJ é obrigatório")]
        [StringLength(18, MinimumLength = 18)]
        public string Cnpj { get; set; }

        [StringLength(15, MinimumLength = 15)]
        public string? StateRegistration { get; set; }

        [EmailAddress]
        [MaxLength(200)]
        public string? Email { get; set; }

        [StringLength(14, MinimumLength = 14)]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "O campo Celular está vazio")]
        [StringLength(15, MinimumLength = 15)]
        public string? CellPhone { get; set; }

        [MaxLength(100)]
        public string? ContactName { get; set; }

        [MaxLength(400, ErrorMessage = "Máximo de caracteris 400")]
        public string? Observation { get; set; }

        [Required(ErrorMessage = "Os campos de endereço estão vazios")]
        public Address Address { get; set; }

        public bool Active { get; set; } = true;

        [Required(ErrorMessage = "O campo de Data está vazio")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
    }
}
