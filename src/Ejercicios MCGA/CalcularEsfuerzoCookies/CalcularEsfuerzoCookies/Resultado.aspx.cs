using System;
using System.Web.UI;

namespace CalcularEsfuerzoCookies
{
    public partial class Resultado : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblEsfuerzo.Text = Request.Cookies["Datos"]["Esfuerzo"].ToString();
        }
    }
}
