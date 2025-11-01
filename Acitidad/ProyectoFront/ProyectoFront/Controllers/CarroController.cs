using Microsoft.AspNetCore.Mvc;

namespace ProyectoFront.Controllers
{
    public class CarroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
