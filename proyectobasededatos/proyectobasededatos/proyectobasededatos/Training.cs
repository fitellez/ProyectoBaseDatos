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
    public partial class Training : Form
    {
        public Training()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button_Profesor_Click(object sender, EventArgs e)
        {
            Profesor profesor = new Profesor();
            profesor.ShowDialog();
        }

        private void button_Comentario_Click(object sender, EventArgs e)
        {
            Comentario comentario = new Comentario();
            comentario.ShowDialog();
        }

        private void button_Pago_Click(object sender, EventArgs e)
        {
            Pago_Sueldo pago = new Pago_Sueldo();
            pago.ShowDialog();
        }

        private void button_Inscripcion_Click(object sender, EventArgs e)
        {
            Incripcion inscripcion = new Incripcion();
            inscripcion.ShowDialog();
        }

        private void button_Administrador_Click(object sender, EventArgs e)
        {
            Administrador administrador = new Administrador();
            administrador.ShowDialog();
        }

        private void button_Alumno_Click(object sender, EventArgs e)
        {
            Alumnos alumnos = new Alumnos();
            alumnos.ShowDialog();
        }

        private void button_Horario_Click(object sender, EventArgs e)
        {
            Horario horario = new Horario();
            horario.ShowDialog();
        }

        private void button_Asistencia_Click(object sender, EventArgs e)
        {
            Asistencia asistencia = new Asistencia();
            asistencia.ShowDialog();
        }

        private void button_Curso_Click(object sender, EventArgs e)
        {
            Curso curso = new Curso();
            curso.ShowDialog();
        }
    }
}
