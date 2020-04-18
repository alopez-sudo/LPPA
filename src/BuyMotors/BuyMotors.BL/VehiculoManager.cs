using BuyMotors.BE;
using BuyMotors.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMotors.BL
{
	public class VehiculoManager
	{
		public static IEnumerable<Vehiculo> ObtenerVehiculos(FiltroVehiculo filtro)
		{
			return VehiculoMapper.ObtenerVehiculos(filtro);
		}
		public static Vehiculo ObtenerVehiculo(int Id)
		{
			return VehiculoMapper.ObtenerVehiculo(Id);
		}
	}
}
