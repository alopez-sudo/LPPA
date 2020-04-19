using System;
using System.Collections.Generic;

namespace BuyMotors.BE
{
    public class Factura
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Carrito Carrito { get; set; }
        public Usuario Usuario { get; set; }
        public List<FacturaDetalle> Detalles { get; set; }
    }
}
