using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class CalcPrestamo : Page
    {
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Mensaje { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
                            Mensaje = "Es menor a $36.000, se le otorgarán $ 30.000";
                            break;
                        case "B":
                            Mensaje = "Está entre $36.001 y $72.000, le otorgarán $ 45.000";
                            break;
                        case "C":
                            Mensaje = "Es mayor a $72.000, se le otorgarán $ 65.000";
                            break;
                    }
                }
            }
            catch (Exception EX) { string ex = EX.Message; };
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}