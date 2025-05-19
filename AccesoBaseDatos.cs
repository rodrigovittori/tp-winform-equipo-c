using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using tp_winform_equipo_c;
using modeloDatos;
using System.Windows.Forms;

namespace baseDatos
{
    public class AccesoBaseDatos
    {
        private const string cadenaConexion = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true;";

        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = @"SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion,
                                    m.Id AS IdMarca, m.Descripcion AS Marca,
                                    c.Id AS IdCategoria, c.Descripcion AS Categoria,
                                    a.ImagenUrl, a.Precio
                             FROM ARTICULOS a
                             JOIN MARCAS m ON m.Id = a.IdMarca
                             JOIN CATEGORIAS c ON c.Id = a.IdCategoria";

                    SqlCommand comando = new SqlCommand(query, conexion);
                    SqlDataReader lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        Articulo art = new Articulo();
                        art.Id = (int)lector["Id"];
                        art.Codigo = lector["Codigo"].ToString();
                        art.Nombre = lector["Nombre"].ToString();
                        art.Descripcion = lector["Descripcion"].ToString();
                        art.ImagenUrl = lector["ImagenUrl"].ToString();
                        art.Precio = (decimal)lector["Precio"];

                        art.Marca = new Marca
                        {
                            Id = (int)lector["IdMarca"],
                            Descripcion = lector["Marca"].ToString()
                        };

                        art.Categoria = new Categoria
                        {
                            Id = (int)lector["IdCategoria"],
                            Descripcion = lector["Categoria"].ToString()
                        };

                        lista.Add(art);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Error en base de datos: " + sqlEx.Message);
                return new List<Articulo>(); // o throw si querés propagar
            }

            return lista;
        }

    } // Fin de Clase AccesoBaseDatos

} // Fin de namespace baseDatos