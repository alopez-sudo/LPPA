using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuyMotors.BE;
using BuyMotors.BL;

namespace BuyMotors.UI
{
	public partial class VehiculoDetalle : System.Web.UI.Page
	{
		private int Id;
		protected void Page_Load(object sender, EventArgs e)
		{
			CargarDetalle();
		}

		private void LeerParametros()
		{
			if(!int.TryParse(Request.QueryString["CodigoVehiculo"], out Id))
				Response.Redirect("ListadoVehiculos.aspx", true);
		}

		private void CargarDetalle()
		{
			LeerParametros();
			Vehiculo vehiculo = VehiculoManager.ObtenerVehiculo(Id);
			if(vehiculo == null)
				Response.Redirect("ListadoVehiculos.aspx", true);
			LblTipoVehiculo.Text = vehiculo.Tipo.Nombre;
			LblCategoria.Text = vehiculo.Categoria.Nombre;
			LblMarca.Text = vehiculo.Modelo.Marca.Nombre;
			LblModelo.Text = vehiculo.Modelo.Nombre;
			LblColor.Text = vehiculo.Color.Nombre;
			LblPrecio.Text = vehiculo.Precio.ToString();
			LblAnioFabricacion.Text = vehiculo.AnioFabricacion.ToString();
			ImgFotoVehiculo.ImageUrl = string.Format(@"~\Images\{0}", vehiculo.ImagenNombre);
		}
	}
}
