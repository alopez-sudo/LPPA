﻿using System;
using System.Web.UI;

namespace CalcularEsfuerzoSesion
{
    public partial class Principal : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCalcularEsfuerzo_Click(object sender, EventArgs e)
        {
            double l = double.Parse(txtL.Text);
            double ck = double.Parse(txtCk.Text);
            double td = double.Parse(txtTd.Text);

            double esfuerzo = Math.Pow(l, 3) / (Math.Pow(ck, 3) * Math.Pow(td, 4));
            Session["Esfuerzo"] = esfuerzo;

            Response.Redirect("Resultado.aspx");
        }
    }
}