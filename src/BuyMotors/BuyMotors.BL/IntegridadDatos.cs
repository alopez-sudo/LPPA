using BuyMotors.DAL;
using System.Collections.Generic;

namespace BuyMotors.BL
{
    public static class IntegridadDatos
    {
        public static bool Chequear(List<string> mensajesDeError)
        {
            return DigitoVerificador.VerificarIntegridad(mensajesDeError);
        }
    }
}
