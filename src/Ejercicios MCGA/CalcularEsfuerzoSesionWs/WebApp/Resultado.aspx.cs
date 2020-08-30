using System;
using System.Web.UI;

public partial class Resultado : Page
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
