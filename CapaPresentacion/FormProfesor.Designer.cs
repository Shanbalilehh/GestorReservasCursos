namespace CapaPresentacion
{
    partial class FormProfesor
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
            dgvMisCursos = new DataGridView();
            btnVerDetalle = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMisCursos).BeginInit();
            SuspendLayout();
            // 
            // dgvMisCursos
            // 
            dgvMisCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMisCursos.Location = new Point(58, 41);
            dgvMisCursos.Name = "dgvMisCursos";
            dgvMisCursos.Size = new Size(415, 287);
            dgvMisCursos.TabIndex = 0;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.Location = new Point(206, 334);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(105, 33);
            btnVerDetalle.TabIndex = 1;
            btnVerDetalle.Text = "Ver Detalle";
            btnVerDetalle.UseVisualStyleBackColor = true;
            btnVerDetalle.Click += btnVerDetalle_Click;
            // 
            // FormProfesor
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 440);
            Controls.Add(btnVerDetalle);
            Controls.Add(dgvMisCursos);
            Name = "FormProfesor";
            Text = "FormProfesor";
            ((System.ComponentModel.ISupportInitialize)dgvMisCursos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvMisCursos;
        private Button btnVerDetalle;
    }
}