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
    public partial class Profesor : Form
    {
        sqlProfesor sqlP;
        public Profesor()
        {
            InitializeComponent();
        }

        private void Profesor_Load(object sender, EventArgs e)
        {
            sqlP = new sqlProfesor();
            sqlP.cargaDatos(dataGridView1);
            txt_IDProfesor.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sqlP.insertar(txtNombre.Text, txtTelefono.Text, txtDireccion.Text, int.Parse(txtTotalHoras.Text), float.Parse(txtPagoHora.Text.Replace('.',','))));
            sqlP.cargaDatos(dataGridView1); 
            this.limpiarCampos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sqlP.modificar(txtNombre.Text, txtTelefono.Text, txtDireccion.Text, int.Parse(txtTotalHoras.Text), float.Parse(txtPagoHora.Text.Replace('.', ',')), int.Parse(txt_IDProfesor.Text)));
            sqlP.cargaDatos(dataGridView1);
            this.limpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sqlP.elimina(int.Parse(txt_IDProfesor.Text)));
            sqlP.cargaDatos(dataGridView1);
            this.limpiarCampos();
        }

        private void limpiarCampos()
        {
            txt_IDProfesor.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtTotalHoras.Text = "";
            txtPagoHora.Text = "";

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_IDProfesor.Text = dataGridView1.CurrentRow.Cells["id_Profesor"].Value.ToString();
            txtNombre.Text= dataGridView1.CurrentRow.Cells["nombre_Profesor"].Value.ToString();
            txtTelefono.Text= dataGridView1.CurrentRow.Cells["telefono_Profesor"].Value.ToString();
            txtDireccion.Text= dataGridView1.CurrentRow.Cells["direccion_Profesor"].Value.ToString();
            txtTotalHoras.Text= dataGridView1.CurrentRow.Cells["total_Horas"].Value.ToString();
            txtPagoHora.Text= dataGridView1.CurrentRow.Cells["pago_Horas"].Value.ToString();
        }
    }
}
