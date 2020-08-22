<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ControlesDeValidacion.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Que comience con P y 4 números seguidos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Inserte un código de producto que comience con "P" (mayúscula) y con cuatro números seguidos
        </div>
        <div>
            <asp:TextBox ID="CodigoProducto" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="AA" ControlToValidate="CodigoProducto" Text="Este campo debe llenarse" runat="server"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="BB" ControlToValidate="CodigoProducto" Text="Ese código de producto es inválido" ValidationExpression="P[0-9]{4}" runat="server"></asp:RegularExpressionValidator>
        </div>
        <br />
        <div>
            <asp:Button ID="CC" Text="Enviar" runat="server" OnClick="BotonClick" />
        </div>
    </form>
</body>
</html>
