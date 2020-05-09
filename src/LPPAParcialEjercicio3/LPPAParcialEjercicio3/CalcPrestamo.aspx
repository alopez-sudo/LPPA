<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalcPrestamo.aspx.cs" Inherits="LPPAParcialEjercicio3.CalcPrestamo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Otorgamiento del préstamo</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%= Apellido %>
        </div>
        <div>
            <%= Edad %>
        </div>
        <div>
            <%= Mensaje %>
        </div>
        <div>
            <input type="button" value="Volver a la página principal" onclick="javascript: location.href = 'Default.aspx';" />
        </div>
    </form>
</body>
</html>
