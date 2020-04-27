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
	public partial class VehiculoDetalle : BasePage
	{
		private int Id;
		protected void Page_Load(object sender, EventArgs e)
		{
			CargarDetalle();
		}

		private void LeerParametros()
		{
			if(string.IsNullOrEmpty(Request.QueryString["CodigoVehiculo"]) || !int.TryParse(Request.QueryString["CodigoVehiculo"], out Id))
				Response.Redirect("ListadoVehiculos.aspx", true);
		}

		private void CargarDetalle()
		{
			LeerParametros();
			Vehiculo vehiculo = VehiculoManager.ObtenerVehiculo(Id);
			if(vehiculo == null)
				Response.Redirect("ListadoVehiculos.aspx", true);
			HiddenVehiculoId.Value = vehiculo.Id.ToString();
			HiddenVehiculoPrecio.Value = vehiculo.Precio.ToString();
			LblTipoVehiculo.Text = vehiculo.Tipo.Nombre;
			LblCategoria.Text = vehiculo.Categoria.Nombre;
			LblMarca.Text = vehiculo.Modelo.Marca.Nombre;
			LblModelo.Text = vehiculo.Modelo.Nombre;
			LblColor.Text = vehiculo.Color.Nombre;
			LblPrecio.Text = vehiculo.Precio.ToString();
			LblAnioFabricacion.Text = vehiculo.AnioFabricacion.ToString();
			ImgFotoVehiculo.ImageUrl = string.Format(@"~\Images\{0}", vehiculo.ImagenNombre);
			BtnAgregarAlCarrito.Visible = UsuarioLogueado != null;
		}

		protected void BtnAgregarAlCarrito_Click(object sender, EventArgs e)
		{
			Vehiculo vehiculo = new Vehiculo();
			vehiculo.Id = int.Parse(HiddenVehiculoId.Value);
			vehiculo.Precio = int.Parse(HiddenVehiculoPrecio.Value);
			CarritoDetalle detalle = new CarritoDetalle();
			detalle.Vehiculo = vehiculo;
			detalle.Cantidad = 1;
			Carrito carrito = new Carrito();
			carrito.FechaCreacion = DateTime.Now;
			carrito.Usuario = UsuarioLogueado;
			carrito.UsuarioSessionId = Session.SessionID;
			carrito.Detalles.Add(detalle);
			CarritoManager.AgregarDetalle(carrito);
			Response.Redirect("ListadoCarrito.aspx");
		}
	}
}
