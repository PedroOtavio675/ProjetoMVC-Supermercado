using CrudMVC.Helpers;
using CrudMVC.Migrations;
using CrudMVC.Models;
using CrudMVC.Ropositorio;
using Microsoft.AspNetCore.Mvc;

namespace CrudMVC.Controllers
{
    public class VenderController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IVendaRepositorio _vendaRepositorio;


        public VenderController(IProdutoRepositorio produtoRepositorio, IVendaRepositorio vendaRepositorio
            )
        {
            _produtoRepositorio = produtoRepositorio;
            _vendaRepositorio = vendaRepositorio;
          
        }
        
        public IActionResult Index()
        {
            List<ItemVendaModel> itens = HttpContext.Session.GetObject<List<ItemVendaModel>>("itens") ?? new List<ItemVendaModel>();

            foreach(var item in itens)
            {
                item.Produto = _produtoRepositorio.BuscarProduto(item.ProdutoId);
            }
            return View(itens);
        }

       

        public IActionResult AdicionarItens(int produtoId, int quantidade)
        {
            ProdutoModel produto = _produtoRepositorio.BuscarProduto(produtoId);

            if (produto == null)
            {
                ModelState.AddModelError("", "Produto não encontrado");
                return RedirectToAction("Index");
            }
            if(produto.Estoque < quantidade)
            {
                ModelState.AddModelError("", "Produto sem estoque");
                return RedirectToAction("Index");
            }
            List<ItemVendaModel> itens = HttpContext.Session.GetObject<List<ItemVendaModel>>("itens");
            if (itens == null)
            {
                itens = new List<ItemVendaModel>();
            }
                
            ItemVendaModel item = new ItemVendaModel
            {
                Id = 0,
                ProdutoId = produto.Id,
                Quantidade = quantidade,
                ValorUnitario = produto.Preco,
                TotalItem = quantidade * produto.Preco
            };
            itens.Add(item);
            HttpContext.Session.SetObject("itens", itens);

            return RedirectToAction("Index");
        }
        public IActionResult RemoverItem(int id)
        {
            List<ItemVendaModel> itens = HttpContext.Session.GetObject<List<ItemVendaModel>>("itens");
            if(itens != null)
            {
                var item = itens.FirstOrDefault(i => i.ProdutoId == id);
                if(item != null)
                {
                    itens.Remove(item);
                    HttpContext.Session.SetObject("itens", itens);
                }
            }
            return RedirectToAction("Index");
        } 
        public IActionResult RegistrarVenda()
        {
            var itens = HttpContext.Session.GetObject<List<ItemVendaModel>>("itens");
            if (itens == null || itens.Count == 0)
            {
                ViewData["MenssagemErro"] = "Nenhum item adicionado!";
                return RedirectToAction("Index");
            }
            foreach (var item in itens)
            {
                item.Id = 0;
                item.Produto = null;
                item.Venda = null;
            }

            VendaModel venda = new()
            {
                Data = DateTime.UtcNow,
                TotalGeral = itens.Sum(i => i.TotalItem),
                ItensVenda = itens
            };
            
            _vendaRepositorio.RegistrarVenda(venda);
            foreach (var item in itens)
            {
                _produtoRepositorio.DarBaixaNoEstoque(item.ProdutoId, item.Quantidade);
            }
            HttpContext.Session.Remove("itens");

            ViewData["MensagemSucesso"] = "Venda Finalizado";
            return RedirectToAction("Index");
        }
    }
}
