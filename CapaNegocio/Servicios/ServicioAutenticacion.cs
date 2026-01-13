using System;
using System.Linq;
using CapaEntidad.Entidades;
using CapaEntidad.Interfaces;

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
        private readonly IRepositorio<Usuario> _repoUsuarios;
        public ServicioAutenticacion(IRepositorio<Usuario> repoUsuarios)
        {
            _repoUsuarios = repoUsuarios;
        }

        public UsuarioSesion Login(string user, string pass)
        {
            var usuarios = _repoUsuarios.ObtenerTodos();
            
            // Buscar coincidencia exacta
            var cuenta = usuarios.FirstOrDefault(u => u.Username == user && u.Password == pass);

            if (cuenta != null)
            {
                return new UsuarioSesion
                {
                    Id = cuenta.EntidadId, // ¡Clave! Pasamos el ID del Estudiante/Profe
                    Username = cuenta.Username,
                    Rol = (RolUsuario)cuenta.Rol
                };
            }

            return null;
        }

        public void RegistrarUsuario(string user, string pass, RolUsuario rol, Guid entidadId)
        {
            if (_repoUsuarios.ObtenerTodos().Any(u => u.Username == user))
                throw new InvalidOperationException("El nombre de usuario ya existe.");

            var nuevoUsuario = new Usuario(user, pass, (int)rol, entidadId);
            _repoUsuarios.Guardar(nuevoUsuario);
        }
        
    }
}
