using BuyMotors.BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMotors.DAL
{
	public class VehiculoMapper
	{
		public static IEnumerable<Vehiculo> ObtenerVehiculos(FiltroVehiculo filtro)
		{
			string filtroSql = "";

			List<SqlParameter> parameters = null;

			if(filtro != null)
			{
				parameters = new List<SqlParameter>();
				if(!string.IsNullOrEmpty(filtro.Patente))
				{
					filtroSql += " AND v.Patente LIKE @Patente";
					parameters.Add(new SqlParameter("@Patente", string.Format("%{0}%", filtro.Patente)));
				}
				if(filtro.PrecioDesde.HasValue)
				{
					filtroSql += " AND v.Precio >= @PrecioDesde";
					parameters.Add(new SqlParameter("@PrecioDesde", filtro.PrecioDesde.Value));
				}
				if(filtro.PrecioHasta.HasValue)
				{
					filtroSql += " AND v.Precio <= @PrecioHasta";
					parameters.Add(new SqlParameter("@PrecioHasta", filtro.PrecioHasta.Value));
				}
			}

			string query = "SELECT v.Id,v.Patente,v.ColorId,c.Nombre AS Color,v.ModeloId,m.Nombre AS Modelo,m.MarcaId,ma.Nombre AS Marca,v.Precio,v.AnioFabricacion,v.TipoVehiculoId,t.Nombre AS Tipo,v.CategoriaVehiculoId,ca.Nombre AS Categoria" +
							" FROM Vehiculo v INNER JOIN Color c ON c.Id=v.ColorId" +
							" INNER JOIN CategoriaVehiculo ca ON ca.Id=v.CategoriaVehiculoId" +
							" INNER JOIN TipoVehiculo t ON t.Id=v.TipoVehiculoId" +
							" INNER JOIN Modelo m ON m.Id=v.ModeloId" +
							" INNER JOIN Marca ma ON ma.Id=m.MarcaId" +
							" WHERE 1=1" + filtroSql +
							" ORDER BY v.Id";
			DataTable tabla = SqlHelper.Obtener(query, parameters == null ? null : parameters.ToArray());

			if(tabla == null || tabla.Rows.Count == 0)
				return null;

			List<Vehiculo> lista = new List<Vehiculo>();
			foreach(DataRow fila in tabla.Rows)
			{
				Vehiculo vehiculo = new Vehiculo();
				vehiculo.Id = int.Parse(fila["Id"].ToString());
				vehiculo.Patente = fila["Patente"].ToString();
				vehiculo.AnioFabricacion = int.Parse(fila["AnioFabricacion"].ToString());
				vehiculo.Precio = int.Parse(fila["Precio"].ToString());
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
				lista.Add(vehiculo);
			}

			return lista;
		}
	}
}
