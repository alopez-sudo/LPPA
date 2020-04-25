using BuyMotors.BL;
using System;

namespace BuyMotors.UI.Account
{
    public partial class Logout : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UsuarioLogueado != null)
            {
                BitacoraManager.Grabar(UsuarioLogueado, "Cierre de sesión");
                UsuarioLogueado = null;
                Response.Redirect("../Default.aspx");
            }
        }
    }
}