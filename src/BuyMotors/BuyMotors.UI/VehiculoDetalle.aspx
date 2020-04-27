<%@ Page Language="C#" Title="Listado Vehiculos" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VehiculoDetalle.aspx.cs" Inherits="BuyMotors.UI.VehiculoDetalle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<asp:HiddenField ID="HiddenVehiculoId" runat="server" />
	<asp:HiddenField ID="HiddenVehiculoPrecio" runat="server" />
	<h1>Detalle del Vehículo</h1>
	<h3><asp:Label id="LblTipoVehiculo" runat="server" /> - 
	<asp:Label id="LblMarca" runat="server" /> - 
	<asp:Label id="LblModelo" runat="server" /> - 
	<asp:Label id="LblColor" runat="server" /> - 
	<asp:Label id="LblCategoria" runat="server" /></h3><br />
	<h3>Precio: $<asp:Label id="LblPrecio" runat="server" /></h3><br />
	<h3>Modelo: <asp:Label id="LblAnioFabricacion" runat="server" /></h3><br /><br />
	<asp:Image ID="ImgFotoVehiculo" runat="server" CssClass="size-imagen-vehiculo" /><br /><br />
	<asp:Button ID="BtnAgregarAlCarrito" runat="server" Text="Agregar al Carrito" CssClass="btn btn-primary" OnClick="BtnAgregarAlCarrito_Click" />
	<asp:HyperLink ID="VolverHyperlink" runat="server" NavigateUrl='~\ListadoVehiculos.aspx' Text="Volver a Listado" CssClass="btn btn-default"></asp:HyperLink>
</asp:Content>
