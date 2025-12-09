using System;
using System.Windows.Forms;
using CapaEntidad;   // Namespace donde está RepositorioJson
using CapaEntidad.Entidades;
using CapaEntidad.Interfaces;
using CapaEntidad.Repositorios;
using CapaNegocio.Servicios; // Namespace donde está ServicioEstudiante
using CapaNegocio.Interfaces;

namespace CapaPresentacion
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            try 
            {
                // Creamos las instancias ANTES de iniciar el formulario
                string nombreArchivoBd = "estudiantes_db.json";
                
                // A. Capa de Datos
                IRepositorio<Estudiante> repositorio = new RepositorioJson<Estudiante>(nombreArchivoBd);
                
                // B. Capa de Negocio (Le inyectamos el repositorio)
                IServicioEstudiante servicio = new ServicioEstudiante(repositorio);

                // C. Capa de Presentación (Le inyectamos el servicio)
                Form1 formularioPrincipal = new Form1(servicio);
                Application.Run(formularioPrincipal);
            }
            catch (UnauthorizedAccessException uaEx)
            {
                MessageBox.Show($"Error de permisos al acceder al archivo de datos: {uaEx.Message}");
            }
            catch (System.IO.IOException ioEx)
            {
                MessageBox.Show($"Error de entrada/salida al acceder al archivo de datos: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fatal al iniciar: {ex.Message}");
            }
        }
    }
}