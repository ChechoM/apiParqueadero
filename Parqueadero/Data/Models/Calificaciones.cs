using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parqueadero.Data.Models
{
    public class Calificaciones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Comentario { get; set; }
        public int Calificacion { get; set; }
        public long IdVisita { get; set; }
        [ForeignKey(nameof(IdVisita))]
        public virtual Visita Visita { get; set; }
    }
}
