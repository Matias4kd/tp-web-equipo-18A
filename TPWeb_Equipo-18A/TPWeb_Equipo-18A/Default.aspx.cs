using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPWeb_Equipo_18A
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        protected void btnVerificar_Click(object sender, EventArgs e)
        {
            
            string voucherIngresado = txtCodigo.Text;
            VoucherNegocio negocio = new VoucherNegocio();

            

            switch (negocio.verificarVoucher(voucherIngresado))
            {
                case -1:
                    lblError.Text = "El voucher ingresado es invalido";
                    lblError.Visible = true;
                    break;
                case 0:
                    lblError.Text = "El voucher ingresado ya fue utilizado, intente nuevamente";
                    lblError.Visible = true;
                    break;
                case 1:
                    Session.Add("voucher", voucherIngresado);
                    Response.Redirect("Catalogo.aspx");
                    break;
                default:
                    break;
            }

        }
    }
}