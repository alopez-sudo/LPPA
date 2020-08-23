<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="CalcularEsfuerzoSesion.Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label>Fórmula para calcular el esfuerzo (K)</label>
            <br />
            <label>L - Líneas de código (en miles)</label>
            <asp:TextBox id="txtL" runat="server"></asp:TextBox>
            <br />
            <label>Ck - Constante tecnológica de desarrollo</label>
            <asp:TextBox id="txtCk" runat="server"></asp:TextBox>
            <br />
            <label id="tets">Td - Tiempo de desarrollo (en años)</label>
            <asp:TextBox id="txtTd" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnCalcularEsfuerzo" Text="Calcular esfuerzo (K)" runat="server" OnClick="BtnCalcularEsfuerzo_Click" />
        </div>
    </form>
</body>
</html>
