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
            VendaModel venda = new VendaModel();
            return View(venda);
        }

        [HttpGet]
        public IActionResult BuscarProduto(int id)
        {
            try
            {
                ProdutoModel produto = _produtoRepositorio.BuscarProduto(id);

                if (produto == null) {
                    throw new Exception("Produto não encontrado!");
                }
                else
                {
                    VendaModel model = new VendaModel
                    {
                        Produto = produto,
                        ProdutoId = produto.Id
                    };

                    ViewData["MensagemSucesso"] = "Ok";
                    return View("Index", model);
                }
                
            }
            catch (Exception ex)
            {
                VendaModel model = new VendaModel();
               
                ModelState.AddModelError("", "Ocorreu um erro ao buscar o produto: " + ex.Message);
                ViewData["MensagemErro"] = "Não foi possível encontrar o produto";
                return View("Index", model);
            };
            
        }


        [HttpPost]
        public IActionResult RegistrarVenda(VendaModel vendaProduto)
        {
            //ModelState.Remove("Id");
            ModelState.Remove("Produto");
            if (ModelState.IsValid)
            {
                try
                {
                 
                  _vendaRepositorio.RegistrarVenda(vendaProduto);
                    _produtoRepositorio.DarBaixaNoEstoque(vendaProduto.ProdutoId, vendaProduto.Quantidade);
                    ViewData["MensagemSucesso"] = "✅ Venda registrada e estoque atualizado com sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewData["MensagemErro"] = "Não foi possivel registrar venda!";
                    ModelState.AddModelError("", "Ocorreu um erro ao salvar a venda: " + ex.Message);
                }
            }

            return View("Index", vendaProduto);
        }
    }
}
