namespace SistemaCalificaciones
{
    partial class FormEstudiante
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtMatricula = new TextBox();
            label1 = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            txtC1 = new TextBox();
            txtC2 = new TextBox();
            txtC3 = new TextBox();
            txtC4 = new TextBox();
            label3 = new Label();
            txtExamen = new TextBox();
            label4 = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // txtMatricula
            // 
            txtMatricula.Location = new Point(112, 52);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(100, 23);
            txtMatricula.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 55);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 1;
            label1.Text = "Matricula";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(112, 99);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 99);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 3;
            label2.Text = "Nombre";
            // 
            // txtC1
            // 
            txtC1.Location = new Point(317, 91);
            txtC1.Name = "txtC1";
            txtC1.Size = new Size(100, 23);
            txtC1.TabIndex = 4;
            // 
            // txtC2
            // 
            txtC2.Location = new Point(441, 91);
            txtC2.Name = "txtC2";
            txtC2.Size = new Size(100, 23);
            txtC2.TabIndex = 5;
            // 
            // txtC3
            // 
            txtC3.Location = new Point(317, 139);
            txtC3.Name = "txtC3";
            txtC3.Size = new Size(100, 23);
            txtC3.TabIndex = 6;
            // 
            // txtC4
            // 
            txtC4.Location = new Point(441, 139);
            txtC4.Name = "txtC4";
            txtC4.Size = new Size(100, 23);
            txtC4.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(392, 52);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 8;
            label3.Text = "Calificaciones";
            // 
            // txtExamen
            // 
            txtExamen.Location = new Point(383, 226);
            txtExamen.Name = "txtExamen";
            txtExamen.Size = new Size(100, 23);
            txtExamen.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(392, 195);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 10;
            label4.Text = "Examen Cali";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(31, 226);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 69);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(153, 226);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 69);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FormEstudiante
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(label4);
            Controls.Add(txtExamen);
            Controls.Add(label3);
            Controls.Add(txtC4);
            Controls.Add(txtC3);
            Controls.Add(txtC2);
            Controls.Add(txtC1);
            Controls.Add(label2);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Controls.Add(txtMatricula);
            Name = "FormEstudiante";
            Text = "FormEstudiante";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMatricula;
        private Label label1;
        private TextBox txtNombre;
        private Label label2;
        private TextBox txtC1;
        private TextBox txtC2;
        private TextBox txtC3;
        private TextBox txtC4;
        private Label label3;
        private TextBox txtExamen;
        private Label label4;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}