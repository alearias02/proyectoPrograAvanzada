namespace ProyectoFront.Models
{
    public class Producto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        //Inventario: con las funciones Listar, Registrar, Editar, Detalles y Eliminar.
    }
}
