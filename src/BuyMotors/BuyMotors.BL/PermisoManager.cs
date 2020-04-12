using BuyMotors.BE;
using BuyMotors.DAL;

namespace BuyMotors.BL
{
    public class PermisoManager
    {
        public static Permiso Obtener(string nombre)
        {
            return PermisoMapper.ObtenerPorNombre(nombre);
        }
    }
}
