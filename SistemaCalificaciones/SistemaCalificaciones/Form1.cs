using System;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic; 
using System.Text; 

namespace SistemaCalificaciones
{
    public partial class Form1 : Form
    {
        // Método para recargar el DataGridView con los datos actuales
        private void CargarDatos()
        {
            // 1. Limpia la fuente de datos anterior
            // Asume que tu DataGridView se llama 'dataGridView1'
            dataGridView1.DataSource = null;

            // 2. Enlaza la lista global del Gestor al DataGridView (Muestra todos)
            dataGridView1.DataSource = GestorEstudiantes.ObtenerTodos();

           if (dataGridView1.Columns["TotalCalificación"] != null)
             {
                dataGridView1.Columns["TotalCalificación"].HeaderText = "Nota Final";

                dataGridView1.AutoResizeColumns();

        }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Opcional: Agregar un estudiante de prueba para que la tabla no esté vacía al inicio
            GestorEstudiantes.AgregarEstudiante(new Estudiante { Matrícula = "2024-001", Nombre = "Luis Perez", Calificación1 = 80, Calificación2 = 75, Calificación3 = 90, Calificación4 = 85, Examen = 95 });

            CargarDatos(); // Llama al método para mostrar la lista
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Pedir al usuario la Matrícula a eliminar.
            // Se requiere tomar el ID de referencia.
            string matriculaAEliminar = Interaction.InputBox("Ingrese la Matrícula del estudiante a eliminar:", "Eliminar Estudiante", "");

            if (string.IsNullOrWhiteSpace(matriculaAEliminar))
            {
                return; // El usuario canceló o no ingresó nada
            }

            // Confirmación de seguridad
            if (MessageBox.Show($"¿Está seguro de eliminar al estudiante con Matrícula: {matriculaAEliminar}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Llamar a la lógica de negocio. Esto valida ID inexistente.
                if (GestorEstudiantes.EliminarEstudiante(matriculaAEliminar))
                {
                    MessageBox.Show("Estudiante eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos(); // Recargar la tabla para mostrar el cambio
                }
                else
                {
                    // Manejo de Error: ID Inexistente
                    MessageBox.Show($"No se encontró al estudiante con Matrícula: {matriculaAEliminar}.", "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Pedir Matrícula de referencia para actualizar.
            string matriculaAActualizar = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la Matrícula del estudiante a actualizar:", "Actualizar Estudiante", "");

            if (string.IsNullOrWhiteSpace(matriculaAActualizar))
            {
                return; // El usuario canceló o no ingresó nada
            }

            // Buscar al estudiante. Esto cumple la validación de ID inexistente.
            Estudiante estudianteExistente = GestorEstudiantes.BuscarEstudiante(matriculaAActualizar);

            // Manejo de Error: ID Inexistente
            if (estudianteExistente == null)
            {
                MessageBox.Show($"No se encontró al estudiante con Matrícula: {matriculaAActualizar}.", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Abrir el formulario de Edición, enviando el objeto.
            // (Asegúrate de haber implementado el constructor de edición en FormEstudiante como te mostré en un paso anterior).
            FormEstudiante formEditar = new FormEstudiante(estudianteExistente);
            formEditar.ShowDialog();

            CargarDatos(); // Recargar la tabla
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            // 1. Define el encabezado CSV
            string encabezado = "Matrícula,Nombre,Calificación1,Calificación2,Calificación3,Calificación4,Examen,TotalCalificación,Clasificación,Estado\n";

            // Usamos StringBuilder para construir el contenido
            StringBuilder sb = new StringBuilder(encabezado);

            // 2. Genera las líneas de datos.
            // La función de exportación debe guardar todos los datos actuales en un archivo separado por coma (CSV).
            foreach (var est in GestorEstudiantes.ObtenerTodos())
            {
                // Concatenar los valores separados por coma (CSV)
                sb.AppendLine($"{est.Matrícula},{est.Nombre},{est.Calificación1},{est.Calificación2},{est.Calificación3},{est.Calificación4},{est.Examen},{est.TotalCalificación:F2},{est.Clasificación},{est.Estado}");
            }

            // --- 3. Manejo de Errores y Guardado del Archivo ---
            try
            {
                // SaveFileDialog permite al usuario elegir dónde guardar
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
                    saveFileDialog.Title = "Guardar Calificaciones como CSV";
                    saveFileDialog.FileName = "Calificaciones_Exportadas.csv";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Escribe todo el contenido generado en el archivo
                        File.WriteAllText(saveFileDialog.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show($"Datos exportados exitosamente a:\n{saveFileDialog.FileName}", "Exportación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Se deben incluir manejos de errores para garantizar que el programa no se detenga inesperadamente.
                MessageBox.Show($"Ocurrió un error al intentar guardar el archivo: {ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
          
            FormEstudiante formCrear = new FormEstudiante();

            
            formCrear.ShowDialog();

        
            CargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            {
                Application.Exit();
            }
        }
    }
}
