using CrudMVC.Models;

namespace CrudMVC.Ropositorio
{
    public interface IProdutoRepositorio
    {
        List<ProdutoModel> BuscarProdutos();
        ProdutoModel Adicionar(ProdutoModel produto);

        ProdutoModel BuscarProduto(int id);

        bool EditarProduto(ProdutoModel produto);

        bool ApagarProduto(int id);

        ProdutoModel DarBaixaNoEstoque(int id, int quantidade);
    }
}
