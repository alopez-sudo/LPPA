using System;
using System.Web.UI;

namespace CalcularEsfuerzoSesion
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

			Session["l"] = l;
			Session["ck"] = ck;
			Session["td"] = td;

			Response.Redirect("Resultado.aspx");
        }
    }
}
