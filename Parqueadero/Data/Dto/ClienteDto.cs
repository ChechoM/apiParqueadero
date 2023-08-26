using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Parqueadero.Data.Dto
{
    public class ClienteDto
    {
        public string Name { get; set; }
        public string Nit { get; set; }
        public double ValorHora { get; set; }
        public string Direccion { get; set; }
        public string Descripcion { get; set; }
        public DateTime HorarioAbre { get; set; } = DateTime.Now;
        public DateTime HorarioCierre { get; set; } = DateTime.Now;
        public bool Techo { get; set; } = false;
        public bool Datafono { get; set; } = false;
        public bool Disponibilidad { get; set; } = false;
        public string Longitud { get; set; }
        public string Latitud { get; set; }
        public long UserId { get; set; }
    }
}
