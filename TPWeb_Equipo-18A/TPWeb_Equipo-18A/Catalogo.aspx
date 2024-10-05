<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TPWeb_Equipo_18A.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Elegí Tu premio: </h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <div class="card-img-top">
                        <%--aca va el carrousel de imagenes--%>
                        </div>
                    </div>
                    <div class="card-body">
                        <h5 class="card-title"><%#Eval("Nombre") %></h5>
                        <p class="card-text"><%#Eval("Descripcion")%></p>
                        <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" OnClick="btnSelccionar_Click" CssClass="btn btn-primary" CommandArgument='<%# Eval("IDArticulo") %>' />
                </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
