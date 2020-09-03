using BuyMotors.BE;
using BuyMotors.BE.Filtros;
using BuyMotors.BL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Services;

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
        public IEnumerable<Vehiculo> ObtenerVehiculos(FiltroVehiculo filtro)
        {
            return VehiculoManager.ObtenerVehiculos(filtro);
        }
    }
}
