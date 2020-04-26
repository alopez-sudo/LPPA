using BuyMotors.BE;
using BuyMotors.BE.Filtros;
using BuyMotors.DAL;
using System.Collections.Generic;

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
