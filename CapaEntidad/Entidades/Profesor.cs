using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace CapaEntidad.Entidades
{
    public class Profesor
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }

        [JsonIgnore]
        public List<Curso> CursosAsignados { get; set; } = new List<Curso>();

        public Profesor() { }

        public Profesor(string nombre, string especialidad)
        {
            Id = Guid.NewGuid();
            Nombre = nombre;
            Especialidad = especialidad;
        }
    }
}
