using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Estudiante
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public DateTime FechaRegistro { get; set; }

        // Constructor vacío necesario para la deserialización JSON
        public Estudiante() { }

        public Estudiante(string nombre, string correo)
        {
            Id = Guid.NewGuid();
            Nombre = nombre;
            Correo = correo;
            FechaRegistro = DateTime.Now;
        }
    }
}
