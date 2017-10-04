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
    public partial class Alumnos : Form
    {
        string opcion;
        sqlAlumno alum;
        public Alumnos()
        {
            InitializeComponent();
        }

        private void Alumnos_Load(object sender, EventArgs e)
        {
            opcion = "";
            txtID_Alumno.Enabled = false;

            alum = new sqlAlumno();
            alum.cargaDatos(dataGridView1, opcion);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(alum.insertar(txtnombre.Text, txtTelefono.Text, txtCorreo.Text, txtDireccion.Text, int.Parse(txtAdeudo.Text)));
            alum.cargaDatos(dataGridView1, opcion);
            this.limpiar();
        }


        private void limpiar()
        {
            txtID_Alumno.Text = "";
            txtnombre.Text = "";
            txtTelefono.Text = "";
            txtAdeudo.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            MessageBox.Show(alum.eliminar(int.Parse(txtID_Alumno.Text)));
            alum.cargaDatos(dataGridView1, opcion);
            this.limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(alum.modificar(txtnombre.Text, txtTelefono.Text, txtCorreo.Text, txtDireccion.Text, int.Parse(txtAdeudo.Text),int.Parse(txtID_Alumno.Text)));
            alum.cargaDatos(dataGridView1, opcion);
            this.limpiar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (opcion)
            {
                case "":
                    txtID_Alumno.Text = dataGridView1.CurrentRow.Cells["id_Alumno"].Value.ToString();
                    txtnombre.Text = dataGridView1.CurrentRow.Cells["nombre_Alumno"].Value.ToString();
                    txtDireccion.Text = dataGridView1.CurrentRow.Cells["direccion_Alumno"].Value.ToString();
                    txtCorreo.Text = dataGridView1.CurrentRow.Cells["correo_Alumno"].Value.ToString();
                    txtTelefono.Text = dataGridView1.CurrentRow.Cells["telefono_Alumno"].Value.ToString();
                    txtAdeudo.Text= dataGridView1.CurrentRow.Cells["adeudo_Alumno"].Value.ToString();
                    break;
            }
        }

    }
}
