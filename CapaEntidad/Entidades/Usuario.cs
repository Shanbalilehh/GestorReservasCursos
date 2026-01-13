using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Entidades
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // En un sistema real, esto iría cifrado (Hash)
        public int Rol { get; set; } // Guardamos el int del Enum RolUsuario
        
        // FK: El ID del Estudiante o Instructor al que pertenece esta cuenta
        // Si es Admin, puede ser Guid.Empty o un ID específico
        public Guid EntidadId { get; set; } 

        public Usuario() { }

        public Usuario(string user, string pass, int rol, Guid entidadId)
        {
            Id = Guid.NewGuid();
            Username = user;
            Password = pass;
            Rol = rol;
            EntidadId = entidadId;
        }
    }
}
