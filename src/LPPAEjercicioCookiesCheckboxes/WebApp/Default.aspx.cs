using System;
using System.Web.UI;

namespace WebApp
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		protected void BtnEnviar_Click(object sender, EventArgs e)
		{
			if(Checkbox1.Checked)
				Response.Cookies["Datos"]["Lunes"] = Checkbox1.Text;
			if(Checkbox2.Checked)
				Response.Cookies["Datos"]["Martes"] = Checkbox2.Text;
			if(Checkbox3.Checked)
				Response.Cookies["Datos"]["Miercoles"] = Checkbox3.Text;
			if(Checkbox4.Checked)
				Response.Cookies["Datos"]["Jueves"] = Checkbox4.Text;
			if(Checkbox5.Checked)
				Response.Cookies["Datos"]["Viernes"] = Checkbox5.Text;
			Response.Redirect("Vuelta.aspx");
		}
	}
}
