using CrudMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudMVC.Controllers
{
    public class VenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Vender(VendaModel vendaProduto)
        {
            return View();
        }
    }
}
