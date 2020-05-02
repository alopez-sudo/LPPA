using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
	public partial class Vuelta : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string destino = Request.Form["destino"];
			string categoria = Request.Form["estrella"];
			int cantidadPersonas = int.Parse(Request.Form["TxtCantidad"]);
			int cantidadDias = int.Parse(Request.Form["TxtDias"]);

			double precio = destino == "Mar del Plata" ? 2000 : 30000;
			if (categoria == "Cuatro")
			{
				precio *= 1.2;
			}

			precio *= cantidadPersonas;
			precio *= cantidadDias;

			LblDestino.Text = destino;
			LblCategoria.Text = categoria;
			LblCantidadDePersonas.Text = Request.Form["TxtCantidad"];
			LblCantidadDeDias.Text = Request.Form["TxtDias"];
			LblPrecioTotal.Text = precio.ToString();
		}
	}
}
