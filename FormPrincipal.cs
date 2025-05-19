using System;
using System.Collections.Generic;
using System.Windows.Forms;

using modeloDatos;
using baseDatos;

namespace tp_winform_equipo_c
{
    public partial class FormPrincipal : Form
    {
        private List<Articulo> listaArticulos;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            CargarArticulos();
        }

        private void CargarArticulos()
        {
            AccesoBaseDatos datos = new AccesoBaseDatos();
            listaArticulos = datos.Listar();

            articlesDataGridView.DataSource = listaArticulos;

            // Opcional: ocultar columnas que no queremos mostrar
            articlesDataGridView.Columns["ImagenUrl"].Visible = false;
            articlesDataGridView.Columns["Id"].Visible = false;

            // Mostrar la primer imágen (si existe)
            if (listaArticulos.Count > 0 && !string.IsNullOrEmpty(listaArticulos[0].ImagenUrl))
                { CargarImagen(listaArticulos[0].ImagenUrl); }
        }

        private void CargarImagen(string url)
        {
            try
                { pictureBox.Load(url); }
            
            catch
                { pictureBox.Load("https://cdn-icons-png.flaticon.com/512/2748/2748558.png"); }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (articlesDataGridView.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)articlesDataGridView.CurrentRow.DataBoundItem;

                if (!string.IsNullOrEmpty(seleccionado.ImagenUrl))
                    CargarImagen(seleccionado.ImagenUrl);
                else
                    CargarImagen("https://cdn-icons-png.flaticon.com/512/2748/2748558.png");
            }
        }

    } // Fin de Clase FormPrincipal


}