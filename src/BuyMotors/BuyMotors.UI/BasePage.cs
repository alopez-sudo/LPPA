using BuyMotors.BE;
using System.Web.UI;

namespace BuyMotors.UI
{
    public class BasePage : Page
    {
        public Usuario UsuarioLogueado
        {
            get
            {
                return Session["UsuarioLogueado"] != null ? (Usuario)Session["UsuarioLogueado"] : null;
            }
            set
            {
                Session["UsuarioLogueado"] = value;
            }
        }
    }
}