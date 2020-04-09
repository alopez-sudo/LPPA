using BuyMotors.BE;
using BuyMotors.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuyMotors.UI
{
	public partial class ListadoVehiculos : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			CargarGvVehiculo(null);
		}

		private void CargarGvVehiculo(FiltroVehiculo filtro)
		{
			gvVehiculos.DataSource = VehiculoManager.ObtenerVehiculos(filtro);
			gvVehiculos.DataBind();
		}

		protected void BtnBuscar_Click(object sender, EventArgs e)
		{
			FiltroVehiculo filtro = new FiltroVehiculo();
			if(!string.IsNullOrEmpty(TxtPatente.Text))
				filtro.Patente = TxtPatente.Text;
			if(!string.IsNullOrEmpty(TxtPrecioDesde.Text))
				filtro.PrecioDesde = int.Parse(TxtPrecioDesde.Text);
			if(!string.IsNullOrEmpty(TxtPrecioHasta.Text))
				filtro.PrecioHasta = int.Parse(TxtPrecioHasta.Text);
			CargarGvVehiculo(filtro);
		}
		protected void BtnLimpiar_Click(object sender, EventArgs e)
		{
			TxtPatente.Text = "";
			TxtPrecioDesde.Text = "";
			TxtPrecioHasta.Text = "";
			CargarGvVehiculo(null);
		}
	}
}