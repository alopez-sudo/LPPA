using BuyMotors.BE;
using BuyMotors.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMotors.BL
{
	public class CarritoManager
	{
		public static Carrito ObtenerCarrito(string UsuarioSessionId)
		{
			return CarritoMapper.ObtenerCarrito(UsuarioSessionId);
		}
		public static Carrito ObtenerCarritoSesion(string UsuarioSessionId)
		{
			return CarritoMapper.ObtenerCarritoSesion(UsuarioSessionId);
		}
		public static void AgregarDetalle(Carrito carrito)
		{
			CarritoMapper.AgregarDetalle(carrito);
		}
		public static void EliminarDetalle(CarritoDetalle detalle)
		{
			CarritoMapper.EliminarDetalle(detalle);
		}
	}
}
