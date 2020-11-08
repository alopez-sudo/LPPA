using BuyMotors.BE;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BuyMotors.DAL
{
	public class VehiculoMapper
	{
		public static List<Vehiculo> ObtenerVehiculos()
		{
			string filtroSql = "";

			List<SqlParameter> parameters = null;

			string query = "SELECT v.Id,v.Patente,v.ColorId,c.Nombre AS Color,v.ModeloId,m.Nombre AS Modelo,m.MarcaId,ma.Nombre AS Marca,v.Precio,v.AnioFabricacion,v.TipoVehiculoId,t.Nombre AS Tipo,v.CategoriaVehiculoId,ca.Nombre AS Categoria" +
							" FROM Vehiculo v INNER JOIN Color c ON c.Id=v.ColorId" +
							" INNER JOIN CategoriaVehiculo ca ON ca.Id=v.CategoriaVehiculoId" +
							" INNER JOIN TipoVehiculo t ON t.Id=v.TipoVehiculoId" +
							" INNER JOIN Modelo m ON m.Id=v.ModeloId" +
							" INNER JOIN Marca ma ON ma.Id=m.MarcaId" +
							" WHERE v.Disponible = 1" + filtroSql +
							" ORDER BY v.Id";
			DataTable tabla = SqlHelper.Obtener(query, parameters == null ? null : parameters.ToArray());

			if (tabla == null || tabla.Rows.Count == 0)
            {
                return null;
            }

            List<Vehiculo> lista = new List<Vehiculo>();
			foreach(DataRow fila in tabla.Rows)
			{
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
				lista.Add(vehiculo);
			}

			return lista;
		}

		public static Vehiculo ObtenerVehiculo(int Id)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			string filtroSql = " v.Disponible = 1 AND v.Id=@Id";
			parameters.Add(new SqlParameter("@Id", Id));

			string query = "SELECT v.Id,v.Patente,v.ColorId,c.Nombre AS Color,v.ModeloId,m.Nombre AS Modelo,m.MarcaId,ma.Nombre AS Marca,v.Precio,v.AnioFabricacion,v.TipoVehiculoId,t.Nombre AS Tipo,v.CategoriaVehiculoId,ca.Nombre AS Categoria,v.ImagenNombre" +
							" FROM Vehiculo v INNER JOIN Color c ON c.Id=v.ColorId" +
							" INNER JOIN CategoriaVehiculo ca ON ca.Id=v.CategoriaVehiculoId" +
							" INNER JOIN TipoVehiculo t ON t.Id=v.TipoVehiculoId" +
							" INNER JOIN Modelo m ON m.Id=v.ModeloId" +
							" INNER JOIN Marca ma ON ma.Id=m.MarcaId" +
							" WHERE " + filtroSql +
							" ORDER BY v.Id";
			DataTable tabla = SqlHelper.Obtener(query, parameters.ToArray());

			if(tabla == null || tabla.Rows.Count == 0)
				return null;

			DataRow fila = tabla.Rows[0];
			Vehiculo vehiculo = new Vehiculo();
			vehiculo.Id = int.Parse(fila["Id"].ToString());
			vehiculo.Patente = fila["Patente"].ToString();
			vehiculo.AnioFabricacion = int.Parse(fila["AnioFabricacion"].ToString());
			vehiculo.Precio = int.Parse(fila["Precio"].ToString());
			vehiculo.ImagenNombre = fila["ImagenNombre"].ToString();
			Color color = new Color();
			color.Id = int.Parse(fila["ColorId"].ToString());
			color.Nombre = fila["Color"].ToString();
			vehiculo.Color = color;
			Marca marca = new Marca();
			marca.Id = int.Parse(fila["ModeloId"].ToString());
			marca.Nombre = fila["Marca"].ToString();
			Modelo modelo = new Modelo();
			modelo.Id = int.Parse(fila["ModeloId"].ToString());
			modelo.Nombre = fila["Modelo"].ToString();
			modelo.Marca = marca;
			vehiculo.Modelo = modelo;
			CategoriaVehiculo categoriaVehiculo = new CategoriaVehiculo();
			categoriaVehiculo.Id = int.Parse(fila["CategoriaVehiculoId"].ToString());
			categoriaVehiculo.Nombre = fila["Categoria"].ToString();
			vehiculo.Categoria = categoriaVehiculo;
			TipoVehiculo tipoVehiculo = new TipoVehiculo();
			tipoVehiculo.Id = int.Parse(fila["TipoVehiculoId"].ToString());
			tipoVehiculo.Nombre = fila["Tipo"].ToString();
			vehiculo.Tipo = tipoVehiculo;

			return vehiculo;
		}

		public static bool EstaDisponible(Vehiculo vehiculo)
        {
			string query = "SELECT Id FROM Vehiculo WHERE Id = @id AND Disponible = 1";
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@id", vehiculo.Id)
			};

			return SqlHelper.ObtenerValor<int>(query, parameters) > 0;
        }

		public static void MarcarNoDisponible(Vehiculo vehiculo)
        {
			string query = "UPDATE Vehiculo SET Disponible = 0 WHERE Id = @id";
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@id", vehiculo.Id)
			};

			SqlHelper.Ejecutar(query, parameters);
		}
	}
}
