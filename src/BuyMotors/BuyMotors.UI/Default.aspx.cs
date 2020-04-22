using BuyMotors.BE;
using BuyMotors.BL;
using System;
using System.Web.UI;

namespace BuyMotors
{
    public partial class _Default : Page
    {
        protected bool mostrarBotonBackup = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuarioLogueado = Session["UsuarioLogueado"] == null ? null : (Usuario)Session["UsuarioLogueado"];
            mostrarBotonBackup = usuarioLogueado != null && UsuarioManager.TienePermiso(usuarioLogueado, Permisos.BACKUPS);
        }
    }
}