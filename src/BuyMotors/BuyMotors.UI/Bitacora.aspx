<%@ Page Language="C#" Title="Bitacora" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="BuyMotors.UI.Bitacora" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<h2>Bitácora</h2>
		<asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>
		<div class="row col-md-12">
			<div class="form-group col-md-4">
				<label for="TxtFechaDesde">Fecha desde</label>
				<asp:TextBox ID="TxtFechaDesde" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
			</div>
			<div class="form-group col-md-4">
				<label for="TxtFechaHasta">Fecha hasta</label>
				<asp:TextBox ID="TxtFechaHasta" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
			</div>
			<div class="form-group col-md-4">
				<label for="TxtUsuario">Usuario</label>
				<asp:TextBox ID="TxtUsuario" CssClass="form-control" runat="server"></asp:TextBox>
			</div>
		</div>
		<div class="row col-md-12">
			<div class="form-group col-md-4">
				<asp:Button ID="BtnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="BtnBuscar_Click" />
			</div>
		</div>
		<asp:GridView ID="gvBitacora" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive table-striped table-hover">
			<Columns>
				<asp:BoundField DataField="Fecha" HeaderText="Fecha" />
				<asp:BoundField DataField="Usuario" HeaderText="Usuario" />
				<asp:BoundField DataField="Detalle" HeaderText="Detalle" />
			</Columns>
			<HeaderStyle CssClass="thead-dark" />
		</asp:GridView>
	</div>
</asp:Content>