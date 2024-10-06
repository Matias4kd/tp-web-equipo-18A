using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
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
       


        public int agregarCliente(Cliente cliente)
        {
            try
            {
                // Consulta para insertar el cliente y obtener el ID generado automáticamente
                datos.setearConsulta("INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) " +
                                     "OUTPUT INSERTED.Id " + // Esto devuelve el ID generado automáticamente
                                     "VALUES (@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP)");

                // Establece los parámetros con los valores del cliente
                datos.setearParametro("@Documento", cliente.Documento);
                datos.setearParametro("@Nombre", cliente.Nombre);
                datos.setearParametro("@Apellido", cliente.Apellido);
                datos.setearParametro("@Email", cliente.Mail);
                datos.setearParametro("@Direccion", cliente.Direccion);
                datos.setearParametro("@Ciudad", cliente.Ciudad);
                datos.setearParametro("@CP", cliente.CodigoPostal);

               
                int clienteId = (int)datos.ejecutarEscalar(); //  para obtener el ID

                return clienteId; // Devuelve el ID del cliente recién creado
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
