<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EjercicioDXml.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <Font size="4"><strong>XpathDocument</strong></Font>
        <hr width="100%" size="1" />
        <p></p>
        <p>
            <em><strong>Cuentas en Barcelona</strong></em>
            <asp:ListBox ID="ListBox1" runat="server" Width="137px" Rows="2"></asp:ListBox>
        </p>
        <asp:Button ID="Button1" runat="server" Text="Actualizar cuentas" Font-Bold="true" Font-Italic="True" OnClick="Button1_Click" />
        <hr width="100%" size="1" />
    </form>
</body>
</html>
