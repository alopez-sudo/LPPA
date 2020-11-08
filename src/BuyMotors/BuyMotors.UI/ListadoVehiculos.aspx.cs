using BuyMotors.BE;
using BuyMotors.BE.Filtros;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.XPath;

namespace BuyMotors.UI
{
    public partial class ListadoVehiculos : BasePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                CargarGvVehiculo(new FiltroVehiculo());
            }
        }

        private void CargarGvVehiculo(FiltroVehiculo filtro)
        {
            VehiculosWS vehiculosWS = new VehiculosWS();
            // Obtengo el XML de los vehículos dentro de un string.
            string xmlVehiculos = vehiculosWS.ObtenerVehiculosXml();
            List<Vehiculo> vehiculos = new List<Vehiculo>();

            // Utilizo el xml dentro del string para crear un documento XPath
            StringReader sr = new StringReader(xmlVehiculos);
            XPathDocument xPathDocument = new XPathDocument(sr);

            // Defino el query de xPath de acuerdo a los filtros recibidos
            List<string> queries = new List<string>();
            if (!string.IsNullOrEmpty(filtro.Patente))
            {
                queries.Add("Patente='" + filtro.Patente + "'");
            }
            if (filtro.PrecioDesde.HasValue)
            {
                queries.Add("Precio>=" + filtro.PrecioDesde);
            }
            if (filtro.PrecioHasta.HasValue)
            {
                queries.Add("Precio<=" + filtro.PrecioHasta);
            }
            string query = queries.Any() ? "[" + string.Join(" and ", queries) + "]" : "";

            XPathNavigator xNavegador = xPathDocument.CreateNavigator();
            XPathNodeIterator iterador;
            iterador = xNavegador.Select("Vehiculos/Vehiculo" + query);

            // Reconstruyo los objetos Vehiculo iterando con el iterador de XPath y obteniendo los valores de los nodos.
            while (iterador.MoveNext())
            {
                Vehiculo vehiculo = new Vehiculo
                {
                    Id = int.Parse(iterador.Current.SelectSingleNode("Id").Value),
                    Patente = iterador.Current.SelectSingleNode("Patente").Value,
                    Tipo = new TipoVehiculo { Nombre = iterador.Current.SelectSingleNode("Tipo").Value },
                    Categoria = new CategoriaVehiculo { Nombre = iterador.Current.SelectSingleNode("Categoria").Value },
                    Color = new Color { Nombre = iterador.Current.SelectSingleNode("Color").Value },
                    Modelo = new Modelo
                    {
                        Nombre = iterador.Current.SelectSingleNode("Modelo").Value,
                        Marca = new Marca { Nombre = iterador.Current.SelectSingleNode("Marca").Value }
                    },
                    Precio = int.Parse(iterador.Current.SelectSingleNode("Precio").Value),
                    AnioFabricacion = int.Parse(iterador.Current.SelectSingleNode("AnioFabricacion").Value),
                    ImagenNombre = iterador.Current.SelectSingleNode("ImagenNombre").Value
                };

                vehiculos.Add(vehiculo);
            }

            sr.Close();

            gvVehiculos.DataSource = vehiculos;
            gvVehiculos.DataBind();
        }

		protected void BtnBuscar_Click(object sender, EventArgs e)
		{
            FiltroVehiculo filtro = new FiltroVehiculo();
            if (!string.IsNullOrEmpty(TxtPatente.Text))
            {
                filtro.Patente = TxtPatente.Text;
            }

            if (!string.IsNullOrEmpty(TxtPrecioDesde.Text) && int.TryParse(TxtPrecioDesde.Text, out _))
            {
                filtro.PrecioDesde = int.Parse(TxtPrecioDesde.Text);
            }
            else
            {
                TxtPrecioDesde.Text = string.Empty;
            }

            if (!string.IsNullOrEmpty(TxtPrecioHasta.Text) && int.TryParse(TxtPrecioHasta.Text, out _))
            {
                filtro.PrecioHasta = int.Parse(TxtPrecioHasta.Text);
            }
            else
            {
                TxtPrecioHasta.Text = string.Empty;
            }

            CargarGvVehiculo(filtro);
		}

		protected void BtnLimpiar_Click(object sender, EventArgs e)
		{
			TxtPatente.Text = string.Empty;
			TxtPrecioDesde.Text = string.Empty;
			TxtPrecioHasta.Text = string.Empty;
			CargarGvVehiculo(new FiltroVehiculo());
		}
	}
}