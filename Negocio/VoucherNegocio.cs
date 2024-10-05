using dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VoucherNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public int verificarVoucher(string voucher)
        {
            

            datos.setearConsulta("SELECT CodigoVoucher, FechaCanje FROM Vouchers WHERE CodigoVoucher = @voucher");
            datos.setearParametro("@voucher", voucher);
            datos.ejecutarLectura();

            try
            {
                if(datos.lector.Read()){

                    
                    if (!(datos.lector["FechaCanje"] is DBNull))
                        return 0;
                    
                }
                else
                {
                    return -1;
                }
                              
                return 1;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
                throw ex;

            }
            finally
            {
                datos.cerrarConexion();
            }
            
        }

        public void cargarUso(string voucher, int idArticulo, int idUsuario)
        {
            try
            {
                DateTime fecha = DateTime.Now;
                datos.setearConsulta("update Vouchers set Idcliente = @idcliente, FechaCanje = @fecha, IdArticulo = @idart WHERE CodigoVoucher = @voucher");
                datos.setearParametro("@idcliente", idUsuario);
                datos.setearParametro("@fecha",fecha);
                datos.setearParametro("@idart", idArticulo);
                datos.setearParametro("@voucher", voucher);

                datos.ejecutarLectura();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
