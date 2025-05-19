using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using modeloDatos;
using baseDatos;
using validaciones;

namespace capaLogica
{
    public class GestorArticulos
    {
        private AccesoBaseDatos _accesoDatos = new AccesoBaseDatos();
        private GestorMarcas _gestorMarcas = new GestorMarcas();
        private GestorCategorias _gestorCategorias = new GestorCategorias();
        private GestorImagenes _gestorImagenes = new GestorImagenes();

        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            try
            {
                lista = _accesoDatos.Listar();
                foreach (Articulo articulo in lista)
                {
                    articulo.Imagenes = _gestorImagenes.Listar(articulo.Id);
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar artículos: " + ex.Message);
                return new List<Articulo>();
            }
        }

        public void Agregar(Articulo articulo)
        {
            try
            {
                _gestorMarcas.ValidarOMantener(articulo.Marca);
                _gestorCategorias.ValidarOMantener(articulo.Categoria);

                _accesoDatos.SetearConsulta("INSERT INTO Articulos (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
                _accesoDatos.AgregarParametro("@Codigo", articulo.Codigo);
                _accesoDatos.AgregarParametro("@Nombre", articulo.Nombre);
                _accesoDatos.AgregarParametro("@Descripcion", articulo.Descripcion);
                _accesoDatos.AgregarParametro("@IdMarca", articulo.Marca.Id);
                _accesoDatos.AgregarParametro("@IdCategoria", articulo.Categoria.Id);
                _accesoDatos.AgregarParametro("@ImagenUrl", articulo.ImagenUrl);
                _accesoDatos.AgregarParametro("@Precio", articulo.Precio);
                _accesoDatos.EjecutarAccion();

                int idArticulo = _accesoDatos.ObtenerUltimoId("Articulos");
                _gestorImagenes.GuardarImagenes(articulo.Imagenes, idArticulo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar artículo: " + ex.Message);
            }
        }

        public void Modificar(Articulo articulo)
        {
            try
            {
                _gestorMarcas.ValidarOMantener(articulo.Marca);
                _gestorCategorias.ValidarOMantener(articulo.Categoria);

                _accesoDatos.SetearConsulta("UPDATE Articulos SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio WHERE Id = @Id");
                _accesoDatos.AgregarParametro("@Id", articulo.Id);
                _accesoDatos.AgregarParametro("@Codigo", articulo.Codigo);
                _accesoDatos.AgregarParametro("@Nombre", articulo.Nombre);
                _accesoDatos.AgregarParametro("@Descripcion", articulo.Descripcion);
                _accesoDatos.AgregarParametro("@IdMarca", articulo.Marca.Id);
                _accesoDatos.AgregarParametro("@IdCategoria", articulo.Categoria.Id);
                _accesoDatos.AgregarParametro("@ImagenUrl", articulo.ImagenUrl);
                _accesoDatos.AgregarParametro("@Precio", articulo.Precio);
                _accesoDatos.EjecutarAccion();

                _gestorImagenes.GuardarImagenes(articulo.Imagenes, articulo.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar artículo: " + ex.Message);
            }
        }

        public void EliminarArticulo(int id)
        {
            try
            {
                _accesoDatos.SetearConsulta("DELETE FROM Articulos WHERE Id = @Id");
                _accesoDatos.AgregarParametro("@Id", id);
                _accesoDatos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar artículo: " + ex.Message);
            }
        }
    }

    public class GestorMarcas
    {
        private AccesoBaseDatos _accesoDatos = new AccesoBaseDatos();

        public List<Marca> Listar()
        {
            List<Marca> lista = new List<Marca>();
            try
            {
                _accesoDatos.SetearConsulta("SELECT Id, Descripcion FROM Marcas");
                _accesoDatos.EjecutarLectura();
                while (_accesoDatos.Lector.Read())
                {
                    Marca marca = new Marca
                    {
                        Id = (int)_accesoDatos.Lector["Id"],
                        Descripcion = _accesoDatos.Lector["Descripcion"].ToString()
                    };
                    lista.Add(marca);
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar marcas: " + ex.Message);
                return new List<Marca>();
            }
            finally { _accesoDatos.CerrarConexion(); }
        }

        public int ObtenerId(Marca marca)
        {
            try
            {
                _accesoDatos.SetearConsulta("SELECT Id FROM Marcas WHERE Descripcion = @Descripcion");
                _accesoDatos.AgregarParametro("@Descripcion", marca.Descripcion);
                _accesoDatos.EjecutarLectura();
                if (_accesoDatos.Lector.Read())
                {
                    return (int)_accesoDatos.Lector["Id"];
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener ID de marca: " + ex.Message);
                return 0;
            }
            finally { _accesoDatos.CerrarConexion(); }
        }

        public void Agregar(Marca marca)
        {
            try
            {
                _accesoDatos.SetearConsulta("INSERT INTO Marcas (Descripcion) VALUES (@Descripcion)");
                _accesoDatos.AgregarParametro("@Descripcion", marca.Descripcion);
                _accesoDatos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar marca: " + ex.Message);
            }
            finally { _accesoDatos.CerrarConexion(); }
        }

        public void ValidarOMantener(Marca marca)
        {
            if (marca.Id == 0)
            {
                marca.Id = ObtenerId(marca);
                if (marca.Id == 0)
                {
                    Agregar(marca);
                    marca.Id = ObtenerUltimoId("Marcas");
                }
            }
        }
        public int ObtenerUltimoId(string tabla)
        {
            return _accesoDatos.ObtenerUltimoId(tabla);
        }
    }

    public class GestorCategorias
    {
        private AccesoBaseDatos _accesoDatos = new AccesoBaseDatos();

        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();
            try
            {
                _accesoDatos.SetearConsulta("SELECT Id, Descripcion FROM Categorias");
                _accesoDatos.EjecutarLectura();
                while (_accesoDatos.Lector.Read())
                {
                    Categoria categoria = new Categoria
                    {
                        Id = (int)_accesoDatos.Lector["Id"],
                        Descripcion = _accesoDatos.Lector["Descripcion"].ToString()
                    };
                    lista.Add(categoria);
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar categorías: " + ex.Message);
                return new List<Categoria>();
            }
            finally { _accesoDatos.CerrarConexion(); }
        }

        public int ObtenerId(Categoria categoria)
        {
            try
            {
                _accesoDatos.SetearConsulta("SELECT Id FROM Categorias WHERE Descripcion = @Descripcion");
                _accesoDatos.AgregarParametro("@Descripcion", categoria.Descripcion);
                _accesoDatos.EjecutarLectura();
                if (_accesoDatos.Lector.Read())
                {
                    return (int)_accesoDatos.Lector["Id"];
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener ID de categoría: " + ex.Message);
                return 0;
            }
            finally { _accesoDatos.CerrarConexion(); }
        }

        public void Agregar(Categoria categoria)
        {
            try
            {
                _accesoDatos.SetearConsulta("INSERT INTO Categorias (Descripcion) VALUES (@Descripcion)");
                _accesoDatos.AgregarParametro("@Descripcion", categoria.Descripcion);
                _accesoDatos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar categoría: " + ex.Message);
            }
            finally { _accesoDatos.CerrarConexion(); }
        }

        public void ValidarOMantener(Categoria categoria)
        {
            if (categoria.Id == 0)
            {
                categoria.Id = ObtenerId(categoria);
                if (categoria.Id == 0)
                {
                    Agregar(categoria);
                    categoria.Id = ObtenerUltimoId("Categorias");
                }
            }
        }

        public int ObtenerUltimoId(string tabla)
        {
            return _accesoDatos.ObtenerUltimoId(tabla);
        }
    }

    public class GestorImagenes
    {
        private AccesoBaseDatos _accesoDatos = new AccesoBaseDatos();

        public List<Imagen> Listar(int idArticulo)
        {
            List<Imagen> lista = new List<Imagen>();
            try
            {
                _accesoDatos.SetearConsulta("SELECT Id, ImagenUrl FROM Imagenes WHERE IdArticulo = @IdArticulo");
                _accesoDatos.AgregarParametro("@IdArticulo", idArticulo);
                _accesoDatos.EjecutarLectura();
                while (_accesoDatos.Lector.Read())
                {
                    Imagen img = new Imagen((int)_accesoDatos.Lector["Id"], _accesoDatos.Lector["ImagenUrl"].ToString());
                    lista.Add(img);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar imágenes: " + ex.Message);
            }
            finally { _accesoDatos.CerrarConexion(); }
        }

        public void GuardarImagenes(List<Imagen> imagenes, int idArticulo)
        {
            foreach (Imagen img in imagenes)
            {
                _accesoDatos.SetearConsulta("INSERT INTO Imagenes (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");
                _accesoDatos.AgregarParametro("@IdArticulo", idArticulo);
                _accesoDatos.AgregarParametro("@ImagenUrl", img.Url);
                _accesoDatos.EjecutarAccion();
            }
        }

        public void Agregar(Imagen imagen, int idArticulo)
        {
            try
            {
                _accesoDatos.SetearConsulta("INSERT INTO Imagenes (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");
                _accesoDatos.AgregarParametro("@IdArticulo", idArticulo);
                _accesoDatos.AgregarParametro("@ImagenUrl", imagen.Url);
                _accesoDatos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar imagen: " + ex.Message);
            }
            finally { _accesoDatos.CerrarConexion(); }
        }

        public void Modificar(Imagen imagen)
        {
            try
            {
                _accesoDatos.SetearConsulta("UPDATE Imagenes SET ImagenUrl = @ImagenUrl WHERE Id = @Id");
                _accesoDatos.AgregarParametro("@Id", imagen.Id);
                _accesoDatos.AgregarParametro("@ImagenUrl", imagen.Url);
                _accesoDatos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar imagen: " + ex.Message);
            }
            finally { _accesoDatos.CerrarConexion(); }
        }

        public void Eliminar(int idImagen)
        {
            try
            {
                _accesoDatos.SetearConsulta("DELETE FROM Imagenes WHERE Id = @Id");
                _accesoDatos.AgregarParametro("@Id", idImagen);
                _accesoDatos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar imagen: " + ex.Message);
            }
            finally { _accesoDatos.CerrarConexion(); }
        }
    }
}

