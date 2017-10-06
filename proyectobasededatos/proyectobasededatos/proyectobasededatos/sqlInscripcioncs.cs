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
    class sqlInscripcioncs
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public sqlInscripcioncs()
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
        public string insertar(int Admin,int alumno,int curso, int monto, string fecha)
        {
            string ms = "Se agregó correctamente";
            try
            {
                cmd = new SqlCommand("INSERT INTO CLASES.T_Inscripcion(id_Admnistrador,id_Alumno,id_Curso,monto,fecha_hora) VALUES (" + Admin + "," + alumno + "," + curso + "," + monto + ",'" + fecha + "')", cn);
                cmd.ExecuteNonQuery();
            }            
            catch(Exception ex)
            {
                ms = "no se pudo agregar" + ex;
            }
            return ms;
        }

        public string modificar(int Admin, int alumno, int curso, int monto, string fecha, int id)
        {
            string ms = "Se modificó correctamente";
            try
            {
                cmd = new SqlCommand("UPDATE CLASES.T_Inscripcion SET id_Admnistrador=" + Admin + ",id_Alumno=" + alumno + ",id_Curso=" + curso + ",monto=" + monto + ",fecha_hora='" + fecha + "' WHERE id_Inscripcion="+id, cn);                
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
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
                cmd = new SqlCommand("DELETE FROM CLASES.T_Inscripcion WHERE id_Inscripcion=" + id + "", cn);                
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                ms = "no se pudo eliminar" + ex;
            }
            return ms;
        }
        public void cargaDatos(DataGridView dgv,string opcion)
        {
            switch (opcion)
            {
                case "":
                    try
                    {
                        da = new SqlDataAdapter("SELECT i.*,nombre_Alumno, nombre_Administrador, nombre_Curso FROM CLASES.T_Inscripcion i, Usuarios.T_Alumno a, Clases.T_Curso c, Usuarios.T_Administrador ad Where i.id_Alumno=a.id_Alumno AND i.id_Admnistrador=ad.id_Administrador AND i.id_Curso=c.id_Curso", cn);
                        dt = new DataTable();
                        da.Fill(dt);
                        dgv.DataSource = dt;
                        dgv.Columns["id_Alumno"].Visible = false;
                        dgv.Columns["id_Admnistrador"].Visible = false;
                        dgv.Columns["id_Curso"].Visible = false;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    break;
                case "Administrador":
                    try
                    {
                        da = new SqlDataAdapter("SELECT * FROM USUARIOS.T_Administrador", cn);
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
                        da = new SqlDataAdapter("SELECT c.*, nombre_Profesor, Hora_Inicio FROM CLASES.T_Curso c, Clases.T_Horario h, Usuarios.T_Profesor p where c.id_Profesor=p.id_Profesor AND c.id_Horario=h.id_Horario", cn);
                        dt = new DataTable();
                        da.Fill(dt);
                        dgv.DataSource = dt;
                        dgv.Columns["id_Profesor"].Visible = false;
                        dgv.Columns["id_Horario"].Visible = false;
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
                case "Inscripciones":
                    try
                    {
                        da = new SqlDataAdapter("SELECT i.*,nombre_Alumno, nombre_Administrador, nombre_Curso FROM CLASES.T_Inscripcion i, Usuarios.T_Alumno a, Clases.T_Curso c, Usuarios.T_Administrador ad Where i.id_Alumno=a.id_Alumno AND i.id_Admnistrador=ad.id_Administrador AND i.id_Curso=c.id_Curso", cn);
                        dt = new DataTable();
                        da.Fill(dt);
                        dgv.DataSource = dt;
                        dgv.Columns["id_Alumno"].Visible = false;
                        dgv.Columns["id_Admnistrador"].Visible = false;
                        dgv.Columns["id_Curso"].Visible = false;
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
