using BuyMotors.BE.Filtros;
using System;

namespace BuyMotors.UI
{
    public partial class ListadoVehiculos : BasePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                CargarGvVehiculo(null);
            }
        }

		private void CargarGvVehiculo(FiltroVehiculo filtro)
		{
			//gvVehiculos.DataSource = VehiculoManager.ObtenerVehiculos(filtro);
			VehiculosWS vehiculosWS = new VehiculosWS();
			gvVehiculos.DataSource = vehiculosWS.ObtenerVehiculos(filtro);
			gvVehiculos.DataBind();
		}

		protected void BtnBuscar_Click(object sender, EventArgs e)
		{
            FiltroVehiculo filtro = new FiltroVehiculo();
            if (!string.IsNullOrEmpty(TxtPatente.Text))
            {
                filtro.Patente = TxtPatente.Text;
            }

            if (!string.IsNullOrEmpty(TxtPrecioDesde.Text) && int.TryParse(TxtPrecioDesde.Text, out _))
            {
                filtro.PrecioDesde = int.Parse(TxtPrecioDesde.Text);
            }
            else
            {
                TxtPrecioDesde.Text = string.Empty;
            }

            if (!string.IsNullOrEmpty(TxtPrecioHasta.Text) && int.TryParse(TxtPrecioHasta.Text, out _))
            {
                filtro.PrecioHasta = int.Parse(TxtPrecioHasta.Text);
            }
            else
            {
                TxtPrecioHasta.Text = string.Empty;
            }

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