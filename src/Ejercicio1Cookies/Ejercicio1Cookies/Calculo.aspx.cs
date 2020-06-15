using System;
using System.Web.UI;

namespace Ejercicio1Cookies
{
    public partial class Calculo : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string apellido = Request.Cookies["Datos"]["Apellido"];
            string edadStr = Request.Cookies["Datos"]["Edad"];
            int edad = Convert.ToInt32(edadStr);
            
            Response.Write(apellido);
            Response.Write("<br/>");
            Response.Write("Su edad en meses es " + (edad * 12));
        }
    }
}