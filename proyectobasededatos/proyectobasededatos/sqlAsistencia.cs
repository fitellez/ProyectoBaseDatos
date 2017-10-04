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
                cn = new SqlConnection(@"Data Source=.;initial catalog=TrainingInstitute; integrated Security=true");
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
            string ms = "Se inserto";
            try
            {
                cmd = new SqlCommand("INSERT INTO CLASES.T_Asistencia (id_Profesor,num_Horas,fecha_hora) VALUES ("  + profesor + "," + numhoras + ",'" + fecha + "')", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ms = "no se pudo insertar" + ex;
            }
            return ms;
        }

        public string modificar(int profesor, int numhoras, string fecha, int id)
        {
            string ms = "Se modifico";
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
            string ms = "Se elimino";
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
                        da = new SqlDataAdapter("SELECT * FROM CLASES.T_Asistencia", cn);
                        dt = new DataTable();
                        da.Fill(dt);
                        dgv.DataSource = dt;
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
                        da = new SqlDataAdapter("SELECT * FROM CLASES.T_Asistencia", cn);
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
    }
}
