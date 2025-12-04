using Microsoft.VisualBasic; // <--- Necesario para Eliminar/Actualizar (InputBox)

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

            // Opcional: Autoajustar las columnas
            dataGridView1.AutoResizeColumns();
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
}
}
