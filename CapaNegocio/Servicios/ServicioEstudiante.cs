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
        private readonly IRepositorio<Estudiante> _repo;
        public ServicioEstudiante(IRepositorio<Estudiante> repo) { _repo = repo; }
        public Guid RegistrarEstudiante(string nombre, string correo)
        {
            // Validaciones de Negocio
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del estudiante es obligatorio.");

            if (string.IsNullOrWhiteSpace(correo) || !correo.Contains("@"))
                throw new ArgumentException("El correo electrónico no es válido.");

            // Verificar duplicados (Regla de Negocio: No repetir correo)
            var estudiantesExistentes = _repo.ObtenerTodos();
            if (estudiantesExistentes.Any(e => e.Correo.Equals(correo, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("Ya existe un estudiante registrado con ese correo.");
            }

            // Crear Entidad
            var nuevo = new Estudiante(nombre, correo);
            _repo.Guardar(nuevo);
            
            return nuevo.Id;
        }
        public List<Estudiante> ObtenerListaEstudiantes() => _repo.ObtenerTodos();
    }
}
