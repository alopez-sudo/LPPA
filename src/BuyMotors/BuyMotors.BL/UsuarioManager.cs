using BuyMotors.BE;
using BuyMotors.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMotors.BL
{
    public class UsuarioManager
    {
        public static Usuario Login(string email, string contrasenia)
        {
            try
            {
                Usuario usuario = UsuarioMapper.Obtener(email, Encriptador.Encriptar(contrasenia));
                if (usuario != null && TienePermiso(usuario, Permisos.LOGIN))
                {
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                Log.Log.Grabar(ex);
            }

            return null;
        }

        public static bool TienePermiso(Usuario usuario, string permiso)
        {
            return ChequearPermiso(usuario.Permisos, permiso);
        }

        private static bool ChequearPermiso(List<Permiso> permisos, string permisoAChequear)
        {
            foreach (Permiso permiso in permisos)
            {
                if (permiso.Nombre == permisoAChequear)
                {
                    return true;
                }
                else
                {
                    return ChequearPermiso(permiso.DevolverPerfil(), permisoAChequear);
                }
            }

            return false;
        }
    }
}
