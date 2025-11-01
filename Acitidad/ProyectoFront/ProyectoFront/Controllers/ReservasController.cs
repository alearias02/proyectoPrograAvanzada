using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFront.Data;
using ProyectoFront.Models;

namespace ProyectoFront.Controllers
{
    public class ReservasController : Controller
    {
        private readonly AppDbContext _context;

        public ReservasController(AppDbContext context)
        {
            _context = context;
        }

        // LISTAR SERVICIOS DISPONIBLES PARA RESERVAR
        public async Task<IActionResult> Index()
        {
            var reservas = await _context.ReservasActivity.ToListAsync();

            foreach (var r in reservas)
            {
                r.Usuario = await _context.UsuarioActivity.FindAsync(r.IdUsuario);
                r.Laboratorio = await _context.Laboratorios.FindAsync(r.IdLaboratorio);
            }

            return View(reservas);
        }


        // RESERVAR CITA (GET)
        public IActionResult Reservar()
        {
            ViewBag.Usuarios = _context.UsuarioActivity.ToList();
            ViewBag.Laboratorios = _context.Laboratorios.ToList();

            return View();
        }


        // RESERVAR CITA (POST)
        [HttpPost]
        public IActionResult Reservar(Reservas reserva)
        {
            if (ModelState.IsValid)
            {
                reserva.FechaReserva = reserva.FechaReserva == default ? DateTime.Now : reserva.FechaReserva;
                _context.ReservasActivity.Add(reserva);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Usuarios = _context.UsuarioActivity.ToList();
            ViewBag.Laboratorios = _context.Laboratorios.ToList();

            return View(reserva);
        }
    }

}
