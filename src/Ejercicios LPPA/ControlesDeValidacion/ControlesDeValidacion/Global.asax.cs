using System;
using System.Web;
using System.Web.UI;

namespace ControlesDeValidacion
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
    }
}