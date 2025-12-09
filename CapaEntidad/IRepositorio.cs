using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public interface IRepositorio<T>
    {
        List<T> ObtenerTodos();
        T ObtenerPorId(Guid id);
        void Guardar(T entidad);
        // Aquí irían Eliminar y Actualizar en el futuro
    }
}
