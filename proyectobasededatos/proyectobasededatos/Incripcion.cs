<<<<<<< HEAD
﻿using System;
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
    public partial class Incripcion : Form
    {       
        string opcion;
        sqlInscripcioncs insc;

        public Incripcion()
        {
            InitializeComponent();            
        }          

        private void Incripcion_Load(object sender, EventArgs e)
        {
            txtID_Incripcion.Enabled = false;
            txtID_Alumno.Enabled = false;
            txtID_Curso.Enabled = false;
            txt_IDAdmin.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTime2.Enabled = false;
            opcion = "";
            insc = new sqlInscripcioncs();
            insc.cargaDatos(dataGridView1, opcion);

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTime2.Text = DateTime.Now.TimeOfDay.ToString();

        }       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            opcion = comboBox1.Text;           
            insc.cargaDatos(dataGridView1, opcion);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (opcion)
            {
                case "Administrador":
                    txt_IDAdmin.Text= dataGridView1.CurrentRow.Cells["id_Administrador"].Value.ToString();
                    break;
                case "Curso":
                    txtID_Curso.Text= dataGridView1.CurrentRow.Cells["id_Curso"].Value.ToString();
                    break;
                case "Alumno":
                    txtID_Alumno.Text = dataGridView1.CurrentRow.Cells["id_Alumno"].Value.ToString();
                    break;
                case "":
                    txtID_Incripcion.Text = dataGridView1.CurrentRow.Cells["id_Inscripcion"].Value.ToString();
                    txtID_Alumno.Text =  dataGridView1.CurrentRow.Cells["id_Alumno"].Value.ToString();
                    txtID_Curso.Text = dataGridView1.CurrentRow.Cells["id_Curso"].Value.ToString();
                    txt_IDAdmin.Text = dataGridView1.CurrentRow.Cells["id_Admnistrador"].Value.ToString();
                    txtMonto.Text =  dataGridView1.CurrentRow.Cells["monto"].Value.ToString();
                    dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["fecha_hora"].Value.ToString();
                    dateTime2.Text = dataGridView1.CurrentRow.Cells["fecha_hora"].Value.ToString();
                    break;
                case "Inscripciones":
                    txtID_Incripcion.Text = dataGridView1.CurrentRow.Cells["id_Inscripcion"].Value.ToString();
                    txtID_Alumno.Text = dataGridView1.CurrentRow.Cells["id_Alumno"].Value.ToString();
                    txtID_Curso.Text = dataGridView1.CurrentRow.Cells["id_Curso"].Value.ToString();
                    txt_IDAdmin.Text = dataGridView1.CurrentRow.Cells["id_Admnistrador"].Value.ToString();
                    txtMonto.Text = dataGridView1.CurrentRow.Cells["monto"].Value.ToString();
                    dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["fecha_hora"].Value.ToString();
                    dateTime2.Text = dataGridView1.CurrentRow.Cells["fecha_hora"].Value.ToString();
                    break;

            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(insc.insertar(int.Parse(txt_IDAdmin.Text), int.Parse(txtID_Alumno.Text), int.Parse(txtID_Curso.Text), int.Parse(txtMonto.Text), dateTimePicker1.Text+" "+dateTime2.Text));
            insc.cargaDatos(dataGridView1, opcion);
            this.limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(insc.modificar(int.Parse(txt_IDAdmin.Text), int.Parse(txtID_Alumno.Text), int.Parse(txtID_Curso.Text), int.Parse(txtMonto.Text), dateTimePicker1.Text + " " + dateTime2.Text,int.Parse(txtID_Incripcion.Text)));
            insc.cargaDatos(dataGridView1, opcion);
            this.limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(insc.eliminar(int.Parse(txtID_Incripcion.Text)));
            insc.cargaDatos(dataGridView1, opcion);
            this.limpiar();
        }

        private void limpiar()
        {
            txtID_Incripcion.Text = "";
            txtID_Alumno.Text = "";
            txtID_Curso.Text = "";
            txt_IDAdmin.Text = "";
            txtMonto.Text = "";
            dateTimePicker1.Text = "";
            dateTime2.Text = "";
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }

}
=======
﻿using System;
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
    public partial class Incripcion : Form
    {       
        string opcion;
        sqlInscripcioncs insc;

        public Incripcion()
        {
            InitializeComponent();            
        }          

        private void Incripcion_Load(object sender, EventArgs e)
        {
            txtID_Incripcion.Enabled = false;
            txtID_Alumno.Enabled = false;
            txtID_Curso.Enabled = false;
            txt_IDAdmin.Enabled = false;
            opcion = "";
            insc = new sqlInscripcioncs();
            insc.cargaDatos(dataGridView1, opcion);

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTime2.Text = DateTime.Now.TimeOfDay.ToString();

        }       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            opcion = comboBox1.Text;           
            insc.cargaDatos(dataGridView1, opcion);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (opcion)
            {
                case "Administrador":
                    txt_IDAdmin.Text= dataGridView1.CurrentRow.Cells["id_Administrador"].Value.ToString();
                    break;
                case "Curso":
                    txtID_Curso.Text= dataGridView1.CurrentRow.Cells["id_Curso"].Value.ToString();
                    break;
                case "Alumno":
                    txtID_Alumno.Text = dataGridView1.CurrentRow.Cells["id_Alumno"].Value.ToString();
                    break;
                case "":
                    txtID_Incripcion.Text = dataGridView1.CurrentRow.Cells["id_Inscripcion"].Value.ToString();
                    txtID_Alumno.Text =  dataGridView1.CurrentRow.Cells["id_Alumno"].Value.ToString();
                    txtID_Curso.Text = dataGridView1.CurrentRow.Cells["id_Curso"].Value.ToString();
                    txt_IDAdmin.Text = dataGridView1.CurrentRow.Cells["id_Admnistrador"].Value.ToString();
                    txtMonto.Text =  dataGridView1.CurrentRow.Cells["monto"].Value.ToString();
                    dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["fecha_hora"].Value.ToString();
                    dateTime2.Text = dataGridView1.CurrentRow.Cells["fecha_hora"].Value.ToString();
                    break;
                case "Inscripciones":
                    txtID_Incripcion.Text = dataGridView1.CurrentRow.Cells["id_Inscripcion"].Value.ToString();
                    txtID_Alumno.Text = dataGridView1.CurrentRow.Cells["id_Alumno"].Value.ToString();
                    txtID_Curso.Text = dataGridView1.CurrentRow.Cells["id_Curso"].Value.ToString();
                    txt_IDAdmin.Text = dataGridView1.CurrentRow.Cells["id_Admnistrador"].Value.ToString();
                    txtMonto.Text = dataGridView1.CurrentRow.Cells["monto"].Value.ToString();
                    dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["fecha_hora"].Value.ToString();
                    dateTime2.Text = dataGridView1.CurrentRow.Cells["fecha_hora"].Value.ToString();
                    break;

            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(insc.insertar(int.Parse(txt_IDAdmin.Text), int.Parse(txtID_Alumno.Text), int.Parse(txtID_Curso.Text), int.Parse(txtMonto.Text), dateTimePicker1.Text+" "+dateTime2.Text));
            insc.cargaDatos(dataGridView1, opcion);
            this.limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(insc.modificar(int.Parse(txt_IDAdmin.Text), int.Parse(txtID_Alumno.Text), int.Parse(txtID_Curso.Text), int.Parse(txtMonto.Text), dateTimePicker1.Text + " " + dateTime2.Text,int.Parse(txtID_Incripcion.Text)));
            insc.cargaDatos(dataGridView1, opcion);
            this.limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(insc.eliminar(int.Parse(txtID_Incripcion.Text)));
            insc.cargaDatos(dataGridView1, opcion);
            this.limpiar();
        }

        private void limpiar()
        {
            txtID_Incripcion.Text = "";
            txtID_Alumno.Text = "";
            txtID_Curso.Text = "";
            txt_IDAdmin.Text = "";
            txtMonto.Text = "";
            dateTimePicker1.Text = "";
            dateTime2.Text = "";
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }

}
>>>>>>> 6f3f6d27b995f9ff4a65017675f722efff3e009b
