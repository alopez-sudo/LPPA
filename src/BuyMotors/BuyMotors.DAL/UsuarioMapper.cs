using BuyMotors.BE;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BuyMotors.DAL
{
    public class UsuarioMapper
    {
        public static Usuario Obtener(string email, string contrasenia)
        {
            string query = "SELECT TOP 1 Id, Nombre, Apellido, Telefono FROM Usuario " +
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
                    Permisos = PermisoMapper.ObtenerPorUsuario(id)
                };
            }

            return null;
        }

        public static bool Existe(string email)
        {
            string query = "SELECT COUNT(*) FROM Usuario WHERE Email = @email";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@email", email)
            };

            try
            {
                int conteo = SqlHelper.ObtenerValor<int>(query, parameters);
                return conteo > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Guardar(Usuario usuario)
        {
            if (usuario.Id > 0)
            {
                return Actualizar(usuario);
            }
            else
            {
                return Insertar(usuario);
            }
        }

        private static bool Insertar(Usuario usuario)
        {
            string query = "INSERT INTO Usuario (Nombre, Apellido, Telefono, Email, Password) OUTPUT INSERTED.Id " +
                "VALUES (@nombre, @apellido, @telefono, @email, @password)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@nombre", usuario.Nombre),
                new SqlParameter("@apellido", usuario.Apellido),
                new SqlParameter("@telefono", usuario.Telefono),
                new SqlParameter("@email", usuario.Email),
                new SqlParameter("@password", usuario.Contrasenia)
            };

            usuario.Id = SqlHelper.Insertar(query, parameters);
            if (usuario.Id == 0)
            {
                return false;
            }

            // Ahora inserto los permisos
            foreach (Permiso permiso in usuario.Permisos)
            {
                query = "INSERT INTO UsuarioPermiso (UsuarioId, PermisoId) VALUES (@usuarioId, @permisoId)";
                SqlParameter[] parametersPermisos = new SqlParameter[]
                {
                    new SqlParameter("@usuarioId", usuario.Id),
                    new SqlParameter("@permisoId", permiso.Id)
                };

                try
                {
                    SqlHelper.Ejecutar(query, parametersPermisos);
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        private static bool Actualizar(Usuario usuario)
        {
            // TODO: Esto se hará cuando haga falta
            return false;
        }
    }
}
