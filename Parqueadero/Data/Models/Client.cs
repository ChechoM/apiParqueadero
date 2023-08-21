using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Parqueadero.Data.Models
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
        [AllowNull]
        public string Nit { get; set; }
        [Required]
        public double ValorHora { get; set; }
        [AllowNull]
        public string Direccion { get; set; }
        [AllowNull]
        public string Descripcion { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{HH}", ApplyFormatInEditMode = true)]
        public DateTime HorarioAbre { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{HH}", ApplyFormatInEditMode = true)]
        public DateTime HorarioCierre { get; set; }
        [AllowNull]
        public bool Techo { get; set; } = false;
        [AllowNull]
        public bool Datafono { get; set; } = false;
        [AllowNull]
        public bool Disponibilidad { get; set; } = false;
        [Required]
        public string Longitud { get; set; }
        [Required]
        public string Latitud { get; set; }
        public long UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

    }
}
