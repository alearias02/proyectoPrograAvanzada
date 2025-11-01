using Microsoft.AspNetCore.Mvc;
using ProyectoFront.Models;

namespace ProyectoFront.Controllers
{
    public class ProductoController : Controller
    {

        //Propiedades y variables
        //public int Id { get; set; }

        //public string Nombre { get; set; }
        //public string Descripcion { get; set; }
        //public decimal Precio { get; set; }
        //public int Cantidad { get; set; }
        private static List<Producto> _productos = new List<Producto>()
        {
            new Producto{ Id=1, Nombre="Producto 1", Descripcion="Tabla", Precio= 1000, Cantidad=20 },
            new Producto{ Id=2, Nombre="Producto 2", Descripcion="Tabla", Precio=1000, Cantidad=20 },
        };
        private static int _siguienteIndice = 3;
        //Get
        public IActionResult Index()
        {
            
            return View(_productos);
        }

        //Get
        public IActionResult Crear()
        {

            return View();
        }
        //Post
        [HttpPost]
        public IActionResult Crear(Producto _producto)
        {

            if (ModelState.IsValid)
            {
                _producto.Id = _siguienteIndice++;

                _productos.Add(_producto);

                return RedirectToAction("Index");
            }


            return View(_producto);
        }


        //Get /Editar/Id

        public IActionResult Editar(int id)
        {

            Producto itemProducto = _productos.FirstOrDefault(x => x.Id == id);
            if (itemProducto == null)
            {
                return NotFound();
            }
            return View(itemProducto);
        }


        //Post
        [HttpPost]
        public IActionResult Editar(Producto _producto)
        {

            Producto itemProducto = _productos.FirstOrDefault(x => x.Id == _producto.Id);
            if (itemProducto == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                itemProducto.Nombre = _producto.Nombre;
                itemProducto.Descripcion = _producto.Descripcion;
                itemProducto.Cantidad = _producto.Cantidad;
                itemProducto.Precio = _producto.Precio;
                return RedirectToAction(nameof(Index));
            }


            return View(_producto);
        }

        //Get /Eliminar/Id

        public IActionResult Eliminar (int id)
        {

            Producto itemProducto = _productos.FirstOrDefault(x => x.Id == id);
            if (itemProducto == null)
            {
                return NotFound();
            }
            return View(itemProducto);
        }



        [HttpPost]
        public IActionResult Eliminar(Producto _producto)
        {

            Producto itemProducto = _productos.FirstOrDefault(x => x.Id == _producto.Id);
            if (itemProducto == null)
            {
                return NotFound();
            }

            _productos.Remove(itemProducto);

            return RedirectToAction(nameof(Index));
        }

    }
}
