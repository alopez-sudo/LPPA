using System;
using System.Web.UI;
using System.Xml.XPath;

namespace EjercicioEXml
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                XPathDocument xPathDocum = new XPathDocument(Server.MapPath("Banco.xml"));
                XPathNavigator xNavegador = xPathDocum.CreateNavigator();
                XPathNodeIterator iterador = xNavegador.Select("banco/cuenta/@cuentanum");
                while (iterador.MoveNext())
                {
                    DropDownList1.Items.Add(iterador.Current.Value);
                }
                iterador = xNavegador.Select("banco/cuenta/cuentanombre");
                while (iterador.MoveNext())
                {
                    DropDownList2.Items.Add(iterador.Current.Value);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cuentaNum = DropDownList1.SelectedItem.Text.Trim();
            string cuentaNom = DropDownList2.SelectedItem.Text.Trim();
            XPathDocument xPathDocum = new XPathDocument(Server.MapPath("Banco.xml"));
            XPathNavigator xNavegador = xPathDocum.CreateNavigator();

            XPathNodeIterator iterador = xNavegador.Select("banco/cuenta[@cuentanum='" + cuentaNum + "']/cuentasaldo");
            iterador.MoveNext();
            TextBox1.Text = string.Format("{0:C}", iterador.Current.Value);

            iterador = xNavegador.Select("banco/cuenta[cuentanombre='" + cuentaNom + "']/cuentasaldo");
            iterador.MoveNext();
            TextBox2.Text = string.Format("{0:C}", iterador.Current.Value);
        }
    }
}