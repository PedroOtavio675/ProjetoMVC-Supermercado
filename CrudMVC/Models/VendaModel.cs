using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudMVC.Models
{
    public class VendaModel
    {

        public int Id { get; set; }

        public decimal TotalGeral {  get; set; }
        public List<ItemVendaModel> ItensVenda { get; set; } = new List<ItemVendaModel>();
       
        public DateTime Data { get; set; } = DateTime.UtcNow;

       
    }
}
