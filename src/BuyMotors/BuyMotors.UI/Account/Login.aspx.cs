using System;
using System.Web;
using System.Web.UI;
using BuyMotors.BL;
using BuyMotors.BE;

namespace BuyMotors.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogueado"] != null)
            {
                SalirDeLaPagina();

                // Esto va a servir para las demás páginas que requieren autenticación
                //var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
                //if (!String.IsNullOrEmpty(returnUrl))
                //{
                //    RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
                //}
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Usuario usuarioLogueado = UsuarioManager.Login(Email.Text, Password.Text);
                if (usuarioLogueado != null)
                {
                    Session["UsuarioLogueado"] = usuarioLogueado;

                    SalirDeLaPagina();
                }
                else
                {
                    // El login falló
                    FailureText.Text = "Intento de inicio de sesión no válido";
                    ErrorMessage.Visible = true;
                }
            }
        }

        private void SalirDeLaPagina()
        {
            string urlRegreso = Request.QueryString["ReturnUrl"];
            if (!string.IsNullOrEmpty(urlRegreso))
            {
                Response.Redirect(urlRegreso);
            }
            else
            {
                // No hay Url especificada, se lo manda a la página principal
                Response.Redirect("../Default.aspx");
            }
        }
    }
}