using BuyMotors.BE;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BuyMotors.DAL
{
    public class PermisoDAL
    {
        public static List<Permiso> ObtenerPorRol(int rolId)
        {
            string query = "SELECT p.Id, p.Nombre FROM Permiso p INNER JOIN RolPermiso rp ON p.Id = rp.PermisoId " +
                "WHERE rp.RolId = @rolId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@rolId", rolId)
            };

            DataTable table = SqlHelper.Obtener(query, parameters);
            List<Permiso> permisos = new List<Permiso>();
            foreach (DataRow row in table.Rows)
            {
                permisos.Add(new Permiso
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Nombre = row["Nombre"].ToString()
                });
            }

            return permisos;
        }
    }
}
