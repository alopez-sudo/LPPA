using BuyMotors.BE;
using System.Data;
using System.Data.SqlClient;

namespace BuyMotors.DAL
{
    public class RolDAL
    {
        public static Rol Obtener(int id)
        {
            string query = "SELECT Nombre FROM Rol WHERE Id = @id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };

            DataTable table = SqlHelper.Obtener(query, parameters);
            if (table.Rows.Count > 0)
            {
                return new Rol
                {
                    Id = id,
                    Nombre = table.Rows[0]["Nombre"].ToString(),
                    Permisos = PermisoDAL.ObtenerPorRol(id)
                };
            }

            return null;
        }
    }
}
