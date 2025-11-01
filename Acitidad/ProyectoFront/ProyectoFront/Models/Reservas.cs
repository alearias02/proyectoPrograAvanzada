using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFront.Models
{
    public class Reservas
    {
        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public int IdLaboratorio { get; set; }

        public DateTime FechaReserva { get; set; }

        [ForeignKey("IdUsuario")]
        public UsuarioModel? Usuario { get; set; }

        [ForeignKey("IdLaboratorio")]
        public LaboratoriosModel? Laboratorio { get; set; }

    }
}
