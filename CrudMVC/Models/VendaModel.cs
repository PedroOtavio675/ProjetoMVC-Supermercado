using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudMVC.Models
{
    public class VendaModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Coloque um código válido")]
        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]

        [ValidateNever]
        public ProdutoModel Produto { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; } = DateTime.UtcNow;
    }
}
