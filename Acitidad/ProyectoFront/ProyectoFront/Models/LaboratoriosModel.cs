namespace ProyectoFront.Models
{
    public class LaboratoriosModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public int Capacidad { get; set; }

        public string Responsable { get; set; } = string.Empty;
    }
}