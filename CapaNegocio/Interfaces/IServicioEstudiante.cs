using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad.Entidades;

namespace CapaNegocio.Interfaces
{
    public interface IServicioEstudiante
    {
        void RegistrarEstudiante(string nombre, string correo);
        List<Estudiante> ObtenerListaEstudiantes();
    }
}
