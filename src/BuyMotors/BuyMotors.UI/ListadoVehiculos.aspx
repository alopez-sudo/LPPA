<%@ Page Language="C#" Title="Listado Vehiculos" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoVehiculos.aspx.cs" Inherits="BuyMotors.UI.ListadoVehiculos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<h2>Listado de vehículos</h2>
		<div class="row col-md-12">
			<div class="form-group col-md-4">
				<label for="inputPatente">Patente</label>
				<asp:TextBox ID="TxtPatente" placeholder="Patente" CssClass="form-control" runat="server"></asp:TextBox>
			</div>
			<div class="form-group col-md-4">
				<label for="inputPrecioDesde">Precio Desde</label>
				<asp:TextBox ID="TxtPrecioDesde" placeholder="Precio desde" CssClass="form-control" runat="server"></asp:TextBox>
			</div>
			<div class="form-group col-md-4">
				<label for="inputPrecioHasta">Precio Hasta</label>
				<asp:TextBox ID="TxtPrecioHasta" placeholder="Precio Hasta" CssClass="form-control" runat="server"></asp:TextBox>
			</div>
		</div>
		<div class="row col-md-12">
			<div class="form-group col-md-4">
				<asp:Button ID="BtnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="BtnBuscar_Click" />
				<asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar" CssClass="btn" OnClick="BtnLimpiar_Click" />
			</div>
		</div>
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
				<asp:TemplateField HeaderText="Acción">
					<ItemTemplate>
						<asp:HyperLink ID="VehiculoDetalleHyperlink" runat="server" NavigateUrl='<%# Eval("Id", @"~\VehiculoDetalle.aspx?CodigoVehiculo={0}") %>' Text="Ver Detalle" CssClass="btn btn-primary"></asp:HyperLink>
					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
			<HeaderStyle CssClass="thead-dark" />
		</asp:GridView>
	</div>
</asp:Content>
