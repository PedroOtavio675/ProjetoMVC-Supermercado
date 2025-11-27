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

        public ProdutoModel BuscarProduto(int id)
        {
            return _bancoContext.Produto.FirstOrDefault(x => x.Id == id);
        }

        public bool ApagarProduto(int id)
        {
            ProdutoModel produto = BuscarProduto(id);

            if(produto == null)
            {
                throw new System.Exception("Não foi possivel encontrar o produto para remove-lo");
               
            }

            _bancoContext.Produto.Remove(produto);
            _bancoContext.SaveChanges();

            return true;

        }

        public bool EditarProduto(ProdutoModel produto)
        {
            ProdutoModel produtoDB = BuscarProduto(produto.Id);
            if (produtoDB == null)
            {
                throw new System.Exception("Não foi possivel encontrar o produto para remove-lo");

            }
            produtoDB.Nome = produto.Nome;
            produtoDB.Estoque = produto.Estoque;
            produtoDB.Preco = produto.Preco;
            
            _bancoContext.Produto.Update(produtoDB);
            _bancoContext.SaveChanges();
            return true;

        }

        public ProdutoModel DarBaixaNoEstoque(int id, int quantidade)
        {
            ProdutoModel produto = BuscarProduto(id);

            if(quantidade <= produto.Estoque)
            {
                produto.Estoque = produto.Estoque - quantidade;
            }
            else
            {
                throw new System.Exception($"Estoque insuficiente, o estoque atual é: {produto.Estoque}");
            }


            _bancoContext.Produto.Update(produto);
            _bancoContext.SaveChanges();
            return produto;
        }
    }
}
