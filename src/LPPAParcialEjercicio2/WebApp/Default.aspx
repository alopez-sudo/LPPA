<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
	<meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0" />
	<title>VIAJES Y TURISMO</title>

	<asp:PlaceHolder runat="server">
		<%: Scripts.Render("~/bundles/modernizr") %>
	</asp:PlaceHolder>

	<webopt:BundleReference runat="server" Path="~/Content/css" />
	<link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
|
	<script>
		function validar() {
			var radios = document.getElementsByName("destino");
			if (radios[0].checked == false && radios[1].checked == false) {
				alert("Debe seleccionar un destino");
				return true;
			}
			return true;
		}
	</script>
</head>

<body>
	<div class="container body-content">

		<h3>Formulario de Cotización</h3>

		<form id="dato" method="post" action="vuelta.aspx" runat="server">
			<asp:ScriptManager runat="server">
				<Scripts>
					<asp:ScriptReference Name="MsAjaxBundle" />
					<asp:ScriptReference Name="jquery" />
					<asp:ScriptReference Name="bootstrap" />
					<asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
					<asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
					<asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
					<asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
					<asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
					<asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
					<asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
					<asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
					<asp:ScriptReference Name="WebFormsBundle" />
				</Scripts>
			</asp:ScriptManager>

			<div class="form-group">
				<label>¿Donde va de vacaciones?</label>
				<div class="form-group">
					<asp:RadioButtonList ID="destino" runat="server" RepeatLayout="Flow">
						<asp:ListItem Value="Mar del Plata"> Mar del Plata</asp:ListItem>
						<asp:ListItem Value="Niza"> Niza</asp:ListItem>
					</asp:RadioButtonList>
				</div>
			</div>

			<div class="form-group">
				<label>¿Cual es la categoría?</label>
				<div class="form-group">
					<asp:RadioButtonList ID="estrella" runat="server" RepeatLayout="Flow">
						<asp:ListItem Value="Tres"> Tres</asp:ListItem>
						<asp:ListItem Value="Cuatro"> Cuatro</asp:ListItem>
					</asp:RadioButtonList>
				</div>
			</div>

			<div class="form-group">
				<label>Cantidad de Personas</label>
				<div class="form-group">
					<asp:TextBox ID="TxtCantidad" runat="server" CssClass="form-control" />
				</div>
			</div>

			<div class="form-group">
				<label>Cantidad de días</label>
				<div class="form-group">
					<asp:TextBox ID="TxtDias" runat="server" CssClass="form-control" />
				</div>
			</div>

			<div class="form-group">
				<asp:Button ID="BtnEnviar" runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="BtnEnviar_Click" OnClientClick="javascript:return validar();" />
			</div>

		</form>

		<hr />
		<footer>
			<p>&copy; <%: DateTime.Now.Year %> - LPPA - 1er. Parcial - Ejercicio N°2</p>
		</footer>
	</div>
</body>
</html>
