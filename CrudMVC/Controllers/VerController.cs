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

            return View();
        }
        public IActionResult ExcluirConfirma()
        {
            return View();
        }
    }
}
