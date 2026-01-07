using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace CapaEntidad.Entidades
{
    public class Curso
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Horario { get; set; }
        public int CupoMaximo { get; set; }
        
        public Guid ProfesorId { get; set; } 
        
        [JsonIgnore]
        public Profesor Profesor { get; set; }

        [JsonIgnore]
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();

        public Curso() { }

        public Curso(string nombre, string horario, int cupoMaximo, Guid profesorId)
        {
            Id = Guid.NewGuid();
            Nombre = nombre;
            Horario = horario;
            CupoMaximo = cupoMaximo;
            ProfesorId = profesorId;
        }
    }
}
