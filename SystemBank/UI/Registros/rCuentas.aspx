<%@ Page Title="Cuentas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rCuentas.aspx.cs" Inherits="SystemBank.UI.Registros.rCuentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-row">
        <%--CuentaId--%>
        <div class="form-group col-md-3">
            <asp:Label Text="Cuenta Id" class="text-primary" runat="server" />
            <asp:TextBox ID="CuentaIdTextBox" class="form-control input-group" TextMode="Number" placeholder="0" runat="server" />
        </div>
        <%--Fecha--%>
        <div class="form-group col-md-3">
            <asp:Label Text="Fecha" runat="server" />
            <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
        </div>
    </div>

    <div class="form-row">
        <%--Nombre--%>
        <div class="form-group col-md-3">
            <asp:Label Text="Nombre" runat="server" />
            <asp:TextBox ID="NombreTextBox" class="form-control input-sm"  runat="server" />
        </div>

        <%--Balance--%>
        <div class="form-group col-md-3">
            <asp:Label Text="Balance" runat="server" />
            <asp:TextBox ID="BalanceTextBox" TextMode="Number" class="form-control input-sm"  runat="server" />
        </div>

    </div>

    <%--Botones--%>
    <div class="panel-footer">
            <div class="text-center">
                <div class="form-group" style="display: inline-block">
                    <asp:Button Text="Nuevo" class="btn btn-outline-info btn-md"  runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                    <asp:Button Text="Guardar" class="btn btn-outline-success btn-md" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" />
                    <asp:Button Text="Eliminar" class="btn btn-outline-danger btn-md" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />

                </div>
            </div>
        </div>



</asp:Content>
