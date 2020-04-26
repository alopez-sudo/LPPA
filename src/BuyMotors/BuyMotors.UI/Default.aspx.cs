using BuyMotors.BL;
using BuyMotors.UI;
using System;

namespace BuyMotors
{
    public partial class _Default : BasePage
    {
        protected bool mostrarBotonBackup = false;
        protected bool mostrarBotonBitacora = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarBotonBackup = UsuarioLogueado != null && UsuarioManager.TienePermiso(UsuarioLogueado, Permisos.BACKUPS);
            mostrarBotonBitacora = UsuarioLogueado != null && UsuarioManager.TienePermiso(UsuarioLogueado, Permisos.BITACORA);
        }
    }
}