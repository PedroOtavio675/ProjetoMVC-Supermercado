using CrudMVC.Data;
using CrudMVC.Models;

namespace CrudMVC.Ropositorio
{
    public interface IVendaRepositorio
    {
        public VendaModel RegistrarVenda(VendaModel venda);
        public List<VendaModel> BuscarVendasPorData(DateTime data);
        
        public VendaModel BuscarVenda(int id);
        public List<VendaModel> ListarVendas();
        public List<ItemVendaModel> BuscarItensVenda(int id);

        public bool ExcluirConfirma(int id);
    }
}
