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
        private readonly IRepositorio<Estudiante> _repositorioEstudiante;

        public ServicioEstudiante(IRepositorio<Estudiante> repoEstudiante)
        {
            _repositorioEstudiante = repoEstudiante;
        }

        public void RegistrarEstudiante(string nombre, string correo)
        {
            // Validaciones de Negocio
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del estudiante es obligatorio.");

            if (string.IsNullOrWhiteSpace(correo) || !correo.Contains("@"))
                throw new ArgumentException("El correo electrónico no es válido.");

            // Verificar duplicados (Regla de Negocio: No repetir correo)
            var estudiantesExistentes = _repositorioEstudiante.ObtenerTodos();
            if (estudiantesExistentes.Any(e => e.Correo.Equals(correo, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("Ya existe un estudiante registrado con ese correo.");
            }

            // Crear Entidad
            var nuevoEstudiante = new Estudiante(nombre, correo);

            // Persistir (Guardar en JSON)
            _repositorioEstudiante.Guardar(nuevoEstudiante);
        }

        public List<Estudiante> ObtenerListaEstudiantes()
        {
            return _repositorioEstudiante.ObtenerTodos();
        }
    }
}
