using System;
using System.Windows.Forms;
using CapaNegocio; // Asegúrate de usar el namespace correcto de tu proyecto
// using CapaEntidad; // No es necesario aquí si solo pasamos strings al servicio

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        // 1. Declarar el campo para guardar el servicio
        private readonly IServicioEstudiante _servicioEstudiante;

        // 2. Modificar el Constructor para recibir el servicio (Inyección de Dependencias)
        public Form1(IServicioEstudiante servicio)
        {
            InitializeComponent();
            _servicioEstudiante = servicio;
        }

        // Clase de utilidad para limpieza (Inner Class)
        public static class InputParser
        {
            public static string LimpiarTexto(string entrada)
            {
                return entrada?.Trim() ?? string.Empty;
            }

            public static string NormalizarCorreo(string entrada)
            {
                return LimpiarTexto(entrada).ToLowerInvariant();
            }
        }

        // 3. Evento del Botón (Firma estándar de WinForms)
        private void btnCrearEstdnt_Click(object sender, EventArgs e)
        {
            // A. Lectura y Limpieza (UI)
            string nombreLimpio = InputParser.LimpiarTexto(txtNombre.Text);
            string correoNormalizado = InputParser.NormalizarCorreo(txtCorreo.Text);
            
            try
            {
                // B. Llamada a Negocio (El formulario no sabe guardar, solo pide hacerlo)
                _servicioEstudiante.RegistrarEstudiante(nombreLimpio, correoNormalizado);

                // C. Feedback al usuario
                MessageBox.Show($"Estudiante '{nombreLimpio}' registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Opcional: Limpiar las cajas
                txtNombre.Clear();
                txtCorreo.Clear();
            }
            catch (ArgumentException ex) // Validaciones simples (campos vacíos)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex) // Reglas de negocio (duplicados)
            {
                MessageBox.Show(ex.Message, "Error de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // Errores inesperados
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}