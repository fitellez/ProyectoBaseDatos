using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace proyectoBasedeDatos
{
    class sqlAlumno
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public sqlAlumno()
        {
            try
            {
                cn = new SqlConnection(@"Data Source=ARTURO-PC\SQLEXPRESS;initial catalog=TrainingInstitute; integrated Security=true");
                cn.Open();
                //MessageBox.Show("abierto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir" + ex.ToString());
            }
        }

        public string insertar(string nombre, string telefono, string correo, string domicilio, int adeudo)
        {
            string ms = "Se agregó correctamente";
            try
            {
                cmd = new SqlCommand("INSERT INTO USUARIOS.T_Alumno(nombre_Alumno,telefono_Alumno,correo_Alumno,direccion_Alumno,adeudo_Alumno)VALUES('" + nombre + "','" + telefono + "','" + correo + "','" + domicilio + "'," + adeudo + ")", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ms = "no se pudo agregar" + ex;
            }
            return ms;
        }
        public string modificar(string nombre, string telefono, string correo, string domicilio, int adeudo,int id)
        {
            string ms = "Se modificó corrctamente";
            try
            {
                cmd = new SqlCommand("UPDATE USUARIOS.T_Alumno SET nombre_Alumno='" + nombre + "',telefono_Alumno='" + telefono + "',correo_Alumno='" + correo + "',direccion_Alumno='" + domicilio + "',adeudo_Alumno=" + adeudo + " WHERE id_Alumno=" + id + "", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ms = "no se pudo modificar" + ex;
            }
            return ms;
        }

        public string eliminar(int id)
        {
            string ms = "Se eliminó correctamente";
            try
            {
                cmd = new SqlCommand("DELETE FROM USUARIOS.T_Alumno WHERE id_Alumno=" + id + "", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ms = "no se pudo eliminar" + ex;
            }
            return ms;
        }
        public void cargaDatos(DataGridView dgv, string opcion)
        {
            switch (opcion)
            {
                case "":
                    try
                    {
                        da = new SqlDataAdapter("SELECT * FROM USUARIOS.T_Alumno", cn);
                        dt = new DataTable();
                        da.Fill(dt);
                        dgv.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    break;
                case "Curso":
                    try
                    {
                        da = new SqlDataAdapter("SELECT * FROM CLASES.T_Curso", cn);
                        dt = new DataTable();
                        da.Fill(dt);
                        dgv.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    break;
                case "Alumno":
                    try
                    {
                        da = new SqlDataAdapter("SELECT * FROM USUARIOS.T_Alumno", cn);
                        dt = new DataTable();
                        da.Fill(dt);
                        dgv.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    break;
            }
        }

        public void cargaDatosComentario(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("SELECT  nombre_Alumno AS nombre, concat('Alumno','') AS Tipo FROM USUARIOS.T_Alumno", cn);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
