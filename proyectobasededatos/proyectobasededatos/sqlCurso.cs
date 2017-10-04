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
    class sqlCurso
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        
        public sqlCurso()
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

        public string insertar(int Horario, int profesor,string nombre, int cupo,string fechaIni, string fechaFin,float costo, string tipo)
        {
            string ms = "Se inserto";
            try
            {
                cmd = new SqlCommand("INSERT INTO CLASES.T_Curso(id_Horario,id_Profesor,nombre_Curso,cupo,fecha_Inicio,fecha_Fin,costo_Hora,tipo) VALUES(" + Horario + "," + profesor +",'"+nombre+ "'," + cupo + ",'" + fechaIni +"','"+fechaFin+"',"+costo+",'"+tipo+ "')", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ms = "no se pudo insertar" + ex;
            }
            return ms;
        }

        public string modificar(int Horario, int profesor, string nombre, int cupo, string fechaIni, string fechaFin, float costo, string tipo, int id)
        {
            string ms = "Se modifico";
            try
            {
                cmd = new SqlCommand("UPDATE CLASES.T_Curso SET id_Horario=" + Horario + ",id_Profesor=" + profesor+",nombre_Curso='"+nombre+"',cupo="+cupo+",fecha_Inicio='"+fechaIni+"',fecha_Fin='"+fechaFin+"', costo_Hora="+costo.ToString().Replace(',','.') + ", tipo='" + tipo + "' WHERE id_Curso=" + id, cn);
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
                cmd = new SqlCommand("DELETE FROM CLASES.T_Curso WHERE id_Curso=" + id + "", cn);
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
                case "Horario":
                    try
                    {
                        da = new SqlDataAdapter("SELECT * FROM CLASES.T_Horario", cn);
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
            }
        }
    }
}
