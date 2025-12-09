using System;
using System.Windows.Forms;
using CapaEntidad;   // Namespace donde está RepositorioJson
using CapaNegocio; // Namespace donde está ServicioEstudiante

namespace CapaPresentacion
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // --- 1. CONFIGURACIÓN DE DEPENDENCIAS (COMPOSICIÓN) ---
            // Creamos las instancias ANTES de iniciar el formulario
            
            string nombreArchivoBd = "estudiantes_db.json";
            
            // A. Capa de Datos
            IRepositorio<Estudiante> repositorio = new RepositorioJson<Estudiante>(nombreArchivoBd);
            
            // B. Capa de Negocio (Le inyectamos el repositorio)
            IServicioEstudiante servicio = new ServicioEstudiante(repositorio);

            // --- 2. INICIO DE LA APLICACIÓN ---
            // C. Capa de Presentación (Le inyectamos el servicio)
            // Ahora Form1 tiene todo lo que necesita para funcionar
            Form1 formularioPrincipal = new Form1(servicio);

            try 
            {
                Application.Run(formularioPrincipal);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fatal al iniciar: {ex.Message}");
            }
        }
    }
}