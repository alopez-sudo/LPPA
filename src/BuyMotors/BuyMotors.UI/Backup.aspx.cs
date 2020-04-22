using BuyMotors.BE;
using BuyMotors.BL;
using System;
using System.Web.UI;

namespace BuyMotors.UI
{
    public partial class Backup : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuarioLogueado = Session["UsuarioLogueado"] == null ? null : (Usuario)Session["UsuarioLogueado"];
            if (usuarioLogueado == null || !UsuarioManager.TienePermiso(usuarioLogueado, Permisos.BACKUPS))
            {
                Response.Redirect("Default.aspx");
            }

            CargarGvBackups();
        }

        protected void BtnBackup_Click(object sender, EventArgs e)
        {
            if (BackupManager.HacerBackup())
            {
                Response.Redirect("Backup.aspx");
            }
            else
            {
                FailureText.Text = "Ocurrió un error al realizar el backup";
                ErrorMessage.Visible = true;
            }
        }

        private void CargarGvBackups()
        {
            gvBackups.DataSource = BackupManager.ObtenerBackups();
            gvBackups.DataBind();
        }
    }
}