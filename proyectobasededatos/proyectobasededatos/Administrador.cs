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
    public partial class Administrador : Form
    {
        sqlAdmnistrador sqlAd;
        public Administrador()
        {
            InitializeComponent();
        }

        private void Administrador_Load(object sender, EventArgs e)
        {
                 dateTimeEntrada.Format = DateTimePickerFormat.Custom;
                 dateTimeEntrada.CustomFormat = "HH:mm:ss";
                 dateTimeEntrada.ShowUpDown = true;
                 dateTimeEntrada.Value = new DateTime(1753,1, 1, 0, 0, 0);
                 dateTimeSalida.Format = DateTimePickerFormat.Custom;
                 dateTimeSalida.CustomFormat = "HH:mm:ss";
                 dateTimeSalida.ShowUpDown = true;
                 dateTimeSalida.Value = new DateTime(1753,1, 1,0,0,0);

                 sqlAd = new sqlAdmnistrador();
                 sqlAd.cargaDatos(dataGridView1);
                 txt_IDAdministrador.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_IDAdministrador.Text = dataGridView1.CurrentRow.Cells["id_Administrador"].Value.ToString();
            txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre_Administrador"].Value.ToString();
            txtTelefono.Text = dataGridView1.CurrentRow.Cells["telefono_Administrador"].Value.ToString();
            txtCorreo.Text = dataGridView1.CurrentRow.Cells["correo_Administrador"].Value.ToString();
            txtDireccion.Text = dataGridView1.CurrentRow.Cells["direccion_Administrador"].Value.ToString();
           dateTimeEntrada .Text = dataGridView1.CurrentRow.Cells["hora_Ent"].Value.ToString();
            dateTimeSalida.Text = dataGridView1.CurrentRow.Cells["hora_Sal"].Value.ToString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sqlAd.insertar(txtNombre.Text,txtTelefono.Text,txtCorreo.Text,txtDireccion.Text,dateTimeEntrada.Text,dateTimeSalida.Text));
            sqlAd.cargaDatos(dataGridView1);
            this.limpiarCampos();
        }

        private void limpiarCampos()
        {
            txt_IDAdministrador.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            dateTimeEntrada .Text = "";
            dateTimeSalida.Text = "";

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sqlAd.elimina(int.Parse(txt_IDAdministrador.Text)));
            sqlAd.cargaDatos(dataGridView1);
            this.limpiarCampos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sqlAd.modificar(txtNombre.Text, txtTelefono.Text, txtCorreo.Text,txtDireccion.Text,dateTimeEntrada.Text, dateTimeSalida.Text, int.Parse(txt_IDAdministrador.Text)));
            sqlAd.cargaDatos(dataGridView1);
            this.limpiarCampos();
        }
    }
}
