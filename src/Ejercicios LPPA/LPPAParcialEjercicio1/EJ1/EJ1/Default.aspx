<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EJ1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" method="post" action="Calculo.aspx">
        <div>
            APELLIDO
            <input type="text" id="apellido" name="apellido" />
            EDAD
            <input type="text" id="edad" name="edad"/>
        </div>
        <input type="submit" value="Enviar" />
        
    </form>
</body>
</html>