using BuyMotors.BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BuyMotors.DAL
{
    public static class DigitoVerificador
    {
        private const string DV_KEY = "Hl2NspLLkg";

        public static void ActualizarDV(Usuario usuario)
        {
            // Primero el DVH
            string dvh = ObtenerDVH(usuario);

            string query = "UPDATE Usuario SET DVH = @dvh WHERE Id = @id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@dvh", dvh),
                new SqlParameter("@id", usuario.Id)
            };
            SqlHelper.Ejecutar(query, parameters);

            // Ahora el DVV
            RecalcularDVV("DVH", "Usuario", "Id");
        }

        public static void ActualizarDV(Factura factura)
        {
            // Primero el DVH
            string dvh = ObtenerDVH(factura);

            string query = "UPDATE FacturaCabecera SET DVH = @dvh WHERE Id = @id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@dvh", dvh),
                new SqlParameter("@id", factura.Id)
            };
            SqlHelper.Ejecutar(query, parameters);

            // Ahora el DVV
            RecalcularDVV("DVH", "FacturaCabecera", "Id");
        }

        public static bool VerificarIntegridad(List<string> mensajes)
        {
            string query;
            DataTable tabla;
            StringBuilder sbDvhs = new StringBuilder();
            bool sinErrores = true;

            #region Usuario
            query = "SELECT Id, Nombre, Apellido, Telefono, Email, Password, DVH FROM Usuario ORDER BY Id";
            tabla = SqlHelper.Obtener(query, null);
            if (tabla != null)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    Usuario usuario = new Usuario
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Nombre = row["Nombre"].ToString(),
                        Apellido = row["Apellido"].ToString(),
                        Telefono = row["Telefono"].ToString(),
                        Email = row["Email"].ToString(),
                        Contrasenia = row["Password"].ToString()
                    };

                    string dvhBD = row["DVH"].ToString();
                    string dvhCalculado = ObtenerDVH(usuario);
                    if (dvhBD != dvhCalculado)
                    {
                        mensajes.Add(string.Format("El usuario con el ID {0} fue modificado externamente.", usuario.Id));
                        sinErrores = false;
                    }
                    sbDvhs.Append(dvhBD.ToString());
                }

                // Chequear DVV
                string dvvCalculado = CalcularDV(sbDvhs.ToString());
                query = "SELECT DVV FROM DigitoVerificador WHERE Tabla = 'Usuario'";
                string dvvBD = SqlHelper.ObtenerValor<string>(query, null);

                if (dvvCalculado != dvvBD)
                {
                    mensajes.Add("Un registro de la tabla Usuario fue eliminado externamente.");
                    sinErrores = false;
                }
            }
            #endregion

            #region Factura
            query = "SELECT Id, FechaCreacion, UsuarioId, CarritoId, DVH FROM FacturaCabecera ORDER BY Id";
            tabla = SqlHelper.Obtener(query, null);
            sbDvhs.Clear();
            if (tabla != null)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    Factura factura = new Factura()
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Fecha = DateTime.Parse(row["FechaCreacion"].ToString()),
                        Usuario = new Usuario
                        {
                            Id = int.Parse(row["UsuarioId"].ToString())
                        },
                        Carrito = new Carrito
                        {
                            Id = int.Parse(row["CarritoId"].ToString())
                        }
                    };

                    string dvhBD = row["DVH"].ToString();
                    string dvhCalculado = ObtenerDVH(factura);
                    if (dvhBD != dvhCalculado)
                    {
                        mensajes.Add(string.Format("La factura con el ID {0} fue modificada externamente.", factura.Id));
                        sinErrores = false;
                    }
                    sbDvhs.Append(dvhBD.ToString());
                }

                // Chequear DVV
                string dvvCalculado = CalcularDV(sbDvhs.ToString());
                query = "SELECT DVV FROM DigitoVerificador WHERE Tabla = 'FacturaCabecera'";
                string dvvBD = SqlHelper.ObtenerValor<string>(query, null);

                if (dvvCalculado != dvvBD)
                {
                    mensajes.Add("Un registro de la tabla Factura fue eliminado externamente.");
                    sinErrores = false;
                }
            }
            #endregion

            return sinErrores;
        }

        private static string ObtenerDVH(Usuario usuario)
        {
            string registro = string.Format("{0}{1}{2}{3}{4}{5}",
                usuario.Id,
                usuario.Nombre,
                usuario.Apellido,
                usuario.Telefono,
                usuario.Email,
                usuario.Contrasenia);
            return CalcularDV(registro);
        }

        private static string ObtenerDVH(Factura factura)
        {
            string registro = string.Format("{0}{1}{2}{3}",
                factura.Id,
                factura.Fecha.ToString("ddMMyyyy"),
                factura.Usuario.Id,
                factura.Carrito.Id);
            return CalcularDV(registro);
        }

        private static string CalcularDV(string registro)
        {
            byte[] data = Encoding.ASCII.GetBytes(registro + DV_KEY);
            data = new SHA256Managed().ComputeHash(data);
            return Convert.ToBase64String(data);
        }

        private static void RecalcularDVV(string columnaDVH, string tabla, string columnaOrden)
        {
            string query = string.Format("SELECT {0} FROM {1} ORDER BY {2}", columnaDVH, tabla, columnaOrden);

            StringBuilder sb = new StringBuilder();
            DataTable table = SqlHelper.Obtener(query, new SqlParameter[0]);
            table.Select().ToList().ForEach(r => sb.Append(r[columnaDVH].ToString()));

            string dvv = CalcularDV(sb.ToString());

            query = "UPDATE DigitoVerificador SET DVV = @dvv WHERE Tabla = @tabla";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@dvv", dvv),
                new SqlParameter("@tabla", tabla)
            };
            SqlHelper.Ejecutar(query, parameters);
        }
    }
}
