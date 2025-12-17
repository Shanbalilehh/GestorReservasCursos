using System;

namespace CapaNegocio.Servicios
{
    // definir los Roles
    public enum RolUsuario
    {
        Desarrollador, 
        Profesor,    
        Estudiante     
    }

    // Usuario (solo para sesión)
    public class UsuarioSesion
    {
        public Guid Id { get; set; } 
        public string Username { get; set; }
        public RolUsuario Rol { get; set; }
    }

    // 3. Servicio de Autenticación
    public class ServicioAutenticacion
    {
        public UsuarioSesion Login(string usuario, string password)
        {
            
            if (usuario == "admin" && password == "admin123")
            {
                return new UsuarioSesion 
                { 
                    Id = Guid.NewGuid(), 
                    Username = "Admin", 
                    Rol = RolUsuario.Desarrollador 
                };
            }

            if (usuario == "profe" && password == "profe123")
            {
                return new UsuarioSesion 
                { 
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), 
                    Username = "Profesor X", 
                    Rol = RolUsuario.Profesor 
                };
            }

            if (usuario == "alumno" && password == "alumno123")
            {
                return new UsuarioSesion 
                { 
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), 
                    Username = "Juan Perez", 
                    Rol = RolUsuario.Estudiante 
                };
            }

            return null;
        }
    }
}
