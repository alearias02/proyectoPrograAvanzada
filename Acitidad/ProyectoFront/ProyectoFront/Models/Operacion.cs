namespace ProyectoFront.Models
{
    public class Operacion
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double datoa { get; set;  }
        public double datob { get; set; }
        public double resultado { get; set; }
        public string? tipooperacion { get; set; }

    }
}
