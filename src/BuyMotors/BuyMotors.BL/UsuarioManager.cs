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
                Usuario usuario = UsuarioDAL.Obtener(email, Encriptador.Encriptar(contrasenia));
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
            return usuario.Rol.Permisos.Any(p => p.Nombre == permiso);
        }
    }
}
