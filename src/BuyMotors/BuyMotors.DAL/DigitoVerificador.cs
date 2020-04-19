using BuyMotors.BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BuyMotors.DAL
{
    public static class DigitoVerificador
    {
        public static void ActualizarDV(Usuario usuario)
        {
            // Primero el DVH
            int dvh = ObtenerDVH(usuario);

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
            int dvh = ObtenerDVH(factura);

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

        public static bool VerificarIntegridad()
        {
            string query;
            DataTable tabla;
            StringBuilder sbDvhs = new StringBuilder();

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

                    int dvhBD = int.Parse(row["DVH"].ToString());
                    int dvhCalculado = ObtenerDVH(usuario);
                    if (dvhBD != dvhCalculado)
                    {
                        return false;
                    }
                    sbDvhs.Append(dvhBD.ToString());
                }

                // Chequear DVV
                int dvvCalculado = CalcularDV(sbDvhs.ToString());
                query = "SELECT DVV FROM DigitoVerificador WHERE Tabla = 'Usuario'";
                int dvvBD = SqlHelper.ObtenerValor<int>(query, null);

                if (dvvCalculado != dvvBD)
                {
                    return false;
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

                    int dvhBD = int.Parse(row["DVH"].ToString());
                    int dvhCalculado = ObtenerDVH(factura);
                    if (dvhBD != dvhCalculado)
                    {
                        return false;
                    }
                    sbDvhs.Append(dvhBD.ToString());
                }

                // Chequear DVV
                int dvvCalculado = CalcularDV(sbDvhs.ToString());
                query = "SELECT DVV FROM DigitoVerificador WHERE Tabla = 'FacturaCabecera'";
                int dvvBD = SqlHelper.ObtenerValor<int>(query, null);

                if (dvvCalculado != dvvBD)
                {
                    return false;
                }
            }
            #endregion

            return true;
        }

        private static int ObtenerDVH(Usuario usuario)
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

        private static int ObtenerDVH(Factura factura)
        {
            string registro = string.Format("{0}{1}{2}{3}",
                factura.Id,
                factura.Fecha.ToString("ddMMyyyy"),
                factura.Usuario.Id,
                factura.Carrito.Id);
            return CalcularDV(registro);
        }

        private static int CalcularDV(string registro)
        {
            // Aplico el algoritmo de Luhn
            int sum = 0;
            byte[] regBytes = Encoding.UTF8.GetBytes(registro);

            for (int pos = regBytes.Length - 1; pos >= 0; pos--)
            {
                sum += ObtenerDigito(regBytes[pos], pos);
            }

            int d = int.Parse(sum.ToString().Substring(sum.ToString().Length - 1));
            return (d == 0) ? 0 : (10 - d);
        }

        private static void RecalcularDVV(string columnaDVH, string tabla, string columnaOrden)
        {
            string query = string.Format("SELECT {0} FROM {1} ORDER BY {2}", columnaDVH, tabla, columnaOrden);

            StringBuilder sb = new StringBuilder();
            DataTable table = SqlHelper.Obtener(query, new SqlParameter[0]);
            table.Select().ToList().ForEach(r => sb.Append(r[columnaDVH].ToString()));

            int dvv = CalcularDV(sb.ToString());

            query = "UPDATE DigitoVerificador SET DVV = @dvv WHERE Tabla = @tabla";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@dvv", dvv),
                new SqlParameter("@tabla", tabla)
            };
            SqlHelper.Ejecutar(query, parameters);
        }

        private static int ObtenerDigito(byte digito, int pos)
        {
            // Si es par, multiplico el dígito por 2
            if (pos % 2 == 0)
            {
                digito *= 2;
            }

            if (digito >= 10)
            {
                // Tengo que sumar cada dígito
                int resultado = 0;
                string digitoStr = digito.ToString();
                switch (digitoStr.Length)
                {
                    case 2:
                        resultado = int.Parse(digitoStr.Substring(0, 1)) +
                            int.Parse(digitoStr.Substring(1, 1));
                        break;
                    case 3:
                        resultado = int.Parse(digitoStr.Substring(0, 1)) +
                            int.Parse(digitoStr.Substring(1, 1)) +
                            int.Parse(digitoStr.Substring(2, 1));
                        break;
                }

                if (resultado >= 10)
                {
                    resultado = int.Parse(resultado.ToString().Substring(0, 1)) +
                            int.Parse(resultado.ToString().Substring(1, 1));
                }

                return resultado;
            }

            return digito;
        }
    }
}
