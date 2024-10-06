<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="FormularioRegistro.aspx.cs" Inherits="TPWeb_Equipo_18A.FormularioRegistro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



   <div class="row">
    <div class="col-3"></div>
    <div class="col">
        <div class="mb-3">
            <br />
            <label for="txtDocumento" class="form-label">Ingrese su número de DNI:</label>
            <asp:TextBox ID="txtDocumento" CssClass="form-control" runat="server" OnTextChanged="txtDocumento_TextChanged" AutoPostBack="true"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDocumento" ControlToValidate="txtDocumento" runat="server" ErrorMessage="El DNI es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
            <br />
            <div id="InformacionPersonal" visible="false">
                <!-- Aquí aseguramos que cada campo solo tenga una definición -->
                <asp:Label ID="lblNombre" for="txtNombre" runat="server" class="form-label">Nombre:</asp:Label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" ControlToValidate="txtNombre" runat="server" ErrorMessage="El nombre es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>

                <asp:Label ID="lblApellido" for="txtApellido" runat="server" class="form-label">Apellido:</asp:Label>
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvApellido" ControlToValidate="txtApellido" runat="server" ErrorMessage="El apellido es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>

                <!-- Resto de los campos -->
                <asp:Label ID="lblMail" for="txtMail" runat="server" class="form-label">Email:</asp:Label>
                <asp:TextBox ID="txtMail" Type="email" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMail" ControlToValidate="txtMail" runat="server" ErrorMessage="El email es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>

                <asp:Label ID="lblDireccion" for="txtDireccion" runat="server" class="form-label">Dirección:</asp:Label>
                <asp:TextBox ID="txtDireccion" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDireccion" ControlToValidate="txtDireccion" runat="server" ErrorMessage="La dirección es obligatoria" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>

                <asp:Label ID="lblCiudad" for="txtCiudad" runat="server" class="form-label">Ciudad:</asp:Label>
                <asp:TextBox ID="txtCiudad" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCiudad" ControlToValidate="txtCiudad" runat="server" ErrorMessage="La ciudad es obligatoria" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>

                <asp:Label ID="lblCP" for="txtCP" runat="server" class="form-label">Código Postal:</asp:Label>
                <asp:TextBox ID="txtCP" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCP" ControlToValidate="txtCP" runat="server" ErrorMessage="El código postal es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
            
            </div>

            <!-- Label para mostrar si el cliente ya existe -->
            <asp:Label ID="lblClienteExistente" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
            <asp:Label ID="lblExito" runat="server" Text="" ForeColor="Green" Visible="false"></asp:Label>
        </div>

        <asp:Button ID="btnParticipar" runat="server" Text="Participar!" OnClick="btnParticipar_Click" CssClass="btn btn-primary"/>
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" CssClass="btn btn-primary"/>
    </div>

    <div class="col-3"></div>
</div>


</asp:Content>
