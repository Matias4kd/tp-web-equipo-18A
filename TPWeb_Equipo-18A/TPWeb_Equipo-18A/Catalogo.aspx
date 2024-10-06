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
                        <div id="carousel_<%# Eval("IDArticulo") %>" class="carousel slide">
                            <div class="carousel-inner">
                                <asp:Repeater ID="repImages" runat="server" DataSource='<%# (Eval("ListImagen")) %>'>
                                    <ItemTemplate>
                                        <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                            <img src='<%# Eval("UrlImagen") %>' class="d-block w-100" alt="...">
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <button class="carousel-control-prev" type="button" data-bs-target="#carousel_<%# Eval("IDArticulo") %>" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Previous</span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target="#carousel_<%# Eval("IDArticulo") %>" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Next</span>
                            </button>
                        </div>
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
