using BuyMotors.BE;
using BuyMotors.BL;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace BuyMotors.UI
{
    public partial class ListadoCarrito : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UsuarioLogueado == null)
                Response.Redirect("Default.aspx");
            if (!IsPostBack)
                CargarGvCarrito();
        }

        private void CargarGvCarrito()
        {
            Carrito carrito = CarritoManager.ObtenerCarrito(UsuarioLogueado.Id, Session.SessionID);
            if (carrito != null && carrito.Detalles != null && carrito.Detalles.Count > 0)
            {
                gvCarrito.DataSource = carrito.Detalles;
                gvCarrito.DataBind();
                gvCarrito.Visible = true;
                LblTotal.Text = "Total: $" + carrito.Detalles.Sum(d => d.Precio);
                LblTotal.Visible = true;
                BtnFinalizarCompra.Visible = true;
                LblResultado.Visible = false;
            }
            else
            {
                gvCarrito.Visible = false;
                LblTotal.Visible = false;
                BtnFinalizarCompra.Visible = false;
                LblResultado.Visible = true;
            }
        }

        protected void gvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "EliminarDetalle")
                return;
            CarritoDetalle detalle = new CarritoDetalle()
            {
                Id = Convert.ToInt32(e.CommandArgument)
            };
            CarritoManager.EliminarDetalle(detalle);
            CargarGvCarrito();
        }

        protected void BtnFinalizarCompra_Click(object sender, EventArgs e)
        {
            Carrito carrito = CarritoManager.ObtenerCarrito(UsuarioLogueado.Id, Session.SessionID);
            if (carrito != null && CarritoManager.FinalizarCompra(carrito))
            {
                Response.Redirect("CompraFinalizada.aspx");
            }
            else
            {
                // Mostrar que hubo error
                FailureText.Text = "Ocurrió un error al generar la factura";
                ErrorMessage.Visible = true;
            }
        }
    }
}
