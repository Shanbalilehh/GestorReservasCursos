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
            txtPass = new TextBox();
            txtUser = new TextBox();
            label3 = new Label();
            label2 = new Label();
            btnCancelar = new Button();
            btnIngresar = new Button();
            label1 = new Label();
            tabEstudiante = new TabPage();
            btnCerrarSesion = new Button();
            tabControl1 = new TabControl();
            tabMisReservas = new TabPage();
            button1 = new Button();
            dgvMisReservas = new DataGridView();
            tabOferta = new TabPage();
            btnReservar = new Button();
            dgvCursos = new DataGridView();
            tabProfesor = new TabPage();
            button3 = new Button();
            btnVerDetalle = new Button();
            dgvMisCursos = new DataGridView();
            tabAdmin = new TabPage();
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
            SuspendLayout();
            // 
            // tabControlPrincipal
            // 
            tabControlPrincipal.Controls.Add(tabLogin);
            tabControlPrincipal.Controls.Add(tabEstudiante);
            tabControlPrincipal.Controls.Add(tabProfesor);
            tabControlPrincipal.Controls.Add(tabAdmin);
            tabControlPrincipal.Dock = DockStyle.Fill;
            tabControlPrincipal.Location = new Point(0, 0);
            tabControlPrincipal.Name = "tabControlPrincipal";
            tabControlPrincipal.SelectedIndex = 0;
            tabControlPrincipal.Size = new Size(800, 450);
            tabControlPrincipal.TabIndex = 0;
            // 
            // tabLogin
            // 
            tabLogin.Controls.Add(txtPass);
            tabLogin.Controls.Add(txtUser);
            tabLogin.Controls.Add(label3);
            tabLogin.Controls.Add(label2);
            tabLogin.Controls.Add(btnCancelar);
            tabLogin.Controls.Add(btnIngresar);
            tabLogin.Controls.Add(label1);
            tabLogin.Location = new Point(4, 30);
            tabLogin.Name = "tabLogin";
            tabLogin.Padding = new Padding(3);
            tabLogin.Size = new Size(792, 416);
            tabLogin.TabIndex = 0;
            tabLogin.Text = "LOGIN";
            tabLogin.UseVisualStyleBackColor = true;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(399, 170);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(100, 29);
            txtPass.TabIndex = 13;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(399, 130);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(100, 29);
            txtUser.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(282, 130);
            label3.Name = "label3";
            label3.Size = new Size(67, 21);
            label3.TabIndex = 11;
            label3.Text = "Usuario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(282, 173);
            label2.Name = "label2";
            label2.Size = new Size(92, 21);
            label2.TabIndex = 10;
            label2.Text = "Contraseña:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(399, 228);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(81, 32);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(301, 228);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(78, 32);
            btnIngresar.TabIndex = 8;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(368, 85);
            label1.Name = "label1";
            label1.Size = new Size(56, 21);
            label1.TabIndex = 7;
            label1.Text = "LOGIN";
            // 
            // tabEstudiante
            // 
            tabEstudiante.Controls.Add(btnCerrarSesion);
            tabEstudiante.Controls.Add(tabControl1);
            tabEstudiante.Location = new Point(4, 30);
            tabEstudiante.Name = "tabEstudiante";
            tabEstudiante.Padding = new Padding(3);
            tabEstudiante.Size = new Size(792, 416);
            tabEstudiante.TabIndex = 1;
            tabEstudiante.Text = "ESTUDIANTE";
            tabEstudiante.UseVisualStyleBackColor = true;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.Transparent;
            btnCerrarSesion.ForeColor = SystemColors.HotTrack;
            btnCerrarSesion.Location = new Point(6, 382);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(112, 28);
            btnCerrarSesion.TabIndex = 7;
            btnCerrarSesion.Text = "Cerrar Sesion";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabMisReservas);
            tabControl1.Controls.Add(tabOferta);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(786, 410);
            tabControl1.TabIndex = 4;
            // 
            // tabMisReservas
            // 
            tabMisReservas.Controls.Add(button1);
            tabMisReservas.Controls.Add(dgvMisReservas);
            tabMisReservas.Location = new Point(4, 30);
            tabMisReservas.Name = "tabMisReservas";
            tabMisReservas.Padding = new Padding(3);
            tabMisReservas.Size = new Size(778, 376);
            tabMisReservas.TabIndex = 0;
            tabMisReservas.Text = "Mis Reservas";
            tabMisReservas.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(310, 342);
            button1.Name = "button1";
            button1.Size = new Size(133, 28);
            button1.TabIndex = 1;
            button1.Text = "Cancelar Curso";
            button1.UseVisualStyleBackColor = true;
            // 
            // dgvMisReservas
            // 
            dgvMisReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMisReservas.Location = new Point(31, 24);
            dgvMisReservas.Name = "dgvMisReservas";
            dgvMisReservas.Size = new Size(718, 312);
            dgvMisReservas.TabIndex = 0;
            // 
            // tabOferta
            // 
            tabOferta.Controls.Add(btnReservar);
            tabOferta.Controls.Add(dgvCursos);
            tabOferta.Location = new Point(4, 30);
            tabOferta.Name = "tabOferta";
            tabOferta.Padding = new Padding(3);
            tabOferta.Size = new Size(778, 376);
            tabOferta.TabIndex = 1;
            tabOferta.Text = "Oferta Academica";
            tabOferta.UseVisualStyleBackColor = true;
            // 
            // btnReservar
            // 
            btnReservar.Location = new Point(302, 338);
            btnReservar.Name = "btnReservar";
            btnReservar.Size = new Size(139, 32);
            btnReservar.TabIndex = 1;
            btnReservar.Text = "Reservar Curso";
            btnReservar.UseVisualStyleBackColor = true;
            btnReservar.Click += btnReservar_Click;
            // 
            // dgvCursos
            // 
            dgvCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCursos.Location = new Point(31, 22);
            dgvCursos.Name = "dgvCursos";
            dgvCursos.Size = new Size(714, 313);
            dgvCursos.TabIndex = 0;
            // 
            // tabProfesor
            // 
            tabProfesor.Controls.Add(button3);
            tabProfesor.Controls.Add(btnVerDetalle);
            tabProfesor.Controls.Add(dgvMisCursos);
            tabProfesor.Location = new Point(4, 30);
            tabProfesor.Name = "tabProfesor";
            tabProfesor.Size = new Size(792, 416);
            tabProfesor.TabIndex = 2;
            tabProfesor.Text = "PROFESOR";
            tabProfesor.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.ForeColor = SystemColors.HotTrack;
            button3.Location = new Point(8, 380);
            button3.Name = "button3";
            button3.Size = new Size(112, 28);
            button3.TabIndex = 8;
            button3.Text = "Cerrar Sesion";
            button3.UseVisualStyleBackColor = false;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.Location = new Point(337, 338);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(105, 33);
            btnVerDetalle.TabIndex = 3;
            btnVerDetalle.Text = "Ver Detalle";
            btnVerDetalle.UseVisualStyleBackColor = true;
            btnVerDetalle.Click += btnVerDetalle_Click;
            // 
            // dgvMisCursos
            // 
            dgvMisCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMisCursos.Location = new Point(37, 45);
            dgvMisCursos.Name = "dgvMisCursos";
            dgvMisCursos.Size = new Size(717, 287);
            dgvMisCursos.TabIndex = 2;
            // 
            // tabAdmin
            // 
            tabAdmin.Controls.Add(button4);
            tabAdmin.Location = new Point(4, 30);
            tabAdmin.Name = "tabAdmin";
            tabAdmin.Size = new Size(792, 416);
            tabAdmin.TabIndex = 3;
            tabAdmin.Text = "ADMIN";
            tabAdmin.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.ForeColor = SystemColors.HotTrack;
            button4.Location = new Point(8, 380);
            button4.Name = "button4";
            button4.Size = new Size(112, 28);
            button4.TabIndex = 8;
            button4.Text = "Cerrar Sesion";
            button4.UseVisualStyleBackColor = false;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControlPrincipal);
            Name = "FormPrincipal";
            Text = "FormPrincipal";
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
        private Button btnCancelar;
        private Button btnIngresar;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabMisReservas;
        private Button button1;
        private DataGridView dgvMisReservas;
        private TabPage tabOferta;
        private Button btnReservar;
        private DataGridView dgvCursos;
        private Button btnVerDetalle;
        private DataGridView dgvMisCursos;
        private Button btnCerrarSesion;
        private Button button3;
        private Button button4;
    }
}