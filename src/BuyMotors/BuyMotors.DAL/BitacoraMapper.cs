using BuyMotors.BE;
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
    }
}
