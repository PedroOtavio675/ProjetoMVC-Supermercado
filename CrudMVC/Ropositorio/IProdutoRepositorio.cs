using CrudMVC.Models;

namespace CrudMVC.Ropositorio
{
    public interface IProdutoRepositorio
    {
        List<ProdutoModel> BuscarProdutos();
        ProdutoModel Adicionar(ProdutoModel produto);
    }
}
