using BuyMotors.BE.Filtros;
using BuyMotors.BL;
using System;

namespace BuyMotors.UI
{
    public partial class Bitacora : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (UsuarioLogueado == null || !UsuarioManager.TienePermiso(UsuarioLogueado, Permisos.BITACORA))
                {
                    Response.Redirect("Default.aspx");
                }

                CargarGvBitacora();
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarGvBitacora();
        }

        private void CargarGvBitacora()
        {
            // Valido los datos
            if (CalFechaDesde.SelectedDate != DateTime.MinValue && CalFechaHasta.SelectedDate != DateTime.MinValue &&
                CalFechaDesde.SelectedDate > CalFechaHasta.SelectedDate)
            {
                FailureText.Text = "La fecha de inicio no puede ser mayor a la fecha de fin";
                ErrorMessage.Visible = true;
                return;
            }

            ErrorMessage.Visible = false;
            
            FiltroBitacora filtro = new FiltroBitacora
            {
                FechaDesde = CalFechaDesde.SelectedDate == DateTime.MinValue ? (DateTime?)null : CalFechaDesde.SelectedDate,
                FechaHasta = CalFechaHasta.SelectedDate == DateTime.MinValue ? (DateTime?)null : CalFechaHasta.SelectedDate,
                Usuario = TxtUsuario.Text
            };

            gvBitacora.DataSource = BitacoraManager.ObtenerBitacoras(filtro);
            gvBitacora.DataBind();
        }
    }
}