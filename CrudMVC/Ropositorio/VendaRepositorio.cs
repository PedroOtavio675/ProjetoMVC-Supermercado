using CrudMVC.Data;
using CrudMVC.Models;

namespace CrudMVC.Ropositorio
{
    public class VendaRepositorio : IVendaRepositorio
    {
        private readonly BancoContext _bancoContext;

        public VendaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<ItemVendaModel> BuscarItensVenda(int id)
        {

            return _bancoContext.ItemVenda.Where(x => x.VendaId == id).ToList();
        }
        public List<VendaModel> BuscarVendasPorData(DateTime data)
        {
            var tudo = _bancoContext.Venda.ToList();
            return tudo.Where(x => x.Data.Date == data.Date).ToList();
        }
        public VendaModel BuscarVenda(int id)
        {
            return _bancoContext.Venda.FirstOrDefault(x => x.Id ==  id);
        }
        

        public bool ExcluirConfirma(int id)
        {
            VendaModel vendaParaExcluir =  BuscarVenda(id);

            _bancoContext.Remove(vendaParaExcluir);
            _bancoContext.SaveChanges();
            return true;
        }


        public List<VendaModel> ListarVendas()
        {
           return _bancoContext.Venda.ToList();
        }

        public VendaModel RegistrarVenda(VendaModel venda)
        {
            
     
            _bancoContext.Venda.Add(venda);
            _bancoContext.SaveChanges();
            return venda;
        }

        
    }
}
