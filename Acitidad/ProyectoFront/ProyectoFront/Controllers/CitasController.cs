using Microsoft.AspNetCore.Mvc;
using ProyectoFront.Data;
using ProyectoFront.Models;

namespace ProyectoFront.Controllers
{
    public class CitasController : Controller
    {
        private readonly AppDbContext _context;

        public CitasController(AppDbContext context)
        {
            _context = context;
        }

        // LISTAR SERVICIOS DISPONIBLES PARA RESERVAR
        public IActionResult Index()
        {
            var lista = _context.SERVICIOS
                .Where(s => s.Estado == true)
                .ToList();
            return View(lista);
        }

        // RESERVAR CITA (GET)
        public IActionResult Reservar(int id)
        {
            var servicio = _context.SERVICIOS.Find(id);
            if (servicio == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Servicio = servicio;
            return View(new CitaModel
            {
                IdServicio = id,
                FechaDeRegistro = DateTime.Now
            });
        }

        // RESERVAR CITA (POST)
        [HttpPost]
        public IActionResult Reservar(CitaModel cita)
        {
            var servicio = _context.SERVICIOS.Find(cita.IdServicio);
            if (servicio == null)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                cita.MontoTotal = (servicio.Monto * servicio.IVA) + servicio.Monto;
                cita.FechaDeRegistro = DateTime.Now;
                _context.CITAS.Add(cita);
                _context.SaveChanges();
                ViewBag.Mensaje = "Cita reservada correctamente.";
                return RedirectToAction("Index");
            }

            ViewBag.Servicio = servicio;
            return View(cita);
        }

        // DETALLE DE CITA
        public IActionResult Detalle(int id)
        {
            var cita = _context.CITAS.Find(id);
            if (cita == null)
            {
                TempData["Mensaje"] = "Estimado usuario, no se ha encontrado la cita, favor realice una.";
                return RedirectToAction("Index");
            }

            var servicio = _context.SERVICIOS.Find(cita.IdServicio);
            ViewBag.Servicio = servicio;
            return View(cita);
        }

        // HISTORICO GENERAL DE CITAS
        public IActionResult Historico(int? idServicio)
        {
            var lista = _context.CITAS.AsQueryable();

            if (idServicio != null)
            {
                lista = lista.Where(c => c.IdServicio == idServicio);
            }

            return View(lista.ToList());
        }
    }
}
