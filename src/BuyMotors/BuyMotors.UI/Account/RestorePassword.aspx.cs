using BuyMotors.BL;
using System;
using System.Web.UI;

namespace BuyMotors.UI.Account
{
    public partial class RestorePassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Request.QueryString["email"];
            string token = Request.QueryString["token"];

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token) || !UsuarioManager.ValidarToken(email, token))
            {
                Response.Redirect("~/Default.aspx");
            }

            EmailHidden.Value = email;
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            UsuarioManager.RestablecerContrasenia(EmailHidden.Value, Password.Text);
            Response.Redirect("~/Default.aspx");
        }
    }
}