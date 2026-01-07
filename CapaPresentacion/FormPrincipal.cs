using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio.Servicios;
using CapaNegocio.Interfaces;

namespace CapaPresentacion
{
    public partial class FormPrincipal : Form
    {
        // --- ESTADO GLOBAL ---
        private UsuarioSesion _usuarioActual;

        // --- SERVICIOS ---
        private readonly ServicioAutenticacion _servAuth;
        private readonly IServicioEstudiante _servEst;
        private readonly IServicioProfesor _servInst;
        private readonly IServicioCurso _servCur;
        private readonly IServicioReserva _servRes;

        // --- PESTAÑAS (Referencias) ---
        private TabPage _paginaLogin;
        private TabPage _paginaEstudiante;
        private TabPage _paginaProfesor;
        private TabPage _paginaAdmin;

        public FormPrincipal(
            ServicioAutenticacion sAuth,
            IServicioEstudiante sEst,
            IServicioProfesor sInst,
            IServicioCurso sCur,
            IServicioReserva sRes)
        {
            InitializeComponent();

            _servAuth = sAuth;
            _servEst = sEst;
            _servInst = sInst;
            _servCur = sCur;
            _servRes = sRes;

            // Guardar referencias de pestañas
            _paginaLogin = tabControlPrincipal.TabPages["tabLogin"];
            _paginaEstudiante = tabControlPrincipal.TabPages["tabEstudiante"];
            _paginaProfesor = tabControlPrincipal.TabPages["tabProfesor"];
            _paginaAdmin = tabControlPrincipal.TabPages["tabAdmin"];

            ResetearVista();
        }

        // --- GESTIÓN DE VISTAS ---
        private void ResetearVista()
        {
            tabControlPrincipal.TabPages.Clear();
            tabControlPrincipal.TabPages.Add(_paginaLogin);
            this.Text = "Sistema de Cursos - Bienvenido";
        }

