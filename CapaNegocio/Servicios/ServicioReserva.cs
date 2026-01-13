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
    public class ServicioReserva : IServicioReserva
    {
        private readonly IRepositorio<Reserva> _repoReserva;
        private readonly IRepositorio<Curso> _repoCurso;

        public ServicioReserva(IRepositorio<Reserva> repoReserva, IRepositorio<Curso> repoCurso)
        {
            _repoReserva = repoReserva;
            _repoCurso = repoCurso;
        }

        public void Reservar(Guid estudianteId, Guid cursoId)
        {
            var curso = _repoCurso.ObtenerPorId(cursoId);
            if (curso == null) throw new ArgumentException("Curso no existe.");

            // Usamos el nuevo método interno para validar
            int inscritos = ObtenerCantidadInscritos(cursoId);
            if (inscritos >= curso.CupoMaximo)
                throw new InvalidOperationException("El curso está lleno.");

            var reservas = _repoReserva.ObtenerTodos();
            if (reservas.Any(r => r.CursoId == cursoId && r.EstudianteId == estudianteId))
                throw new InvalidOperationException("Ya estás inscrito en este curso.");

            _repoReserva.Guardar(new Reserva(estudianteId, cursoId));
        }

        public List<Reserva> ObtenerReservasPorEstudiante(Guid estudianteId)
        {
            return _repoReserva.ObtenerTodos().Where(r => r.EstudianteId == estudianteId).ToList();
        }

        public int ObtenerCantidadInscritos(Guid cursoId)
        {
            return _repoReserva.ObtenerTodos().Count(r => r.CursoId == cursoId);
        }
        
        public List<Reserva> ObtenerReservasPorCurso(Guid cursoId)
        {
            return _repoReserva.ObtenerTodos().Where(r => r.CursoId == cursoId).ToList();
        }
        public void CancelarReserva(Guid reservaId)
        {
            // Aquí podrías validar reglas de negocio extras
            // Ej: "No se puede cancelar si el curso ya empezó"
            
            _repoReserva.Eliminar(reservaId);
        }
    }
}
