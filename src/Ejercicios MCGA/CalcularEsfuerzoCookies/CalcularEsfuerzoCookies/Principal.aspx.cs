using System;
using System.Web.UI;

namespace CalcularEsfuerzoCookies
{
    public partial class Principal : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCalcularEsfuerzo_Click(object sender, EventArgs e)
        {
			double l = double.Parse(txtL.Text);
            double ck = double.Parse(txtCk.Text);
            double td = double.Parse(txtTd.Text);

            double esfuerzo = Math.Pow(l, 3.0) / (Math.Pow(ck, 3.0) * Math.Pow(td, 4.0));
			Response.Cookies["Datos"]["Esfuerzo"] = esfuerzo.ToString();

            Response.Redirect("Resultado.aspx");
        }
    }
}
