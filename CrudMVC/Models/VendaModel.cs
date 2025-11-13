namespace CrudMVC.Models
{
    public class VendaModel
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public decimal Valor { get; set; }
        public int Quatidade { get; set; }
        public string Data { get; set; }
    }
}
