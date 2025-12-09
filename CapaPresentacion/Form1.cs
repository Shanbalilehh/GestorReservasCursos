using System;
using System.Windows.Forms;
using CapaNegocio.Interfaces; // Para IServicioEstudiante

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        private readonly IServicioEstudiante _servicioEstudiante;

        public Form1(IServicioEstudiante servicio)
        {
            InitializeComponent();
            _servicioEstudiante = servicio;
        }

        private void btnCrearEstdnt_Click(object sender, EventArgs e)
        {
            // 1. Usamos la clase estática externa 'Utilidades'
            string nombre = Utilidades.LimpiarTexto(txtNombre.Text);
            string correo = Utilidades.NormalizarCorreo(txtCorreo.Text);

            try
            {
                _servicioEstudiante.RegistrarEstudiante(nombre, correo);

                MessageBox.Show("¡Estudiante registrado exitosamente!", 
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
            }
            catch (ArgumentException ex) 
            {
                // 2. Llamamos al Logger compartido
                // Pasamos el nombre de ESTA clase (nameof(Form1)) para saber dónde ocurrió
                Utilidades.RegistrarError(nameof(Form1), nameof(btnCrearEstdnt_Click), ex.Message);

                MessageBox.Show(ex.Message, "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
            }
            catch (InvalidOperationException ex)
            {
                Utilidades.RegistrarError(nameof(Form1), nameof(btnCrearEstdnt_Click), ex.Message);
                
                MessageBox.Show(ex.Message, "Operación Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Utilidades.RegistrarError(nameof(Form1), nameof(btnCrearEstdnt_Click), ex.Message);

                MessageBox.Show($"Ocurrió un error inesperado.\nDetalle: {ex.Message}", 
                                "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtNombre.Focus();
        }
    }
}