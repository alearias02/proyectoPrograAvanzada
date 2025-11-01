using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFront.Data;
using ProyectoFront.Models;

namespace ProyectoFront.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            return View(await _context.UsuarioActivity.ToListAsync());
        }

        //Crear
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(UsuarioModel _usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(_usuario);
        }

        // GET: Editar
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UsuarioModel usuario = await _context.UsuarioActivity.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(UsuarioModel _usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Update(_usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_usuario);
        }

        // GET Eliminar
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UsuarioModel usuario = await _context.UsuarioActivity.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int Id)
        {
            UsuarioModel usuario = await _context.UsuarioActivity.FindAsync(Id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.UsuarioActivity.Remove(usuario);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
