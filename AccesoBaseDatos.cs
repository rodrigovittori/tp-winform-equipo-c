using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

using modeloDatos;

namespace baseDatos
{
    public class AccesoBaseDatos
    {
        private const string cadenaConexion = "Server=localhost\\SQLEXPRESS; Database=CATALOGO_P3_DB; Trusted_Connection=True;";
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector => lector;

        public AccesoBaseDatos()
        {
            conexion = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
        }

        public void SetearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void AgregarParametro(string clave, object valor)
        {
            comando.Parameters.AddWithValue(clave, valor);
        }

        public void EjecutarLectura()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar lectura: " + ex.Message);
            }
            finally
            {
                comando.Parameters.Clear();
            }
        }

        public void EjecutarAccion()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar acción: " + ex.Message);
            }
            finally
            {
                comando.Parameters.Clear();
            }
        }

        public int EjecutarEscalar()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                return (int)comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar escalar: " + ex.Message);
            }
            finally
            {
                comando.Parameters.Clear();
            }
        }

        public int ObtenerUltimoId(string tabla)
        {
            int ultimoId = 0;
            SetearConsulta("SELECT IDENT_CURRENT(@Tabla) AS UltimoId");
            AgregarParametro("@Tabla", tabla);
            EjecutarLectura();

            if (lector.Read())
                ultimoId = Convert.ToInt32(lector["UltimoId"]);

            CerrarConexion();
            return ultimoId;
        }


        public void CerrarConexion()
        {
            lector?.Close();
            conexion.Close();
        }

        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = @"
                        SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion,
                               m.Id AS IdMarca, m.Descripcion AS Marca,
                               c.Id AS IdCategoria, c.Descripcion AS Categoria,
                               (SELECT TOP 1 ImagenUrl FROM IMAGENES i WHERE i.IdArticulo = a.Id) AS ImagenUrl,
                               a.Precio
                        FROM ARTICULOS a
                        JOIN MARCAS m ON m.Id = a.IdMarca
                        JOIN CATEGORIAS c ON c.Id = a.IdCategoria";

                    SqlCommand comando = new SqlCommand(query, conexion);
                    SqlDataReader lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        Articulo art = new Articulo
                        {
                            Id = (int)lector["Id"],
                            Codigo = lector["Codigo"].ToString(),
                            Nombre = lector["Nombre"].ToString(),
                            Descripcion = lector["Descripcion"].ToString(),
                            ImagenUrl = lector["ImagenUrl"].ToString(),
                            Precio = (decimal)lector["Precio"],
                            Marca = new Marca
                            {
                                Id = (int)lector["IdMarca"],
                                Descripcion = lector["Marca"].ToString()
                            },
                            Categoria = new Categoria
                            {
                                Id = (int)lector["IdCategoria"],
                                Descripcion = lector["Categoria"].ToString()
                            }
                        };

                        lista.Add(art);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Error en base de datos: " + sqlEx.Message);
                return new List<Articulo>();
            }

            return lista;
        }
    } // Fin de Clase AccesoBaseDatos

} // Fin de namespace baseDatos