using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using ProyectoFront.Models;

namespace ProyectoFront.Controllers
{
    public class FuncionesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Operacion());
        }

        [HttpPost]
        public IActionResult Calculadora(Operacion operacion, string tipooperacion)
        {

            operacion.tipooperacion = "El resultado " + tipooperacion;

            return View("Index", operacion);
           
        }
    }
}
