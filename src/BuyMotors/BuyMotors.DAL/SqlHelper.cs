using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;

namespace BuyMotors.DAL
{
    class SqlHelper
    {
        private const string CONN_STRING_KEY = "Principal";

        public static DataTable Obtener(string query, SqlParameter[] parameters)
        {
            string connString = ConfigurationManager.ConnectionStrings[CONN_STRING_KEY].ConnectionString;
            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = new SqlConnection
                    {
                        ConnectionString = connString
                    },
                    CommandText = query,
                    CommandType = CommandType.Text,
                };
                if(parameters != null && parameters.Count() > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                DataSet ds = new DataSet();
                cmd.Connection.Open();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                {
                    dataAdapter.SelectCommand = cmd;
                    dataAdapter.Fill(ds);
                }
                cmd.Connection.Close();

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                Log.Log.Grabar(ex);
                return null;
            }
        }

        public static T ObtenerValor<T>(string query, SqlParameter[] parameters)
        {
            string connString = ConfigurationManager.ConnectionStrings[CONN_STRING_KEY].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddRange(parameters);
                    command.Connection.Open();
                    object value = command.ExecuteScalar();
                    T valor = value is DBNull || value == null ? default : (T)Convert.ChangeType(value, typeof(T));
                    command.Connection.Close();
                    return valor;
                }
            }
            catch (Exception ex)
            {
                Log.Log.Grabar(ex);
                throw ex;
            }
        }

        public static void Ejecutar(string query, SqlParameter[] parameters)
        {
            string connString = ConfigurationManager.ConnectionStrings[CONN_STRING_KEY].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddRange(parameters);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                Log.Log.Grabar(ex);
                throw ex;
            }
        }

        public static int Insertar(string query, SqlParameter[] parameters)
        {
            string connString = ConfigurationManager.ConnectionStrings[CONN_STRING_KEY].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddRange(parameters);
                    command.Connection.Open();
                    int idInsertado = (int)command.ExecuteScalar();
                    command.Connection.Close();
                    return idInsertado;
                }
            }
            catch (Exception ex)
            {
                Log.Log.Grabar(ex);
                return 0;
            }
        }
    }
}
