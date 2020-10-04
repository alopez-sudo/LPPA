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
            <asp:Button ID="btnLeerConXmlTextReader" runat="server" Text="Leer" OnClick="BtnLeerConXmlTextReader_Click" />
            <br />
            <div>
                <asp:Label ID="lblDatos" runat="server"></asp:Label>
            </div>

            <hr />

            <h3>Escritura con XmlTextWriter</h3>
            Nombre: <asp:TextBox ID="txtNombreLibro1" runat="server"></asp:TextBox> 
            Autor: <asp:TextBox ID="txtAutorLibro1" runat="server"></asp:TextBox> 
            Editorial: <asp:TextBox ID="txtEditorialLibro1" runat="server"></asp:TextBox> 
            Precio: <asp:TextBox ID="txtPrecioLibro1" runat="server"></asp:TextBox> 
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El nombre del libro es requerido. " ControlToValidate="txtNombreLibro1"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El autor del libro es requerido. " ControlToValidate="txtAutorLibro1"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="La editorial del libro es requerida. " ControlToValidate="txtEditorialLibro1"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="El precio del libro es requerido. " ControlToValidate="txtPrecioLibro1"></asp:RequiredFieldValidator>
            <br />
            Nombre: <asp:TextBox ID="txtNombreLibro2" runat="server"></asp:TextBox> 
            Autor: <asp:TextBox ID="txtAutorLibro2" runat="server"></asp:TextBox> 
            Editorial: <asp:TextBox ID="txtEditorialLibro2" runat="server"></asp:TextBox> 
            Precio: <asp:TextBox ID="txtPrecioLibro2" runat="server"></asp:TextBox> 
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="El nombre del libro es requerido. " ControlToValidate="txtNombreLibro2"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="El autor del libro es requerido. " ControlToValidate="txtAutorLibro2"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="La editorial del libro es requerida. " ControlToValidate="txtEditorialLibro2"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="El precio del libro es requerido. " ControlToValidate="txtPrecioLibro2"></asp:RequiredFieldValidator>
            <br />
            Nombre: <asp:TextBox ID="txtNombreLibro3" runat="server"></asp:TextBox> 
            Autor: <asp:TextBox ID="txtAutorLibro3" runat="server"></asp:TextBox> 
            Editorial: <asp:TextBox ID="txtEditorialLibro3" runat="server"></asp:TextBox> 
            Precio: <asp:TextBox ID="txtPrecioLibro3" runat="server"></asp:TextBox> 
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="El nombre del libro es requerido. " ControlToValidate="txtNombreLibro3"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="El autor del libro es requerido. " ControlToValidate="txtAutorLibro3"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="La editorial del libro es requerida. " ControlToValidate="txtEditorialLibro3"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="El precio del libro es requerido. " ControlToValidate="txtPrecioLibro3"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="btnEscribirConXmlTextWriter" runat="server" Text="Agregar 3 libros" OnClick="BtnEscribirConXmlTextWriter_Click" />
            <br />
            <asp:Label ID="lblResultadoEscritura" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
