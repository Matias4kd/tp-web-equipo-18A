using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using dominio;

namespace TPWeb_Equipo_18A
{
    public partial class Catalogo : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo{ get; set; }
        public List<Imagen> ListaImagenes{ get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulo = negocio.listar();
            //ImagenNegocio Inegocio = new ImagenNegocio();
            //ListaImagenes = Inegocio.ObtenerImagenes();

        }

        protected void btnSelccionar_Click(object sender, EventArgs e)
        {

        }
    }
}