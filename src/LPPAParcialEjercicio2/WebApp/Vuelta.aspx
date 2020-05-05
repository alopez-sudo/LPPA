<%@ Page Language="C#" %>
<!DOCTYPE html>

<html lang="en">
<head runat="server">
	<title>VUELTA</title>
	<%
		string destino = Request.Form["destino"];
		string categoria = Request.Form["estrella"];
		int cantidadPersonas = int.Parse(Request.Form["personas"]);
		int cantidadDias = int.Parse(Request.Form["dias"]);

		double precio = destino == "MdelPlata" ? 2000 : 30000;
		if (categoria == "Cuatro")
		{
			precio *= 1.2;
		}

		precio *= cantidadPersonas;
		precio *= cantidadDias;

		Session["Precio"] = precio;
	%>
</head>
<body>
	<form id="form1" runat="server">
		El costo es $
		<% Response.Write(Session["Precio"]); %>
		<div>
			<input value="Retornar a la página de inicio" id="back" type="button" onclick="javascript:location.href='Default.aspx'" />
		</div>
	</form>
</body>
</html>
