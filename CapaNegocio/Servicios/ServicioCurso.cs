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
    public class ServicioCurso : IServicioCurso
    {
        private readonly IRepositorio<Curso> _repoCurso;
        private readonly IRepositorio<Profesor> _repoProfesor;

        public ServicioCurso(IRepositorio<Curso> repoCurso, IRepositorio<Profesor> repoProfesor)
        {
            _repoCurso = repoCurso;
            _repoProfesor = repoProfesor;
        }

        public void CrearCurso(string nombre, string horario, int cupo, Guid ProfesorId)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("Nombre obligatorio.");
            if (cupo <= 0) throw new ArgumentException("Cupo debe ser mayor a 0.");

            var Profesor = _repoProfesor.ObtenerPorId(ProfesorId);
            if (Profesor == null) throw new InvalidOperationException("Profesor no existe.");

            _repoCurso.Guardar(new Curso(nombre, horario, cupo, ProfesorId));
        }

        public List<Curso> ObtenerOfertaAcademica() => _repoCurso.ObtenerTodos();
        
        // IMPLEMENTACIÓN DEL NUEVO MÉTODO
        public Curso ObtenerCursoPorId(Guid id) => _repoCurso.ObtenerPorId(id);
    }
}
