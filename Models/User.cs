using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace StockControlApi.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }

        public Guid SupplierId { get; set; }
        public string? Coding { get; set; }

        [Required(ErrorMessage = "O campo descrição está vazio")]
        [MaxLength(100, ErrorMessage = "A quantidade máxima de caracteris já foi excedida")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo Quantidade está vazio")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "O campo Quantidade minima está vázio")]
        [Range(1, int.MaxValue, ErrorMessage = $"Máximo é {nameof(int.MaxValue)}, valor minimo 1")]
        public int MinAmount { get; set; }

        [Required(ErrorMessage = "O campo preso de compra está vazio")]
        public decimal BuyPrice{ get; set; }

        [Required(ErrorMessage = "O campo preso de venda está vazio")]
        public decimal SalePrice { get; set; }

        [Required(ErrorMessage = "O campo unidade está vazio")]
        public int Unit { get; set; }

        public string? Barcode { get; set; }

        public bool Enable { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
        }

        [ForeignKey(nameof(SupplierId))]
        public Supplier?  Supplier { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
    }
}
