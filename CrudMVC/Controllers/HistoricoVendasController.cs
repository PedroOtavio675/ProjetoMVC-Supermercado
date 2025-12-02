using CrudMVC.Models;
using CrudMVC.Ropositorio;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace CrudMVC.Controllers
{
    public class HistoricoVendasController : Controller
    {
        private readonly IVendaRepositorio _vendaRepositorio;
        public HistoricoVendasController(IVendaRepositorio vendaRepositorio) { 
         _vendaRepositorio = vendaRepositorio;
        }
        public IActionResult Index()
        {
            var vendas = _vendaRepositorio.ListarVendas();
            
        
         
            return View(vendas);
        }
        public IActionResult VerProdutos(int id)
        {
           var itens = _vendaRepositorio.BuscarItensVenda(id);
            return View(itens);
        }
        public IActionResult ExcluirConfirma(int id)
        {
            var vendaRemove = _vendaRepositorio.BuscarVenda(id);
            
            return View(vendaRemove);
        }

        [HttpPost]
        public IActionResult ExcluirVenda(int id)
        {
            try
            {
                _vendaRepositorio.ExcluirConfirma(id);
                TempData["MensagemSucesso"] = "Produto excluído com sucesso!";
                return RedirectToAction("Index", "HistoricoVendas");
            }catch(Exception err)
            {
                TempData["MensagemErro"] = $"Não foi possivel excluir o produto: {err}";
                return RedirectToAction("Index", "HistoricoVendas");
            }
           
        }
    }
}
