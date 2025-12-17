using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad.Entidades;

namespace CapaNegocio.Interfaces
{
    public interface IServicioCurso
    {
       void CrearCurso(string nombre, string horario, int cupo, Guid ProfesorId);
        List<Curso> ObtenerOfertaAcademica();
        Curso ObtenerCursoPorId(Guid id);
    }
}
