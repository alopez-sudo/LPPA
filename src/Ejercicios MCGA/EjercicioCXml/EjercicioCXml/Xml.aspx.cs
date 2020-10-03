using System;
using System.Web.UI;
using System.Xml;

namespace EjercicioCXml
{
    public partial class Xml : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                XmlDocument miDoc = new XmlDocument();
                XmlTextReader miLector = new XmlTextReader(Server.MapPath("Inventario2.xml"));
                miLector.WhitespaceHandling = WhitespaceHandling.None;
                miDoc.Load(miLector);
                Session.Add("DocumentoEnSesion", miDoc);

                for (int i = 0; i < miDoc.DocumentElement.ChildNodes.Count; i++)
                {
                    ddlProducto.Items.Add(miDoc.DocumentElement.ChildNodes[i].ChildNodes[1].InnerText);
                }
                miLector.Close();
            }
        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            XmlDocument miDoc = (XmlDocument)Session["DocumentoEnSesion"];
            int n = ddlProducto.SelectedIndex;
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            double precio = Convert.ToDouble(miDoc.DocumentElement.ChildNodes[n].ChildNodes[2].InnerText);

            lblPrecio.Text = precio.ToString();
            lblTotal.Text = (cantidad * precio).ToString();
        }
    }
}