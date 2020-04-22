<%@ Page Language="C#" Title="Backup" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Backup.aspx.cs" Inherits="BuyMotors.UI.Backup" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<h2>Backup</h2>
		<asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>
		<asp:PlaceHolder runat="server" ID="SuccessMessage" Visible="false">
            <p class="text-success">
                <asp:Literal runat="server" ID="SuccessText" />
            </p>
        </asp:PlaceHolder>
		<div class="row col-md-12">
			<div class="form-group col-md-4">
				<asp:Button ID="BtnBackup" runat="server" Text="Realizar un backup" CssClass="btn btn-primary" OnClick="BtnBackup_Click" />
			</div>
		</div>
		<asp:GridView ID="gvBackups" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive table-striped table-hover">
			<Columns>
				<asp:BoundField DataField="Fecha" HeaderText="Backups realizados" />
				<asp:TemplateField HeaderText="Acción">
					<ItemTemplate>
						<asp:Button runat="server" Text="Restaurar" CommandArgument='<%# Eval("NombreArchivo") %>' CssClass="btn btn-primary" OnClick="BtnRestaurar_Click" />
					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
			<HeaderStyle CssClass="thead-dark" />
		</asp:GridView>
	</div>
</asp:Content>