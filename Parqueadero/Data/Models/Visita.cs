using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parqueadero.Data.Models
{
    public class Visita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string CodigoVisita { get; set; }
        public long ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public virtual Client? Client { get; set; }
    }
}
