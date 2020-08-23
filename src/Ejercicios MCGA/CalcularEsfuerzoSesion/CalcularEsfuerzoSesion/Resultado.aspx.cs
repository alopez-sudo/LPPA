using System;
using System.Web.UI;

namespace CalcularEsfuerzoSesion
{
    public partial class Resultado : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblEsfuerzo.Text = Session["Esfuerzo"].ToString();
        }
    }
}