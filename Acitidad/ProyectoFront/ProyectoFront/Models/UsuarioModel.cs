namespace ProyectoFront.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Tipo { get; set; }  

        public string Correo { get; set; }

        // Tabla: UsuarioActivity
        // CREATE TABLE `u484426513_pac325`.`UsuarioActivity` (
        //   Id INT AUTO_INCREMENT PRIMARY KEY,
        //   Nombre VARCHAR(100) NOT NULL,
        //   Tipo VARCHAR(20) NOT NULL,
        //   Correo VARCHAR(100) NOT NULL
        // );
    }
}
