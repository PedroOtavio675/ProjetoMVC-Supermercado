using CrudMVC.Models;
using CrudMVC.Ropositorio;
using Microsoft.AspNetCore.Mvc;

namespace CrudMVC.Controllers
{
    public class VerController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public VerController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }
        public IActionResult Index()
        {
            var produtos = _produtoRepositorio.BuscarProdutos();
            return View(produtos);
        }
        public IActionResult Editar(int id)
        {
            ProdutoModel produto = _produtoRepositorio.BuscarProduto(id);
            if (produto == null)
            {
                return RedirectToAction("Index", "Ver");
            }

            return View(produto);
        }
        public IActionResult ExcluirConfirma(int id)
        {
            ProdutoModel produtoRemove = _produtoRepositorio.BuscarProduto(id);

            if(produtoRemove == null)
            {
                return RedirectToAction("Index", "Ver");
            }
            return View(produtoRemove);
        }

        [HttpPost]

        public IActionResult ApagarProduto(int id)
        {
            try
            {
                _produtoRepositorio.ApagarProduto(id);
                TempData["MensagemSucesso"] = "Produto excluído com sucesso!";
                return RedirectToAction("Index", "Ver");

            }catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel excluir o produto: {erro}";
                return RedirectToAction("Index", "Ver");
            }
        }

        [HttpPost]

        public IActionResult AtualizarProduto(ProdutoModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoRepositorio.EditarProduto(produto);
                    TempData["MensagemSucesso"] = "Produto excluído com sucesso!";
                   
                }
                return RedirectToAction("Index", "Ver");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel editar o produto: {erro}";
                return RedirectToAction("Index", "Ver");
            }
        }
    }
}
