using BuyMotors.BE;
using BuyMotors.DAL;
using System;

namespace BuyMotors.BL
{
    public class BitacoraManager
    {
        public static void Grabar(Usuario usuario, string mensaje)
        {
            Bitacora bitacora = new Bitacora
            {
                Fecha = DateTime.Now,
                Usuario = usuario?.Email,
                Detalle = mensaje
            };
            BitacoraMapper.Guardar(bitacora);
        }
    }
}
