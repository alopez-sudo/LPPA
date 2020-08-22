using System;
using System.Web.UI;

namespace Ejercicio3Cookies
{
    public partial class CalcPrestamo : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string apellido = Request.Cookies["Datos"]["Apellido"];
            int edad = int.Parse(Request.Cookies["Datos"]["Edad"]);
            string catSueldo = Request.Cookies["Datos"]["Sueldo"];

            Response.Write(apellido);
            Response.Write("<br/>");
            Response.Write(edad);
            Response.Write("<br/>");

            string mensaje = "";
            if (edad < 23 || edad > 75)
            {
                mensaje = "Su edad no le permite obtener el préstamo";
            }
            else
            {
                switch (catSueldo)
                {
                    case "A":
                        mensaje = "Es menor a $36.000, se le otorgarán $ 30.000";
                        break;
                    case "B":
                        mensaje = "Está entre $36.001 y $72.000, le otorgarán $ 45.000";
                        break;
                    case "C":
                        mensaje = "Es mayor a $72.000, se le otorgarán $ 65.000";
                        break;
                }
            }
            Response.Write(mensaje);
        }
    }
}