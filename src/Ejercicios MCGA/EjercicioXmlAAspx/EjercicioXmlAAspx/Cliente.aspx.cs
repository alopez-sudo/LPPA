using System;
using System.Web.UI;
using System.Xml;

namespace EjercicioXmlAAspx
{
    public partial class Cliente : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlTextReader xmlTextReader = new XmlTextReader(Server.MapPath("Datos.xml"));
            Session["Apellido"] = "";
            Session["Sueldo"] = "";
            while (xmlTextReader.Read())
            {
                xmlTextReader.MoveToElement();
                if (xmlTextReader.Name == "Apellido")
                {
                    Session["Apellido"] = xmlTextReader.ReadString();
                }
                if (xmlTextReader.Name == "Sueldo")
                {
                    Session["Sueldo"] = xmlTextReader.ReadString();
                }
            }

            xmlTextReader.Close();
            Response.Redirect("VerDatos.aspx");
        }
    }
}