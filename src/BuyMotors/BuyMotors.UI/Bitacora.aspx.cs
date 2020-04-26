using BuyMotors.BE.Filtros;
using BuyMotors.BL;
using System;

namespace BuyMotors.UI
{
    public partial class Bitacora : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UsuarioLogueado == null || !UsuarioManager.TienePermiso(UsuarioLogueado, Permisos.BITACORA))
            {
                Response.Redirect("Default.aspx");
            }

            CargarGvBitacora();
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            // Valido los datos
            DateTime fechaDesde = DateTime.MinValue;
            DateTime fechaHasta = DateTime.MaxValue;
            if (!string.IsNullOrEmpty(TxtFechaDesde.Text) && !DateTime.TryParse(TxtFechaDesde.Text, out fechaDesde))
            {
                FailureText.Text = "El formato de la fecha de inicio no es correcto";
                ErrorMessage.Visible = true;
                return;
            }

            if (!string.IsNullOrEmpty(TxtFechaHasta.Text) && !DateTime.TryParse(TxtFechaHasta.Text, out fechaHasta))
            {
                FailureText.Text = "El formato de la fecha de fin no es correcto";
                ErrorMessage.Visible = true;
                return;
            }

            if (fechaDesde > fechaHasta)
            {
                FailureText.Text = "La fecha de inicio no puede ser mayor a la fecha de fin";
                ErrorMessage.Visible = true;
                return;
            }

            CargarGvBitacora();
        }

        private void CargarGvBitacora()
        {
            FiltroBitacora filtro = new FiltroBitacora
            {
                FechaDesde = string.IsNullOrEmpty(TxtFechaDesde.Text) ? (DateTime?)null : DateTime.Parse(TxtFechaDesde.Text),
                FechaHasta = string.IsNullOrEmpty(TxtFechaHasta.Text) ? (DateTime?)null : DateTime.Parse(TxtFechaHasta.Text),
                Usuario = TxtUsuario.Text
            };

            gvBitacora.DataSource = BitacoraManager.ObtenerBitacoras(filtro);
            gvBitacora.DataBind();
        }
    }
}