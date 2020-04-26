using BuyMotors.BE;
using BuyMotors.BE.Filtros;
using BuyMotors.DAL;
using System;
using System.Collections.Generic;

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

        public static List<Bitacora> ObtenerBitacoras(FiltroBitacora filtro)
        {
            return BitacoraMapper.Obtener(filtro);
        }
    }
}
