using System;
using System.Web.UI;

namespace Ejercicio2Cookies
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Response.Cookies["Datos"]["Destino"] = RadDestino.SelectedValue;
                Response.Cookies["Datos"]["Categoria"] = RadCategoria.SelectedValue;
                Response.Cookies["Datos"]["CantidadPersonas"] = TxtCantidadPersonas.Text;
                Response.Cookies["Datos"]["CantidadDias"] = TxtCantidadDias.Text;
                Response.Redirect("Vuelta.aspx");
            }

        }
    }
}