<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Xml.aspx.cs" Inherits="EjercicioCXml.Xml" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>DOM: Elija un producto</h3>
            <hr />
            <div>
                <asp:DropDownList ID="ddlProducto" runat="server"></asp:DropDownList>
                <label style="margin-left: 20px">Cantidad: </label>
                <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
            </div>
            <hr />

            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="BtnEnviar_Click" />
            <div>
                <label>Precio: </label>
                <asp:Label ID="lblPrecio" runat="server"></asp:Label>
            </div>
            <div>
                <label>Total: </label>
                <asp:Label ID="lblTotal" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
