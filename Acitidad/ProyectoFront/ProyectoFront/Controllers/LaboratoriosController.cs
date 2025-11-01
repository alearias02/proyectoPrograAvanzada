using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFront.Data;
using ProyectoFront.Models;

namespace ProyectoFront.Controllers
{
    public class LaboratoriosController : Controller
    {
        private readonly AppDbContext _context;

        public LaboratoriosController(AppDbContext context)
        {
            _context = context;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            return View(await _context.Laboratorios.ToListAsync());
        }

        // GET
        public IActionResult Crear()
        {
            return View();
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Crear(LaboratoriosModel laboratorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laboratorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(laboratorio);
        }
    }
}