using System;
using System.Web;
using System.Web.UI;

namespace BuyMotors.UI.Account
{
    public partial class ForgotPassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Session["Email"].ToString();
            string token = Session["PasswordToken"].ToString();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
            {
                Response.Redirect("Default.aspx");
            }

            lblInstrucciones.Text = $"Se envió un email a {email} con instrucciones para restablecer su contraseña";

            string url = HttpContext.Current.Request.Url.AbsoluteUri.Replace("ForgotPassword", "RestorePassword");
            lblLink.Text = $"{url}?email={Server.UrlEncode(email)}&token={Server.UrlEncode(token)}";
        }
    }
}