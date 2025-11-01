using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFront.Data;
using ProyectoFront.Models;

namespace ProyectoFront.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly AppDbContext _context;

        public ServiciosController(AppDbContext context)
        {
            _context = context;
        }

        // LISTAR SERVICIOS
        public IActionResult Index()
        {
            var lista = _context.SERVICIOS.ToList();
            return View(lista);
        }

        // CREAR SERVICIO (GET)
        public IActionResult Crear()
        {
            return View();
        }

        // CREAR SERVICIO (POST)
        [HttpPost]
        public IActionResult Crear(ServicioModel servicio)
        {
            if (ModelState.IsValid)
            {
                servicio.FechaDeRegistro = DateTime.Now;
                servicio.Estado = true;
                _context.SERVICIOS.Add(servicio);
                _context.SaveChanges();
                ViewBag.Mensaje = "Servicio registrado correctamente.";
                return RedirectToAction("Index");
            }
            return View(servicio);
        }

        // EDITAR SERVICIO (GET)
        public IActionResult Editar(int id)
        {
            var servicio = _context.SERVICIOS.Find(id);
            if (servicio == null)
            {
                return RedirectToAction("Index");
            }
            return View(servicio);
        }

        // EDITAR SERVICIO (POST)
        [HttpPost]
        public IActionResult Editar(ServicioModel model)
        {
            var servicio = _context.SERVICIOS.Find(model.Id);
            if (servicio != null)
            {
                servicio.Nombre = model.Nombre;
                servicio.Descripcion = model.Descripcion;
                servicio.Monto = model.Monto;
                servicio.IVA = model.IVA;
                servicio.Especialista = model.Especialista;
                servicio.Clinica = model.Clinica;
                servicio.Estado = model.Estado;
                servicio.FechaDeModificacion = DateTime.Now;

                _context.SERVICIOS.Update(servicio);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // VER CITAS RELACIONADAS A UN SERVICIO
        public IActionResult VerCitas(int id)
        {
            var citas = _context.CITAS
                .Where(c => c.IdServicio == id)
                .ToList();
            ViewBag.NombreServicio = _context.SERVICIOS.Find(id)?.Nombre;
            return View(citas);
        }
    }
}
