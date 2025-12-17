using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace CapaEntidad.Entidades
{
    public class Reserva
    {
        public Guid Id { get; set; }
        public Guid EstudianteId { get; set; }
        public Guid CursoId { get; set; }
        public DateTime FechaReserva { get; set; }

        [JsonIgnore]
        public Estudiante Estudiante { get; set; }
        
        [JsonIgnore]
        public Curso Curso { get; set; }

        public Reserva() { }

        public Reserva(Guid estudianteId, Guid cursoId)
        {
            Id = Guid.NewGuid();
            EstudianteId = estudianteId;
            CursoId = cursoId;
            FechaReserva = DateTime.Now;
        }
    }
}
