using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StockControlApi.Models
{
    public enum UnitType
    {
        Unit,
        Kg,
        Liter,
        Meter,
        Box,
        Package
    }

    [Index(nameof(InternalCode), IsUnique = true)]
    public class Product
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "É necessário ter um Usuário logado")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "É necessário ter um fornecedor")]
        public Guid SupplierId { get; set; }

        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Código interno não foi incrementado")]
        public int? InternalCode { get; set; }

        [Required(ErrorMessage = "O campo descrição está vazio")]
        [MaxLength(100, ErrorMessage = "A quantidade máxima de caracteris já foi excedida")]
        [MinLength(3, ErrorMessage = "É necessário no minimo 3 caracteris")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo Quantidade está vazio")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "O campo Quantidade está vazio")]
        public int MinimumStock { get; set; }

        [Required(ErrorMessage = "O campo preço de compra está vazio")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal BuyPrice { get; set; }

        [Required(ErrorMessage = "O campo preço de venda está vazio")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal SalePrice { get; set; }

        [Required(ErrorMessage = "O campo unidade está vazio")]
        public UnitType UnitType { get; set; }

        [MaxLength(13)]
        public string? Barcode { get; set; }

        [Required(ErrorMessage = "O Campo ativo deve ser preenchido")]
        public bool IsActive { get; set; } = true;

        [Column(TypeName = "decimal(10,2)")]
        public decimal ProfitMargin =>
        BuyPrice == 0
        ? 0
        : ((SalePrice - BuyPrice) / BuyPrice) * 100;

        [Required(ErrorMessage = "O campo Data de criação é obrigatório")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public string? ImagePath { get; set; }

        [Required(ErrorMessage = "O campo Marca está vazio")]
        public Guid BrandId { get; set; }

        [MaxLength(500, ErrorMessage = "Limite de 500 caracteris")]
        public string? Observation { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(SupplierId))]
        public Supplier? Supplier { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(BrandId))]
        public Brand? Brand { get; set; }
    }
}
