using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Resultado : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		double l = double.Parse(Session["l"].ToString());
		double ck = double.Parse(Session["ck"].ToString());
		double td = double.Parse(Session["td"].ToString());

		WebService webService = new WebService();
		lblEsfuerzo.Text = webService.CalculaEsfuerzo(l, ck, td).ToString();
	}
}
