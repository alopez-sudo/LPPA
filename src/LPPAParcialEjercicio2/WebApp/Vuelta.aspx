<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vuelta.aspx.cs" Inherits="WebApp.Vuelta" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
	<meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0" />
	<title>VIAJES Y TURISMO</title>

	<asp:PlaceHolder runat="server">
		<%: Scripts.Render("~/bundles/modernizr") %>
	</asp:PlaceHolder>

	<webopt:bundlereference runat="server" path="~/Content/css" />
	<link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>

<body>
	<div class="container body-content">

		<h3>Cotización Vacaciones</h3>

		<form id="dato" method="post"  runat="server">
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

			<h4>Destino: <asp:Label id="LblDestino" runat="server" /></h4>
			<h4>Categoría: <asp:Label id="LblCategoria" runat="server" /></h4>
			<h4>Cantidad de personas: <asp:Label id="LblCantidadDePersonas" runat="server" /></h4>
			<h4>Cantidad de días: <asp:Label id="LblCantidadDeDias" runat="server" /></h4>

		</form>

		<hr />
		<footer>
			<p>&copy; <%: DateTime.Now.Year %> - LPPA - 1er. Parcial - Ejercicio N°2</p>
		</footer>
	</div>
</body>
</html>
