using System;
using System.Web.UI;
using System.Xml;

namespace EjercicioAXml
{
    public partial class XML : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlTextReader miLector = new XmlTextReader(Server.MapPath("Inventario.xml"));
            while (miLector.Read())
            {
                Response.Write(miLector.NodeType.ToString() + ": " + miLector.Name + ": " + miLector.Value + "<br/>");
                if(miLector.HasAttributes)
                {
                    for (int n = 0; n < miLector.AttributeCount; n++)
                    {
                        miLector.MoveToAttribute(n);
                        Response.Write("<b>" + miLector.NodeType.ToString() + ": " + miLector.Name + ": " + miLector.Value + "</b><br/>");
                    }
                    miLector.MoveToElement();
                }
            }
            miLector.Close();
        }
    }
}