using System;
using System.Web.UI;

namespace ControlesDeValidacion
{
    public partial class Default : Page
    {
        protected void BotonClick(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Response.Redirect("ffff.aspx");
            }
        }
    }
}