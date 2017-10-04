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
    public partial class Pago_Sueldo : Form
    {
        sqlPago_Sueldo pago;
        string opcion;
        public Pago_Sueldo()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            opcion = comboBox1.Text;
            pago.cargaDatos(dataGridView1, opcion);
        }

        private void Pago_Sueldo_Load(object sender, EventArgs e)
        {
            txtID_Administrador.Enabled = false;
            txtID_Pago.Enabled = false;
            txtID_Profesor.Enabled = false;
            opcion = "";            
            pago = new sqlPago_Sueldo();
            pago.cargaDatos(dataGridView1, opcion);

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (opcion)
            {               
                case "Administrador":
                   txtID_Administrador.Text= dataGridView1.CurrentRow.Cells["id_Administrador"].Value.ToString();
                    break;
                case "Profesor":
                    txtID_Profesor.Text = dataGridView1.CurrentRow.Cells["id_Profesor"].Value.ToString();
                    break;
                case "Pago_Sueldo":
                    txtID_Pago.Text =dataGridView1.CurrentRow.Cells["id_Pago"].Value.ToString();
                    txtID_Administrador.Text = dataGridView1.CurrentRow.Cells["id_Admnistrador"].Value.ToString();
                    txtID_Profesor.Text = dataGridView1.CurrentRow.Cells["id_Profesor"].Value.ToString();
                    txtHoras_Pagadas.Text = dataGridView1.CurrentRow.Cells["horasPagadas"].Value.ToString();
                    dateTimePicker1.Text=dataGridView1.CurrentRow.Cells["fecha_hora"].Value.ToString();

                    break;
                case "":
                    txtID_Pago.Text = dataGridView1.CurrentRow.Cells["id_Pago"].Value.ToString();
                    txtID_Administrador.Text = dataGridView1.CurrentRow.Cells["id_Admnistrador"].Value.ToString();
                    txtID_Profesor.Text = dataGridView1.CurrentRow.Cells["id_Profesor"].Value.ToString();
                    txtHoras_Pagadas.Text = dataGridView1.CurrentRow.Cells["horasPagadas"].Value.ToString();
                    dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["fecha_hora"].Value.ToString();

                    break;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(dateTimePicker1.Text);
            //MessageBox.Show(dateTimePicker1.Value.Date.ToString());
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (txtID_Administrador.Text != "" && txtID_Profesor.Text != "" && txtHoras_Pagadas.Text != "")
            {
                MessageBox.Show(pago.insertar(int.Parse(txtID_Administrador.Text), int.Parse(txtID_Profesor.Text), int.Parse(txtHoras_Pagadas.Text), dateTimePicker1.Text));
                pago.cargaDatos(dataGridView1, opcion);
                this.limpiar();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(pago.modificar(int.Parse(txtID_Administrador.Text), int.Parse(txtID_Profesor.Text), int.Parse(txtHoras_Pagadas.Text), dateTimePicker1.Text,int.Parse(txtID_Pago.Text)));
            pago.cargaDatos(dataGridView1, opcion);
            this.limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(pago.eliminar(int.Parse(txtID_Pago.Text)));
            pago.cargaDatos(dataGridView1, opcion);
            this.limpiar();
        }

        private void limpiar()
        {
            txtID_Pago.Text = "";
            txtID_Administrador.Text = "";
            txtID_Profesor.Text = "";
            txtHoras_Pagadas.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtHoras_Pagadas_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_Profesor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_Administrador_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_Pago_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
