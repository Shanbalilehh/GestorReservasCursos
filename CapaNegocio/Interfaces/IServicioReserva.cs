using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad.Entidades;

namespace CapaNegocio.Interfaces
{
    public interface IServicioReserva
    {
        void Reservar(Guid estudianteId, Guid cursoId);
        List<Reserva> ObtenerReservasPorEstudiante(Guid estudianteId);
        int ObtenerCantidadInscritos(Guid cursoId);
        List<Reserva> ObtenerReservasPorCurso(Guid cursoId);
    }
}
