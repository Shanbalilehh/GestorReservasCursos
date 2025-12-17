namespace CapaPresentacion
{
    partial class FormEstudiante
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
            tabControl1 = new TabControl();
            tabMisReservas = new TabPage();
            dgvMisReservas = new DataGridView();
            tabOferta = new TabPage();
            dgvCursos = new DataGridView();
            btnReservar = new Button();
            btnCancelar = new Button();
            tabControl1.SuspendLayout();
            tabMisReservas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMisReservas).BeginInit();
            tabOferta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCursos).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabMisReservas);
            tabControl1.Controls.Add(tabOferta);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(424, 426);
            tabControl1.TabIndex = 3;
            // 
            // tabMisReservas
            // 
            tabMisReservas.Controls.Add(btnCancelar);
            tabMisReservas.Controls.Add(dgvMisReservas);
            tabMisReservas.Location = new Point(4, 30);
            tabMisReservas.Name = "tabMisReservas";
            tabMisReservas.Padding = new Padding(3);
            tabMisReservas.Size = new Size(416, 392);
            tabMisReservas.TabIndex = 0;
            tabMisReservas.Text = "Mis Reservas";
            tabMisReservas.UseVisualStyleBackColor = true;
            // 
            // dgvMisReservas
            // 
            dgvMisReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMisReservas.Location = new Point(45, 24);
            dgvMisReservas.Name = "dgvMisReservas";
            dgvMisReservas.Size = new Size(334, 300);
            dgvMisReservas.TabIndex = 0;
            // 
            // tabOferta
            // 
            tabOferta.Controls.Add(btnReservar);
            tabOferta.Controls.Add(dgvCursos);
            tabOferta.Location = new Point(4, 30);
            tabOferta.Name = "tabOferta";
            tabOferta.Padding = new Padding(3);
            tabOferta.Size = new Size(416, 392);
            tabOferta.TabIndex = 1;
            tabOferta.Text = "Oferta Academica";
            tabOferta.UseVisualStyleBackColor = true;
            // 
            // dgvCursos
            // 
            dgvCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCursos.Location = new Point(47, 22);
            dgvCursos.Name = "dgvCursos";
            dgvCursos.Size = new Size(335, 313);
            dgvCursos.TabIndex = 0;
            // 
            // btnReservar
            // 
            btnReservar.Location = new Point(141, 341);
            btnReservar.Name = "btnReservar";
            btnReservar.Size = new Size(139, 38);
            btnReservar.TabIndex = 1;
            btnReservar.Text = "Reservar Curso";
            btnReservar.UseVisualStyleBackColor = true;
            btnReservar.Click += btnReservar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(143, 330);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(133, 41);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar Curso";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormEstudiante
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 450);
            Controls.Add(tabControl1);
            Name = "FormEstudiante";
            Text = "FormEstudiante";
            tabControl1.ResumeLayout(false);
            tabMisReservas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMisReservas).EndInit();
            tabOferta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCursos).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabMisReservas;
        private TabPage tabOferta;
        private DataGridView dgvMisReservas;
        private DataGridView dgvCursos;
        private Button btnReservar;
        private Button btnCancelar;
    }
}