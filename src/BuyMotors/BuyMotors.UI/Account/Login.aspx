<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BuyMotors.Account.Login" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Utilice una cuenta local para iniciar sesión.</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Correo electrónico</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" 
                                ErrorMessage="El campo de correo electrónico es obligatorio." ValidationGroup="Login" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" 
                                ErrorMessage="El campo de correo electrónico es obligatorio." ValidationGroup="ForgotPassword" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Contraseña</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" 
                                ErrorMessage="El campo de contraseña es obligatorio." ValidationGroup="Login" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="LogIn" Text="Iniciar sesión" CssClass="btn btn-default" ValidationGroup="Login" />
                            <span style="margin-left:30px;">
                                <asp:LinkButton ID="ForgotPasswordLinkButton" runat="server" OnClick="ForgotPasswordLinkButton_Click" ValidationGroup="ForgotPassword">Olvidé mi contraseña</asp:LinkButton>
                            </span>
                        </div>
                    </div>
                </div>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" NavigateUrl='~/Account/Register.aspx'>Registrarse como usuario nuevo</asp:HyperLink>
                </p>
            </section>
        </div>
    </div>
</asp:Content>