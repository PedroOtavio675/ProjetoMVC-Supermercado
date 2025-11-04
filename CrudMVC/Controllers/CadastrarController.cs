using CrudMVC.Models;
using CrudMVC.Ropositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CrudMVC.Controllers
{
    public class CadastrarController : Controller
    {

        private readonly IProdutoRepositorio _produtoRepositorio;

        public CadastrarController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ProdutoModel produto)
        {

            if (ModelState.IsValid)
            {
                try
                {

                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Ocorreu um erro ao salvar o produto");
                }
            }
            _produtoRepositorio.Adicionar(produto);
            return RedirectToAction("Index", "Ver");
        }
    }
}
