using BuyMotors.BE;
using BuyMotors.DAL;
using System;
using System.Collections.Generic;

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

        public static bool Guardar(Usuario usuario, out string mensaje)
        {
            try
            {
                if (UsuarioMapper.Existe(usuario.Email))
                {
                    mensaje = "Ya existe un usuario registrado con ese correo electrónico";
                    return false;
                }

                usuario.Contrasenia = Encriptador.Encriptar(usuario.Contrasenia);
                Permiso perfilUsuarioBasico = PermisoManager.Obtener(Familias.USUARIO_BASICO);
                usuario.Permisos.Add(perfilUsuarioBasico);
                bool guardadoOk = UsuarioMapper.Guardar(usuario);
                mensaje = guardadoOk ? "Usuario guardado correctamente" : "Ocurrió un error al guardar el usuario";

                return guardadoOk;
            }
            catch
            {
                mensaje = "Ocurrió un error al guardar el usuario";
                return false;
            }
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
                    bool tienePermiso = ChequearPermiso(permiso.DevolverPerfil(), permisoAChequear);
                    if (tienePermiso)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
