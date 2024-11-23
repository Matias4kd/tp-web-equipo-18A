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
        private Cliente cliente = new Cliente();
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
                btnRegresar.Visible = false;

                // Ocultar mensaje de cliente existente
                lblClienteExistente.Visible = false;
            }
            else
            {
                activarOpciones();
            }

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {

            Response.Redirect("Default.aspx");

        }



        protected void btnParticipar_Click(object sender, EventArgs e)
        {

            if (!Page.IsValid)
            {
                lblExito.Text = "Por favor, complete todos los campos obligatorios.";
                lblExito.ForeColor = System.Drawing.Color.Red;
                lblExito.Visible = true;
                return;
            }

            ClienteNegocio cnegocio = new Negocio.ClienteNegocio();
            string voucher = Session["voucher"].ToString();
            int idProducto = int.Parse(Session["IDArt"].ToString());

            // Buusca al cliente en la base de datos por su documento.
            cliente = cnegocio.buscarCliente(int.Parse(txtDocumento.Text));

            // Si el cliente ya existe (cliente.ID > 0), no lo agregamos de nuevo, asociamos idcliente al codigo voucher
            if (cliente != null && cliente.ID > 0)
            {
                VoucherNegocio voucherNegocio = new VoucherNegocio();
                voucherNegocio.cargarUso(voucher, idProducto, cliente.ID);
                lblClienteExistente.Visible = false;
                btnParticipar.Visible = false;


                lblExito.Text = "El registro se realizó con éxito, ya estás participando";
                lblExito.Visible = true;
                btnRegresar.Visible = true;
            }
            else
            {
                // Cliente no existe, se crea
                cliente = new Cliente
                {
                    Documento = txtDocumento.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Mail = txtMail.Text,
                    Direccion = txtDireccion.Text,
                    Ciudad = txtCiudad.Text,
                    CodigoPostal = int.Parse(txtCP.Text)
                };

                // Llamamos a agregarCliente para insertar el nuevo cliente en la base de datos.
                int nuevoId = cnegocio.agregarCliente(cliente); // Este método debe devolver el ID del nuevo cliente.

                // buscamos nuevamente el cliente para asegurarnos de tener todos los datos actualizados.
                cliente = cnegocio.buscarCliente(int.Parse(cliente.Documento));

                VoucherNegocio voucherNegocio = new VoucherNegocio();
                voucherNegocio.cargarUso(voucher, idProducto, cliente.ID);


                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtMail.Enabled = false;
                txtDireccion.Enabled = false;
                txtCiudad.Enabled = false;
                txtCP.Enabled = false;

                btnParticipar.Visible = false;
                btnRegresar.Visible = true;


                lblExito.Text = "El registro se realizó con éxito, ya estás participando";
                lblExito.Visible = true;
                lblExito.ForeColor = System.Drawing.Color.Green;
            }
        }


        protected void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                Response.Redirect("FormularioRegistro.aspx");
            }

            int dniParticipante;

            if (int.TryParse(txtDocumento.Text, out dniParticipante))
            {
                Negocio.ClienteNegocio cnegocio = new Negocio.ClienteNegocio();
                cliente = cnegocio.buscarCliente(dniParticipante);

                if (cliente != null && cliente.ID > 0)
                {
                    lblClienteExistente.Visible = true;
                    lblClienteExistente.Text = "Cliente existente";

                    txtNombre.Text = cliente.Nombre;
                    txtApellido.Text = cliente.Apellido;
                    txtMail.Text = cliente.Mail;
                    txtDireccion.Text = cliente.Direccion;
                    txtCiudad.Text = cliente.Ciudad;
                    txtCP.Text = cliente.CodigoPostal.ToString();

                    // Deshabilitar campos para evitar modificaciones
                    txtNombre.Enabled = false;
                    txtApellido.Enabled = false;
                    txtMail.Enabled = false;
                    txtDireccion.Enabled = false;
                    txtCiudad.Enabled = false;
                    txtCP.Enabled = false;

                    btnParticipar.Visible = true;
                    btnRegresar.Visible = false;
                }
                else // Cliente no existe
                {
                    cliente = null; // Asegurarse de limpiar el objeto cliente
                    lblClienteExistente.Visible = false;
                    limpiarCampos(); // Limpiar los campos
                    activarOpciones(); // Habilitar los campos para un nuevo cliente
                }
            }
            else
            {
                lblClienteExistente.Visible = true;
                lblClienteExistente.Text = "DNI inválido";
                limpiarCampos(); // Limpiar los campos en caso de DNI inválido
            }
        }

        private void limpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtMail.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtCP.Text = string.Empty;

            // Habilitar los campos para edición
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtMail.Enabled = true;
            txtDireccion.Enabled = true;
            txtCiudad.Enabled = true;
            txtCP.Enabled = true;

            btnParticipar.Visible = false; // Ocultar el botón hasta que sea relevante
            btnRegresar.Visible = false;  // Mantener oculto inicialmente
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