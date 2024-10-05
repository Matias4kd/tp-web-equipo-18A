<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TPWeb_Equipo_18A.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Elegí Tu premio: </h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%foreach (dominio.Articulo art in ListaArticulo)
          {
        %>
            <div class="col">
                <div class="card">
                    <div class="card-img-top">
                        <div id="carousel" class="carousel slide">
                            <div class="carousel-inner">
                                <%  Negocio.ImagenNegocio negocio = new Negocio.ImagenNegocio();
                                    List<dominio.Imagen> listaImagenes = new List<dominio.Imagen>();
                                    listaImagenes = negocio.ObtenerImagenes(art.IdArticulo);
                                %>
                                <div class="carousel-item active">
                                    <img src=<%:listaImagenes[0].UrlImagen %> class="card-img-top" alt="...">
                                  </div>
                                <%--<%foreach (dominio.Imagen foto in listaImagenes)
                                  {%>
                                        <div class="carousel-item active">
                                            <img src=<%:foto.UrlImagen %> class="card-img-top" alt="...">
                                        </div>
                                <%} %>--%>
                            </div>
                            <button class="carousel-control-prev" type="button" data-bs-target="#carousel" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Previous</span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target="#carousel" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Next</span>
                            </button>
                        </div>
                    </div>
                
                    
                    <div class="card-body">
                        <h5 class="card-title"><%: art.Nombre %></h5>
                        <p class="card-text"><%:art.Descripcion %></p>
                        <asp:Button ID="btnSelccionar" runat="server" Text="Seleccionar" OnClick="btnSelccionar_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        <%}%>
    </div>
</asp:Content>
