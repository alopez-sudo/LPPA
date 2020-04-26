using BuyMotors.BE;
using BuyMotors.BE.Filtros;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BuyMotors.DAL
{
    public class BitacoraMapper
    {
        public static void Guardar(Bitacora bitacora)
        {
            string query = "INSERT INTO Bitacora (Fecha, Usuario, Detalle) OUTPUT INSERTED.Id " +
                "VALUES (@fecha, @usuario, @detalle)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@fecha", bitacora.Fecha),
                new SqlParameter("@usuario", bitacora.Usuario),
                new SqlParameter("@detalle", bitacora.Detalle)
            };

            bitacora.Id = SqlHelper.InsertarBitacora(query, parameters);
        }

        public static List<Bitacora> Obtener(FiltroBitacora filtro)
        {
            string query = "SELECT Id, Fecha, Usuario, Detalle FROM Bitacora WHERE 1 = 1";
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (filtro.FechaDesde.HasValue)
            {
                query += " AND Fecha >= @fechaDesde";
                parameters.Add(new SqlParameter("@fechaDesde", filtro.FechaDesde));
            }

            if (filtro.FechaHasta.HasValue)
            {
                query += " AND Fecha < @fechaHasta";
                parameters.Add(new SqlParameter("@fechaHasta", filtro.FechaHasta.Value.AddDays(1)));
            }

            if (!string.IsNullOrEmpty(filtro.Usuario))
            {
                query += " AND Usuario = @usuario";
                parameters.Add(new SqlParameter("@usuario", filtro.Usuario));
            }

            query += " ORDER BY Fecha DESC";

            List<Bitacora> bitacoras = new List<Bitacora>();
            DataTable table = SqlHelper.ObtenerBitacora(query, parameters.ToArray());
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    bitacoras.Add(new Bitacora
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Fecha = DateTime.Parse(row["Fecha"].ToString()),
                        Usuario = row["Usuario"].ToString(),
                        Detalle = row["Detalle"].ToString()
                    });
                }
            }

            return bitacoras;
        }
    }
}
