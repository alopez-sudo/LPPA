<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoVehiculos.aspx.cs" Inherits="BuyMotors.UI.ListadoVehiculos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
			<asp:GridView ID="gvVehiculos" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive table-striped table-hover">
				<Columns>
					<asp:BoundField DataField="Patente" HeaderText="Patente" />
					<asp:BoundField DataField="Tipo.Nombre" HeaderText="Tipo" />
					<asp:BoundField DataField="Categoria.Nombre" HeaderText="Categoría" />
					<asp:BoundField DataField="Modelo.Marca.Nombre" HeaderText="Marca" />
					<asp:BoundField DataField="Modelo.Nombre" HeaderText="Modelo" />
					<asp:BoundField DataField="Color.Nombre" HeaderText="Color" />
					<asp:BoundField DataField="AnioFabricacion" HeaderText="Año Fabricación" />
					<asp:BoundField DataField="Precio" HeaderText="Precio" />
				</Columns>
				<HeaderStyle CssClass="thead-dark" />
			</asp:GridView>
        </div>
    </form>
</body>
</html>
