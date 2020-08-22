using System;
using System.Web.UI;

namespace Ejercicio3Cookies
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
                Response.Cookies["Datos"]["Apellido"] = TxtApellido.Text;
                Response.Cookies["Datos"]["Edad"] = TxtEdad.Text;
                Response.Cookies["Datos"]["Sueldo"] = DdlSueldo.SelectedValue;
                Response.Redirect("CalcPrestamo.aspx");
            }

        }
    }
}