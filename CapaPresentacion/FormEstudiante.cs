using System;
using System.Windows.Forms;
using CapaNegocio.Interfaces;
using CapaNegocio.Servicios;

namespace CapaPresentacion
{
    // Partial class: Se une con lo que hagas en el Designer
    public partial class FormEstudiante : Form
    {
        private readonly UsuarioSesion _usuario;
        private readonly IServicioReserva _servicioReserva;
        private readonly IServicioCurso _servicioCurso;

        public FormEstudiante(UsuarioSesion usuario, IServicioReserva servicioReserva, IServicioCurso servicioCurso)
        {
            InitializeComponent();
            
            _usuario = usuario;
            _servicioReserva = servicioReserva;
            _servicioCurso = servicioCurso;

            this.Text = $"Portal Estudiante - {_usuario.Username}";

            // Configuración visual inicial
            ConfigurarGrids();
            
            // Carga inicial de datos
            ActualizarPantallas();
        }

        private void ConfigurarGrids()
        {
            // Configuración común para ambas tablas para evitar repetir código
            DataGridView[] grids = { dgvCursos, dgvMisReservas };

            foreach (var grid in grids)
            {
                grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grid.MultiSelect = false;
                grid.ReadOnly = true;
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                grid.RowHeadersVisible = false;
                grid.AllowUserToAddRows = false; // Importante para que no salga la fila vacía abajo
            }
        }

        // --- LÓGICA DE ACTUALIZACIÓN DE DATOS ---
        
        // Este método orquesta la carga de ambas pestañas
        private void ActualizarPantallas()
        {
            CargarOfertaAcademica();
            CargarHistorialReservas();
        }

        private void CargarOfertaAcademica()
        {
            try 
            {
                var cursos = _servicioCurso.ObtenerOfertaAcademica();
                
                // Proyección (ViewModel): Calculamos cupos en tiempo real
                var listaVisual = cursos.Select(c => {
                    int ocupados = _servicioReserva.ObtenerCantidadInscritos(c.Id);
                    int disponibles = c.CupoMaximo - ocupados;

                    return new 
                    {
                        Id = c.Id, // Columna oculta necesaria para la lógica
                        Curso = c.Nombre,
                        Horario = c.Horario,
                        // Formato condicional en texto
                        Disponibilidad = disponibles > 0 ? $"{disponibles} lugares" : "AGOTADO"
                    };
                }).ToList();

                dgvCursos.DataSource = null;
                dgvCursos.DataSource = listaVisual;
                
                if (dgvCursos.Columns["Id"] != null) dgvCursos.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                Utilidades.RegistrarError(nameof(FormEstudiante), "CargarOferta", ex.Message);
            }
        }

        private void CargarHistorialReservas()
        {
            try
            {
                var misReservas = _servicioReserva.ObtenerReservasPorEstudiante(_usuario.Id);

                // Proyección: Cruzamos datos para mostrar nombres bonitos
                var listaHistorial = misReservas.Select(r => {
                    var curso = _servicioCurso.ObtenerCursoPorId(r.CursoId);
                    
                    return new 
                    {
                        ReservaId = r.Id, // Útil si implementamos cancelación
                        Fecha = r.FechaReserva.ToShortDateString(),
                        Curso = curso != null ? curso.Nombre : "(Curso Eliminado)",
                        Horario = curso != null ? curso.Horario : "-",
                        Profesor = curso != null && curso.Profesor != null ? curso.Profesor.Nombre : "No asignado"
                    };
                }).ToList();

                dgvMisReservas.DataSource = null;
                dgvMisReservas.DataSource = listaHistorial;
                
                if (dgvMisReservas.Columns["ReservaId"] != null) dgvMisReservas.Columns["ReservaId"].Visible = false;
            }
            catch (Exception ex)
            {
                Utilidades.RegistrarError(nameof(FormEstudiante), "CargarHistorial", ex.Message);
            }
        }

        // --- EVENTOS DE INTERACCIÓN ---

        // Evento: tabControl1_SelectedIndexChanged
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarPantallas();
        }

        // Evento: btnReservar_Click
        private void btnReservar_Click(object sender, EventArgs e)
        {
            // Validar selección
            if (dgvCursos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un curso para reservar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Obtener ID (Celda 0 suele ser el ID si es la primera propiedad del objeto anónimo)
                // Es más seguro buscar por nombre de columna:
                Guid cursoId = (Guid)dgvCursos.SelectedRows[0].Cells["Id"].Value;
                string nombreCurso = dgvCursos.SelectedRows[0].Cells["Curso"].Value.ToString();

                // Confirmación
                var confirm = MessageBox.Show($"¿Deseas reservar cupo en '{nombreCurso}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    _servicioReserva.Reservar(_usuario.Id, cursoId);
                    
                    MessageBox.Show("¡Reserva confirmada!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Actualizamos INMEDIATAMENTE para que bajen los cupos en la vista
                    ActualizarPantallas();
                    
                    // Opcional: Llevar al usuario a la pestaña de "Mis Reservas" para que vea su logro
                    // tabControl1.SelectedTab = tabMisReservas; // Asumiendo que tabMisReservas es la variable de la página 2
                }
            }
            catch (Exception ex)
            {
                Utilidades.RegistrarError(nameof(FormEstudiante), "Reservar", ex.Message);
                MessageBox.Show(ex.Message, "No se pudo reservar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento Opcional: btnCancelar_Click 
        private void btnCancelar_Click(object sender, EventArgs e)
        {
             if (dgvMisReservas.SelectedRows.Count == 0) return;

             // Lógica similar: Obtener ReservaId -> llamar _servicioReserva.Cancelar(...) -> ActualizarPantallas();
             MessageBox.Show("Funcionalidad de cancelación pendiente.");
        }
    }
}
