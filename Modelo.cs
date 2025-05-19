using System.Collections.Generic;
using System.ComponentModel;

namespace modeloDatos
{
    public class Articulo
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Código")]
        public string Codigo { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [DisplayName("Marca")]
        public Marca Marca { get; set; }

        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; }

        [DisplayName("Imagen principal")]
        public string ImagenUrl { get; set; }

        [DisplayName("Imágenes")]
        public List<Imagen> Imagenes { get; set; }

        [DisplayName("Precio")]
        public decimal Precio { get; set; }

        public Articulo()
        {
            Marca = new Marca();
            Categoria = new Categoria();
            Imagenes = new List<Imagen>();
        }
    }

    public class Marca
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString() => Descripcion;
    }

    public class Categoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString() => Descripcion;
    }

    public class Imagen
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public Imagen() { }

        public Imagen(int id, string url)
        {
            Id = id;
            Url = url;
        }
    }

} // Fin del namespace modeloDatos
