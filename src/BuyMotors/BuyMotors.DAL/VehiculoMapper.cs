using BuyMotors.BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMotors.DAL
{
	public class VehiculoMapper
	{
		public static IEnumerable<Vehiculo> ObtenerVehiculos()
		{
			string query = "SELECT v.Id,v.Patente,v.ColorId,c.Nombre AS Color,v.ModeloId,m.Nombre AS Modelo,m.MarcaId,ma.Nombre AS Marca,v.Precio,v.AnioFabricacion,v.CategoriaVehiculoId,ca.Nombre AS Categoria" +
							" FROM Vehiculo v INNER JOIN Color c ON c.Id=v.ColorId" +
							" INNER JOIN CategoriaVehiculo ca ON ca.Id=v.CategoriaVehiculoId" +
							" INNER JOIN Modelo m ON m.Id=v.ModeloId" +
							" INNER JOIN Marca ma ON ma.Id=m.MarcaId" +
							" ORDER BY Patente";
			DataTable tabla = SqlHelper.Obtener(query, null, SqlHelper.Bd.Principal);

			if(tabla == null || tabla.Rows.Count == 0)
				return null;

			IEnumerable<Vehiculo> lista = new List<Vehiculo>();
			foreach(DataRow fila in tabla.Rows)
			{
				Vehiculo vehiculo = new Vehiculo();
				vehiculo.Id = int.Parse(fila["Id"].ToString());
				vehiculo.Patente = fila["Patente"].ToString();
			}

			return lista;
		}
	}
}
