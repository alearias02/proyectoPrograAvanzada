namespace ProyectoFront.Models
{
    public class ServicioModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public decimal IVA { get; set; }
        public int Especialidad { get; set; }
        public string Especialista { get; set; }
        public string Clinica { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public DateTime? FechaDeModificacion { get; set; }
        public bool Estado { get; set; }
    }
}
