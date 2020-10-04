<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EjercicioIntegradorXml.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Lectura con XmlTextReader</h3>
            <asp:Button ID="btnLeerConXmlTextReader" runat="server" Text="Leer con XmlTextReader" OnClick="BtnLeerConXmlTextReader_Click" />
            <br />
            <div>
                <asp:Label ID="lblDatos" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
