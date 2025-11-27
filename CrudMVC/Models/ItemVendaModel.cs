using System.ComponentModel.DataAnnotations.Schema;
namespace CrudMVC.Models
{
    public class ItemVendaModel
    {
        public int ProdutoId { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal ValorTotal => Quantidade * PrecoUnitario;
    }
}
