using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad.Entidades;
using CapaNegocio.Interfaces;
using CapaEntidad.Interfaces;

namespace CapaNegocio.Servicios
{
    public class ServicioProfesor : IServicioProfesor
    {
        private readonly IRepositorio<Profesor> _repo;
        public ServicioProfesor(IRepositorio<Profesor> repo) { _repo = repo; }
        public Guid RegistrarProfesor(string nombre, string especialidad)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("Nombre requerido");
            
            var nuevo = new Profesor(nombre, especialidad);
            _repo.Guardar(nuevo);
            
            return nuevo.Id; // Retornamos ID
        }

        public List<Profesor> ObtenerTodos() => _repo.ObtenerTodos();
    }
}
