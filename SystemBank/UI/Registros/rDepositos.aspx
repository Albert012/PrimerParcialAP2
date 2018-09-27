﻿<%@ Page Title="Depositos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rDepositos.aspx.cs" Inherits="SystemBank.UI.Registros.rDepositos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-row">
        <%--DepositoId--%>
        <div class="form-group col-md-3">
            <asp:Label Text="Deposito Id" class="text-primary" runat="server" />
            <asp:TextBox ID="DepositoIdTextBox" class="form-control input-group" TextMode="Number" placeholder="0" runat="server" />
        </div>
        <%--Fecha--%>
        <div class="form-group col-md-3">
            <asp:Label Text="Fecha" runat="server" />
            <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
        </div>

        <%--Boton--%>
        <div class="col-lg-1 p-0">
            <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-outline-info mt-4" runat="server" OnClick="BuscarLinkButton_Click">
                        <span class="fas fa-search"></span>
                        Buscar
                    </asp:LinkButton>
        </div>

    </div>

    <div class="form-row">
        <%--CuentaId--%>
        <div class="form-group col-md-3">
            <asp:Label Text="Cuenta" runat="server" />
            <asp:DropDownList ID="CuentaDropDownList" class="form-control input-sm" runat="server">
                <asp:ListItem Selected="True">[Seleccione]</asp:ListItem>
            </asp:DropDownList>
        </div>


        <%--Concepto--%>
        <div class="form-group col-md-3">
            <asp:Label Text="Concepto" runat="server" />
            <asp:TextBox ID="ConceptoTextBox" class="form-control input-sm" placeholder="Concepto Deposito" runat="server" />
        </div>

    </div>

    <div class="form-row">
        <%--Monto--%>
        <div class="form-group col-md-3">
            <asp:Label Text="Monto" runat="server" />
            <asp:TextBox ID="MontoTextBox" TextMode="Number" class="form-control input-sm" placeholder="0" runat="server" />
        </div>
    </div>

    <asp:Label ID="MensajeLabel" runat="server" Text=""></asp:Label>

    <%--Botones--%>
    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">
                <asp:Button Text="Nuevo" class="btn btn-outline-info btn-md" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                <asp:Button Text="Guardar" class="btn btn-outline-success btn-md" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" />
                <asp:Button Text="Eliminar" class="btn btn-outline-danger btn-md" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />

            </div>
        </div>
    </div>





</asp:Content>
