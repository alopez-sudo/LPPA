using System;
using System.Web.UI;

namespace CalcularEsfuerzoCookies
{
    public partial class Resultado : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			double l = double.Parse(Request.Cookies["Datos"]["l"]);
			double ck = double.Parse(Request.Cookies["Datos"]["ck"]);
			double td = double.Parse(Request.Cookies["Datos"]["td"]);

			double esfuerzo = Math.Pow(l, 3.0) / (Math.Pow(ck, 3.0) * Math.Pow(td, 4.0));

			lblEsfuerzo.Text = esfuerzo.ToString();
        }
    }
}
