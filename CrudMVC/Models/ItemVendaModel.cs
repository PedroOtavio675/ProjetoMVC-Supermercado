using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudMVC.Models
{
    public class ItemVendaModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Coloque um código válido")]
      
        public VendaModel Venda { get; set; }

        public string Nome { get; set;  }

        public int VendaId { get; set; }
        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]

        [ValidateNever]
        public ProdutoModel Produto { get; set; }
        public decimal TotalItem { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}
