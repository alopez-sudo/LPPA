using BuyMotors.BE;
using BuyMotors.BL;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            if (BackupManager.HacerBackup(out string mensajeError))
            {
                Response.Redirect("Backup.aspx");
            }
            else
            {
                FailureText.Text = string.IsNullOrEmpty(mensajeError) ? "Ocurrió un error al realizar el backup" : mensajeError;
                ErrorMessage.Visible = true;
            }
        }

        protected void BtnRestaurar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string nombreArchivo = btn.CommandArgument;
            if (BackupManager.RestaurarBackup(nombreArchivo))
            {
                SuccessText.Text = "Backup restaurado satisfactoriamente";
                SuccessMessage.Visible = true;
            }
            else
            {
                FailureText.Text = "Ocurrió un error al restaurar el backup";
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