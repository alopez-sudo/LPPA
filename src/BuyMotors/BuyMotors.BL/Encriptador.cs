using System;
using System.Text;
using System.Security.Cryptography;
using BuyMotors.Log;

namespace BL
{
    public static class Encriptador
    {
        private const string _salt = "b5N3pWkRwzJH";

        public static string Encriptar(string texto)
        {
            try
            {
                byte[] data = Encoding.ASCII.GetBytes(texto + _salt);
                data = new SHA256Managed().ComputeHash(data);
                return Convert.ToBase64String(data);
            }
            catch (Exception ex)
            {
                Log.Grabar(ex);
                return "";
            }
        }
    }
}
