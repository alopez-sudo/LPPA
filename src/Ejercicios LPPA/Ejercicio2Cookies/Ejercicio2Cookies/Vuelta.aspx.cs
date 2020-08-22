using System;
using System.Web.UI;

namespace Ejercicio2Cookies
{
    public partial class Vuelta : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string destino = Request.Cookies["Datos"]["Destino"];
            string categoria = Request.Cookies["Datos"]["Categoria"];
            int cantidadPersonas = int.Parse(Request.Cookies["Datos"]["CantidadPersonas"]);
            int cantidadDias = int.Parse(Request.Cookies["Datos"]["CantidadDias"]);

            double precio = destino == "MdelPlata" ? 2000 : 30000;
            if (categoria == "Cuatro")
            {
                precio *= 1.2;
            }

            precio *= cantidadPersonas;
            precio *= cantidadDias;

            Response.Write("El costo es $" + precio);
        }
    }
}