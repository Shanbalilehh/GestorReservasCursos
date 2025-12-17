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
        private readonly IRepositorio<Profesor> _repoProfesor;

        public ServicioProfesor(IRepositorio<Profesor> repoProfesor)
        {
            _repoProfesor = repoProfesor;
        }

        public void RegistrarProfesor(string nombre, string especialidad)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(especialidad)) throw new ArgumentException("La especialidad es obligatoria.");

            _repoProfesor.Guardar(new Profesor(nombre, especialidad));
        }

        public List<Profesor> ObtenerTodos() => _repoProfesor.ObtenerTodos();
    }
}
