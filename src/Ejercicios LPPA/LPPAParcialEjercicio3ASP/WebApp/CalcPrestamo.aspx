<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalcPrestamo.aspx.cs" Inherits="WebApp.CalcPrestamo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Otorgamiento del préstamo</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <% Response.Write(Apellido); %>
        </div>
        <div>
            <% Response.Write(Edad); %>
        </div>
        <div>
            <% Response.Write(Mensaje); %>
        </div> 
        <div>
            
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Volver a la página principal" />
        </div>
    </form>

</body>
</html>