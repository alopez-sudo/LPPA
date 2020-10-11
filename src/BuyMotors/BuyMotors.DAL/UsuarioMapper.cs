using BuyMotors.BE;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BuyMotors.DAL
{
    public class UsuarioMapper
    {
        public static Usuario Obtener(int id)
        {
            string query = "SELECT Nombre, Apellido, Telefono, Email FROM Usuario WHERE Id = @id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };

            DataTable table = SqlHelper.Obtener(query, parameters);
            if (table != null && table.Rows.Count > 0)
            {
                Usuario usuario = new Usuario
                {
                    Id = id,
                    Nombre = table.Rows[0]["Nombre"].ToString(),
                    Apellido = table.Rows[0]["Apellido"].ToString(),
                    Telefono = table.Rows[0]["Telefono"].ToString(),
                    Email = table.Rows[0]["Email"].ToString(),
                };

                return usuario;
            }

            return null;
        }

        public static Usuario Obtener(string email)
        {
            string query = "SELECT TOP 1 Id, Nombre, Apellido, Telefono, Password, IntentosLogin FROM Usuario " +
                "WHERE Email = @email";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@email", email)
            };

            DataTable table = SqlHelper.Obtener(query, parameters);
            if (table != null && table.Rows.Count > 0)
            {
                int id = int.Parse(table.Rows[0]["Id"].ToString());
                if (DigitoVerificador.VerificarUsuario(id))
                {
                    return new Usuario
                    {
                        Id = id,
                        Nombre = table.Rows[0]["Nombre"].ToString(),
                        Apellido = table.Rows[0]["Apellido"].ToString(),
                        Telefono = table.Rows[0]["Telefono"].ToString(),
                        Email = email,
                        Contrasenia = table.Rows[0]["Password"].ToString(),
                        IntentosLogin = int.Parse(table.Rows[0]["IntentosLogin"].ToString()),
                        Permisos = PermisoMapper.ObtenerPorUsuario(id)
                    };
                }
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
            string query = "INSERT INTO Usuario (Nombre, Apellido, Telefono, Email, Password, DVH) OUTPUT INSERTED.Id " +
                "VALUES (@nombre, @apellido, @telefono, @email, @password, 0)";
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

            DigitoVerificador.ActualizarDV(usuario);

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
            // Ninguna actualización puede ocurrir si previamente el usuario no está íntegro
            if (!DigitoVerificador.VerificarUsuario(usuario.Id))
            {
                return false;
            }

            string query = "UPDATE Usuario set IntentosLogin = @intentosLogin WHERE Id = @id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@intentosLogin", usuario.IntentosLogin),
                new SqlParameter("@id", usuario.Id)
            };

            try
            {
                SqlHelper.Ejecutar(query, parameters);
                DigitoVerificador.ActualizarDV(usuario);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
