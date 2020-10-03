using System;
using System.Web.UI;
using System.Xml;

namespace EjercicioBXml
{
    public partial class XML : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            XmlTextWriter miEscritor = new XmlTextWriter(Server.MapPath("Clientes.xml"), null)
            {
                Formatting = Formatting.Indented
            };
            miEscritor.WriteStartDocument();
            miEscritor.WriteComment("Escribir datos en XML");
            miEscritor.WriteStartElement("DatosCliente");
            miEscritor.WriteAttributeString("NombreTipo", "Guardar");
            miEscritor.WriteStartElement("NombreNumero", "");
            miEscritor.WriteString(NombreTxt.Text);
            miEscritor.WriteEndElement();

            miEscritor.WriteStartElement("Apellidos", "");
            miEscritor.WriteString(ApellidoTxt.Text);
            miEscritor.WriteEndElement();

            miEscritor.WriteStartElement("Direccion", "");
            miEscritor.WriteString(DireccionTxt.Text);
            miEscritor.WriteEndElement();

            miEscritor.WriteEndDocument();
            miEscritor.Flush();
            miEscritor.Close();

            Response.Redirect("Clientes.xml");
        }
    }
}