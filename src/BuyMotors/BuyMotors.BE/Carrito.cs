using System;
using System.Collections.Generic;

namespace BuyMotors.BE
{
    public class Carrito
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
		public List<CarritoDetalle> Detalles { get; set; } = new List<CarritoDetalle>();
        public Usuario Usuario { get; set; }
		public string UsuarioSessionId { get; set; }
	}
}
