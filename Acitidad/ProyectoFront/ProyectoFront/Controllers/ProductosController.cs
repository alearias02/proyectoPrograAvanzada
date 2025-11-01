using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFront.Data;
using ProyectoFront.Models;

namespace ProyectoFront.Controllers
{
    public class ProductosController : Controller
    {

        //Invocar o hacer una instancia
        private readonly AppDbContext _context;

        //Instanciarme
        public ProductosController (AppDbContext context)
        {
            _context = context;
        }


        //Los metodos ahora son asyncronicos
        public async Task<IActionResult> Index()
        {
            return View( await _context.Producto.ToListAsync());
        }


        //Crear???

        public IActionResult Crear()
        {

            return View();
        }

        //Post
        [HttpPost]
        public async Task<IActionResult> Crear(ProductoModel _producto)
        {

            if (ModelState.IsValid)
            {

                _context.Add(_producto);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }


            return View(_producto);
        }


        //Get /Editar/Id

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductoModel itemProducto = await _context.Producto.FindAsync(id);
            if (itemProducto == null)
            {
                return NotFound();
            }
            return View(itemProducto);
        }


        //Post
        [HttpPost]
        public async Task<IActionResult> Editar(ProductoModel _producto)
        {

            //ProductoModel itemProducto = await _context.Producto.FindAsync(_producto.Id);
            //if (itemProducto == null)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {

                _context.Update(_producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return View(_producto);
        }




        //Get /Eliminar/Id

        public async Task<IActionResult> Eliminar(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            ProductoModel itemProducto = await _context.Producto.FindAsync(id);
            
            if (itemProducto == null)
            {
                return NotFound();
            }
            return View(itemProducto);
        }



        [HttpPost]
        public async Task<IActionResult> Eliminar(int Id)
        {

            if (Id == null)
            {
                return NotFound();
            }
            ProductoModel itemProducto = await _context.Producto.FindAsync(Id);

            if (itemProducto == null)
            {
                return NotFound();
            }
            else
            {
                _context.Producto.Remove(itemProducto);
                await _context.SaveChangesAsync();
            }
          



            return RedirectToAction(nameof(Index));
        }

    }
}
