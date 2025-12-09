using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class RepositorioJson<T> : IRepositorio<T> where T : class
    {
        private readonly string _rutaArchivo;

        public RepositorioJson(string nombreArchivo)
        {
            // Guarda en la carpeta de ejecución (Debug/bin)
            _rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nombreArchivo);

            // Si el archivo no existe, crea una lista vacía para evitar errores
            if (!File.Exists(_rutaArchivo))
            {
                GuardarEnArchivo(new List<T>());
            }
        }

        public List<T> ObtenerTodos()
        {
            try
            {
                string jsonString = File.ReadAllText(_rutaArchivo);
                if (string.IsNullOrEmpty(jsonString)) return new List<T>();

                return JsonSerializer.Deserialize<List<T>>(jsonString) ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error leyendo archivo JSON: {ex.Message}");
                return new List<T>();
            }
        }

        public T ObtenerPorId(Guid id)
        {
            // Usamos reflexión para encontrar la propiedad "Id" genéricamente
            var todos = ObtenerTodos();
            return todos.FirstOrDefault(item =>
            {
                var prop = item.GetType().GetProperty("Id");
                if (prop != null)
                {
                    var valor = (Guid)prop.GetValue(item);
                    return valor == id;
                }
                return false;
            });
        }

        public void Guardar(T entidad)
        {
            var lista = ObtenerTodos();
            lista.Add(entidad);
            GuardarEnArchivo(lista);
        }

        private void GuardarEnArchivo(List<T> items)
        {
            // WriteIndented = true hace que el JSON se vea bonito y legible
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(items, opciones);
            File.WriteAllText(_rutaArchivo, jsonString);
        }
    }
}
