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
			if(!IsPostBack)
				CargarGvVehiculo(null);
		}

		private void CargarGvVehiculo(FiltroVehiculo filtro)
		{
			gvVehiculos.DataSource = VehiculoManager.ObtenerVehiculos(filtro);
			gvVehiculos.DataBind();
		}

		protected void BtnBuscar_Click(object sender, EventArgs e)
		{
			int unNumero;
			FiltroVehiculo filtro = new FiltroVehiculo();
			if(!string.IsNullOrEmpty(TxtPatente.Text))
			{
				filtro.Patente = TxtPatente.Text;
			}
			if(!string.IsNullOrEmpty(TxtPrecioDesde.Text) && int.TryParse(TxtPrecioDesde.Text, out unNumero))
				filtro.PrecioDesde = int.Parse(TxtPrecioDesde.Text);
			else
				TxtPrecioDesde.Text = string.Empty;
			if(!string.IsNullOrEmpty(TxtPrecioHasta.Text) && int.TryParse(TxtPrecioHasta.Text, out unNumero))
				filtro.PrecioHasta = int.Parse(TxtPrecioHasta.Text);
			else
				TxtPrecioHasta.Text = string.Empty;
			CargarGvVehiculo(filtro);
		}
		protected void BtnLimpiar_Click(object sender, EventArgs e)
		{
			TxtPatente.Text = string.Empty;
			TxtPrecioDesde.Text = string.Empty;
			TxtPrecioHasta.Text = string.Empty;
			CargarGvVehiculo(null);
		}
	}
}