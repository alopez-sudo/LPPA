using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMotors.BE
{
	public class FiltroVehiculo
	{
		public string Patente { get; set; }
		public int? PrecioDesde { get; set; }
		public int? PrecioHasta { get; set; }
	}
}
