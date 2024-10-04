using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public class ArticuloNegocio
	{
		public List<Articulo> listar()
		{
			List<Articulo> lista = new List<Articulo>();
			AccesoDatos datos = new AccesoDatos();

			try
			{

				datos.setearConsulta("SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.Precio, a.IdCategoria, a.IdMarca, c.Descripcion AS Categoria, m.Descripcion AS Marca FROM ARTICULOS a JOIN CATEGORIAS c ON a.IdCategoria = c.Id JOIN MARCAS m ON a.IdMarca = m.Id");
				datos.ejecutarLectura();


				while (datos.lector.Read())  // recorremoss los resultados de la consulta
				{
					Articulo articulo = new Articulo();
					articulo.IdArticulo = (int)datos.lector["Id"];
					articulo.Codigo = (string)datos.lector["Codigo"];
					articulo.Nombre = (string)datos.lector["Nombre"];
					articulo.Descripcion = (string)datos.lector["Descripcion"];
					articulo.Precio = (decimal)datos.lector["Precio"];

					
					articulo.Marca = new Marca();
					articulo.Marca.NombreMarca = (string)datos.lector["Marca"];  
                    articulo.Marca.IdMarca = (int)datos.lector["idMarca"];

					articulo.Categoria = new Categoria();
					articulo.Categoria.descripcion = (string)datos.lector["Categoria"];  
                    articulo.Categoria.id = (int)datos.lector["IdCategoria"];


					lista.Add(articulo);  // añadir articulo a la lista
				}

				return lista;



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


        public List<Articulo> listarPorCategoria(int categoriaId)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Consulta SQL para filtrar por categoría
                string consulta = @"
        SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, C.Descripcion AS Categoria, M.Descripcion AS Marca
        FROM ARTICULOS A
        INNER JOIN MARCAS M ON A.IdMarca = M.Id
        INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id
        WHERE C.Id = @categoriaId";

                // Establecer la consulta y el parámetro
                datos.setearConsulta(consulta);
                datos.setearParametro("@categoriaId", categoriaId);


                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.IdArticulo = (int)datos.Lector["Id"];
                    articulo.Codigo = (string)datos.Lector["Codigo"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Precio = (decimal)datos.Lector["Precio"];


                    articulo.Marca = new Marca();
                    articulo.Marca.NombreMarca = (string)datos.Lector["Marca"];

                    articulo.Categoria = new Categoria();
                    articulo.Categoria.descripcion = (string)datos.Lector["Categoria"];

                    lista.Add(articulo);
                }

                return lista;
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


        public void agregar(Articulo nuevo)
		{
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setearConsulta("Insert into ARTICULOS VALUES('"+nuevo.Codigo+"', '"+nuevo.Nombre+"', '"+nuevo.Descripcion+"',"+nuevo.Marca.IdMarca+" ,"+nuevo.Categoria.id+","+nuevo.Precio+")");
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

        public void modificar(Articulo modificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio WHERE Id = @idArticulo");
                datos.setearParametro("@codigo", modificado.Codigo);
                datos.setearParametro("@nombre", modificado.Nombre);
                datos.setearParametro("@descripcion", modificado.Descripcion);
                datos.setearParametro("@idMarca", modificado.Marca.IdMarca);
                datos.setearParametro("@idCategoria", modificado.Categoria.id);
                datos.setearParametro("@precio", modificado.Precio);
                datos.setearParametro("@idArticulo", modificado.IdArticulo);

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

		public Articulo buscarArticulo(Articulo art)
		{
			AccesoDatos datos = new AccesoDatos();

			try
			{
                string consulta = @"
				SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, C.Descripcion AS Categoria, M.Descripcion AS Marca
				FROM ARTICULOS A
				INNER JOIN MARCAS M ON A.IdMarca = M.Id
				INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id
				WHERE A.Codigo = @codigoArticulo";

                datos.setearConsulta(consulta);
                datos.setearParametro("@codigoArticulo", art.Codigo);

                datos.ejecutarLectura();

                Articulo articulo = new Articulo();

                if (datos.Lector.Read())
                {
                    articulo.IdArticulo = (int)datos.Lector["Id"];
                    articulo.Codigo = (string)datos.Lector["Codigo"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Precio = (decimal)datos.Lector["Precio"];


                    articulo.Marca = new Marca();
                    articulo.Marca.NombreMarca = (string)datos.Lector["Marca"];

                    articulo.Categoria = new Categoria();
                    articulo.Categoria.descripcion = (string)datos.Lector["Categoria"];

                }

				return articulo;

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

        public void eliminar(int id) 
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from ARTICULOS where Id = @id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
