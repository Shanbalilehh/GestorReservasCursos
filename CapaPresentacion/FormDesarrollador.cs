using System;
using System.Windows.Forms;
using CapaNegocio.Interfaces;

namespace CapaPresentacion
{
    public partial class FormDesarrollador : Form
    {
        // El admin necesita acceso a todos los servicios
        private readonly IServicioEstudiante _servEst;
        private readonly IServicioProfesor _servInst;
        private readonly IServicioCurso _servCur;

        public FormDesarrollador(IServicioEstudiante sEst, IServicioProfesor sInst, IServicioCurso sCur)
        {
            InitializeComponent();
            _servEst = sEst;
            _servInst = sInst;
            _servCur = sCur;

            this.Text = "Panel de Control - ADMINISTRADOR";
        }

        // --- GESTIÓN DE ESTUDIANTES ---
        
        // Nombre sugerido en Designer: btnGuardarEstudiante
        private void btnGuardarEstudiante_Click(object sender, EventArgs e)
        {
            // ANTES:
            // // string nombre = txtNombreEst.Text;
            // // string correo = txtCorreoEst.Text;
            // // Lógica de guardado...
            // // MessageBox.Show("Lógica de Admin para guardar estudiante");

            // DESPUÉS: delegar notificación a método auxiliar para evitar duplicación y facilitar cambios futuros.
            MostrarAccionAdmin("guardar estudiante");
        }

        // --- GESTIÓN DE CURSOS ---

        // Nombre sugerido en Designer: btnCrearCurso
        private void btnCrearCurso_Click(object sender, EventArgs e)
        {
            // ANTES:
            // // Lógica para crear curso nuevo
            // // MessageBox.Show("Lógica de Admin para crear curso");

            // DESPUÉS:
            MostrarAccionAdmin("crear curso");
        }

        // --- GESTIÓN DE ProfesorES ---

        // Nombre sugerido en Designer: btnRegistrarProfe
        private void btnRegistrarProfe_Click(object sender, EventArgs e)
        {
            // ANTES:
            // // Lógica para registrar Profesor
            // // MessageBox.Show("Lógica de Admin para registrar profesor");

            // DESPUÉS:
            MostrarAccionAdmin("registrar profesor");
        }

        /// <summary>
        /// Método auxiliar para centralizar la notificación de acciones administrativas.
        /// Refactor aplicado para eliminar duplicación de MessageBox.Show.
        /// </summary>
        /// <param name="accion">Descripción corta de la acción realizada.</param>
        private void MostrarAccionAdmin(string accion)
        {
            // Aquí se puede añadir localización, logging o formato unificado.
            MessageBox.Show($"Lógica de Admin para {accion}");
        }
    }
}
