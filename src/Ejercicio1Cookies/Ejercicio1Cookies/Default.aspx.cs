using System;
using System.Web.UI;

namespace Ejercicio1Cookies
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            Response.Cookies["Datos"]["Apellido"] = TxtApellido.Text;
            Response.Cookies["Datos"]["Edad"] = TxtEdad.Text;
            Response.Redirect("Calculo.aspx");
        }
    }
}