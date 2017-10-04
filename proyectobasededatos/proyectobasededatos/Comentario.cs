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
    public partial class Comentario : Form
    {
        sqlComentario com;
        public Comentario()
        {
            InitializeComponent();            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(com.insertar(txtUsuario.Text, txtTipo_Usuario.Text, txtComentario.Text));
            com.cargaDatos(dataGridView1);
            this.limpiarCampos();
        }

        private void Comentario_Load(object sender, EventArgs e)
        {
            com = new sqlComentario();
            txtID_Comentario.Enabled = false;
            com.cargaDatos(dataGridView1);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(com.modificar(txtUsuario.Text, txtTipo_Usuario.Text, txtComentario.Text,int.Parse(txtID_Comentario.Text)));
            com.cargaDatos(dataGridView1);
            this.limpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(com.elimina(int.Parse(txtID_Comentario.Text)));
                com.cargaDatos(dataGridView1);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            this.limpiarCampos();
        }

        private void limpiarCampos()
        {
            txtID_Comentario.Text = "";
            txtUsuario.Text = "";
            txtTipo_Usuario.Text = "";
            txtComentario.Text = "";
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUsuario.Text = dataGridView2.CurrentRow.Cells["nombre"].Value.ToString();
            txtTipo_Usuario.Text = dataGridView2.CurrentRow.Cells["tipo"].Value.ToString();
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID_Comentario.Text = dataGridView1.CurrentRow.Cells["id_Comentario"].Value.ToString();
            txtUsuario.Text = dataGridView1.CurrentRow.Cells["usuario_Comentario"].Value.ToString();
            txtTipo_Usuario.Text = dataGridView1.CurrentRow.Cells["tipo_Usuario"].Value.ToString();
            txtComentario.Text = dataGridView1.CurrentRow.Cells["comentario"].Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlProfesor sql = new sqlProfesor();
            sqlAdmnistrador sqlAd = new sqlAdmnistrador();
            sqlAlumno sqlA = new sqlAlumno();
            switch (comboBox1.Text)
            {
                case "":
                    
                    break;
                case "Administrador":
                   
                    sqlAd.cargaDatosComentario(dataGridView2);
                    break;
                case "Alumno":
                    sqlA.cargaDatosComentario(dataGridView2);
                    break;
                case "Profesor":
                    sql.cargaDatosComentario(dataGridView2);
                    break;
            }
        }
    }
}
