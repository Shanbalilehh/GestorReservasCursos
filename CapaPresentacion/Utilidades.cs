using System;
using System.IO;

namespace CapaPresentacion
{
    public static class Utilidades
    {
        // --- LOGGING (Registro de Errores) ---
        // Ahora cualquier formulario puede llamar a este método.
        public static void RegistrarError(string claseOrigen, string metodoOrigen, string mensajeError)
        {
            try
            {
                string rutaLog = "errores.log";
                string logLinea = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] Clase: {claseOrigen} - Método: {metodoOrigen} - Error: {mensajeError}{Environment.NewLine}";
                
                File.AppendAllText(rutaLog, logLinea);
            }
            catch
            {
                // Silencioso: Si falla el log, no queremos romper la app.
            }
        }

        // --- PARSING (Limpieza de Datos) ---
        public static string LimpiarTexto(string entrada) => entrada?.Trim() ?? string.Empty;
        
        public static string NormalizarCorreo(string entrada) => LimpiarTexto(entrada).ToLowerInvariant();

        public static bool IntentarParsearEntero(string entrada, out int resultado)
        {
            return int.TryParse(entrada?.Trim(), out resultado);
        }
    }
}
