using System;

namespace BuyMotors.UI.Account
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogueado"] != null)
            {
                Session["UsuarioLogueado"] = null;
                Response.Redirect("../Default.aspx");
            }
        }
    }
}