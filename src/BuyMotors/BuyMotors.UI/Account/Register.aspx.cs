﻿using System;
using System.Web.UI;
using BuyMotors.BE;
using BuyMotors.BL;

namespace BuyMotors.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Un usuario logueado no debería estar en esta página
            if (Session["UsuarioLogueado"] != null)
            {
                Response.Redirect("../Default.aspx");
            }
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario
            {
                Apellido = LastName.Text,
                Contrasenia = Password.Text,
                Email = Email.Text,
                Nombre = FirstName.Text,
                Telefono = PhoneNumber.Text
            };

            bool guardadoOk = UsuarioManager.Guardar(usuario, out string mensaje);
            if (guardadoOk)
            {
                // Dejo al usuario logueado
                Session["UsuarioLogueado"] = usuario;
                Response.Redirect("../Default.aspx");
            }
            else
            {
                ErrorMessage.Text = mensaje;
            }
        }
    }
}