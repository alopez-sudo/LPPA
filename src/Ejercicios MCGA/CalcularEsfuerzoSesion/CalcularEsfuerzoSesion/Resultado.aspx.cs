using System;
using System.Web.UI;

namespace CalcularEsfuerzoSesion
{
    public partial class Resultado : Page
    {
		protected void Page_Load(object sender, EventArgs e)
		{
			double l = double.Parse(Session["l"].ToString());
			double ck = double.Parse(Session["ck"].ToString());
			double td = double.Parse(Session["td"].ToString());

			double esfuerzo = Math.Pow(l, 3.0) / (Math.Pow(ck, 3.0) * Math.Pow(td, 4.0));

			lblEsfuerzo.Text = esfuerzo.ToString();
        }
    }
}
