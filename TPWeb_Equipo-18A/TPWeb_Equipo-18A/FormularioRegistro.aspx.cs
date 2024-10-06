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

        /*protected void btnParticipar_Click(object sender, EventArgs e)
        {
            
            ClienteNegocio cnegocio = new Negocio.ClienteNegocio();
            string voucher = Session["voucher"].ToString();
            int idProducto = int.Parse(Session["IDArt"].ToString());
           
            

            if (cliente != null && cliente.ID > 0)
            {
                VoucherNegocio voucherNegocio = new VoucherNegocio();
                voucherNegocio.cargarUso(voucher, idProducto, cliente.ID);
                lblClienteExistente.Visible = false;
                // Redireccionar o mostrar mensaje de éxito
                lblExito.Text = "El registro se realizó con éxito, ya estás participando";
                lblExito.Visible = true; // Hacer visible el mensaje
                btnRegresar.Visible = true;

            }
            else
            {


                // Crear nuevo cliente si no existe
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


                if (cliente.ID == 0)
                {
                    cnegocio.agregarCliente(cliente);
                }
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
                btnRegresar.Visible = false;


                // Redireccionar o mostrar mensaje de éxito
                lblExito.Text = "El registro se realizó con éxito, ya estás participando";
                lblExito.Visible = true;
                btnRegresar.Visible = true;


            }



        }*/

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            ClienteNegocio cnegocio = new Negocio.ClienteNegocio();
            string voucher = Session["voucher"].ToString();
            int idProducto = int.Parse(Session["IDArt"].ToString());

            // Primero, busca al cliente en la base de datos por su documento.
            cliente = cnegocio.buscarCliente(int.Parse(txtDocumento.Text));

            // Si el cliente ya existe (cliente.ID > 0), no lo agregamos de nuevo.
            if (cliente != null && cliente.ID > 0)
            {
                VoucherNegocio voucherNegocio = new VoucherNegocio();
                voucherNegocio.cargarUso(voucher, idProducto, cliente.ID);
                lblClienteExistente.Visible = false;
                btnParticipar.Visible = false;

                // Mensaje de éxito
                lblExito.Text = "El registro se realizó con éxito, ya estás participando";
                lblExito.Visible = true;
                btnRegresar.Visible = true;
            }
            else
            {
                // Si el cliente no existe, lo creamos.
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

                // Luego de agregar, buscamos nuevamente el cliente para asegurarnos de tener todos los datos actualizados.
                cliente = cnegocio.buscarCliente(int.Parse(cliente.Documento));

                VoucherNegocio voucherNegocio = new VoucherNegocio();
                voucherNegocio.cargarUso(voucher, idProducto, cliente.ID);

                // Deshabilitar los campos del formulario
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtMail.Enabled = false;
                txtDireccion.Enabled = false;
                txtCiudad.Enabled = false;
                txtCP.Enabled = false;

                btnParticipar.Visible = false;
                btnRegresar.Visible = true;

                // Mensaje de éxito
                lblExito.Text = "El registro se realizó con éxito, ya estás participando";
                lblExito.Visible = true;
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

               

                if (cliente != null && cliente.ID > 0) // Asegurarse de que el cliente realmente exista
                {
                    lblClienteExistente.Visible = true;
                    lblClienteExistente.Text = "Cliente existente";

                    // Cargar los datos del cliente en los campos de texto
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

                    btnParticipar.Visible = true; // Ocultar botón si ya es un cliente existente
                    btnRegresar.Visible = false;


                }
                else // Si el cliente no existe
                {
                    cliente = null; // Asegurarse de limpiar el objeto cliente
                    lblClienteExistente.Visible = false;
                    activarOpciones(); // Habilitar los campos para un nuevo cliente
                }
            }
            else
            {
                lblClienteExistente.Visible = true;
                lblClienteExistente.Text = "DNI inválido";
            }
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