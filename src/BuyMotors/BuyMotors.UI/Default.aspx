﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BuyMotors._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h2>Bienvenido a BuyMotors</h2>
        <div class="col-md-4">
            <p><a href="ListadoVehiculos" class="btn btn-primary btn-lg">Vehiculos</a></p>
        </div>
        <% if (mostrarBotonBitacora)
            {%>
        <div class="col-md-4">
            <p><a href="Bitacora" class="btn btn-primary btn-lg">Bitácora</a></p>
        </div>
        <% } %>
        <% if (mostrarBotonBackup)
            {%>
        <div class="col-md-4">
            <p><a href="Backup" class="btn btn-primary btn-lg">Backups</a></p>
        </div>
        <% } %>
    </div>
    <div class="row">
        <asp:AdRotator id="AdVehiculos" runat="server"
            Target="_blank"
            AdvertisementFile="~/Content/Ads.xml"/>
    </div>
</asp:Content>
