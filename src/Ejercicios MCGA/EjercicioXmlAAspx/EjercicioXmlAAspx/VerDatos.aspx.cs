using System;
using System.Web.UI;

namespace EjercicioXmlAAspx
{
    public partial class VerDatos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (float.Parse(Session["Sueldo"].ToString()) > 70000)
            {
                Response.Write("Usted es afortunado");
            }
            else
            {
                Response.Write("Usted es pobre");
            }
        }
    }
}