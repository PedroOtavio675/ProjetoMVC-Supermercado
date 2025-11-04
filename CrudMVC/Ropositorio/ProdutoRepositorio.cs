using CrudMVC.Data;
using CrudMVC.Models;

namespace CrudMVC.Ropositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ProdutoRepositorio(BancoContext bancoContex)
        {
         _bancoContext = bancoContex;
        }
        public ProdutoModel Adicionar(ProdutoModel produto)
        {
       //gravar no banco de dados
      
            _bancoContext.Produto.Add(produto);
            _bancoContext.SaveChanges();
            return produto;
        }

        public List<ProdutoModel> BuscarProdutos()
        {
           return _bancoContext.Produto.ToList();
        }
    }
}
