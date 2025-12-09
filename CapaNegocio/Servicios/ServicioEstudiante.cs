using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad.Entidades;
using CapaEntidad.Interfaces;
using CapaNegocio.Interfaces;

namespace CapaNegocio.Servicios
{
    public class ServicioEstudiante : IServicioEstudiante
    {
        // Inyección de Dependencia: El servicio recibe el repositorio, no lo crea.
        private readonly IRepositorio<Estudiante> _repositorioEstudiante;

        public ServicioEstudiante(IRepositorio<Estudiante> repoEstudiante)
        {
            _repositorioEstudiante = repoEstudiante;
        }

        public void RegistrarEstudiante(string nombre, string correo)
        {
            // 1. Validaciones de Negocio
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del estudiante es obligatorio.");

            if (string.IsNullOrWhiteSpace(correo) || !correo.Contains("@"))
                throw new ArgumentException("El correo electrónico no es válido.");

            // 2. Verificar duplicados (Regla de Negocio: No repetir correo)
            var estudiantesExistentes = _repositorioEstudiante.ObtenerTodos();
            if (estudiantesExistentes.Any(e => e.Correo.Equals(correo, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("Ya existe un estudiante registrado con ese correo.");
            }

            // 3. Crear Entidad
            var nuevoEstudiante = new Estudiante(nombre, correo);

            // 4. Persistir (Guardar en JSON)
            _repositorioEstudiante.Guardar(nuevoEstudiante);
        }

        public List<Estudiante> ObtenerListaEstudiantes()
        {
            return _repositorioEstudiante.ObtenerTodos();
        }
    }
}
