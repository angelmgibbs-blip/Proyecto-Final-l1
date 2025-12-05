using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCalificaciones
{
    public partial class FormEstudiante : Form
    {
        // Variable para saber si estamos creando uno nuevo o actualizando uno existente
        private Estudiante _estudianteEditando;

        // Constructor 1: Para CREAR (Llamado desde btnCrear_Click en Form1)
        public FormEstudiante()
        {
            InitializeComponent();
            this.Text = "Crear Nuevo Estudiante";
        }

        // Constructor 2: Para ACTUALIZAR (Llamado desde btnActualizar_Click en Form1)
        public FormEstudiante(Estudiante estudianteAEditar)
        {
            InitializeComponent();
            _estudianteEditando = estudianteAEditar;
            this.Text = $"Editar Estudiante: {estudianteAEditar.Matrícula}";

            // Cargar los datos del estudiante en los TextBox para su edición
            txtMatricula.Text = _estudianteEditando.Matrícula;
            txtMatricula.ReadOnly = true; // La Matrícula (ID) no se debe cambiar
            txtNombre.Text = _estudianteEditando.Nombre;
            txtC1.Text = _estudianteEditando.Calificación1.ToString();
            txtC2.Text = _estudianteEditando.Calificación2.ToString();
            txtC3.Text = _estudianteEditando.Calificación3.ToString();
            txtC4.Text = _estudianteEditando.Calificación4.ToString();
            txtExamen.Text = _estudianteEditando.Examen.ToString();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // --- 1. Validaciones de Campos Obligatorios ---
            if (string.IsNullOrWhiteSpace(txtMatricula.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Matrícula y Nombre son obligatorios.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- 2. Manejo de Errores: Validación Numérica y Rango (0-100) ---
            int c1, c2, c3, c4, examen;
            try
            {
                // Intentar convertir texto a números (Manejo de Excepción FormatException)
                c1 = int.Parse(txtC1.Text);
                c2 = int.Parse(txtC2.Text);
                c3 = int.Parse(txtC3.Text);
                c4 = int.Parse(txtC4.Text);
                examen = int.Parse(txtExamen.Text);

                // Validación de Rango (0 a 100)
                if (c1 < 0 || c1 > 100 || c2 < 0 || c2 > 100 || c3 < 0 || c3 > 100 || c4 < 0 || c4 > 100 || examen < 0 || examen > 100)
                {
                    MessageBox.Show("Las calificaciones deben ser números enteros entre 0 y 100.", "Error de Rango", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (FormatException)
            {
                // Manejo de Error si el usuario ingresa letras en lugar de números
                MessageBox.Show("Ingrese solo números enteros válidos en las calificaciones.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- 3. Crear Objeto Estudiante con los datos del formulario ---
            Estudiante datosNuevos = new Estudiante
            {
                Matrícula = txtMatricula.Text,
                Nombre = txtNombre.Text,
                Calificación1 = c1,
                Calificación2 = c2,
                Calificación3 = c3,
                Calificación4 = c4,
                Examen = examen
            };


            // --- 4. Lógica de GUARDAR (Crear o Actualizar) ---
            if (_estudianteEditando == null)
            {
                // OPERACIÓN CREAR (Llama al Gestor de Negocio)
                if (GestorEstudiantes.AgregarEstudiante(datosNuevos))
                {
                    MessageBox.Show("Estudiante agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    // Manejo de Error: Matrícula Duplicada
                    MessageBox.Show($"La matrícula {datosNuevos.Matrícula} ya existe.", "Error al Crear", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // OPERACIÓN ACTUALIZAR (Llama al Gestor de Negocio)
                if (GestorEstudiantes.ActualizarEstudiante(datosNuevos))
                {
                    MessageBox.Show("Estudiante actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error desconocido al actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
    }
}
}
}
