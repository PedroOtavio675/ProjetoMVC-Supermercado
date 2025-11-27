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
                    _produtoRepositorio.Adicionar(produto);
                    TempData["MensagemSucesso"] = "Produto cadastrado com sucesso";
                    return RedirectToAction("Index", "Ver");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Ocorreu um erro ao salvar o produto");
                    TempData["MensagemErro"] = "Erro ao cadastrar produto!";
                    return RedirectToAction("Index", "Ver");
                }
            }
            else
            {
                TempData["MensagemErro"] = "Dados inválidos!";
                return RedirectToAction("Index");
            }
        }
    }
}
