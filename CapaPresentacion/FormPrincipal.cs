using System;
using System.Collections.Generic;
using System.Data;
using System.Linq; 
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

        // --- REFERENCIAS A PESTAÑAS ---
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


            _paginaLogin = tabControlPrincipal.TabPages["tabLogin"];
            _paginaEstudiante = tabControlPrincipal.TabPages["tabEstudiante"];
            _paginaProfesor = tabControlPrincipal.TabPages["tabProfesor"];
            _paginaAdmin = tabControlPrincipal.TabPages["tabAdmin"];

            ConfigurarDiseñoProfesional();

            ResetearVista();
        }
        private Panel panelLateral;
        private Label lblTituloHeader;
        private Button btnLogoutDinamico;

        private void ConfigurarDiseñoProfesional()
        {
            // 1. Estilo General del Formulario
            GestorDeEstilos.AplicarTemaFormulario(this);
            this.Text = "Sistema de Gestión Académica"; // Título de la ventana

            // 2. Ocultar las pestañas feas del TabControl
            GestorDeEstilos.ConvertirEnDashboard(tabControlPrincipal);

            // 3. Crear el HEADER (Título Superior)
            lblTituloHeader = new Label();
            lblTituloHeader.Dock = DockStyle.Top;
            lblTituloHeader.Height = 60;
            lblTituloHeader.BackColor = Color.White;
            lblTituloHeader.ForeColor = GestorDeEstilos.ColorPrimario;
            lblTituloHeader.Font = GestorDeEstilos.FuenteTitulo;
            lblTituloHeader.TextAlign = ContentAlignment.MiddleLeft;
            lblTituloHeader.Padding = new Padding(20, 0, 0, 0);
            lblTituloHeader.Text = "Bienvenido";
            this.Controls.Add(lblTituloHeader); // Agregar primero (Top)

            // 4. Crear el SIDEBAR (Menú Lateral)
            panelLateral = new Panel();
            panelLateral.Dock = DockStyle.Left;
            panelLateral.Width = 200;
            panelLateral.BackColor = GestorDeEstilos.ColorPrimario;
            panelLateral.Padding = new Padding(10);
            
            // Logo o Título del Menú
            Label lblLogo = new Label();
            lblLogo.Text = "ACADEMIA\nXXXXXX";
            lblLogo.Dock = DockStyle.Top;
            lblLogo.Height = 100;
            lblLogo.ForeColor = Color.White;
            lblLogo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            panelLateral.Controls.Add(lblLogo);

            // Botón de Cerrar Sesión (En el menú lateral)
            btnLogoutDinamico = new Button();
            btnLogoutDinamico.Text = "Cerrar Sesión";
            btnLogoutDinamico.Dock = DockStyle.Bottom;
            btnLogoutDinamico.Height = 45;
            btnLogoutDinamico.Click += btnCerrarSesion_Click; // Reusamos tu evento
            GestorDeEstilos.EstilizarBoton(btnLogoutDinamico, false); // Estilo rojo/secundario
            panelLateral.Controls.Add(btnLogoutDinamico);

            this.Controls.Add(panelLateral); // Agregar segundo (Left)

            // 5. Ajustar el TabControl existente
            // Importante: BringToFront para asegurar que no quede tapado, 
            // pero después de agregar los Paneles con Dock.
            tabControlPrincipal.Dock = DockStyle.Fill;
            this.Controls.Add(tabControlPrincipal);
            tabControlPrincipal.BringToFront();

            // 6. ESTILIZAR CONTROLES INTERNOS (Automágico)
            // Recorremos las pestañas para estilizar tus botones y grids existentes
            EstilizarControlesRecursivos(tabControlPrincipal);
        }

        // Método recursivo para encontrar tus controles y pintarlos
        private void EstilizarControlesRecursivos(Control contenedor)
        {
            foreach (Control c in contenedor.Controls)
            {
                if (c is Button btn)
                {
                    // Si el botón dice "Cancelar" o "Eliminar", lo pintamos rojo
                    bool esPrimario = !btn.Text.ToLower().Contains("cancelar") && !btn.Text.ToLower().Contains("eliminar");
                    GestorDeEstilos.EstilizarBoton(btn, esPrimario);
                }
                else if (c is DataGridView dgv)
                {
                    GestorDeEstilos.EstilizarGrid(dgv);
                }
                else if (c is TextBox txt)
                {
                    // Opcional: Darle un borde o padding si quisieras
                }
                else if (c is TabPage || c is Panel || c is GroupBox)
                {
                    // Seguir buscando adentro
                    EstilizarControlesRecursivos(c);
                }
            }
        }

        // --- GESTIÓN DE VISTAS ---
        private void ResetearVista()
        {
            tabControlPrincipal.TabPages.Clear();
            tabControlPrincipal.TabPages.Add(_paginaLogin);
            if(panelLateral != null) panelLateral.Visible = false;
            if(lblTituloHeader != null) lblTituloHeader.Visible = false;
            
            this.Text = "Sistema de Cursos - Login";
        }

        private void HabilitarModulo(RolUsuario rol)
        {
            tabControlPrincipal.TabPages.Remove(_paginaLogin);
            if(panelLateral != null) panelLateral.Visible = true;
            if(lblTituloHeader != null) 
            {
                lblTituloHeader.Visible = true;
                lblTituloHeader.Text = $"Portal {rol} | {_usuarioActual.Username}";
            }

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

        // --- LOGIN ---
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;

            var usuario = _servAuth.Login(user, pass);

            if (usuario != null)
            {
                _usuarioActual = usuario;
                this.Text = $"Portal {_usuarioActual.Rol} - {_usuarioActual.Username}";
                HabilitarModulo(_usuarioActual.Rol);

                txtUser.Clear();
                txtPass.Clear();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (dgvCursos == null || dgvMisReservas == null) return;
            DataGridView[] grids = { dgvCursos, dgvMisReservas };
            foreach (var grid in grids) { EstilizarGrid(grid); }
        }

        private void ActualizarPantallasEstudiante()
        {
            // 1. Cargar Oferta
            try
            {
                var cursos = _servCur.ObtenerOfertaAcademica();
                var Profesores = _servInst.ObtenerTodos();

                var listaVisual = cursos.Select(c =>
                {
                    int ocupados = _servRes.ObtenerCantidadInscritos(c.Id);
                    int disponibles = c.CupoMaximo - ocupados;
                    var nombreProfe = Profesores.FirstOrDefault(i => i.Id == c.ProfesorId)?.Nombre ?? "Sin Asignar";

                    return new { Id = c.Id, Curso = c.Nombre, Profesor = nombreProfe, Horario = c.Horario, Disponibilidad = disponibles > 0 ? $"{disponibles} lugares" : "AGOTADO" };
                }).ToList();

                dgvCursos.DataSource = listaVisual;
                if (dgvCursos.Columns["Id"] != null) dgvCursos.Columns["Id"].Visible = false;
            }
            catch (Exception ex) { Utilidades.RegistrarError(nameof(FormPrincipal), "CargarOferta", ex.Message); }

            // 2. Cargar Historial
            try
            {
                var misReservas = _servRes.ObtenerReservasPorEstudiante(_usuarioActual.Id);
                var Profesores = _servInst.ObtenerTodos();

                var listaHistorial = misReservas.Select(r =>
                {
                    var curso = _servCur.ObtenerCursoPorId(r.CursoId);
                    string nombreProfe = "No Asignado";
                    string nombreCurso = "Curso Eliminado";
                    string horarioCurso = "-";

                    if (curso != null)
                    {
                        nombreCurso = curso.Nombre;
                        horarioCurso = curso.Horario;
                        nombreProfe = Profesores.FirstOrDefault(i => i.Id == curso.ProfesorId)?.Nombre ?? "Sin Asignar";
                    }

                    return new { ReservaId = r.Id, Fecha = r.FechaReserva.ToShortDateString(), Curso = nombreCurso, Horario = horarioCurso, Profesor = nombreProfe };
                }).ToList();

                dgvMisReservas.DataSource = listaHistorial;
                if (dgvMisReservas.Columns["ReservaId"] != null) dgvMisReservas.Columns["ReservaId"].Visible = false;
            }
            catch (Exception ex) { Utilidades.RegistrarError(nameof(FormPrincipal), "CargarHistorial", ex.Message); }
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.SelectedRows.Count == 0) return;
            try
            {
                Guid cursoId = (Guid)dgvCursos.SelectedRows[0].Cells["Id"].Value;
                if (MessageBox.Show("¿Confirmar reserva?", "Reservar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _servRes.Reservar(_usuarioActual.Id, cursoId);
                    MessageBox.Show("¡Reserva exitosa!");
                    ActualizarPantallasEstudiante();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            // 1. Validar que haya una fila seleccionada
            if (dgvMisReservas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una reserva para cancelar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Obtener el ID 
                Guid reservaId = (Guid)dgvMisReservas.SelectedRows[0].Cells["ReservaId"].Value;
                string nombreCurso = dgvMisReservas.SelectedRows[0].Cells["Curso"].Value.ToString();

                // 3. Confirmación
                var confirm = MessageBox.Show(
                    $"¿Estás seguro de cancelar tu inscripción al curso '{nombreCurso}'?\nLibera espacio para otros estudiantes.",
                    "Confirmar Cancelación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    // 4. Llamar al servicio
                    _servRes.CancelarReserva(reservaId);

                    MessageBox.Show("Inscripción cancelada exitosamente.", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. Refrescar TODO
                    // Esto quitará la reserva de la lista Y aumentará los cupos disponibles en la otra tabla
                    ActualizarPantallasEstudiante();
                }
            }
            catch (Exception ex)
            {
                Utilidades.RegistrarError(nameof(FormPrincipal), "CancelarReserva", ex.Message);
                MessageBox.Show("Error al cancelar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // MÓDULO PROFESOR
        // =========================================================
        private void InicializarModuloProfesor()
        {
            if (dgvMisCursos != null) EstilizarGrid(dgvMisCursos);
            CargarCursosProfesor();
        }

        private void CargarCursosProfesor()
        {
            try
            {
                var ofertaTotal = _servCur.ObtenerOfertaAcademica();
                var misCursos = ofertaTotal
                                .Where(c => c.ProfesorId == _usuarioActual.Id)
                                .Select(c => new { Id = c.Id, Nombre = c.Nombre, Horario = c.Horario, Cupo = c.CupoMaximo, Inscritos = _servRes.ObtenerCantidadInscritos(c.Id) })
                                .ToList();

                dgvMisCursos.DataSource = misCursos;
                if (dgvMisCursos.Columns["Id"] != null) dgvMisCursos.Columns["Id"].Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvMisCursos.SelectedRows.Count == 0) return;
            try
            {
                Guid cursoId = (Guid)dgvMisCursos.SelectedRows[0].Cells["Id"].Value;
                string nombreCurso = dgvMisCursos.SelectedRows[0].Cells["Nombre"].Value.ToString();

                var reservas = _servRes.ObtenerReservasPorCurso(cursoId);
                if (reservas.Count == 0) { MessageBox.Show("Sin alumnos inscritos."); return; }

                var todosLosEstudiantes = _servEst.ObtenerListaEstudiantes();
                var alumnosInscritos = from r in reservas join est in todosLosEstudiantes on r.EstudianteId equals est.Id select est.Nombre;

                MessageBox.Show($"Alumnos en '{nombreCurso}':\n\n{string.Join(Environment.NewLine, alumnosInscritos)}", "Asistencia");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // =========================================================
        // MÓDULO ADMIN (DESARROLLADOR)
        // =========================================================
        private void InicializarModuloAdmin()
        {
            CargarComboProfesores();
        }

        private void CargarComboProfesores()
        {
            try
            {
                var listaProfes = _servInst.ObtenerTodos();
                cboProfesores.DataSource = null; // Reset crucial
                cboProfesores.DataSource = listaProfes;
                cboProfesores.DisplayMember = "Nombre";
                cboProfesores.ValueMember = "Id";
            }
            catch (Exception ex) { MessageBox.Show("Error cargando Profesores: " + ex.Message); }
        }

        // 1. Guardar Estudiante
        private void btnGuardarEst_Click(object sender, EventArgs e)
        {
            try
            {
                // Datos Personales
                string nombre = Utilidades.LimpiarTexto(txtNombreEst.Text);
                string correo = Utilidades.NormalizarCorreo(txtCorreoEst.Text);

                // Datos de Login
                string user = Utilidades.LimpiarTexto(txtUserEst.Text);
                string pass = txtPassEst.Text; // Password no se limpia ni normaliza

                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Debe asignar un usuario y contraseña.");
                    return;
                }

                // A. Crear Estudiante y OBTENER ID
                Guid nuevoId = _servEst.RegistrarEstudiante(nombre, correo);

                // B. Crear Usuario vinculado a ese ID
                _servAuth.RegistrarUsuario(user, pass, RolUsuario.Estudiante, nuevoId);

                MessageBox.Show($"Estudiante y cuenta '{user}' creados exitosamente.");

                // Limpiar todo...
                txtNombreEst.Clear(); txtCorreoEst.Clear(); txtUserEst.Clear(); txtPassEst.Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // 2. Guardar Profesor
        private void btnGuardarProf_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = Utilidades.LimpiarTexto(txtNombreProf.Text);
                string esp = Utilidades.LimpiarTexto(txtEspecialidadProf.Text);

                string user = Utilidades.LimpiarTexto(txtUserProf.Text);
                string pass = txtPassProf.Text;

                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Debe asignar un usuario y contraseña.");
                    return;
                }

                // A. Crear Instructor y OBTENER ID
                Guid nuevoId = _servInst.RegistrarProfesor(nombre, esp);

                // B. Crear Usuario vinculado
                _servAuth.RegistrarUsuario(user, pass, RolUsuario.Profesor, nuevoId);

                MessageBox.Show($"Instructor y cuenta '{user}' creados.");

                txtNombreProf.Clear(); txtEspecialidadProf.Clear(); txtUserProf.Clear(); txtPassProf.Clear();
                CargarComboProfesores();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // 3. Guardar Curso
        private void btnGuardarCur_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboProfesores.SelectedIndex == -1) { MessageBox.Show("Seleccione Profesor."); return; }

                string nombre = Utilidades.LimpiarTexto(txtNombreCur.Text);
                string horario = Utilidades.LimpiarTexto(txtHorarioCur.Text);
                int cupo = (int)numCupoCur.Value;
                Guid ProfesorId = (Guid)cboProfesores.SelectedValue;

                _servCur.CrearCurso(nombre, horario, cupo, ProfesorId);
                MessageBox.Show("Curso creado.");

                txtNombreCur.Clear(); txtHorarioCur.Clear(); numCupoCur.Value = 20;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // Utilitario visual
        private void EstilizarGrid(DataGridView grid)
        {
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}