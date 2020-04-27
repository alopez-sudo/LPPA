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
	public partial class ListadoCarrito : BasePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if(UsuarioLogueado == null)
				Response.Redirect("Default.aspx");
			if(!IsPostBack)
				CargarGvCarrito();
		}

		private void CargarGvCarrito()
		{
			Carrito carrito = CarritoManager.ObtenerCarrito(Session.SessionID);
			if(carrito != null && carrito.Detalles != null && carrito.Detalles.Count > 0)
			{
				gvCarrito.DataSource = carrito.Detalles;
				gvCarrito.DataBind();
				gvCarrito.Visible = true;
				LblResultado.Visible = false;
			}
			else
			{
				gvCarrito.Visible = false;
				LblResultado.Visible = true;
			}
		}

		protected void gvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if(e.CommandName != "EliminarDetalle")
				return;
			CarritoDetalle detalle = new CarritoDetalle()
			{
				Id = Convert.ToInt32(e.CommandArgument)
			};
			CarritoManager.EliminarDetalle(detalle);
			CargarGvCarrito();
		}
	}
}
