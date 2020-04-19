using BuyMotors.DAL;

namespace BuyMotors.BL
{
    public static class IntegridadDatos
    {
        public static bool Chequear()
        {
            return DigitoVerificador.VerificarIntegridad();
        }
    }
}
