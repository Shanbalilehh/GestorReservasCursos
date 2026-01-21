using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public static class GestorDeEstilos
    {
        // ... (Tus colores y fuentes siguen igual, no los borres) ...
        
        public static readonly Color ColorPrimario = Color.FromArgb(44, 62, 80);
        public static readonly Color ColorSecundario = Color.FromArgb(52, 73, 94);
        public static readonly Color ColorAccion = Color.FromArgb(41, 128, 185);
        public static readonly Color ColorPeligro = Color.FromArgb(231, 76, 60);
        public static readonly Color ColorFondo = Color.FromArgb(245, 247, 250);
        public static readonly Color ColorTexto = Color.FromArgb(45, 52, 54);
        public static readonly Color ColorBlanco = Color.White;

        public static readonly Font FuenteTitulo = new Font("Segoe UI", 22, FontStyle.Bold); 
        public static readonly Font FuenteSubtitulo = new Font("Segoe UI", 14, FontStyle.Regular);
        public static readonly Font FuenteNormal = new Font("Segoe UI", 12, FontStyle.Regular);
        public static readonly Font FuenteBoton = new Font("Segoe UI", 11, FontStyle.Bold);
        
        public static readonly Font FuenteLoginTitulo = new Font("Segoe UI", 24, FontStyle.Bold);
        public static readonly Font FuenteLoginInput = new Font("Segoe UI", 14, FontStyle.Regular);

        // --- MÉTODO ACTUALIZADO: TAMAÑO FIJO ---
        public static void AplicarTemaFormulario(Form form)
        {
            form.BackColor = ColorFondo;
            form.Font = FuenteNormal; 
            form.ForeColor = ColorTexto;
            
            // 1. FIJAR TAMAÑO (Resolución HD Estándar)
            // Esto evita que tengas que redimensionar manualmente
            form.Size = new Size(1280, 720); 
            
            // 2. BLOQUEAR REDIMENSIÓN
            // FixedSingle: Borde fijo de una línea (No se puede estirar)
            form.FormBorderStyle = FormBorderStyle.FixedSingle; 
            
            // 3. DESACTIVAR BOTÓN MAXIMIZAR
            // Opcional: Evita que el usuario rompa el diseño maximizando
            form.MaximizeBox = false;

            form.StartPosition = FormStartPosition.CenterScreen;
        }

        // ... (El resto de métodos EstilizarBoton, EstilizarGrid, etc. se mantienen igual) ...
        
        public static void EstilizarBoton(Button btn, bool esPrimario = true)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = FuenteBoton;
            btn.Height = 45; 
            btn.AutoSize = true; 

            if (esPrimario) { btn.BackColor = ColorAccion; btn.ForeColor = ColorBlanco; }
            else { btn.BackColor = ColorPeligro; btn.ForeColor = ColorBlanco; }
        }

        public static void EstilizarGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = ColorBlanco;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorPrimario;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorBlanco;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold); 
            dgv.ColumnHeadersHeight = 45; 
            dgv.EnableHeadersVisualStyles = false;
            dgv.DefaultCellStyle.Font = FuenteNormal; 
            dgv.DefaultCellStyle.BackColor = ColorBlanco;
            dgv.DefaultCellStyle.ForeColor = ColorTexto;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(223, 230, 233); 
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black; 
            dgv.RowTemplate.Height = 40; 
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public static void ConvertirEnDashboard(TabControl tab)
        {
            tab.Appearance = TabAppearance.FlatButtons;
            tab.ItemSize = new Size(0, 1);
            tab.SizeMode = TabSizeMode.Fixed;
            tab.TabStop = false; 
        }

        // --- DISEÑO DE LOGIN MODERNO ---
        // Este método organiza los controles existentes en una tarjeta centrada
        public static void ConfigurarLoginModerno(Panel pnlCard, TextBox txtUser, TextBox txtPass, Button btnIngresar)
        {
            // 1. Estilo de la Tarjeta (Contenedor Blanco)
            pnlCard.BackColor = ColorBlanco;
            pnlCard.BorderStyle = BorderStyle.None; 
            // Tamaño fijo para la tarjeta (tipo móvil)
            pnlCard.Size = new Size(400, 450); 
            
            // 2. Estilo de Inputs (Minimalistas)
            EstilizarInputLogin(txtUser);
            EstilizarInputLogin(txtPass);
            
            // Placeholder visual (Opcional si ya usas labels)
            txtUser.PlaceholderText = "Usuario";
            txtPass.PlaceholderText = "Contraseña";

            // 3. Estilo del Botón (Ancho completo)
            EstilizarBoton(btnIngresar, true);
            btnIngresar.Width = pnlCard.Width - 60; // Margen de 30px a cada lado
            btnIngresar.Height = 50;

            // 4. POSICIONAMIENTO AUTOMÁTICO (Layout Vertical)
            // Calculamos posiciones relativas dentro de la tarjeta
            int padding = 30;
            int startY = 100; // Espacio para el logo/título arriba

            txtUser.Location = new Point(padding, startY);
            txtUser.Width = pnlCard.Width - (padding * 2);

            txtPass.Location = new Point(padding, startY + 70); // 70px abajo
            txtPass.Width = pnlCard.Width - (padding * 2);

            btnIngresar.Location = new Point(padding, startY + 160);
            
            // Nota: El título "Iniciar Sesión" o Logo se debería agregar en el FormPrincipal
            // usando un Label y agregándolo al pnlCard.
        }

        private static void EstilizarInputLogin(TextBox txt)
        {
            txt.Font = FuenteLoginInput; 
            txt.BorderStyle = BorderStyle.None; // Quitamos borde 3D
            txt.AutoSize = false; // Permitir cambiar altura
            txt.Height = 40; 
            txt.BackColor = Color.FromArgb(240, 242, 245); // Fondo gris suave
            
            // Truco: Agregar un panel debajo para simular borde inferior de color si se quisiera
        }

        public static void CentrarControl(Control hijo, Control padre)
        {
            if (hijo == null || padre == null) return;
            int x = (padre.ClientSize.Width - hijo.Width) / 2;
            int y = (padre.ClientSize.Height - hijo.Height) / 2;
            hijo.Location = new Point(x, y);
        }
    }
}