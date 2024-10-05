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
        public int verificarVoucher(string voucher)
        {
            AccesoDatos datos = new AccesoDatos();
            

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
    }
}
