using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ImagenNegocio
    {
        public Imagen ObtenerImagen(int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();

            datos.setearConsulta("SELECT ID,ImagenUrl From IMAGENES where IdArticulo = " + idArticulo + "");
            datos.ejecutarLectura();

            Imagen imagen = new Imagen();
            imagen.IdArticulo = idArticulo;

            while (datos.lector.Read())  // recorremos los resultados de la consulta
            {
                imagen.UrlImagen = (string)datos.lector["ImagenUrl"];
                imagen.Id = (int)datos.lector["Id"];
                datos.cerrarConexion();
                return imagen;
            }

            datos.cerrarConexion();
            return null;
        }

        public void agregar(Imagen imgNueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into IMAGENES values(" + imgNueva.IdArticulo + ", '" + imgNueva.UrlImagen + "')");
                datos.ejecutarAccion();
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
        public void modificar(Imagen modificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update IMAGENES set ImagenUrl = @url WHERE Id = @idImagen");
                datos.setearParametro("@url", modificado.UrlImagen);
                datos.setearParametro("@idImagen", modificado.Id);
                

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
        
}



