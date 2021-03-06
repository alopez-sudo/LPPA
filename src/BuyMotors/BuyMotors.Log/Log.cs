﻿using System;
using System.Configuration;
using System.IO;

namespace BuyMotors.Log
{
    public static class Log
    {
        private const string ARCHIVO_LOG = "BuyMotors.log";

        public static void Grabar(Exception ex)
        {
            string ubicacionLog = ConfigurationManager.AppSettings.Get("ubicacionLog");
            if (!Directory.Exists(ubicacionLog))
            {
                Directory.CreateDirectory(ubicacionLog);
            }

            using (StreamWriter writer = new StreamWriter(ubicacionLog + ARCHIVO_LOG, true))
            {
                writer.WriteLine("Fecha: " + DateTime.Now.ToString() + Environment.NewLine +
                    "Mensaje: " + ex.Message + Environment.NewLine +
                    "Stack trace: " + ex.StackTrace);
                writer.WriteLine(Environment.NewLine + "--------------------------------------------------" + Environment.NewLine);
            }
        }
    }
}
