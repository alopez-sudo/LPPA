<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XML.aspx.cs" Inherits="EjercicioBXml.XML" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <strong>
                    <font size="4">Escribir datos en un documento XML</font>
                </strong>
            </p>
            <hr width="100%" noShade size="3" />
            <p>
                <asp:Label ID="Label" runat="server" Font-Bold="true" style="margin-right: 10px;">Nombre: </asp:Label>
                <asp:TextBox ID="NombreTxt" runat="server" Width="106px"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label1" runat="server" Font-Bold="true" style="margin-right: 10px;">Apellido: </asp:Label>
                <asp:TextBox ID="ApellidoTxt" runat="server" Width="106px"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label2" runat="server" Font-Bold="true" style="margin-right: 10px;">Dirección: </asp:Label>
                <asp:TextBox ID="DireccionTxt" runat="server" Width="106px"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" Text="Crear documento" Font-Bold="true" Font-Italic="true" Font-Names="Microsoft Sans Serif" OnClick="Button1_Click" />
            </p>
        </div>
    </form>
</body>
</html>
