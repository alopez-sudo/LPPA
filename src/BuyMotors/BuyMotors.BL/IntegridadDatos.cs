using BuyMotors.DAL;

namespace BuyMotors.BL
{
    public static class IntegridadDatos
    {
        public static bool Chequear(out string mensaje)
        {
            return DigitoVerificador.VerificarIntegridad(out mensaje);
        }
    }
}
