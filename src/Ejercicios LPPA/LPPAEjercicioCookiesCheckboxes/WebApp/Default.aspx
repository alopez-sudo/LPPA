<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Home</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>Elija un día de actividad</div>
		<br />
		<asp:CheckBox ID="Checkbox1" Text="Lunes" runat="server" /><br />
		<asp:CheckBox ID="Checkbox2" Text="Martes" runat="server" /><br />
		<asp:CheckBox ID="Checkbox3" Text="Miercoles" runat="server" /><br />
		<asp:CheckBox ID="Checkbox4" Text="Jueves" runat="server" /><br />
		<asp:CheckBox ID="Checkbox5" Text="Viernes" runat="server" /><br />
        <p>
            <asp:Button ID="BtnEnviar" runat="server" OnClick="BtnEnviar_Click" Text="Enviar" />
        </p>
    </form>
</body>
</html>
