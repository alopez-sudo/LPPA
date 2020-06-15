<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ejercicio1Cookies.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Apellido</div>
        <asp:TextBox ID="TxtApellido" runat="server"></asp:TextBox>
        <br />
        Edad<br />
        <asp:TextBox ID="TxtEdad" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="BtnEnviar" runat="server" OnClick="BtnEnviar_Click" Text="Enviar" />
        </p>
    </form>
</body>
</html>
