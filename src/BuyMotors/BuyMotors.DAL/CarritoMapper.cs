using BuyMotors.BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BuyMotors.DAL
{
    public class CarritoMapper
    {
        public static Carrito ObtenerCarrito(int usuarioId, string usuarioSessionId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@UsuarioSessionId", usuarioSessionId),
                new SqlParameter("@UsuarioId", usuarioId)
            };

            string query = "SELECT cr.FechaCreacion,cd.Id AS CarritoDetalleId,cd.CarritoId,cd.Cantidad,cd.Precio AS PrecioDetalle," +
                            " v.Id,v.Patente,v.ColorId,c.Nombre AS Color,v.ModeloId,m.Nombre AS Modelo,m.MarcaId,ma.Nombre AS Marca,v.Precio," +
                            " v.AnioFabricacion,v.TipoVehiculoId,t.Nombre AS Tipo,v.CategoriaVehiculoId,ca.Nombre AS Categoria" +
                            " FROM Carrito cr INNER JOIN CarritoDetalle cd ON cd.CarritoId=cr.Id" +
                            " INNER JOIN Vehiculo v ON v.Id=cd.VehiculoId INNER JOIN Color c ON c.Id=v.ColorId" +
                            " INNER JOIN CategoriaVehiculo ca ON ca.Id=v.CategoriaVehiculoId" +
                            " INNER JOIN TipoVehiculo t ON t.Id=v.TipoVehiculoId" +
                            " INNER JOIN Modelo m ON m.Id=v.ModeloId" +
                            " INNER JOIN Marca ma ON ma.Id=m.MarcaId" +
                            " WHERE UsuarioSessionId = @UsuarioSessionId" +
                            " AND UsuarioId = @UsuarioId" +
                            " ORDER BY v.Id";
            DataTable tabla = SqlHelper.Obtener(query, parameters.ToArray());

            if (tabla == null || tabla.Rows.Count == 0)
                return null;

            Carrito carrito = new Carrito()
            {
                Usuario = UsuarioMapper.Obtener(usuarioId),
                UsuarioSessionId = usuarioSessionId
            };

            List<CarritoDetalle> detalles = new List<CarritoDetalle>();
            foreach (DataRow fila in tabla.Rows)
            {
                carrito.Id = int.Parse(fila["CarritoId"].ToString());
                carrito.FechaCreacion = DateTime.Parse(fila["FechaCreacion"].ToString());

                CarritoDetalle carritoDetalle = new CarritoDetalle
                {
                    Id = int.Parse(fila["CarritoDetalleId"].ToString()),
                    Cantidad = int.Parse(fila["Cantidad"].ToString()),
                    Precio = int.Parse(fila["PrecioDetalle"].ToString())
                };

                Vehiculo vehiculo = new Vehiculo
                {
                    Id = int.Parse(fila["Id"].ToString()),
                    Patente = fila["Patente"].ToString(),
                    AnioFabricacion = int.Parse(fila["AnioFabricacion"].ToString()),
                    Precio = int.Parse(fila["Precio"].ToString())
                };

                Color color = new Color
                {
                    Id = int.Parse(fila["ColorId"].ToString()),
                    Nombre = fila["Color"].ToString()
                };
                vehiculo.Color = color;

                Marca marca = new Marca
                {
                    Id = int.Parse(fila["ModeloId"].ToString()),
                    Nombre = fila["Marca"].ToString()
                };

                Modelo modelo = new Modelo
                {
                    Id = int.Parse(fila["ModeloId"].ToString()),
                    Nombre = fila["Modelo"].ToString(),
                    Marca = marca
                };
                vehiculo.Modelo = modelo;

                CategoriaVehiculo categoriaVehiculo = new CategoriaVehiculo
                {
                    Id = int.Parse(fila["CategoriaVehiculoId"].ToString()),
                    Nombre = fila["Categoria"].ToString()
                };
                vehiculo.Categoria = categoriaVehiculo;

                TipoVehiculo tipoVehiculo = new TipoVehiculo
                {
                    Id = int.Parse(fila["TipoVehiculoId"].ToString()),
                    Nombre = fila["Tipo"].ToString()
                };
                vehiculo.Tipo = tipoVehiculo;

                carritoDetalle.Vehiculo = vehiculo;
                detalles.Add(carritoDetalle);
            }
            carrito.Detalles = detalles;
            return carrito;
        }

        public static Carrito ObtenerCarritoSesion(string UsuarioSessionId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UsuarioSessionId", UsuarioSessionId));

            string query = "SELECT Id FROM Carrito WHERE UsuarioSessionId=@UsuarioSessionId";
            DataTable tabla = SqlHelper.Obtener(query, parameters.ToArray());

            if (tabla == null || tabla.Rows.Count == 0)
                return null;

            DataRow fila = tabla.Rows[0];
            Carrito carrito = new Carrito();
            carrito.Id = int.Parse(fila["Id"].ToString());
            return carrito;
        }

        public static bool Existe(string UsuarioSessionId)
        {
            string query = "SELECT COUNT(*) FROM Carrito WHERE UsuarioSessionId = @UsuarioSessionId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UsuarioSessionId", UsuarioSessionId)
            };

            return SqlHelper.ObtenerValor<int>(query, parameters) > 0;
        }

        public static void AgregarDetalle(Carrito carrito)
        {
            string query = string.Empty;
            if (Existe(carrito.UsuarioSessionId))
            {
                Carrito carritoActual = ObtenerCarritoSesion(carrito.UsuarioSessionId);
                carrito.Id = carritoActual.Id;
            }
            else
            {
                query = "INSERT INTO Carrito (FechaCreacion,UsuarioId,UsuarioSessionId) OUTPUT INSERTED.Id" +
                         " VALUES (@FechaCreacion,@UsuarioId,@UsuarioSessionId)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@FechaCreacion", carrito.FechaCreacion),
                    new SqlParameter("@UsuarioId", carrito.Usuario.Id),
                    new SqlParameter("@UsuarioSessionId", carrito.UsuarioSessionId)
                };

                carrito.Id = SqlHelper.Insertar(query, parameters);
            }

            foreach (CarritoDetalle detalle in carrito.Detalles)
            {
                if (detalle.Id == 0)
                {
                    query = "INSERT INTO CarritoDetalle (CarritoId,VehiculoId,Cantidad,Precio)" +
                             " VALUES (@CarritoId,@VehiculoId,@Cantidad,@Precio)";

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                    new SqlParameter("@CarritoId", carrito.Id),
                    new SqlParameter("@VehiculoId", detalle.Vehiculo.Id),
                    new SqlParameter("@Cantidad", detalle.Cantidad),
                    new SqlParameter("@Precio", detalle.Vehiculo.Precio)
                    };

                    SqlHelper.Ejecutar(query, parameters);
                }
            }
        }
        public static void EliminarDetalle(CarritoDetalle detalle)
        {
            string query = "DELETE FROM CarritoDetalle WHERE Id=@Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", detalle.Id)
            };
            SqlHelper.Ejecutar(query, parameters);
        }
    }
}