        private void HabilitarModulo(RolUsuario rol)
        {
            tabControlPrincipal.TabPages.Remove(_paginaLogin);

            switch (rol)
            {
                case RolUsuario.Estudiante:
                    tabControlPrincipal.TabPages.Add(_paginaEstudiante);
                    InicializarModuloEstudiante();
                    break;

                case RolUsuario.Profesor:
                    tabControlPrincipal.TabPages.Add(_paginaProfesor);
                    InicializarModuloProfesor();
                    break;

                case RolUsuario.Desarrollador:
                    tabControlPrincipal.TabPages.Add(_paginaAdmin);
                    InicializarModuloAdmin();
                    break;
            }
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text; // Asume que existen en tabLogin
            string pass = txtPass.Text;

            var usuario = _servAuth.Login(user, pass);

            if (usuario != null)
            {
                _usuarioActual = usuario;
                this.Text = $"Sesión iniciada: {_usuarioActual.Username}";

                // MAGIA: Habilitamos la pestaña correspondiente
                HabilitarModulo(_usuarioActual.Rol);

                // Limpiar campos por seguridad
                txtUser.Clear();
                txtPass.Clear();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            _usuarioActual = null;
            ResetearVista();
        }

        // =========================================================
        // MÓDULO ESTUDIANTE
        // =========================================================
        
        private void InicializarModuloEstudiante()
        {
            ConfigurarGridsEstudiante();
            ActualizarPantallasEstudiante();
        }

        private void ConfigurarGridsEstudiante()
        {
            // Asumiendo que dgvCursos y dgvMisReservas existen en tabEstudiante
            DataGridView[] grids = { dgvCursos, dgvMisReservas };

            foreach (var grid in grids)
            {
                if (grid == null) continue; // Protección por si no se han creado en Designer
                grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grid.MultiSelect = false;
                grid.ReadOnly = true;
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                grid.RowHeadersVisible = false;
                grid.AllowUserToAddRows = false;
            }
        }

        private void ActualizarPantallasEstudiante()
        {
            CargarOfertaAcademica();
            CargarHistorialReservas();
        }

        private void CargarOfertaAcademica()
        {
            try 
            {
                var cursos = _servCur.ObtenerOfertaAcademica();
                
                // ViewModel con cálculo de cupos
                var listaVisual = cursos.Select(c => {
                    int ocupados = _servRes.ObtenerCantidadInscritos(c.Id);
                    int disponibles = c.CupoMaximo - ocupados;

                    return new 
                    {
                        Id = c.Id, 
                        Curso = c.Nombre,
                        Horario = c.Horario,
                        Disponibilidad = disponibles > 0 ? $"{disponibles} lugares" : "AGOTADO"
                    };
                }).ToList();

                dgvCursos.DataSource = null;
                dgvCursos.DataSource = listaVisual;
                
                if (dgvCursos.Columns["Id"] != null) dgvCursos.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                Utilidades.RegistrarError(nameof(FormPrincipal), "CargarOferta", ex.Message);
            }
        }

        private void CargarHistorialReservas()
        {
            try
            {
                var misReservas = _servRes.ObtenerReservasPorEstudiante(_usuarioActual.Id);
                // Traemos todos los Profesores para buscar nombres
                var Profesores = _servInst.ObtenerTodos(); 

                var listaHistorial = misReservas.Select(r => {
                    var curso = _servCur.ObtenerCursoPorId(r.CursoId);
                    
                    // Lógica segura: Si el curso existe, buscamos el Profesor por ID en nuestra lista local
                    string nombreProfe = "No Asignado";
                    string nombreCurso = "Curso Eliminado";
                    string horarioCurso = "-";

                    if (curso != null)
                    {
                        nombreCurso = curso.Nombre;
                        horarioCurso = curso.Horario;
                        // Buscamos el nombre usando el ID, no la propiedad de navegación vacía
                        nombreProfe = Profesores.FirstOrDefault(i => i.Id == curso.ProfesorId)?.Nombre ?? "Sin Asignar";
                    }

                    return new { 
                        ReservaId = r.Id, 
                        Fecha = r.FechaReserva.ToShortDateString(), 
                        Curso = nombreCurso, 
                        Horario = horarioCurso,
                        Profesor = nombreProfe // ¡Ahora sí aparecerá!
                    };
                }).ToList();

                dgvMisReservas.DataSource = null;
                dgvMisReservas.DataSource = listaHistorial;
                
                if (dgvMisReservas.Columns["ReservaId"] != null) dgvMisReservas.Columns["ReservaId"].Visible = false;
            }
            catch (Exception ex)
            {
                Utilidades.RegistrarError(nameof(FormPrincipal), "CargarHistorial", ex.Message);
            }
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un curso.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Guid cursoId = (Guid)dgvCursos.SelectedRows[0].Cells["Id"].Value;
                string nombreCurso = dgvCursos.SelectedRows[0].Cells["Curso"].Value.ToString();

                var confirm = MessageBox.Show($"¿Reservar cupo en '{nombreCurso}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (confirm == DialogResult.Yes)
                {
                    _servRes.Reservar(_usuarioActual.Id, cursoId);
                    
                    MessageBox.Show("¡Reserva exitosa!");
                    ActualizarPantallasEstudiante(); // Refrescar cupos
                    
                    // Opcional: Cambiar foco a pestaña mis reservas si tuvieras un sub-tab
                }
            }
            catch (Exception ex)
            {
                Utilidades.RegistrarError(nameof(FormPrincipal), "Reservar", ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        
        // =========================================================
        // MÓDULO PROFESOR (Lógica Integrada)
        // =========================================================
        
        private void InicializarModuloProfesor()
        {
            ConfigurarGridProfesor();
            CargarCursosProfesor();
        }

        private void ConfigurarGridProfesor()
        {
            if (dgvMisCursos == null) return;

            dgvMisCursos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMisCursos.MultiSelect = false;
            dgvMisCursos.ReadOnly = true;
            dgvMisCursos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMisCursos.RowHeadersVisible = false;
            dgvMisCursos.AllowUserToAddRows = false;
        }

        private void CargarCursosProfesor()
        {
            try
            {
                // 1. Obtenemos TODOS los cursos
                var ofertaTotal = _servCur.ObtenerOfertaAcademica();

                // 2. FILTRADO: Buscamos cursos donde ProfesorId == ID del Usuario Actual
                // Nota: Usamos 'ProfesorId' (Nombre de la Entidad), no 'ProfesorId'
                var misCursos = ofertaTotal
                                .Where(c => c.ProfesorId == _usuarioActual.Id)
                                .Select(c => new 
                                {
                                    Id = c.Id,
                                    Nombre = c.Nombre,
                                    Horario = c.Horario,
                                    Cupo = c.CupoMaximo,
                                    Inscritos = _servRes.ObtenerCantidadInscritos(c.Id) // Agregamos dato útil para el profe
                                })
                                .ToList();

                // 3. Enlazar
                dgvMisCursos.DataSource = null;
                dgvMisCursos.DataSource = misCursos;

                // 4. Ocultar ID
                if (dgvMisCursos.Columns["Id"] != null) dgvMisCursos.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                Utilidades.RegistrarError(nameof(FormPrincipal), "CargarCursosProfesor", ex.Message);
                MessageBox.Show($"Error al cargar sus cursos: {ex.Message}");
            }
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvMisCursos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un curso para ver los alumnos inscritos.");
                return;
            }

            try 
            {
                // 1. Obtener datos del curso seleccionado
                Guid cursoId = (Guid)dgvMisCursos.SelectedRows[0].Cells["Id"].Value;
                string nombreCurso = dgvMisCursos.SelectedRows[0].Cells["Nombre"].Value.ToString();
                
                // 2. Obtener las reservas de ese curso (Usando el nuevo método del servicio)
                var reservas = _servRes.ObtenerReservasPorCurso(cursoId);

                if (reservas.Count == 0)
                {
                    MessageBox.Show($"El curso '{nombreCurso}' no tiene alumnos inscritos aún.", "Detalle del Curso");
                    return;
                }

                // 3. CRUZAR DATOS (JOIN): Obtener nombres de estudiantes
                // Traemos todos los estudiantes para buscar sus nombres
                var todosLosEstudiantes = _servEst.ObtenerListaEstudiantes();

                // Usamos LINQ para unir Reserva con Estudiante
                var alumnosInscritos = from r in reservas
                                       join est in todosLosEstudiantes on r.EstudianteId equals est.Id
                                       select est.Nombre; // Solo nos interesa el nombre

                // 4. Mostrar en un mensaje (Lista separada por saltos de línea)
                string listaNombres = string.Join(Environment.NewLine, alumnosInscritos);

                MessageBox.Show($"Alumnos en '{nombreCurso}':\n\n{listaNombres}", 
                                "Lista de Asistencia", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Utilidades.RegistrarError(nameof(FormPrincipal), "VerDetalle", ex.Message);
                MessageBox.Show("Error al obtener detalles: " + ex.Message);
            }
        }
        private void InicializarModuloAdmin() { }
    }
}
