using System;
using System.Windows.Forms;
using CapaNegocio.Servicios;

namespace CapaPresentacion
{
    public partial class FormLogin : Form
    {
        private readonly ServicioAutenticacion _authService;
        
        // Propiedad pública para que Program.cs sepa quién entró y qué rol tiene
        public UsuarioSesion UsuarioLogueado { get; private set; }

        public FormLogin()
        {
            InitializeComponent();
            _authService = new ServicioAutenticacion();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;

            // Llamamos al negocio
            var usuario = _authService.Login(user, pass);

            if (usuario != null)
            {
                // ¡Login Exitoso!
                UsuarioLogueado = usuario;
                
                // ESTO ES CLAVE: Le decimos al programa que el resultado fue OK
                // Esto permite que Program.cs cierre esta ventana y abra la siguiente
                this.DialogResult = DialogResult.OK; 
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Clear();
                txtPass.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
