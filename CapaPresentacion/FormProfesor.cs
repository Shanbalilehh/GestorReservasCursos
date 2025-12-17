using System;
using System.Windows.Forms;
using CapaNegocio.Servicios;
using CapaNegocio.Interfaces;

namespace CapaPresentacion
{
    public partial class FormProfesor : Form
    {
        private readonly UsuarioSesion _usuario;
        private readonly IServicioProfesor _servicioProfesor;
        private readonly IServicioCurso _servicioCurso; // ¡Nueva Dependencia!

        // Constructor actualizado: Ahora pide IServicioCurso
        public FormProfesor(UsuarioSesion usuario, IServicioProfesor servicioProfesor, IServicioCurso servicioCurso)
        {
            InitializeComponent(); // Método del Designer
            
            _usuario = usuario;
            _servicioProfesor = servicioProfesor;
            _servicioCurso = servicioCurso;

            this.Text = $"Panel Académico - Prof. {_usuario.Username}";
            
            ConfigurarTabla();
            CargarMisCursos();
        }
        
        private void ConfigurarTabla()
        {
            dgvMisCursos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMisCursos.MultiSelect = false;
            dgvMisCursos.ReadOnly = true;
            dgvMisCursos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMisCursos.RowHeadersVisible = false;
        }

        private void CargarMisCursos()
        {
            try
            {
                // 1. Obtenemos TODOS los cursos del sistema
                var ofertaTotal = _servicioCurso.ObtenerOfertaAcademica();

                // 2. FILTRADO EN MEMORIA (Lógica de Presentación)
                // Buscamos solo los cursos donde el ProfesorId coincide con el ID del usuario logueado
                var misCursos = ofertaTotal.Where(c => c.ProfesorId == _usuario.Id).ToList();

                // 3. Enlazar a la tabla
                dgvMisCursos.DataSource = null;
                dgvMisCursos.DataSource = misCursos;

                // 4. Ocultar columnas técnicas (IDs y Navegación)
                OcultarColumna("Id");
                OcultarColumna("ProfesorId");
                OcultarColumna("Profesor"); // Objeto anidado
                OcultarColumna("Reservas");   // Lista anidada
            }
            catch (Exception ex)
            {
                Utilidades.RegistrarError(nameof(FormProfesor), nameof(CargarMisCursos), ex.Message);
                MessageBox.Show($"Error al cargar sus cursos: {ex.Message}");
            }
        }

        private void OcultarColumna(string nombreColumna)
        {
            if (dgvMisCursos.Columns[nombreColumna] != null)
            {
                dgvMisCursos.Columns[nombreColumna].Visible = false;
            }
        }

        // Evento sugerido para botón 'btnVerDetalle' (Ver alumnos inscritos)
        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvMisCursos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un curso para ver los alumnos inscritos.");
                return;
            }

            // Aquí podrías abrir un sub-formulario mostrando la lista de alumnos
            // usando el Id del curso seleccionado.
            MessageBox.Show("Funcionalidad de 'Ver Alumnos' pendiente de implementar.");
        }
    }
}
