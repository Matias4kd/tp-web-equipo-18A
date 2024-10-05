using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Negocio
{
    public class ClienteNegocio
    {
		AccesoDatos datos = new AccesoDatos();
        public Cliente buscarCliente(int Dni)
        {
			Cliente aux = new Cliente();
			try
			{

				datos.setearConsulta("SELECT ID,Documento,Nombre,Apellido,Email,Direccion,Ciudad,CP FROM Clientes where Documento = @dni");
				datos.setearParametro("@dni", Dni);

				datos.ejecutarLectura();

				if (datos.Lector.Read())
				{
					aux.ID = (int)datos.Lector["ID"];
					aux.Documento = Dni.ToString();
					aux.Nombre = (string)datos.Lector["Nombre"];
					aux.Apellido = (string)datos.Lector["Apellido"];
					aux.Mail = (string)datos.Lector["Email"];
					aux.Direccion = (string)datos.Lector["Direccion"];
					aux.Ciudad = (string)datos.Lector["Ciudad"];
					aux.CodigoPostal = (int)datos.Lector["CP"];
                }
				return aux;
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				datos.cerrarConexion();
			}
        }
    }
}
