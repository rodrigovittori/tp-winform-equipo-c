using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using baseDatos;

namespace validaciones
{
    public static class Validacion
    {
        public static bool EsNumero(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsNumber(c))
                    return false;
            }
            return true;
        }

        public static string QuitarEspacios(string texto)
        {
            string temp = "";
            foreach (char c in texto)
            {
                if (!char.IsWhiteSpace(c))
                    temp += c;
            }
            return temp;
        }

        public static bool EsAlfanumerico(string texto)
        {
            foreach (char c in QuitarEspacios(texto))
            {
                if (!char.IsNumber(c) && !char.IsLetter(c))
                    return false;
            }
            return true;
        }

        public static bool EsDecimal(string texto)
        {
            int contadorComas = 0;
            if (texto[0] == '.' || texto[0] == ',')
                return false;
            if (texto[texto.Length - 1] == '.' || texto[texto.Length - 1] == ',')
                return false;
            foreach (char c in texto)
            {
                if (c == '.' || c == ',')
                    contadorComas++;
                if (!char.IsNumber(c) && (c != '.' && c != ','))
                    return false;
            }
            return (contadorComas <= 1);
        }

        public static void MostrarError(string mensaje)
        {
            MessageBox.Show(
                mensaje,
                "Error de validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        public static bool ContieneDatos(string texto, int longitudMin = 2, int longitudMax = 0)
        {
            if (string.IsNullOrEmpty(texto))
                return false;
            if (texto.Length < longitudMin)
                return false;
            if (longitudMax != 0 && texto.Length > longitudMax)
                return false;

            return true;
        }

        public static bool VerificarEntradas(List<ContenedorEntrada> entradas)
        {
            int noValidos = 0;
            foreach (ContenedorEntrada entrada in entradas)
            {
                if (!EsEntradaValida(entrada))
                {
                    noValidos++;
                    PintarEntradaIncorrecta(entrada.Control);
                }
            }
            return (noValidos == 0);
        }

        public static bool EsEntradaValida(ContenedorEntrada entrada)
        {
            switch (entrada.TipoEntrada.ToString())
            {
                case "System.String":
                    if (!ContieneDatos(entrada.Control.Text, entrada.LongitudMin, entrada.LongitudMax))
                    {
                        Debug.Print($"Campo no válido: {entrada.Control.Name}");
                        return false;
                    }
                    break;
                case "System.Decimal":
                    if (
                        !ContieneDatos(entrada.Control.Text, entrada.LongitudMin)
                        || !EsDecimal(entrada.Control.Text)
                        || !decimal.TryParse(entrada.Control.Text, out _)
                    )
                    {
                        Debug.Print($"Campo no válido: {entrada.Control.Name}");
                        return false;
                    }
                    break;
                case "System.Int32": //Agregado para que compile
                    if (
                       !ContieneDatos(entrada.Control.Text, entrada.LongitudMin)
                       || !EsNumero(entrada.Control.Text)
                       || !int.TryParse(entrada.Control.Text, out _)
                   )
                    {
                        Debug.Print($"Campo no válido: {entrada.Control.Name}");
                        return false;
                    }
                    break;
            }
            return true;
        }

        public static void PintarEntradaIncorrecta(Control control)
        {
            if (!control.Enabled)
                return;

            Task.Run(async () =>
            {
                CambiarColorDesdeTarea(control, Color.LightCoral);
                await Task.Delay(4000);
                CambiarColorDesdeTarea(control, SystemColors.Window);
            });
        }

        private static void CambiarColorDesdeTarea(Control control, Color color)
        {
            control.Invoke(
                new MethodInvoker(() =>
                {
                    control.BackColor = color;
                })
            );
        }
    }

    public static class GestorFormularios
    {
        public static void CargarFormulario<Formulario>(Form mdiParent) where Formulario : Form, new()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is Formulario formClass)
                {
                    if (formClass.WindowState == FormWindowState.Minimized)
                        formClass.WindowState = FormWindowState.Normal;

                    formClass.BringToFront();
                    return;
                }
            }

            Formulario nuevoFormulario = new Formulario();
            nuevoFormulario.MdiParent = mdiParent;
            nuevoFormulario.Show();
        }
    }

    public static class FuncionesFormulario
    {
        public static void CargarImagen(PictureBox pictureBox, string imageUrl)
        {
            try
            {
                pictureBox.Load(imageUrl);
            }
            catch (Exception)
            {
                pictureBox.Load(".\\..\\..\\..\\images\\image-not-found");
            }
        }

        public static void ConfigurarDataGrid(DataGridView dataGridView)
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        public static void ResaltarNoValidos(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex != 0 && !Validacion.ContieneDatos(cell.Value.ToString()))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                }
            }
        }
    }

    public class ContenedorEntrada
    {
        public Control Control { get; set; }
        public Type TipoEntrada { get; set; }
        public int LongitudMin { get; set; }
        public int LongitudMax { get; set; }

        public ContenedorEntrada(Control control, Type tipo, int min = 2, int max = 0)
        {
            Control = control;
            TipoEntrada = tipo;
            LongitudMin = min;
            LongitudMax = max;
        }

        // Sobrecarga del constructor para TextBox
        public ContenedorEntrada(TextBox textBox, Type tipo, int min = 2, int max = 0)
        {
            Control = textBox;
            TipoEntrada = tipo;
            LongitudMin = min;
            LongitudMax = max;
        }

        // Sobrecarga del constructor para ComboBox
        public ContenedorEntrada(ComboBox comboBox, Type tipo, int min = 2, int max = 0)
        {
            Control = comboBox;
            TipoEntrada = tipo;
            LongitudMin = min;
            LongitudMax = max;
        }
    }

    public static class AyudanteBaseDatos // Asegúrate de que esta clase esté en el namespace correcto
    {
        public static int ObtenerUltimoId(string tabla)
        {
            int ultimoId = 0;
            AccesoBaseDatos acceso = new AccesoBaseDatos();

            try
            {
                acceso.SetearConsulta("select ident_current(@Tabla) as UltimoId");
                acceso.AgregarParametro("@Tabla", tabla);
                acceso.EjecutarLectura();

                if (acceso.Lector.Read())
                    ultimoId = Convert.ToInt32(acceso.Lector["UltimoId"]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.CerrarConexion();
            }

            return ultimoId;
        }
    }
}
