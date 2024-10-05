using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace TPWeb_Equipo_18A
{
    public partial class FormularioRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblNombre.Visible = false;
                txtNombre.Visible = false;
                lblApellido.Visible = false;
                txtApellido.Visible = false;
                lblMail.Visible = false;
                txtMail.Visible = false;
                lblDireccion.Visible = false;
                txtDireccion.Visible = false;
                lblCiudad.Visible = false;
                txtCiudad.Visible = false;
                lblCP.Visible = false;
                txtCP.Visible = false;
                btnParticipar.Visible = false;
            }
            else
            {
                activarOpciones();
            }
            
        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            
        }

        protected void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            int dniParticipante = int.Parse(txtDocumento.Text);
            Negocio.ClienteNegocio cnegocio = new Negocio.ClienteNegocio();

            dominio.Cliente aux = cnegocio.buscarCliente(dniParticipante);

            txtNombre.Text = aux.Nombre;
            txtApellido.Text = aux.Apellido;
            txtMail.Text = aux.Mail;
            txtDireccion.Text = aux.Direccion;
            txtCiudad.Text = aux.Ciudad;
            txtCP.Text = aux.CodigoPostal.ToString();
        }

        void activarOpciones()
        {
            lblNombre.Visible = true;
            txtNombre.Visible = true;
            lblApellido.Visible = true;
            txtApellido.Visible = true;
            lblMail.Visible = true;
            txtMail.Visible = true;
            lblDireccion.Visible = true;
            txtDireccion.Visible = true;
            lblCiudad.Visible = true;
            txtCiudad.Visible = true;
            lblCP.Visible = true;
            txtCP.Visible = true;
            btnParticipar.Visible = true;
        }
    }
}