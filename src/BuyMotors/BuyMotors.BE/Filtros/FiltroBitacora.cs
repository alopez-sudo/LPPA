using System;

namespace BuyMotors.BE.Filtros
{
    public class FiltroBitacora
    {
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public string Usuario { get; set; }
    }
}
