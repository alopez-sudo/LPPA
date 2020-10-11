using System;
using BuyMotors.BL;
using BuyMotors.BE;
using BuyMotors.UI;
using System.Collections.Generic;

namespace BuyMotors.Account
{
    public partial class Login : BasePage
    {
        protected string mensajeError;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UsuarioLogueado != null)
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
                Usuario usuarioLogueado = UsuarioManager.Login(Email.Text, Password.Text, out bool estaBloqueado);
                if (usuarioLogueado != null)
                {
                    UsuarioLogueado = usuarioLogueado;
                    BitacoraManager.Grabar(usuarioLogueado, "Login ok");

                    if (UsuarioManager.TienePermiso(usuarioLogueado, Permisos.CHEQUEO_DV))
                    {
                        List<string> mensajesDeError = new List<string>();
                        Session["MostrarMensajeDV"] = !IntegridadDatos.Chequear(mensajesDeError);
						Session["MensajeDV"] = string.Format(@"Error de integridad de datos:\n{0}", string.Join(@"\n", mensajesDeError));
					}

                    SalirDeLaPagina();
                }
                else if (estaBloqueado)
                {
                    FailureText.Text = "El usuario está bloquado. Restablezca la contraseña haciendo clic en \"Olvidé mi clave\" para desbloquearlo";
                    ErrorMessage.Visible = true;
                }
                else
                {
                    // El login falló
                    FailureText.Text = "Intento de inicio de sesión no válido";
                    ErrorMessage.Visible = true;
                }
            }
        }

        protected void ForgotPasswordLinkButton_Click(object sender, EventArgs e)
        {

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