using BuyMotors.BE;
using BuyMotors.DAL;

namespace BuyMotors.BL
{
	public class CarritoManager
	{
		public static Carrito ObtenerCarrito(int usuarioId, string usuarioSessionId)
		{
			return CarritoMapper.ObtenerCarrito(usuarioId, usuarioSessionId);
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
