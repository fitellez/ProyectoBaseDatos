using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoBasedeDatos
{
    public partial class Curso : Form
    {
        sqlCurso curso;
        string opcion;
        public Curso()
        {
            InitializeComponent();
        }

        private void Curso_Load(object sender, EventArgs e)
        {
            txtID_Curso.Enabled = false;
            txtID_Horario.Enabled = false;
            txtID_Profesor.Enabled = false;
            opcion = "";
            curso = new sqlCurso();
            curso.cargaDatos(dataGridView1, opcion);

            dateTimeInicio.Format = DateTimePickerFormat.Custom;
            dateTimeInicio.CustomFormat = "yyyy-MM-dd";

            dateTimeFin.Format = DateTimePickerFormat.Custom;
            dateTimeFin.CustomFormat = "yyyy-MM-dd";



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            opcion = comboBox1.Text;
            curso.cargaDatos(dataGridView1, opcion);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (opcion)
            {
                case "Horario":
                    txtID_Horario.Text = dataGridView1.CurrentRow.Cells["id_Horario"].Value.ToString();
                    break;
                case "Profesor":
                    txtID_Profesor.Text = dataGridView1.CurrentRow.Cells["id_Profesor"].Value.ToString();
                    break;
                case "Curso":
                    txtID_Curso.Text = dataGridView1.CurrentRow.Cells["id_Curso"].Value.ToString();
                    txtID_Horario.Text = dataGridView1.CurrentRow.Cells["id_Horario"].Value.ToString();
                    txtNombre .Text = dataGridView1.CurrentRow.Cells["nombre_Curso"].Value.ToString();
                    txtID_Profesor.Text = dataGridView1.CurrentRow.Cells["id_Profesor"].Value.ToString();
                    txtCupo.Text = dataGridView1.CurrentRow.Cells["cupo"].Value.ToString();
                    txtCosto_Horas.Text = dataGridView1.CurrentRow.Cells["costo_Hora"].Value.ToString();
                    comboBoxTipo.Text = dataGridView1.CurrentRow.Cells["tipo"].Value.ToString();

                    dateTimeInicio.Text = dataGridView1.CurrentRow.Cells["fecha_Inicio"].Value.ToString();
                    dateTimeInicio.Text = dataGridView1.CurrentRow.Cells["fecha_Fin"].Value.ToString();

                    break;
                case "":
                  txtID_Curso.Text = dataGridView1.CurrentRow.Cells["id_Curso"].Value.ToString();
                    txtID_Horario.Text = dataGridView1.CurrentRow.Cells["id_Horario"].Value.ToString();
                    txtNombre .Text = dataGridView1.CurrentRow.Cells["nombre_Curso"].Value.ToString();
                    txtID_Profesor.Text = dataGridView1.CurrentRow.Cells["id_Profesor"].Value.ToString();
                    txtCupo.Text = dataGridView1.CurrentRow.Cells["cupo"].Value.ToString();
                    txtCosto_Horas.Text = dataGridView1.CurrentRow.Cells["costo_Hora"].Value.ToString();
                    comboBoxTipo.Text = dataGridView1.CurrentRow.Cells["tipo"].Value.ToString();

                    dateTimeInicio.Text = dataGridView1.CurrentRow.Cells["fecha_Inicio"].Value.ToString();
                    dateTimeInicio.Text = dataGridView1.CurrentRow.Cells["fecha_Fin"].Value.ToString();
                    break;
            }
        }
        private void limpiar()
        {
            txtID_Curso.Text = "";
            txtID_Horario.Text = "";
            txtNombre.Text = "";
            txtID_Profesor.Text = "";
            txtCupo.Text = "";
            txtCosto_Horas.Text = "";
            comboBoxTipo.Text = "";

            dateTimeInicio.Text = "";
            dateTimeInicio.Text = "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (txtID_Horario.Text != "" && txtID_Profesor.Text != "" && txtNombre.Text != "" && txtCupo.Text != "" && comboBoxTipo.Text != "" && txtCosto_Horas.Text != "")
            {
                MessageBox.Show(curso.insertar(int.Parse(txtID_Horario.Text), int.Parse(txtID_Profesor.Text), txtNombre.Text, int.Parse(txtCupo.Text), dateTimeInicio.Text, dateTimeFin.Text, float.Parse(txtCosto_Horas.Text.Replace('.', ',')), comboBoxTipo.Text));
                curso.cargaDatos(dataGridView1, opcion);
                this.limpiar();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(curso.modificar(int.Parse(txtID_Horario.Text), int.Parse(txtID_Profesor.Text), txtNombre.Text, int.Parse(txtCupo.Text), dateTimeInicio.Text, dateTimeFin.Text, float.Parse(txtCosto_Horas.Text.Replace('.', ',')), comboBoxTipo.Text, int.Parse(txtID_Curso.Text)));
            curso.cargaDatos(dataGridView1, opcion);
            this.limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(curso.eliminar(int.Parse(txtID_Curso.Text)));
            curso.cargaDatos(dataGridView1, opcion);
            this.limpiar();
        }
    }
}
