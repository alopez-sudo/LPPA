using System;

namespace BuyMotors.BE
{
    public class Bitacora
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
        public string Detalle { get; set; }
    }
}
