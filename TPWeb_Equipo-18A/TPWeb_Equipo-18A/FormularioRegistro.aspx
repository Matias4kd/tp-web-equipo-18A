<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="FormularioRegistro.aspx.cs" Inherits="TPWeb_Equipo_18A.FormularioRegistro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
        <div class="col-3"></div>
        <div class="col">
            <div class="mb-3">
                <br />
                <label for="txtDocumento" class="form-label">Ingrese su numero de DNI:</label>
                <asp:TextBox ID="txtDocumento" CssClass="form-control" runat="server" OnTextChanged="txtDocumento_TextChanged" AutoPostBack="true" ></asp:TextBox>
                <br />               
                <div id="InformacionPersonal" visible="false">
                    <asp:Label ID="lblNombre" for="txtNombre" runat="server" class="form-label">Nombre:</asp:Label>
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>

                    <asp:Label ID="lblApellido" for="txtApellido" runat="server" class="form-label">Apellido:</asp:Label>
                    <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>

                    <asp:Label ID="lblMail" for="txtMail" runat="server" class="form-label">Email:</asp:Label>
                    <asp:TextBox ID="txtMail" Type="email" CssClass="form-control" runat="server"></asp:TextBox>

                    <asp:Label ID="lblDireccion" for="txtDireccion" runat="server" class="form-label">Direccion:</asp:Label>
                    <asp:TextBox ID="txtDireccion" CssClass="form-control" runat="server"></asp:TextBox>

                    
                    <asp:Label ID="lblCiudad" for="txtCiudad" runat="server" class="form-label">Ciudad:</asp:Label>
                    <asp:TextBox ID="txtCiudad" CssClass="form-control" runat="server"></asp:TextBox>

                    <asp:Label ID="lblCP" for="txtCP" runat="server" class="form-label">Codigo Postal:</asp:Label>
                    <asp:TextBox ID="txtCP" CssClass="form-control" runat="server"></asp:TextBox>

                </div>


            </div>

            <asp:Button ID="btnParticipar" runat="server" Text="Participar!" OnClick="btnParticipar_Click" CssClass="btn btn-primary"/>
        </div>

        <div class="col-3"></div>
    </div>


</asp:Content>
