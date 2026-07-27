using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StockControlApi.Models
{
    public enum MovimentType
    {
        Entry,
        Exit,
        Ajustment
    }

    public class StockMovement
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ProductId { get; set; }

        public Guid UserId { get; set; }

        [Required(ErrorMessage = "O campo tipo de movimentação está vazio")]
        public MovimentType MovimentType { get; set; }

        [Required(ErrorMessage = "O campo Quanitade está vazio")]
        [Range(1, int.MaxValue, ErrorMessage = "Digite o valor correto")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "O campo unitário é obrigatório")]
        [Range(1, int.MaxValue)]
        public decimal UnitPrice { get; set; }

        [NotMapped]
        public decimal TotalValue  => Quantity * UnitPrice;

        [MaxLength(500)]
        public string? Observation { get; set; }

        [Required(ErrorMessage = "O campo movimentação precisa de Data")]
        public DateTime MovementDate { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
    }
}
