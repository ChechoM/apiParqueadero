﻿namespace Parqueadero.Data.Dto
{
    public class ReporteVisitasDto
    {
        public long id { get; set; }
        public string Nombre { get; set; }
        public int Recaudo { get; set; }
        public int PromedioCalificacion { get; set; }
        public double CantidadVisitas { get; set; }
    }
}
