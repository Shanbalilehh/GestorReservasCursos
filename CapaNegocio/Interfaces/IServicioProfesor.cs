using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad.Entidades;

namespace CapaNegocio.Interfaces
{
    public interface IServicioProfesor
    {
        Guid RegistrarProfesor(string nombre, string especialidad);
        List<Profesor> ObtenerTodos();
    }
}
