using BuyMotors.BE;
using BuyMotors.BL;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Web.Services;
using System.Xml;

namespace BuyMotors.UI
{
    /// <summary>
    /// Descripción breve de VehiculosWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class VehiculosWS : WebService
    {

        [WebMethod]
        public string ObtenerVehiculosXml()
        {
            List<Vehiculo> vehiculos = VehiculoManager.ObtenerVehiculos();

            // Con estos vehículos armo un XML para devolver.
            // Tenemos claro que la manera más fácil de transformar los vehículos en XML es serializándolos con XmlSerializer,
            // pero lo hacemos con XmlTextWriter para mostrar su funcionamiento
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter)
            {
                Formatting = Formatting.Indented
            };

            xmlTextWriter.WriteStartDocument();
            xmlTextWriter.WriteStartElement("Vehiculos");
            foreach(Vehiculo vehiculo in vehiculos)
            {
                xmlTextWriter.WriteStartElement("Vehiculo");
                xmlTextWriter.WriteStartElement("Id");
                xmlTextWriter.WriteString(vehiculo.Id.ToString());
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteStartElement("Patente");
                xmlTextWriter.WriteString(vehiculo.Patente);
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteStartElement("Tipo");
                xmlTextWriter.WriteString(vehiculo.Tipo.Nombre);
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteStartElement("Categoria");
                xmlTextWriter.WriteString(vehiculo.Categoria.Nombre);
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteStartElement("Color");
                xmlTextWriter.WriteString(vehiculo.Color.Nombre);
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteStartElement("Modelo");
                xmlTextWriter.WriteString(vehiculo.Modelo.Nombre);
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteStartElement("Marca");
                xmlTextWriter.WriteString(vehiculo.Modelo.Marca.Nombre);
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteStartElement("Precio");
                xmlTextWriter.WriteString(vehiculo.Precio.ToString());
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteStartElement("AnioFabricacion");
                xmlTextWriter.WriteString(vehiculo.AnioFabricacion.ToString());
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteStartElement("ImagenNombre");
                xmlTextWriter.WriteString(vehiculo.ImagenNombre);
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteEndElement();
            }

            xmlTextWriter.WriteEndDocument();
            xmlTextWriter.Flush();
            xmlTextWriter.Close();

            return stringWriter.ToString();        }
    }
}
