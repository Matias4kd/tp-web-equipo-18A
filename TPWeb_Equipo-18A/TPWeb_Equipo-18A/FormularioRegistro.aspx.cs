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
        public bool ClienteExistente = false;
        
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
            ClienteNegocio cnegocio = new Negocio.ClienteNegocio();
            Cliente cliente = new Cliente(); 

            cliente = cnegocio.buscarCliente(int.Parse(cliente.Documento));
            cliente.Documento = txtDocumento.Text;
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Mail = txtMail.Text;
            cliente.Direccion = txtDireccion.Text;
            cliente.Ciudad = txtCiudad.Text;
            cliente.CodigoPostal = int.Parse(txtCP.Text);

            if(cliente.ID == 0)
            {
                cnegocio.agregarCliente(cliente);
            }

            string voucher = Session["voucher"].ToString();
            int idProducto = int.Parse(Session["IDArt"].ToString());
 
            cliente = cnegocio.buscarCliente(int.Parse(cliente.Documento));

            VoucherNegocio voucherNegocio = new VoucherNegocio();

            voucherNegocio.cargarUso(voucher,idProducto, cliente.ID);
        }

        protected void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            int dniParticipante = int.Parse(txtDocumento.Text);
            Negocio.ClienteNegocio cnegocio = new Negocio.ClienteNegocio();
            Cliente cliente = new Cliente();
            cliente = cnegocio.buscarCliente(dniParticipante);

            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtMail.Text = cliente.Mail;
            txtDireccion.Text = cliente.Direccion;
            txtCiudad.Text = cliente.Ciudad;
            txtCP.Text = cliente.CodigoPostal.ToString();
                       
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