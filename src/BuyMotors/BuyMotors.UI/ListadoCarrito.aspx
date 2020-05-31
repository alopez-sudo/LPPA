<%@ Page Language="C#" Title="Carrito de Compras" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoCarrito.aspx.cs" Inherits="BuyMotors.UI.ListadoCarrito" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<div class="row col-md-12">
			<h2>Mi Carrito de Compras</h2>
			<asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
				<p class="text-danger">
					<asp:Literal runat="server" ID="FailureText" />
				</p>
			</asp:PlaceHolder>
			<asp:GridView ID="gvCarrito" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive table-striped table-hover" OnRowCommand="gvCarrito_RowCommand">
				<Columns>
					<asp:BoundField DataField="Vehiculo.Descripcion" HeaderText="Descripcion" />
					<asp:BoundField DataField="Precio" HeaderText="Precio" />
					<asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
					<asp:TemplateField HeaderText="Acción">
						<ItemTemplate>
							<asp:Button ID="BtnEliminar" runat="server" CausesValidation="false" CommandName="EliminarDetalle" Text="Eliminar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" />
						</ItemTemplate>
					</asp:TemplateField>
				</Columns>
				<HeaderStyle CssClass="thead-dark" />
			</asp:GridView>
			<asp:Button ID="BtnFinalizarCompra" runat="server" Text="Finalizar compra" OnClick="BtnFinalizarCompra_Click" />
			<h3><asp:Label id="LblResultado" runat="server" Text="El carrito está vacio" /></h3>
		</div>
	</div>
</asp:Content>
