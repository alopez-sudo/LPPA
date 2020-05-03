<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculo.aspx.cs" Inherits="EJ1.Calculo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>PAGINA DE VUELTA</title>
    <%
        string ape;
        Int16 ed;
        string edadenmeses;

        ape = Request.Form["APELLIDO"];
        ed = Convert.ToInt16( Request.Form["EDAD"]);
        edadenmeses = Convert.ToString( ed*12);


        %>
    <%Response.Write(ape); %>
    SU EDAD EN MESES ES 
    <%Response.Write(edadenmeses); %>

</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
