using BuyMotors.BE;
using BuyMotors.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace BuyMotors.BL
{
    public class BackupManager
    {
        private const string DATE_FORMAT_FOR_FILE = "yyyy_MM_dd_HH_mm_ss";

        public static bool HacerBackup(List<string> mensajesDeError)
        {
            // Primero debo chequear la integridad de la BD
            if (DigitoVerificador.VerificarIntegridad(mensajesDeError))
            {
                try
                {
                    string rutaBackup = ConfigurationManager.AppSettings.Get("ubicacionBackups");
                    Directory.CreateDirectory(rutaBackup); // Si la carpeta no existe, la crea

                    string nombreArchivo = DateTime.Now.ToString(DATE_FORMAT_FOR_FILE);
                    BackupMapper.HacerBackup(rutaBackup + nombreArchivo + ".bak");
                    return true;
                }
                catch (Exception ex)
                {
                    Log.Log.Grabar(ex);
                }
            }

            mensajesDeError.Add("No se puede hacer un backup porque la base de datos no está íntegra.");
            return false;
        }

        public static List<Backup> ObtenerBackups()
        {
            try
            {
                string rutaBackups = ConfigurationManager.AppSettings.Get("ubicacionBackups");
                string[] archivos = Directory.GetFiles(rutaBackups, "*.bak");

                List<Backup> backups = new List<Backup>();
                for (int i = 0; i < archivos.Length; i++)
                {
                    string nombreArchivo = Path.GetFileNameWithoutExtension(archivos[i]);
                    if (DateTime.TryParseExact(nombreArchivo, DATE_FORMAT_FOR_FILE, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaBackup))
                    {
                        backups.Add(new Backup
                        {
                            Fecha = fechaBackup,
                            NombreArchivo = nombreArchivo
                        });
                    }
                }

                return backups;
            }
            catch (Exception ex)
            {
                Log.Log.Grabar(ex);
                return new List<Backup>();
            }
        }

        public static bool RestaurarBackup(string nombreArchivo)
        {
            try
            {
                string rutaBackups = ConfigurationManager.AppSettings.Get("ubicacionBackups");
                string rutaCompletaBackup = rutaBackups + nombreArchivo + ".bak";
                if (File.Exists(rutaCompletaBackup))
                {
                    BackupMapper.RestaurarBackup(rutaCompletaBackup);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Log.Grabar(ex);
            }

            return false;
        }
    }
}
