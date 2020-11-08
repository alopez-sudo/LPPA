using BuyMotors.BE;
using BuyMotors.BE.Filtros;
using BuyMotors.DAL;
using System.Collections.Generic;

namespace BuyMotors.BL
{
	public class VehiculoManager
	{
		public static List<Vehiculo> ObtenerVehiculos()
		{
			return VehiculoMapper.ObtenerVehiculos();
		}
		public static Vehiculo ObtenerVehiculo(int Id)
		{
			return VehiculoMapper.ObtenerVehiculo(Id);
		}
	}
}
