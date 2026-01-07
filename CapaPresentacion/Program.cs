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
                // Configuración de archivos
                string fileEst = "estudiantes.json";
                string fileInst = "Profesores.json";
                string fileCur = "cursos.json";
                string fileRes = "reservas.json";

                var repoEstudiante = new RepositorioJson<Estudiante>(fileEst);
                var repoProfesor = new RepositorioJson<Profesor>(fileInst);
                var repoCurso      = new RepositorioJson<Curso>(fileCur);
                var repoReserva    = new RepositorioJson<Reserva>(fileRes);

                // DATA SEEDING (Reinicio de datos)
                ReiniciarDatosDePrueba(repoEstudiante, repoProfesor, repoCurso, repoReserva, fileEst, fileInst, fileCur, fileRes);

                // Servicios
                var servAuth = new ServicioAutenticacion();
                var servEst = new ServicioEstudiante(repoEstudiante);
                var servInst = new ServicioProfesor(repoProfesor);
                var servCur = new ServicioCurso(repoCurso, repoProfesor);
                var servRes = new ServicioReserva(repoReserva, repoCurso);

                Application.Run(new FormPrincipal(servAuth, servEst, servInst, servCur, servRes));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico: {ex.Message}");
            }
        }

        private static void ReiniciarDatosDePrueba(
            IRepositorio<Estudiante> repoEst,
            IRepositorio<Profesor> repoInst, 
            IRepositorio<Curso> repoCurs,
            IRepositorio<Reserva> repoRes,
            string fEst, string fInst, string fCur, string fRes)
        {
            // 1. LIMPIEZA SEGURA (Reset)
            // En lugar de borrar el archivo (lo que causa error al leer), 
            // escribimos "[]" para indicar una lista vacía válida.
            ResetearArchivo(fEst);
            ResetearArchivo(fInst);
            ResetearArchivo(fCur);
            ResetearArchivo(fRes);

            // 2. CREAR USUARIOS FIJOS
            Guid idProfeFijo = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var profe1 = new Profesor("Profesor X", "Mutantes") { Id = idProfeFijo };
            
            Guid idAlumnoFijo = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var alumno1 = new Estudiante("Juan Perez", "juan@test.com") { Id = idAlumnoFijo };

            repoInst.Guardar(profe1);
            repoEst.Guardar(alumno1);

            // 3. CREAR CURSOS ASIGNADOS
            var curso1 = new Curso("Lógica de Programación", "Lun-Mie 10:00", 5, idProfeFijo);
            var curso2 = new Curso("SQL Server Avanzado", "Mar-Jue 18:00", 20, idProfeFijo);

            repoCurs.Guardar(curso1);
            repoCurs.Guardar(curso2);
        }

        // Método actualizado: Escribe [] en lugar de borrar
        private static void ResetearArchivo(string nombreArchivo)
        {
            try 
            {
                string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nombreArchivo);
                // Sobrescribimos con un array vacío. Así File.ReadAllText no falla después.
                File.WriteAllText(rutaCompleta, "[]");
            }
            catch 
            {
                // Ignoramos errores de escritura (ej. archivo bloqueado) en entorno de prueba
            }
        }        
    }
}