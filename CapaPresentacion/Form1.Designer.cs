namespace CapaPresentacion
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNombre = new TextBox();
            txtCorreo = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnCrearEstdnt = new Button();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(120, 91);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 29);
            txtNombre.TabIndex = 0;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(120, 144);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(100, 29);
            txtCorreo.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(297, 9);
            label1.Name = "label1";
            label1.Size = new Size(199, 21);
            label1.TabIndex = 2;
            label1.Text = "App Gestor Reserva Cursos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 94);
            label2.Name = "label2";
            label2.Size = new Size(71, 21);
            label2.TabIndex = 3;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 147);
            label3.Name = "label3";
            label3.Size = new Size(51, 21);
            label3.TabIndex = 4;
            label3.Text = "Email:";
            // 
            // btnCrearEstdnt
            // 
            btnCrearEstdnt.Location = new Point(120, 194);
            btnCrearEstdnt.Name = "btnCrearEstdnt";
            btnCrearEstdnt.Size = new Size(100, 64);
            btnCrearEstdnt.TabIndex = 5;
            btnCrearEstdnt.Text = "Crear estudiante";
            btnCrearEstdnt.UseVisualStyleBackColor = true;
            btnCrearEstdnt.Click += btnCrearEstdnt_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCrearEstdnt);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCorreo);
            Controls.Add(txtNombre);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtCorreo;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnCrearEstdnt;
    }
}
