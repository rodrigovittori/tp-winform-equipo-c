namespace modeloDatos
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public string ImagenUrl { get; set; }
        public decimal Precio { get; set; }
    } // Fin de clase Articulo

    public class Marca
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public override string ToString() => Descripcion;
    } // Fin de clase Marca

    public class Categoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString() => Descripcion;
    } // Fin de Clase Categoria

} // Fin del namespace modeloDatos