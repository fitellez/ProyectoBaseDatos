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
    public partial class Horario : Form
    {
        sqlHorario sqlH;
        public Horario()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_IDHorario.Text = dataGridView1.CurrentRow.Cells["id_Horario"].Value.ToString();
            txtDias.Text = dataGridView1.CurrentRow.Cells["dias"].Value.ToString();
            dateTimeInicio.Text = dataGridView1.CurrentRow.Cells["hora_Inicio"].Value.ToString();
            dateTimeFin.Text = dataGridView1.CurrentRow.Cells["hora_Fin"].Value.ToString();
        }

        private void Horario_Load(object sender, EventArgs e)
        {
            dateTimeInicio.Format = DateTimePickerFormat.Custom;
            dateTimeInicio.CustomFormat = "HH:mm:ss";
            dateTimeInicio.ShowUpDown = true;
            dateTimeFin.Format = DateTimePickerFormat.Custom;
            dateTimeFin.CustomFormat = "HH:mm:ss";
            dateTimeFin.ShowUpDown = true;

            sqlH = new sqlHorario();
            sqlH.cargaDatos(dataGridView1);
            txt_IDHorario.Enabled = false;

            dateTimeFin.Text = "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sqlH.insertar(txtDias.Text, dateTimeInicio.Text, dateTimeFin.Text));
            sqlH.cargaDatos(dataGridView1);
            this.limpiarCampos();
        }

        private void limpiarCampos()
        {
            txt_IDHorario.Text = "";
            txtDias.Text = "";
            dateTimeInicio.Text = "";
            dateTimeFin.Text = "";

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sqlH.modificar( txtDias.Text, dateTimeInicio.Text, dateTimeFin.Text, int.Parse(txt_IDHorario.Text)));
            sqlH.cargaDatos(dataGridView1);
            this.limpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sqlH.elimina(int.Parse(txt_IDHorario.Text)));
            sqlH.cargaDatos(dataGridView1);
            this.limpiarCampos();
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
    public partial class Horario : Form
    {
        sqlHorario sqlH;
        public Horario()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_IDHorario.Text = dataGridView1.CurrentRow.Cells["id_Horario"].Value.ToString();
            comboBoxDias.Text = dataGridView1.CurrentRow.Cells["dias"].Value.ToString();
            dateTimeInicio.Text = dataGridView1.CurrentRow.Cells["hora_Inicio"].Value.ToString();
            dateTimeFin.Text = dataGridView1.CurrentRow.Cells["hora_Fin"].Value.ToString();
        }

        private void Horario_Load(object sender, EventArgs e)
        {
            dateTimeInicio.Format = DateTimePickerFormat.Custom;
            dateTimeInicio.CustomFormat = "HH:mm:ss";
            dateTimeInicio.ShowUpDown = true;
            dateTimeFin.Format = DateTimePickerFormat.Custom;
            dateTimeFin.CustomFormat = "HH:mm:ss";
            dateTimeFin.ShowUpDown = true;

            sqlH = new sqlHorario();
            sqlH.cargaDatos(dataGridView1);
            txt_IDHorario.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sqlH.insertar(comboBoxDias.Text, dateTimeInicio.Text, dateTimeFin.Text));
            sqlH.cargaDatos(dataGridView1);
            this.limpiarCampos();
        }

        private void limpiarCampos()
        {
            txt_IDHorario.Text = "";
            comboBoxDias.Text = "";
            dateTimeInicio.Text = "";
            dateTimeFin.Text = "";

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sqlH.modificar(comboBoxDias.Text, dateTimeInicio.Text, dateTimeFin.Text, int.Parse(txt_IDHorario.Text)));
            sqlH.cargaDatos(dataGridView1);
            this.limpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sqlH.elimina(int.Parse(txt_IDHorario.Text)));
            sqlH.cargaDatos(dataGridView1);
            this.limpiarCampos();
        }

        

    }
}
>>>>>>> 6f3f6d27b995f9ff4a65017675f722efff3e009b
