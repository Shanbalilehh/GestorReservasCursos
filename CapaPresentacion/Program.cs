using System;
using System.Windows.Forms;
using CapaEntidad.Repositorios;
using CapaEntidad.Entidades;
using CapaEntidad.Interfaces;
using CapaNegocio.Servicios;

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
                // ==============================================================
                // 1. CONFIGURACIÓN DE ARCHIVOS
                // ==============================================================
                string fileEst = "estudiantes.json";
                string fileInst = "Profesores.json";
                string fileCur = "cursos.json";
                string fileRes = "reservas.json";
                string fileUser = "usuarios.json"; 

                // ==============================================================
                // 2. CREACIÓN DE REPOSITORIOS
                // ==============================================================
                var repoEstudiante = new RepositorioJson<Estudiante>(fileEst);
                var repoProfesor = new RepositorioJson<Profesor>(fileInst);
                var repoCurso      = new RepositorioJson<Curso>(fileCur);
                var repoReserva    = new RepositorioJson<Reserva>(fileRes);
                var repoUsuario    = new RepositorioJson<Usuario>(fileUser);

                // ==============================================================
                // 3. DATA SEEDING (Reinicio Limpio)
                // ==============================================================
                // Solo crea al Admin. El resto lo hará el usuario desde la UI.
                ReiniciarDatosDePrueba(repoUsuario, fileEst, fileInst, fileCur, fileRes, fileUser);

                // ==============================================================
                // 4. CREACIÓN DE SERVICIOS
                // ==============================================================
                var servAuth = new ServicioAutenticacion(repoUsuario);
                var servEst = new ServicioEstudiante(repoEstudiante);
                var servInst = new ServicioProfesor(repoProfesor);
                var servCur = new ServicioCurso(repoCurso, repoProfesor);
                var servRes = new ServicioReserva(repoReserva, repoCurso);

                // ==============================================================
                // 5. INICIO DE LA APLICACIÓN
                // ==============================================================
                Application.Run(new FormPrincipal(servAuth, servEst, servInst, servCur, servRes));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al iniciar: {ex.Message}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private static void ReiniciarDatosDePrueba(
            IRepositorio<Usuario> repoUser, 
            string fEst, string fInst, string fCur, string fRes, string fUser)
        {
            // A. LIMPIEZA TOTAL (Empezamos de cero cada vez)
            ResetearArchivo(fEst);
            ResetearArchivo(fInst);
            ResetearArchivo(fCur);
            ResetearArchivo(fRes);
            ResetearArchivo(fUser);

            // B. CREAR SOLO ADMIN
            // Este es el único usuario que existirá al iniciar la app por primera vez.
            // Rol: Desarrollador (Acceso total)
            var adminUser = new Usuario("admin", "admin123", (int)RolUsuario.Desarrollador, Guid.Empty);
            repoUser.Guardar(adminUser);
        }

        private static void ResetearArchivo(string nombreArchivo)
        {
            try 
            {
                string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nombreArchivo);
                // Escribimos un array JSON vacío para reiniciar
                File.WriteAllText(rutaCompleta, "[]");
            }
            catch 
            {
                // Ignorar errores de acceso en tiempo de desarrollo
            }
        }        
    }
}