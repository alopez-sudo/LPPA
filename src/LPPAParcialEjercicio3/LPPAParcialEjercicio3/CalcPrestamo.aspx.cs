using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LPPAParcialEjercicio3
{
    public partial class CalcPrestamo : Page
    {
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Mensaje { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Apellido = Request.Form["apellido"];
            Edad = int.Parse(Request.Form["edad"]);
            string catSueldo = Request.Form["sueldo"];

            if (Edad < 23 || Edad > 75)
            {
                Mensaje = "Su edad no le permite obtener el préstamo";
            }
            else
            {
                switch (catSueldo)
                {
                    case "A":
                        Mensaje = "Es menor a $36000, se le otorga $3600";
                        break;
                    case "B":
                        Mensaje = "Está entre $36001 y $72000, le otorgarán $45000";
                        break;
                    case "C":
                        Mensaje = "Es mayor a $72000, se le otorgarán $65000";
                        break;
                }
            }
        }
    }
}