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
    class sqlAsistencia
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public sqlAsistencia()
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

        public string insertar( int profesor, int numhoras,string fecha)
        {
            string ms = "Se agregó correctamente";
            try
            {
                cmd = new SqlCommand("INSERT INTO CLASES.T_Asistencia (id_Profesor,num_Horas,fecha_hora) VALUES ("  + profesor + "," + numhoras + ",'" + fecha + "')", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ms = "no se pudo agregar" + ex;
            }
            return ms;
        }

        public string modificar(int profesor, int numhoras, string fecha, int id)
        {
            string ms = "Se modificó correctamente";
            try
            {
                cmd = new SqlCommand("UPDATE CLASES.T_Asistencia SET id_Profesor=" + profesor +",num_Horas="+numhoras+ ",fecha_hora='" + fecha + "' WHERE id_Asistencia=" + id, cn);
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
                cmd = new SqlCommand("DELETE FROM CLASES.T_Asistencia WHERE id_Asistencia=" + id + "", cn);
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
                        da = new SqlDataAdapter("SELECT asi.*, nombre_Profesor FROM CLASES.T_Asistencia asi, Usuarios.T_Profesor p Where asi.id_Profesor=p.id_Profesor", cn);
                        dt = new DataTable();
                        da.Fill(dt);
                        dgv.DataSource = dt;
                        dgv.Columns["id_Profesor"].Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    break;
                case "Profesor":
                    try
                    {
                        da = new SqlDataAdapter("SELECT * FROM USUARIOS.T_Profesor", cn);
                        dt = new DataTable();
                        da.Fill(dt);
                        dgv.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    break;
              
                case "Asistencia":
                    try
                    {
                        da = new SqlDataAdapter("SELECT asi.*, nombre_Profesor FROM CLASES.T_Asistencia asi, Usuarios.T_Profesor p Where asi.id_Profesor=p.id_Profesor", cn);
                        dt = new DataTable();
                        da.Fill(dt);
                        dgv.DataSource = dt;
                        dgv.Columns["id_Profesor"].Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    break;
            }
        }
    }
}
