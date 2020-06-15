<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ejercicio2Cookies.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
			Formulario de cotización
		</div>
		<br />
		<div>
			<label>¿Dónde va de vacaciones?</label>
			<div>
				<asp:RadioButtonList ID="RadDestino" runat="server" >
					<asp:ListItem Text="Mar del Plata" Value="mdelplata" />
					<asp:ListItem Text="Niza" Value="niza" />
				</asp:RadioButtonList>
				<asp:RequiredFieldValidator ID="VV" ControlToValidate="RadDestino" Text="Este campo debe llenarse" runat="server"></asp:RequiredFieldValidator><br />
			</div>
		</div>
		<br />
		<div>
			<label>¿Cuál es la categoría?</label>
			<div>
				<asp:RadioButtonList ID="RadCategoria" runat="server" >
					<asp:ListItem Text="Tres Estrellas" Value="tres" />
					<asp:ListItem Text="Cuatro Estrellas" Value="cuatro" />
				</asp:RadioButtonList>
				<asp:RequiredFieldValidator ID="XX" ControlToValidate="RadCategoria" Text="Este campo debe llenarse" runat="server"></asp:RequiredFieldValidator><br />
			</div>
		</div>
		<br />
		<div>
			<label>Cantidad de Personas</label>
			<div>
            <asp:TextBox ID="TxtCantidadPersonas" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="AA" ControlToValidate="TxtCantidadPersonas" Text="Este campo debe llenarse" runat="server"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="BB" ControlToValidate="TxtCantidadPersonas" Text="La cantidad de personas debe ser entre 1 y 99." ValidationExpression="[1-9][0-9]|[1-9]" runat="server"></asp:RegularExpressionValidator>
			</div>
		</div>
		<br />
		<div>
			<label>Cantidad de días</label>
			<div>
			<asp:TextBox ID="TxtCantidadDias" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="CC" ControlToValidate="TxtCantidadDias" Text="Este campo debe llenarse" runat="server"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="DD" ControlToValidate="TxtCantidadDias" Text="La cantidad de días debe ser entre 1 y 365." ValidationExpression="([1-2][0-9][0-9]|3[0-5][0-9]|36[0-5]|[1-9][0-9]|[1-9])" runat="server"></asp:RegularExpressionValidator>
			</div>
		</div>
		<br />
		<div>
			<asp:Button ID="BtnEnviar" text="Enviar" runat="server" OnClick="BtnEnviar_Click" />
		</div>

    </form>
</body>
</html>
