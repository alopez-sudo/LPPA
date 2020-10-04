using System;
using System.Web.UI;
using System.Xml;

namespace EjercicioIntegradorXml
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLeerConXmlTextReader_Click(object sender, EventArgs e)
        {
            XmlTextReader miLector = new XmlTextReader(Server.MapPath("Libros.xml"));
            bool printText = false;
            while (miLector.Read())
            {
                if (miLector.NodeType == XmlNodeType.Element)
                {
                    switch (miLector.Name)
                    {
                        case "Libro":
                            // Es un libro nuevo, agrego un renglón en blanco
                            lblDatos.Text += "<br/>";
                            break;
                        case "NombreLibro":
                            lblDatos.Text += "<b>Nombre:</b> ";
                            // Se pone esta variable en true para que se imprima su valor en la próxima iteración del while
                            printText = true;
                            break;
                        case "Autor":
                            lblDatos.Text += "<b>Autor:</b> ";
                            printText = true;
                            break;
                        case "Editorial":
                            lblDatos.Text += "<b>Editorial:</b> ";
                            printText = true;
                            break;
                        case "Precio":
                            lblDatos.Text += "<b>Precio:</b> $";
                            printText = true;
                            break;
                    }
                }
                else if (miLector.NodeType == XmlNodeType.Text && printText)
                {
                    printText = false;
                    lblDatos.Text += miLector.Value + "<br/>";
                }
            }
            miLector.Close();
        }
    }
}