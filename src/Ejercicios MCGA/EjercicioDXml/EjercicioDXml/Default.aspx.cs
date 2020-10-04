using System;
using System.Web.UI;
using System.Xml.XPath;

namespace EjercicioDXml
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            XPathDocument xPathDocum = new XPathDocument(Server.MapPath("Banco.xml"));

            // Se basa en crear un navegador (variable xNavegador) que nos permita acceder a los nodos del documento "Banco.xml".
            XPathNavigator xNavegador = xPathDocum.CreateNavigator();
            XPathNodeIterator iterador = xNavegador.Select("Banco/Cuenta[CuentaSucursal='Barcelona']/CuentaNombre");

            // Recuperamos secuencialmente los valores de los nodos <CuentaNombre> usando un iterador de la clase XPathNodeIterator 
            // (la propiedad Current.Value).
            while (iterador.MoveNext())
            {
                ListBox1.Items.Add(iterador.Current.Value);
            }
        }
    }
}