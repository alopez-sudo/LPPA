using BuyMotors.BE;
using System.Data.SqlClient;

namespace BuyMotors.DAL
{
    public class FacturaMapper
    {
        public static bool Guardar(Factura factura)
        {
            string queryFactura = "INSERT INTO FacturaCabecera (FechaCreacion, UsuarioId, CarritoId, DVH) OUTPUT INSERTED.Id " +
                "VALUES (@fechaCreacion, @usuarioId, @carritoId, 0)";
            SqlParameter[] parametersFactura = new SqlParameter[]
            {
                new SqlParameter("@fechaCreacion", factura.Fecha),
                new SqlParameter("@usuarioId", factura.Usuario.Id),
                new SqlParameter("@carritoId", factura.Carrito.Id)
            };

            factura.Id = SqlHelper.Insertar(queryFactura, parametersFactura);
            if (factura.Id == 0)
            {
                return false;
            }

            DigitoVerificador.ActualizarDV(factura);

            // Ahora inserto los detalles
            foreach (FacturaDetalle detalle in factura.Detalles)
            {
                string queryDetalle = "INSERT INTO FacturaDetalle (FacturaCabeceraId, VehiculoId, Cantidad, Precio) OUTPUT INSERTED.Id " +
                    "VALUES (@facturaId, @vehiculoId, @cantidad, @precio)";
                SqlParameter[] parametersDetalle = new SqlParameter[]
                {
                    new SqlParameter("@facturaId", factura.Id),
                    new SqlParameter("@vehiculoId", detalle.Vehiculo.Id),
                    new SqlParameter("@cantidad", detalle.Cantidad),
                    new SqlParameter("@precio", detalle.Precio)
                };

                detalle.Id = SqlHelper.Insertar(queryDetalle, parametersDetalle);
                if (detalle.Id == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
