<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWeb_Equipo_18A.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <div class="row">
        <div class="col-4"></div>
        <div class="col">

            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Ingrese su código:</label>
                <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Label ID="lblError" runat="server" Text="" color="red"></asp:Label>
            </div>
            <asp:Button ID="btnVerificar" runat="server" Text="Verificar" OnClick="btnVerificar_Click" CssClass="btn btn-primary"/>
        </div>

        <div class="col-4"></div>
    </div>

</asp:Content>
