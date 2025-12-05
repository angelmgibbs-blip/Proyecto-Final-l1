using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCalificaciones
{
    public static class GestorEstudiantes
    {
        // La lista que almacena todos los datos en memoria
        private static List<Estudiante> _listaEstudiantes = new List<Estudiante>();

        // 1. Mostrar/Obtener todos
        public static List<Estudiante> ObtenerTodos()
        {
            return _listaEstudiantes;
        }

        // 2. Crear (Agregar nuevo)
        public static bool AgregarEstudiante(Estudiante nuevoEstudiante)
        {
            // **Validación de Error: Matrícula duplicada**
            if (_listaEstudiantes.Any(e => e.Matrícula == nuevoEstudiante.Matrícula))
            {
                return false; // Error: Ya existe
            }

            nuevoEstudiante.CalcularCalificaciones();
            _listaEstudiantes.Add(nuevoEstudiante);
            return true;
        }

        // 3. Buscar por Matrícula
        public static Estudiante BuscarEstudiante(string matricula)
        {
            return _listaEstudiantes.FirstOrDefault(e => e.Matrícula == matricula);
        }

        // 4. Actualizar
        public static bool ActualizarEstudiante(Estudiante estudianteActualizado)
        {
            Estudiante existente = BuscarEstudiante(estudianteActualizado.Matrícula);

            if (existente == null)
            {
                return false; // Error: ID Inexistente
            }

            // Actualiza las propiedades (¡La Matrícula no debe cambiarse!)
            existente.Nombre = estudianteActualizado.Nombre;
            existente.Materia = estudianteActualizado.Materia;
            existente.Calificación1 = estudianteActualizado.Calificación1;
            existente.Calificación2 = estudianteActualizado.Calificación2;
            existente.Calificación3 = estudianteActualizado.Calificación3;
            existente.Calificación4 = estudianteActualizado.Calificación4;
            existente.Examen = estudianteActualizado.Examen;

            existente.CalcularCalificaciones(); // Recalcular las notas
            return true;
        }

        // 5. Eliminar
        public static bool EliminarEstudiante(string matricula)
        {
            Estudiante estudianteAEliminar = BuscarEstudiante(matricula);

            if (estudianteAEliminar != null)
            {
                _listaEstudiantes.Remove(estudianteAEliminar);
                return true;
            }
            return false; // Error: ID Inexistente
        }
    }
}


