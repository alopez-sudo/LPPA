<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EjercicioEXml.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            xpathNavigator<br />
            <br />
            Seleccione una cuenta
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            <br />
            <br />
            Saldo actual
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            Titular
            <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
            &nbsp; Activo
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            <hr />
            <asp:Button ID="Button1" runat="server" Text="Pedir datos" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
