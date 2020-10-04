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

        protected void BtnEscribirConXmlTextWriter_Click(object sender, EventArgs e)
        {
            XmlTextWriter miEscritor = new XmlTextWriter(Server.MapPath("Libros.xml"), null)
            {
                Formatting = Formatting.Indented
            };
            miEscritor.WriteStartDocument();
            miEscritor.WriteStartElement("Libros");

            AgregarLibro(miEscritor, "Origen", "Dan Brown", "Planeta", "1490");
            AgregarLibro(miEscritor, "El retorno de los dragones", "Margaret Weis - Tracy Hickman", "Timun Mas", "250");
            AgregarLibro(miEscritor, "La herida", "Jorge Fernandez Diaz", "Planeta", "600");
            AgregarLibro(miEscritor, "Ajuste de cuentas", "John Grisham", "Penguin Random House", "1424");
            AgregarLibro(miEscritor, txtNombreLibro1.Text, txtAutorLibro1.Text, txtEditorialLibro1.Text, txtPrecioLibro1.Text);
            AgregarLibro(miEscritor, txtNombreLibro2.Text, txtAutorLibro2.Text, txtEditorialLibro2.Text, txtPrecioLibro2.Text);
            AgregarLibro(miEscritor, txtNombreLibro3.Text, txtAutorLibro3.Text, txtEditorialLibro3.Text, txtPrecioLibro3.Text);

            miEscritor.WriteEndDocument();
            miEscritor.Flush();
            miEscritor.Close();

            lblResultadoEscritura.Text = "Listo!";
        }

        private void AgregarLibro(XmlTextWriter miEscritor, string nombre, string autor, string editorial, string precio)
        {
            miEscritor.WriteStartElement("Libro");
            miEscritor.WriteStartElement("NombreLibro");
            miEscritor.WriteString(nombre);
            miEscritor.WriteEndElement();
            miEscritor.WriteStartElement("Autor");
            miEscritor.WriteString(autor);
            miEscritor.WriteEndElement();
            miEscritor.WriteStartElement("Editorial");
            miEscritor.WriteString(editorial);
            miEscritor.WriteEndElement();
            miEscritor.WriteStartElement("Precio");
            miEscritor.WriteString(precio);
            miEscritor.WriteEndElement();
            miEscritor.WriteEndElement();
        }
    }
}