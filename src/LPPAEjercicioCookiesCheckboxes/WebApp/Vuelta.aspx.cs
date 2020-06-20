using System;

namespace WebApp
{
	public partial class Vuelta : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string mensaje = "Usted realiza las actividades los días";
			if(!string.IsNullOrEmpty(Request.Cookies["Datos"]["Lunes"]))
				mensaje += string.Format("<br>{0}", Request.Cookies["Datos"]["Lunes"].ToString());
			if(!string.IsNullOrEmpty(Request.Cookies["Datos"]["Martes"]))
				mensaje += string.Format("<br>{0}", Request.Cookies["Datos"]["Martes"].ToString());
			if(!string.IsNullOrEmpty(Request.Cookies["Datos"]["Miercoles"]))
				mensaje += string.Format("<br>{0}", Request.Cookies["Datos"]["Miercoles"].ToString());
			if(!string.IsNullOrEmpty(Request.Cookies["Datos"]["Jueves"]))
				mensaje += string.Format("<br>{0}", Request.Cookies["Datos"]["Jueves"].ToString());
			if(!string.IsNullOrEmpty(Request.Cookies["Datos"]["Viernes"]))
				mensaje += string.Format("<br>{0}", Request.Cookies["Datos"]["Viernes"].ToString());
			LblMensaje.Text = mensaje;
		}
	}
}
