using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockControlApi.Models
{
    public class Address
    {
        public Guid Id { get; set; }    
        
        [Required(ErrorMessage = "O campo Rua/Avenida não foi preenchido preenchido")]
        public string Street { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo númeor não foi preenchido")]
        public string Number { get; set; } = string.Empty;
        public string? Complement { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo bairro não foi preenchido")]
        public string District { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "O campo cidade não foi preenchido")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Estado precisa ser preenchido")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo CEP não foi preenchido")]
        public string ZipCode { get; set; } = string.Empty;

        [ForeignKey(nameof(Id))]
        public Supplier Supplier { get; set; }
    }
}
