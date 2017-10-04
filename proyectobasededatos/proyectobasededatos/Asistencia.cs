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
    public partial class Asistencia : Form
    {
        sqlAsistencia sqlAs;
        string opcion;
        public Asistencia()
        {
            InitializeComponent();
        }

        private void Asistencia_Load(object sender, EventArgs e)
        {
          
            txtID_Asistencia.Enabled = false;
            txtID_Profesor.Enabled = false;
            opcion = "";
            sqlAs = new sqlAsistencia();
            sqlAs.cargaDatos(dataGridView1, opcion);

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd hh:mm:ss";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            opcion = comboBox1.Text;
            sqlAs.cargaDatos(dataGridView1, opcion);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (opcion)
            {
                
                case "Profesor":
                    txtID_Profesor.Text = dataGridView1.CurrentRow.Cells["id_Profesor"].Value.ToString();
                    break;
                case "Asistencia":
                    txtID_Asistencia.Text = dataGridView1.CurrentRow.Cells["id_Asistencia"].Value.ToString();
                    txtID_Profesor.Text = dataGridView1.CurrentRow.Cells["id_Profesor"].Value.ToString();
                    txtHoras.Text = dataGridView1.CurrentRow.Cells["num_Horas"].Value.ToString();
                    dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["fecha_hora"].Value.ToString();

                    break;
                case "":
                     txtID_Asistencia.Text = dataGridView1.CurrentRow.Cells["id_Asistencia"].Value.ToString();
                    txtID_Profesor.Text = dataGridView1.CurrentRow.Cells["id_Profesor"].Value.ToString();
                    txtHoras.Text = dataGridView1.CurrentRow.Cells["num_Horas"].Value.ToString();
                    dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["fecha_hora"].Value.ToString();
                    break;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if ( txtID_Profesor.Text != "" && txtHoras.Text != "")
            {
                MessageBox.Show(sqlAs.insertar(int.Parse(txtID_Profesor.Text), int.Parse(txtHoras.Text), dateTimePicker1.Text));
                sqlAs.cargaDatos(dataGridView1, opcion);
                this.limpiar();
            }
        }
        private void limpiar()
        {  
            txtID_Asistencia.Text = "";
            txtID_Profesor.Text = "";
            txtHoras.Text = "";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sqlAs.modificar(int.Parse(txtID_Profesor.Text), int.Parse(txtHoras.Text), dateTimePicker1.Text, int.Parse(txtID_Asistencia.Text)));
            sqlAs.cargaDatos(dataGridView1, opcion);
            this.limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sqlAs.eliminar(int.Parse(txtID_Asistencia.Text)));
            sqlAs.cargaDatos(dataGridView1, opcion);
            this.limpiar();
        }
    }
}
