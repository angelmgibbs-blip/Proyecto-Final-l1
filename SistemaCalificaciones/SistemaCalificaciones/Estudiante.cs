using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

// Clase Estudiante (El Modelo de Datos)
public class Estudiante
{
    // Propiedades requeridas (datos a registrar)
    public string Matrícula { get; set; } // Identificador único
    public string Materia { get; set; }
    public string Nombre { get; set; }
    public int Calificación1 { get; set; }
    public int Calificación2 { get; set; }
    public int Calificación3 { get; set; }
    public int Calificación4 { get; set; }
    public int Examen { get; set; }

    // Propiedades calculadas (solo se pueden leer)
    public double TotalCalificación { get; private set; }
    public string Clasificación { get; private set; } // A, B, C, F
    public string Estado { get; private set; }        // Aprobado/Reprobado

    // Método para realizar los cálculos requeridos
    public void CalcularCalificaciones()
    {
        // 1. Cálculo de Total Calificación (70% Promedio + 30% Examen)
        double promedioClases = (Calificación1 + Calificación2 + Calificación3 + Calificación4) / 4.0;
        
        TotalCalificación = (promedioClases * 0.70) + (Examen * 0.30);
        
        // 2. Determinar Clasificación (A, B, C, F)
        if (TotalCalificación >= 90)
            Clasificación = "A";
        else if (TotalCalificación >= 80)
            Clasificación = "B";
        else if (TotalCalificación >= 70)
            Clasificación = "C";
        else
            Clasificación = "F";

        // 3. Determinar Estado (Aprobado/Reprobado)
        Estado = (TotalCalificación >= 70) ? "Aprobado" : "Reprobado";
    }
    }