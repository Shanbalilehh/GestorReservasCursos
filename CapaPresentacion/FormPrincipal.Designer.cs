namespace CapaPresentacion
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControlPrincipal = new TabControl();
            tabLogin = new TabPage();
            button2 = new Button();
            txtPass = new TextBox();
            txtUser = new TextBox();
            label3 = new Label();
            label2 = new Label();
            btnIngresar = new Button();
            label1 = new Label();
            tabEstudiante = new TabPage();
            tabControl1 = new TabControl();
            tabMisReservas = new TabPage();
            button5 = new Button();
            btnCancelarReserva = new Button();
            dgvMisReservas = new DataGridView();
            tabOferta = new TabPage();
            btnCerrarSesion = new Button();
            btnReservar = new Button();
            dgvCursos = new DataGridView();
            tabProfesor = new TabPage();
            button3 = new Button();
            btnVerDetalle = new Button();
            dgvMisCursos = new DataGridView();
            tabAdmin = new TabPage();
            tabControl2 = new TabControl();
            tabPage1 = new TabPage();
            button6 = new Button();
            label14 = new Label();
            label15 = new Label();
            txtPassEst = new TextBox();
            txtUserEst = new TextBox();
            label5 = new Label();
            Email = new Label();
            label4 = new Label();
            btnGuardarEst = new Button();
            txtCorreoEst = new TextBox();
            txtNombreEst = new TextBox();
            tabPage2 = new TabPage();
            label16 = new Label();
            label17 = new Label();
            txtPassProf = new TextBox();
            txtUserProf = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            btnGuardarProf = new Button();
            txtEspecialidadProf = new TextBox();
            txtNombreProf = new TextBox();
            tabPage3 = new TabPage();
            label13 = new Label();
            cboProfesores = new ComboBox();
            label12 = new Label();
            numCupoCur = new NumericUpDown();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            btnGuardarCur = new Button();
            txtHorarioCur = new TextBox();
            txtNombreCur = new TextBox();
            button4 = new Button();
            tabControlPrincipal.SuspendLayout();
            tabLogin.SuspendLayout();
            tabEstudiante.SuspendLayout();
            tabControl1.SuspendLayout();
            tabMisReservas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMisReservas).BeginInit();
            tabOferta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCursos).BeginInit();
            tabProfesor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMisCursos).BeginInit();
            tabAdmin.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCupoCur).BeginInit();
            SuspendLayout();
            // 
            // tabControlPrincipal
            // 
            tabControlPrincipal.Controls.Add(tabLogin);
            tabControlPrincipal.Controls.Add(tabEstudiante);
            tabControlPrincipal.Controls.Add(tabProfesor);
            tabControlPrincipal.Controls.Add(tabAdmin);
            tabControlPrincipal.Dock = DockStyle.Fill;
            tabControlPrincipal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            tabControlPrincipal.Location = new Point(0, 0);
            tabControlPrincipal.Margin = new Padding(3, 4, 3, 4);
            tabControlPrincipal.Name = "tabControlPrincipal";
            tabControlPrincipal.SelectedIndex = 0;
            tabControlPrincipal.Size = new Size(923, 580);
            tabControlPrincipal.TabIndex = 0;
            // 
            // tabLogin
            // 
            tabLogin.BackColor = Color.Bisque;
            tabLogin.Controls.Add(button2);
            tabLogin.Controls.Add(txtPass);
            tabLogin.Controls.Add(txtUser);
            tabLogin.Controls.Add(label3);
            tabLogin.Controls.Add(label2);
            tabLogin.Controls.Add(btnIngresar);
            tabLogin.Controls.Add(label1);
            tabLogin.Location = new Point(4, 41);
            tabLogin.Margin = new Padding(3, 4, 3, 4);
            tabLogin.Name = "tabLogin";
            tabLogin.Padding = new Padding(3, 4, 3, 4);
            tabLogin.Size = new Size(915, 535);
            tabLogin.TabIndex = 0;
            tabLogin.Text = "LOGIN";
            // 
            // button2
            // 
            button2.Location = new Point(443, 271);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(173, 59);
            button2.TabIndex = 14;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(456, 199);
            txtPass.Margin = new Padding(3, 4, 3, 4);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(144, 39);
            txtPass.TabIndex = 13;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(456, 126);
            txtUser.Margin = new Padding(3, 4, 3, 4);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(141, 39);
            txtUser.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(313, 129);
            label3.Name = "label3";
            label3.Size = new Size(109, 32);
            label3.TabIndex = 11;
            label3.Text = "Usuario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(287, 202);
            label2.Name = "label2";
            label2.Size = new Size(150, 32);
            label2.TabIndex = 10;
            label2.Text = "Contraseña:";
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(237, 271);
            btnIngresar.Margin = new Padding(3, 4, 3, 4);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(143, 59);
            btnIngresar.TabIndex = 8;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(376, 59);
            label1.Name = "label1";
            label1.Size = new Size(87, 32);
            label1.TabIndex = 7;
            label1.Text = "LOGIN";
            label1.Click += label1_Click;
            // 
            // tabEstudiante
            // 
            tabEstudiante.Controls.Add(tabControl1);
            tabEstudiante.Location = new Point(4, 41);
            tabEstudiante.Margin = new Padding(3, 4, 3, 4);
            tabEstudiante.Name = "tabEstudiante";
            tabEstudiante.Padding = new Padding(3, 4, 3, 4);
            tabEstudiante.Size = new Size(915, 535);
            tabEstudiante.TabIndex = 1;
            tabEstudiante.Text = "ESTUDIANTE";
            tabEstudiante.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabMisReservas);
            tabControl1.Controls.Add(tabOferta);
            tabControl1.Cursor = Cursors.Hand;
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Palatino Linotype", 12F);
            tabControl1.Location = new Point(3, 4);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(909, 527);
            tabControl1.TabIndex = 4;
            // 
            // tabMisReservas
            // 
            tabMisReservas.Controls.Add(button5);
            tabMisReservas.Controls.Add(btnCancelarReserva);
            tabMisReservas.Controls.Add(dgvMisReservas);
            tabMisReservas.Location = new Point(4, 41);
            tabMisReservas.Margin = new Padding(3, 4, 3, 4);
            tabMisReservas.Name = "tabMisReservas";
            tabMisReservas.Padding = new Padding(3, 4, 3, 4);
            tabMisReservas.Size = new Size(901, 482);
            tabMisReservas.TabIndex = 0;
            tabMisReservas.Text = "Mis Reservas";
            tabMisReservas.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.ForeColor = SystemColors.HotTrack;
            button5.Location = new Point(35, 397);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(129, 33);
            button5.TabIndex = 9;
            button5.Text = "Cerrar Sesion";
            button5.UseVisualStyleBackColor = false;
            button5.Click += btnCerrarSesion_Click;
            // 
            // btnCancelarReserva
            // 
            btnCancelarReserva.Location = new Point(329, 397);
            btnCancelarReserva.Margin = new Padding(3, 4, 3, 4);
            btnCancelarReserva.Name = "btnCancelarReserva";
            btnCancelarReserva.Size = new Size(153, 38);
            btnCancelarReserva.TabIndex = 1;
            btnCancelarReserva.Text = "Cancelar Curso";
            btnCancelarReserva.UseVisualStyleBackColor = true;
            btnCancelarReserva.Click += btnCancelarReserva_Click;
            // 
            // dgvMisReservas
            // 
            dgvMisReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMisReservas.Location = new Point(35, 22);
            dgvMisReservas.Margin = new Padding(3, 4, 3, 4);
            dgvMisReservas.Name = "dgvMisReservas";
            dgvMisReservas.RowHeadersWidth = 62;
            dgvMisReservas.Size = new Size(798, 371);
            dgvMisReservas.TabIndex = 0;
            // 
            // tabOferta
            // 
            tabOferta.Controls.Add(btnCerrarSesion);
            tabOferta.Controls.Add(btnReservar);
            tabOferta.Controls.Add(dgvCursos);
            tabOferta.Location = new Point(4, 41);
            tabOferta.Margin = new Padding(3, 4, 3, 4);
            tabOferta.Name = "tabOferta";
            tabOferta.Padding = new Padding(3, 4, 3, 4);
            tabOferta.Size = new Size(892, 440);
            tabOferta.TabIndex = 1;
            tabOferta.Text = "Oferta Academica";
            tabOferta.UseVisualStyleBackColor = true;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.Transparent;
            btnCerrarSesion.ForeColor = SystemColors.HotTrack;
            btnCerrarSesion.Location = new Point(7, 438);
            btnCerrarSesion.Margin = new Padding(3, 4, 3, 4);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(124, 33);
            btnCerrarSesion.TabIndex = 7;
            btnCerrarSesion.Text = "Cerrar Sesion";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnReservar
            // 
            btnReservar.Location = new Point(336, 402);
            btnReservar.Margin = new Padding(3, 4, 3, 4);
            btnReservar.Name = "btnReservar";
            btnReservar.Size = new Size(154, 38);
            btnReservar.TabIndex = 1;
            btnReservar.Text = "Reservar Curso";
            btnReservar.UseVisualStyleBackColor = true;
            btnReservar.Click += btnReservar_Click;
            // 
            // dgvCursos
            // 
            dgvCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCursos.Location = new Point(34, 26);
            dgvCursos.Margin = new Padding(3, 4, 3, 4);
            dgvCursos.Name = "dgvCursos";
            dgvCursos.RowHeadersWidth = 62;
            dgvCursos.Size = new Size(793, 373);
            dgvCursos.TabIndex = 0;
            // 
            // tabProfesor
            // 
            tabProfesor.Controls.Add(button3);
            tabProfesor.Controls.Add(btnVerDetalle);
            tabProfesor.Controls.Add(dgvMisCursos);
            tabProfesor.Font = new Font("Palatino Linotype", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabProfesor.ForeColor = Color.Transparent;
            tabProfesor.Location = new Point(4, 41);
            tabProfesor.Margin = new Padding(3, 4, 3, 4);
            tabProfesor.Name = "tabProfesor";
            tabProfesor.Size = new Size(915, 535);
            tabProfesor.TabIndex = 2;
            tabProfesor.Text = "PROFESOR";
            tabProfesor.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.ForeColor = SystemColors.HotTrack;
            button3.Location = new Point(37, 418);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(132, 33);
            button3.TabIndex = 8;
            button3.Text = "Cerrar Sesion";
            button3.UseVisualStyleBackColor = false;
            button3.Click += btnCerrarSesion_Click;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.Location = new Point(375, 412);
            btnVerDetalle.Margin = new Padding(3, 4, 3, 4);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(117, 39);
            btnVerDetalle.TabIndex = 3;
            btnVerDetalle.Text = "Ver Detalle";
            btnVerDetalle.UseVisualStyleBackColor = true;
            btnVerDetalle.Click += btnVerDetalle_Click;
            // 
            // dgvMisCursos
            // 
            dgvMisCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMisCursos.Location = new Point(37, 52);
            dgvMisCursos.Margin = new Padding(3, 4, 3, 4);
            dgvMisCursos.Name = "dgvMisCursos";
            dgvMisCursos.RowHeadersWidth = 62;
            dgvMisCursos.Size = new Size(797, 342);
            dgvMisCursos.TabIndex = 2;
            // 
            // tabAdmin
            // 
            tabAdmin.Controls.Add(tabControl2);
            tabAdmin.Controls.Add(button4);
            tabAdmin.Location = new Point(4, 41);
            tabAdmin.Margin = new Padding(3, 4, 3, 4);
            tabAdmin.Name = "tabAdmin";
            tabAdmin.Size = new Size(915, 535);
            tabAdmin.TabIndex = 3;
            tabAdmin.Text = "ADMIN";
            tabAdmin.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage1);
            tabControl2.Controls.Add(tabPage2);
            tabControl2.Controls.Add(tabPage3);
            tabControl2.Dock = DockStyle.Fill;
            tabControl2.Font = new Font("Palatino Linotype", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl2.Location = new Point(0, 0);
            tabControl2.Margin = new Padding(3, 4, 3, 4);
            tabControl2.Multiline = true;
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(915, 535);
            tabControl2.TabIndex = 9;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.Bisque;
            tabPage1.Controls.Add(button6);
            tabPage1.Controls.Add(label14);
            tabPage1.Controls.Add(label15);
            tabPage1.Controls.Add(txtPassEst);
            tabPage1.Controls.Add(txtUserEst);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(Email);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(btnGuardarEst);
            tabPage1.Controls.Add(txtCorreoEst);
            tabPage1.Controls.Add(txtNombreEst);
            tabPage1.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage1.Location = new Point(4, 41);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(907, 490);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Estudiantes";
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.ForeColor = SystemColors.HotTrack;
            button6.Location = new Point(16, 384);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(160, 41);
            button6.TabIndex = 10;
            button6.Text = "Cerrar Sesion";
            button6.UseVisualStyleBackColor = false;
            button6.Click += btnCerrarSesion_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Palatino Linotype", 12F);
            label14.Location = new Point(413, 167);
            label14.Name = "label14";
            label14.Size = new Size(141, 32);
            label14.TabIndex = 9;
            label14.Text = "Contraseña:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Palatino Linotype", 12F);
            label15.Location = new Point(428, 108);
            label15.Name = "label15";
            label15.Size = new Size(103, 32);
            label15.TabIndex = 8;
            label15.Text = "Usuario:";
            // 
            // txtPassEst
            // 
            txtPassEst.Font = new Font("Palatino Linotype", 12F);
            txtPassEst.Location = new Point(551, 167);
            txtPassEst.Margin = new Padding(3, 4, 3, 4);
            txtPassEst.Name = "txtPassEst";
            txtPassEst.Size = new Size(155, 40);
            txtPassEst.TabIndex = 7;
            // 
            // txtUserEst
            // 
            txtUserEst.Font = new Font("Palatino Linotype", 12F);
            txtUserEst.Location = new Point(551, 105);
            txtUserEst.Margin = new Padding(3, 4, 3, 4);
            txtUserEst.Name = "txtUserEst";
            txtUserEst.Size = new Size(164, 40);
            txtUserEst.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Palatino Linotype", 12F);
            label5.Location = new Point(290, 33);
            label5.Name = "label5";
            label5.Size = new Size(299, 32);
            label5.TabIndex = 5;
            label5.Text = "Guardar Nuevo Estudiante";
            // 
            // Email
            // 
            Email.AutoSize = true;
            Email.Font = new Font("Palatino Linotype", 12F);
            Email.Location = new Point(130, 171);
            Email.Name = "Email";
            Email.Size = new Size(79, 32);
            Email.TabIndex = 4;
            Email.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Palatino Linotype", 12F);
            label4.Location = new Point(130, 108);
            label4.Name = "label4";
            label4.Size = new Size(107, 32);
            label4.TabIndex = 3;
            label4.Text = "Nombre:";
            // 
            // btnGuardarEst
            // 
            btnGuardarEst.Font = new Font("Palatino Linotype", 12F);
            btnGuardarEst.Location = new Point(375, 282);
            btnGuardarEst.Margin = new Padding(3, 4, 3, 4);
            btnGuardarEst.Name = "btnGuardarEst";
            btnGuardarEst.Size = new Size(156, 59);
            btnGuardarEst.TabIndex = 2;
            btnGuardarEst.Text = "Guardar";
            btnGuardarEst.UseVisualStyleBackColor = true;
            btnGuardarEst.Click += btnGuardarEst_Click;
            // 
            // txtCorreoEst
            // 
            txtCorreoEst.Font = new Font("Palatino Linotype", 12F);
            txtCorreoEst.Location = new Point(248, 167);
            txtCorreoEst.Margin = new Padding(3, 4, 3, 4);
            txtCorreoEst.Name = "txtCorreoEst";
            txtCorreoEst.Size = new Size(159, 40);
            txtCorreoEst.TabIndex = 1;
            // 
            // txtNombreEst
            // 
            txtNombreEst.Font = new Font("Palatino Linotype", 12F);
            txtNombreEst.Location = new Point(246, 105);
            txtNombreEst.Margin = new Padding(3, 4, 3, 4);
            txtNombreEst.Name = "txtNombreEst";
            txtNombreEst.Size = new Size(161, 40);
            txtNombreEst.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.Bisque;
            tabPage2.Controls.Add(label16);
            tabPage2.Controls.Add(label17);
            tabPage2.Controls.Add(txtPassProf);
            tabPage2.Controls.Add(txtUserProf);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(btnGuardarProf);
            tabPage2.Controls.Add(txtEspecialidadProf);
            tabPage2.Controls.Add(txtNombreProf);
            tabPage2.Location = new Point(4, 41);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(907, 490);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Profesores";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Palatino Linotype", 12F);
            label16.Location = new Point(427, 148);
            label16.Name = "label16";
            label16.Size = new Size(141, 32);
            label16.TabIndex = 15;
            label16.Text = "Contraseña:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Palatino Linotype", 12F);
            label17.Location = new Point(452, 94);
            label17.Name = "label17";
            label17.Size = new Size(103, 32);
            label17.TabIndex = 14;
            label17.Text = "Usuario:";
            // 
            // txtPassProf
            // 
            txtPassProf.Font = new Font("Palatino Linotype", 12F);
            txtPassProf.Location = new Point(564, 144);
            txtPassProf.Margin = new Padding(3, 4, 3, 4);
            txtPassProf.Name = "txtPassProf";
            txtPassProf.Size = new Size(172, 40);
            txtPassProf.TabIndex = 13;
            // 
            // txtUserProf
            // 
            txtUserProf.Font = new Font("Palatino Linotype", 12F);
            txtUserProf.Location = new Point(564, 86);
            txtUserProf.Margin = new Padding(3, 4, 3, 4);
            txtUserProf.Name = "txtUserProf";
            txtUserProf.Size = new Size(172, 40);
            txtUserProf.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(317, 38);
            label6.Name = "label6";
            label6.Size = new Size(275, 32);
            label6.TabIndex = 11;
            label6.Text = "Guardar Nuevo Profesor";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(114, 148);
            label7.Name = "label7";
            label7.Size = new Size(152, 32);
            label7.TabIndex = 10;
            label7.Text = "Especialidad:";
            label7.Click += label7_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(159, 94);
            label8.Name = "label8";
            label8.Size = new Size(107, 32);
            label8.TabIndex = 9;
            label8.Text = "Nombre:";
            // 
            // btnGuardarProf
            // 
            btnGuardarProf.Location = new Point(399, 235);
            btnGuardarProf.Margin = new Padding(3, 4, 3, 4);
            btnGuardarProf.Name = "btnGuardarProf";
            btnGuardarProf.Size = new Size(111, 76);
            btnGuardarProf.TabIndex = 8;
            btnGuardarProf.Text = "Guardar";
            btnGuardarProf.UseVisualStyleBackColor = true;
            btnGuardarProf.Click += btnGuardarProf_Click;
            // 
            // txtEspecialidadProf
            // 
            txtEspecialidadProf.Location = new Point(272, 144);
            txtEspecialidadProf.Margin = new Padding(3, 4, 3, 4);
            txtEspecialidadProf.Name = "txtEspecialidadProf";
            txtEspecialidadProf.Size = new Size(149, 40);
            txtEspecialidadProf.TabIndex = 7;
            // 
            // txtNombreProf
            // 
            txtNombreProf.Location = new Point(271, 86);
            txtNombreProf.Margin = new Padding(3, 4, 3, 4);
            txtNombreProf.Name = "txtNombreProf";
            txtNombreProf.Size = new Size(150, 40);
            txtNombreProf.TabIndex = 6;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.Bisque;
            tabPage3.Controls.Add(label13);
            tabPage3.Controls.Add(cboProfesores);
            tabPage3.Controls.Add(label12);
            tabPage3.Controls.Add(numCupoCur);
            tabPage3.Controls.Add(label9);
            tabPage3.Controls.Add(label10);
            tabPage3.Controls.Add(label11);
            tabPage3.Controls.Add(btnGuardarCur);
            tabPage3.Controls.Add(txtHorarioCur);
            tabPage3.Controls.Add(txtNombreCur);
            tabPage3.Location = new Point(4, 41);
            tabPage3.Margin = new Padding(3, 4, 3, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(907, 490);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Cursos";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(239, 243);
            label13.Name = "label13";
            label13.Size = new Size(124, 32);
            label13.TabIndex = 15;
            label13.Text = "Instructor:";
            // 
            // cboProfesores
            // 
            cboProfesores.FormattingEnabled = true;
            cboProfesores.Location = new Point(365, 235);
            cboProfesores.Margin = new Padding(3, 4, 3, 4);
            cboProfesores.Name = "cboProfesores";
            cboProfesores.Size = new Size(134, 40);
            cboProfesores.TabIndex = 14;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(256, 169);
            label12.Name = "label12";
            label12.Size = new Size(78, 32);
            label12.TabIndex = 13;
            label12.Text = "Cupo:";
            // 
            // numCupoCur
            // 
            numCupoCur.Location = new Point(365, 167);
            numCupoCur.Margin = new Padding(3, 4, 3, 4);
            numCupoCur.Name = "numCupoCur";
            numCupoCur.Size = new Size(133, 40);
            numCupoCur.TabIndex = 12;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(293, 22);
            label9.Name = "label9";
            label9.Size = new Size(249, 32);
            label9.TabIndex = 11;
            label9.Text = "Guardar Nuevo Curso";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(256, 119);
            label10.Name = "label10";
            label10.Size = new Size(102, 32);
            label10.TabIndex = 10;
            label10.Text = "Horario:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(256, 77);
            label11.Name = "label11";
            label11.Size = new Size(107, 32);
            label11.TabIndex = 9;
            label11.Text = "Nombre:";
            // 
            // btnGuardarCur
            // 
            btnGuardarCur.Location = new Point(365, 312);
            btnGuardarCur.Margin = new Padding(3, 4, 3, 4);
            btnGuardarCur.Name = "btnGuardarCur";
            btnGuardarCur.Size = new Size(111, 76);
            btnGuardarCur.TabIndex = 8;
            btnGuardarCur.Text = "Guardar";
            btnGuardarCur.UseVisualStyleBackColor = true;
            btnGuardarCur.Click += btnGuardarCur_Click;
            // 
            // txtHorarioCur
            // 
            txtHorarioCur.Location = new Point(366, 117);
            txtHorarioCur.Margin = new Padding(3, 4, 3, 4);
            txtHorarioCur.Name = "txtHorarioCur";
            txtHorarioCur.Size = new Size(111, 40);
            txtHorarioCur.TabIndex = 7;
            // 
            // txtNombreCur
            // 
            txtNombreCur.Location = new Point(365, 69);
            txtNombreCur.Margin = new Padding(3, 4, 3, 4);
            txtNombreCur.Name = "txtNombreCur";
            txtNombreCur.Size = new Size(201, 40);
            txtNombreCur.TabIndex = 6;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.ForeColor = SystemColors.HotTrack;
            button4.Location = new Point(9, 452);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(124, 33);
            button4.TabIndex = 8;
            button4.Text = "Cerrar Sesion";
            button4.UseVisualStyleBackColor = false;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 580);
            Controls.Add(tabControlPrincipal);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormPrincipal";
            Text = "Aplicacion Reservar Cursos";
            Load += FormPrincipal_Load;
            tabControlPrincipal.ResumeLayout(false);
            tabLogin.ResumeLayout(false);
            tabLogin.PerformLayout();
            tabEstudiante.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabMisReservas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMisReservas).EndInit();
            tabOferta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCursos).EndInit();
            tabProfesor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMisCursos).EndInit();
            tabAdmin.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCupoCur).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlPrincipal;
        private TabPage tabLogin;
        private TabPage tabEstudiante;
        private TabPage tabProfesor;
        private TabPage tabAdmin;
        private TextBox txtPass;
        private TextBox txtUser;
        private Label label3;
        private Label label2;
        private Button btnIngresar;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabMisReservas;
        private Button btnCancelarReserva;
        private DataGridView dgvMisReservas;
        private TabPage tabOferta;
        private Button btnReservar;
        private DataGridView dgvCursos;
        private Button btnVerDetalle;
        private DataGridView dgvMisCursos;
        private Button btnCerrarSesion;
        private Button button3;
        private Button button4;
        private TabControl tabControl2;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Label Email;
        private Label label4;
        private Button btnGuardarEst;
        private TextBox txtCorreoEst;
        private TextBox txtNombreEst;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button btnGuardarProf;
        private TextBox txtEspecialidadProf;
        private TextBox txtNombreProf;
        private Label label12;
        private NumericUpDown numCupoCur;
        private Label label9;
        private Label label10;
        private Label label11;
        private Button btnGuardarCur;
        private TextBox txtHorarioCur;
        private TextBox txtNombreCur;
        private Label label13;
        private ComboBox cboProfesores;
        private Button button2;
        private Label label14;
        private Label label15;
        private TextBox txtPassEst;
        private TextBox txtUserEst;
        private Label label16;
        private Label label17;
        private TextBox txtPassProf;
        private TextBox txtUserProf;
        private Button button5;
        private Button button6;
    }
}