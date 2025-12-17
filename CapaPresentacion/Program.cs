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
                string fileEst = "estudiantes.json";
                string filePro = "profesores.json";
                string fileCur = "cursos.json";
                string fileRes = "reservas.json";
                // Repositorios
                var repoEstudiante = new RepositorioJson<Estudiante>(fileEst);
                var repoProfesor = new RepositorioJson<Profesor>(filePro);
                var repoCurso      = new RepositorioJson<Curso>(fileCur);
                var repoReserva    = new RepositorioJson<Reserva>(fileRes);

                // --- DATA SEEDING (Datos de Prueba Hardcodeados) ---
                // Ahora borramos y creamos de nuevo cada vez que inicia la app
                ReiniciarDatosDePrueba(repoProfesor, repoCurso, repoReserva, filePro, fileCur, fileRes);
                // Servicios
                var servicioEstudiante = new ServicioEstudiante(repoEstudiante);
                var servicioProfesor = new ServicioProfesor(repoProfesor);
                var servicioCurso      = new ServicioCurso(repoCurso, repoProfesor);
                var servicioReserva    = new ServicioReserva(repoReserva, repoCurso);

                
                FormLogin login = new FormLogin();
                DialogResult resultadoLogin = login.ShowDialog();

                if (resultadoLogin == DialogResult.OK)
                {
                    UsuarioSesion usuario = login.UsuarioLogueado;
                    Form ventanaPrincipal = null;

                    switch (usuario.Rol)
                    {
                        case RolUsuario.Estudiante:
                            // Estudiante: Ve Cursos y puede Reservar
                            ventanaPrincipal = new FormEstudiante(usuario, servicioReserva, servicioCurso);
                            break;

                        case RolUsuario.Profesor:
                            // Profesor: Ve sus datos Y SUS CURSOS (¡Actualizado!)
                            ventanaPrincipal = new FormProfesor(usuario, servicioProfesor, servicioCurso);
                            break;

                        case RolUsuario.Desarrollador:
                            // Admin: Ve todo
                            ventanaPrincipal = new FormDesarrollador(servicioEstudiante, servicioProfesor, servicioCurso);
                            break;

                        default:
                            MessageBox.Show("Rol no reconocido.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                    }

                    if (ventanaPrincipal != null)
                    {
                        Application.Run(ventanaPrincipal);
                    }
                }
            }
            catch (Exception ex)
            {
                // Utilidades.RegistrarError("Program", "Main", ex.Message);
                MessageBox.Show($"Error crítico: {ex.Message}", "Fatal", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }        
        }
        private static void ReiniciarDatosDePrueba(
            IRepositorio<Profesor> repoInst, 
            IRepositorio<Curso> repoCurs,
            IRepositorio<Reserva> repoRes, // Agregamos repo reservas para limpiarlas también
            string fInst, string fCur, string fRes)
        {
            // 1. LIMPIEZA TOTAL (Reset)
            // Borramos los archivos para asegurar que iniciamos en blanco
            BorrarArchivo(fInst);
            BorrarArchivo(fCur);
            BorrarArchivo(fRes); 
            // Nota: No borramos estudiantes.json para no perder tu usuario de prueba si lo creaste manualmente,
            // pero podrías borrarlo también si quisieras.

            // 2. CREAR ProfesorES
            var profe1 = new Profesor("Dr. House", "Medicina Diagnóstica");
            var profe2 = new Profesor("Walter White", "Química Avanzada");

            // Guardamos (esto creará los archivos de nuevo)
            repoInst.Guardar(profe1);
            repoInst.Guardar(profe2);

            // 3. CREAR CURSOS
            // Curso 1: Medicina (Cupo limitado para probar validación de 'Lleno')
            var curso1 = new Curso("Diagnóstico Diferencial", "Lun-Mie 10:00", 2, profe1.Id);
            
            // Curso 2: Química (Cupo amplio)
            var curso2 = new Curso("Cristalografía Básica", "Mar-Jue 14:00", 20, profe2.Id);
            
            // Curso 3: Otro de Química
            var curso3 = new Curso("Seguridad en Laboratorio", "Vie 09:00", 15, profe2.Id);

            repoCurs.Guardar(curso1);
            repoCurs.Guardar(curso2);
            repoCurs.Guardar(curso3);
        }

        private static void BorrarArchivo(string nombreArchivo)
        {
            string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nombreArchivo);
            if (File.Exists(rutaCompleta))
            {
                File.Delete(rutaCompleta);
            }
        }
        
    }
}