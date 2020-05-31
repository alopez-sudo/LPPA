using BuyMotors.BE;
using BuyMotors.DAL;
using System;
using System.Linq;

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

		public static bool FinalizarCompra(Carrito carrito)
        {
			// Antes de hacer la factura verifico que los vehículos todavía estén disponibles
			foreach (CarritoDetalle detalle in carrito.Detalles)
            {
				if (!VehiculoMapper.EstaDisponible(detalle.Vehiculo))
                {
					return false;
                }
            }

			Factura factura = new Factura
			{
				Fecha = DateTime.Now,
				Usuario = carrito.Usuario,
				Carrito = carrito,
				Detalles = carrito.Detalles.Select(d => new FacturaDetalle
                {
					Vehiculo = d.Vehiculo,
					Cantidad = d.Cantidad,
					Precio = d.Precio
                }).ToList()
			};

			bool guardadoOk = FacturaMapper.Guardar(factura);
			if (guardadoOk)
            {
				// Tengo que marcar los vehículos como No disponibles debido a que ya están facturados
				foreach (FacturaDetalle detalle in factura.Detalles)
                {
					VehiculoMapper.MarcarNoDisponible(detalle.Vehiculo);
                }
            }

			return guardadoOk;
        }
	}
}
