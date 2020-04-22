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

        public static void RestaurarBackup(string ubicacion)
        {
            string nombreBd = ConfigurationManager.AppSettings.Get("nombreBdPrincipal");
            string query = "ALTER DATABASE " + nombreBd + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE; " +
                "RESTORE DATABASE " + nombreBd + " FROM DISK = @ubicacion WITH REPLACE; " +
                "ALTER DATABASE " + nombreBd + " SET MULTI_USER;"; ;
            SqlParameter[] parameters =
            {
                new SqlParameter("@ubicacion", ubicacion)
            };
            SqlHelper.EjecutarEnMaster(query, parameters);
        }
    }
}
