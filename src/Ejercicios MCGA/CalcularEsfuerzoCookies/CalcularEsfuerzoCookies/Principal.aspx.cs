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

			Response.Cookies["Datos"]["l"] = l.ToString();
			Response.Cookies["Datos"]["ck"] = ck.ToString();
			Response.Cookies["Datos"]["td"] = td.ToString();

            Response.Redirect("Resultado.aspx");
        }
    }
}
