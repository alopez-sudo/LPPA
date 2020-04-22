using System.Configuration;
using System.Data.SqlClient;

namespace BuyMotors.DAL
{
    public class BackupMapper
    {
        public static void HacerBackup(string ubicacion)
        {
            string nombreBd = ConfigurationManager.AppSettings.Get("nombreBdPrincipal");
            string query = "BACKUP DATABASE " + nombreBd + " TO DISK = @ubicacion";
            SqlParameter[] parameters =
            {
                new SqlParameter("@ubicacion", ubicacion)
            };
            SqlHelper.Ejecutar(query, parameters);
        }
    }
}
