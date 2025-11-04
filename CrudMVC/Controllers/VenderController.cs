using Microsoft.AspNetCore.Mvc;

namespace CrudMVC.Controllers
{
    public class VenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
