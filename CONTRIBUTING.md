# Contributing

## Introducción
Este archivo define las normas y el flujo de trabajo que todo contribuyente del proyecto "GestorReservasCursos" debe seguir. Incluye directrices sobre estilo, pruebas, refactorizaciones y la actividad práctica de detección y corrección de "code smells".

## Estándares de estilo y herramientas
- El proyecto utiliza C# 12 y .NET 8.
- Se debe respetar un archivo `.editorconfig` en la raíz del repositorio. Si no existe, crear uno siguiendo las reglas de indentación y naming que se indican en la sección "Reglas de estilo".

### Reglas de estilo (resumen)
- Indentación con 4 espacios.
- Evitar variables con nombres ambiguos; usar `camelCase` para variables locales y `PascalCase` para tipos y métodos públicos.
- Métodos no deben superar las 20 líneas sin justificación; en ese caso refactorizar en métodos privados más pequeños.
- Evitar duplicación de código. Extraer comportamiento común en métodos auxiliares o servicios.

## Flujo de trabajo
1. Crear una rama con prefijo `feature/`, `fix/` o `chore/` según corresponda (p. ej. `feature/refactor-formdesarrollador`).
2. Hacer commits pequeños y atómicos. Mensajes de commit deben seguir el formato:
   - `feat: descripción corta` para nuevas funcionalidades
   - `fix: descripción corta` para correcciones
   - `refactor: descripción corta` para refactorizaciones
3. Abrir un Pull Request con descripción clara, capturas antes/después cuando aplique y la lista de cambios.

## Actividad práctica: detección y corrección de "code smells"
Objetivo: revisar el código fuente del proyecto y aplicar mejoras concretas para facilitar mantenimiento y legibilidad.

Instrucciones ampliadas (adaptadas al proyecto):
1. Preparación
   - Abrir el proyecto en Visual Studio 2022.
   - Localizar y abrir archivos candidatos a refactorización. Empezar por `CapaPresentacion\FormDesarrollador.cs` y luego revisar `CapaNegocio` y `CapaDatos`.
2. Identificación de al menos 2 code smells
   - Buscar: métodos > 20 líneas, duplicación de código, condicionales anidados, nombres confusos.
   - Documentar cada smell en un cuadro breve con: tipo, por qué dificulta mantenimiento y propuesta de refactorización.
3. Aplicar una mejora concreta
   - Implementar al menos un cambio en código real del proyecto.
   - Incluir comentarios en el código que expliquen el cambio.
   - Añadir en el PR una sección "Antes y después" con fragmentos de código o capturas.
4. Revisión por pares
   - Formar parejas. Cada miembro presenta su refactorización y recibe feedback.
   - Usar la lista de verificación de revisión (ver abajo) para aprobar la PR.

### Lista de verificación para la revisión por pares
- [ ] ¿El cambio mejora la legibilidad? 
- [ ] ¿Se ha reducido la duplicación? 
- [ ] ¿Los nombres son más descriptivos? 
- [ ] ¿Se añadieron comentarios claros donde fue necesario? 
- [ ] ¿Los tests (si existen) siguen pasando o se añadieron nuevos tests cuando aplica?
- [ ] ¿El commit contiene mensajes claros y atómicos?

## Ejemplo de documentación del refactor (en la PR)
- Archivo modificado: `CapaPresentacion\FormDesarrollador.cs`
- Code smell detectado: duplicación de llamadas a `MessageBox.Show` y métodos con responsabilidades mezcladas.
- Acción tomada: extraído método privado `MostrarMensajeAccion(string accion)` y renombrado de controladores para mejorar claridad.
- Antes:
```
// fragmento antes
MessageBox.Show("Lógica de Admin para guardar estudiante");
MessageBox.Show("Lógica de Admin para crear curso");
```
- Después:
```
// fragmento después
MostrarMensajeAccion("guardar estudiante");
MostrarMensajeAccion("crear curso");
```

## Plantilla mínima de PR
- Título: `refactor: <breve descripción>`
- Descripción: Qué se cambió, por qué, y cómo probarlo.
- Antes/Después: fragmentos de código o capturas.
- Checklist completada.

## Contacto
Si dudas sobre las reglas, abrir un issue o contactar a los mantenedores del proyecto.