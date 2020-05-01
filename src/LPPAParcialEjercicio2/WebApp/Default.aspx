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

	<script>
		function validar() {
			if (!document.getElementById("opMarDelPlata").checked && !document.getElementById("opNiza").checked) {
				alert("Debe seleccionar un destino");
				return false;
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
					<asp:RadioButton ID="opMarDelPlata" runat="server" GroupName="destino" Text="&nbsp;Mar del Plata" />
				</div>
				<div class="form-group">
					<asp:RadioButton ID="opNiza" runat="server" GroupName="destino" Text="&nbsp;Niza" />
				</div>
			</div>

			<%-- demas campos --%>

			<div class="form-group">
				<asp:Button ID="BtnBuscar" runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="BtnEnviar_Click" OnClientClick="javascript:return validar();" />
			</div>

		</form>

		<hr />
		<footer>
			<p>&copy; <%: DateTime.Now.Year %> - LPPA - 1er. Parcial - Ejercicio N°2</p>
		</footer>
	</div>
</body>
</html>
