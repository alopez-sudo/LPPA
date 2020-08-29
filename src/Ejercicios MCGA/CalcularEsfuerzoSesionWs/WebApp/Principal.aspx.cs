using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Principal : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected void BtnCalcularEsfuerzo_Click(object sender, EventArgs e)
	{
		int l = int.Parse(txtL.Text);
		int ck = int.Parse(txtCk.Text);
		double td = double.Parse(txtTd.Text);

		Session["l"] = l;
		Session["ck"] = ck;
		Session["td"] = td;

		Response.Redirect("Resultado.aspx");
	}
}
