using System;
using System.Collections.Generic;
using System.Windows.Forms;
using modeloDatos;
using baseDatos;
using capaLogica;
using validaciones;
using System.Drawing;
using System.Threading.Tasks;

namespace tp_winform_equipo_c
{
    public partial class FormPrincipal : Form
    {
        /* >> ATRIBUTOS << */

        private Articulo articuloActual;
        private List<Articulo> listaArticulos;
        private List<Articulo> articulosFiltrados;
        private List<Imagen> listaImagenes = new List<Imagen>();
        private int indiceImagenActual = 0;

        private GestorArticulos gestorArticulos = new GestorArticulos();
        private GestorImagenes gestorImagenes = new GestorImagenes();
        private AccesoBaseDatos accesoDatos = new AccesoBaseDatos(); // Instancia de AccesoBaseDatos
        private FormularioRegistro formularioRegistro; // Instancia de FormularioRegistro

        public FormPrincipal()
        {
            InitializeComponent();
            formularioRegistro = new FormularioRegistro(); // Inicializar FormularioRegistro
        }

        /* >> EVENTOS << */

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            CargarArticulos();
            ConfigurarDataGridView();
        }

        private void CargarArticulos()
        {
            try
            {
                listaArticulos = accesoDatos.Listar(); // Llama al método Listar de AccesoBaseDatos
                articulosFiltrados = listaArticulos; // Inicializa la lista filtrada
                ActualizarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar artículos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            // Configuración de la DataGridView
            articlesDataGridView.AutoGenerateColumns = false;
            articlesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            articlesDataGridView.ReadOnly = true;
            articlesDataGridView.AllowUserToAddRows = false;
            articlesDataGridView.AllowUserToDeleteRows = false;

            // Definir las columnas de la grilla
            articlesDataGridView.Columns.Add("Id", "ID");
            articlesDataGridView.Columns["Id"].DataPropertyName = "Id";
            articlesDataGridView.Columns["Id"].Visible = false;

            articlesDataGridView.Columns.Add("Nombre", "Nombre");
            articlesDataGridView.Columns["Nombre"].DataPropertyName = "Nombre";

            articlesDataGridView.Columns.Add("Descripcion", "Descripción");
            articlesDataGridView.Columns["Descripcion"].DataPropertyName = "Descripcion";
            articlesDataGridView.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            articlesDataGridView.Columns.Add("Marca", "Marca");
            articlesDataGridView.Columns["Marca"].DataPropertyName = "Marca.Descripcion"; // Asume que Marca tiene una propiedad "Descripcion"

            articlesDataGridView.Columns.Add("Categoria", "Categoría");
            articlesDataGridView.Columns["Categoria"].DataPropertyName = "Categoria.Descripcion"; // Asume que Categoria tiene una propiedad "Descripcion"

            articlesDataGridView.Columns.Add("Precio", "Precio");
            articlesDataGridView.Columns["Precio"].DataPropertyName = "Precio";
            articlesDataGridView.Columns["Precio"].DefaultCellStyle.Format = "N2";

            EstilizarDataGridView();
            articlesDataGridView.DataSource = articulosFiltrados; // Establecer el origen de datos
        }

        private void EstilizarDataGridView()
        {
            // Estilos para la DataGridView
            articlesDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            articlesDataGridView.EnableHeadersVisualStyles = false;
            articlesDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            articlesDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            articlesDataGridView.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            articlesDataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void ActualizarDataGridView()
        {
            // Actualiza la DataGridView con la lista filtrada
            if (articlesDataGridView != null)
            {
                articlesDataGridView.DataSource = null; // Limpia el DataSource antes de reasignarlo
                articlesDataGridView.DataSource = articulosFiltrados;
                articlesDataGridView.Refresh();
                ResaltarArticulosInvalidos();
            }
        }

        private void ResaltarArticulosInvalidos()
        {
            // Resalta los artículos inválidos en la DataGridView
            foreach (DataGridViewRow row in articlesDataGridView.Rows)
            {
                Articulo articulo = (Articulo)row.DataBoundItem;
                if (!EsArticuloValido(articulo))
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private bool EsArticuloValido(Articulo articulo)
        {
            // Lógica para determinar si un artículo es válido
            if (articulo == null) return false;

            // Verifica que las propiedades requeridas tengan valores válidos
            return Validacion.ContieneDatos(articulo.Nombre) &&
                   Validacion.ContieneDatos(articulo.Descripcion) &&
                   articulo.Precio > 0 &&
                   articulo.Imagenes != null && articulo.Imagenes.Count > 0;
        }

        private void MostrarDetallesArticulo(Articulo articulo)
        {
            // Muestra los detalles del artículo en los labels y el PictureBox
            articuloActual = articulo;

            if (articulo != null)
            {
                idLabel.Text = $"ID: {articulo.Id}";
                nameLabel.Text = $"Nombre: {articulo.Nombre}";
                descriptionLabel.Text = $"Descripción: {articulo.Descripcion}";
                priceLabel.Text = $"Precio: {articulo.Precio:C}";
                brandLabel.Text = articulo.Marca != null ? $"Marca: {articulo.Marca.Descripcion}" : "Marca: N/A";
                categoryLabel.Text = articulo.Categoria != null ? $"Categoría: {articulo.Categoria.Descripcion}" : "Categoría: N/A";

                // Carga la primera imagen si existe
                if (articulo.Imagenes != null && articulo.Imagenes.Count > 0)
                {
                    indiceImagenActual = 0;
                    CargarImagen(articulo.Imagenes[indiceImagenActual].Url);
                    buttonPrevImg.Enabled = articulo.Imagenes.Count > 1;
                    buttonNextImg.Enabled = articulo.Imagenes.Count > 1;
                }
                else
                {
                    pictureBox.Image = null;
                    buttonPrevImg.Enabled = false;
                    buttonNextImg.Enabled = false;
                }
            }
            else
            {
                // Limpia los controles si no hay artículo seleccionado
                idLabel.Text = "ID: ";
                nameLabel.Text = "Nombre: ";
                descriptionLabel.Text = "Descripción: ";
                priceLabel.Text = "Precio: ";
                brandLabel.Text = "Marca: ";
                categoryLabel.Text = "Categoría: ";
                pictureBox.Image = null;
                buttonPrevImg.Enabled = false;
                buttonNextImg.Enabled = false;
            }
        }

        private void CargarImagen(string url)
        {
            // Carga una imagen en el PictureBox con manejo de errores
            try
            {
                pictureBox.Load(url);
            }
            catch (Exception)
            {
                pictureBox.Load(".\\..\\..\\..\\images\\image-not-found");
            }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            // Maneja el evento de selección de la grilla
            if (articlesDataGridView.CurrentRow != null)
            {
                Articulo articuloSeleccionado = (Articulo)articlesDataGridView.CurrentRow.DataBoundItem;
                MostrarDetallesArticulo(articuloSeleccionado);
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            // Lógica para crear un nuevo artículo
            formularioRegistro.EsNuevo = true; // Establecer la propiedad EsNuevo
            formularioRegistro.ShowDialog();
            CargarArticulos(); // Recarga la lista después de agregar
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            // Lógica para editar un artículo existente
            if (articuloActual != null)
            {
                formularioRegistro.EsNuevo = false; // Establecer la propiedad EsNuevo
                formularioRegistro.ArticuloAEditar = articuloActual; // Pasar el artículo a editar
                formularioRegistro.ShowDialog();
                CargarArticulos(); // Recarga la lista después de editar
            }
            else
            {
                MessageBox.Show("Seleccione un artículo para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Lógica para eliminar un artículo
            if (articuloActual != null)
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este artículo?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        gestorArticulos.EliminarArticulo(articuloActual.Id); // Llama al método de eliminación
                        CargarArticulos(); // Recarga la lista después de eliminar
                        MostrarDetallesArticulo(null); // Limpia la vista de detalle
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el artículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un artículo para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Lógica para limpiar el filtro
            filterTextBox.Text = "";
            articulosFiltrados = listaArticulos;
            ActualizarDataGridView();
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            // Lógica para filtrar la lista de artículos
            string filtro = filterTextBox.Text.ToLower();
            articulosFiltrados = listaArticulos.FindAll(articulo =>
                articulo.Nombre.ToLower().Contains(filtro) ||
                articulo.Descripcion.ToLower().Contains(filtro) ||
                (articulo.Marca != null && articulo.Marca.Descripcion.ToLower().Contains(filtro)) ||
                (articulo.Categoria != null && articulo.Categoria.Descripcion.ToLower().Contains(filtro))
            );
            ActualizarDataGridView();
        }

        private void chkHideInvalids_CheckedChanged(object sender, EventArgs e)
        {
            // Lógica para mostrar/ocultar artículos inválidos
            if (chkHideInvalids.Checked)
            {
                articulosFiltrados = listaArticulos.FindAll(EsArticuloValido);
            }
            else
            {
                articulosFiltrados = listaArticulos;
            }
            ActualizarDataGridView();
        }

        private void prevImgButton_Click(object sender, EventArgs e)
        {
            // Lógica para mostrar la imagen anterior
            if (articuloActual != null && articuloActual.Imagenes != null && articuloActual.Imagenes.Count > 0)
            {
                if (indiceImagenActual > 0)
                {
                    indiceImagenActual--;
                    CargarImagen(articuloActual.Imagenes[indiceImagenActual].Url);
                }
            }
        }

        private void nextImgButton_Click(object sender, EventArgs e)
        {
            // Lógica para mostrar la siguiente imagen
            if (articuloActual != null && articuloActual.Imagenes != null && articuloActual.Imagenes.Count > 0)
            {
                if (indiceImagenActual < articuloActual.Imagenes.Count - 1)
                {
                    indiceImagenActual++;
                    CargarImagen(articuloActual.Imagenes[indiceImagenActual].Url);
                }
            }
        }
    }
}

