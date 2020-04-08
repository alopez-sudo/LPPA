using BuyMotors.BE;
using System.Data;
using System.Data.SqlClient;

namespace BuyMotors.DAL
{
    public class UsuarioDAL
    {
        public static Usuario Obtener(string email, string contrasenia)
        {
            string query = "SELECT TOP 1 Id, Nombre, Apellido, Telefono, RolId FROM Usuario " +
                "WHERE Email = @email AND Password = @contrasenia";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@email", email),
                new SqlParameter("@contrasenia", contrasenia)
            };

            DataTable table = SqlHelper.Obtener(query, parameters);
            if (table != null && table.Rows.Count > 0)
            {
                int id = int.Parse(table.Rows[0]["id"].ToString());
                return new Usuario
                {
                    Id = id,
                    Nombre = table.Rows[0]["Nombre"].ToString(),
                    Apellido = table.Rows[0]["Apellido"].ToString(),
                    Telefono = table.Rows[0]["Telefono"].ToString(),
                    Email = email,
                    Rol = RolDAL.Obtener(int.Parse(table.Rows[0]["RolId"].ToString()))
                };
            }

            return null;
        }
    }
}
