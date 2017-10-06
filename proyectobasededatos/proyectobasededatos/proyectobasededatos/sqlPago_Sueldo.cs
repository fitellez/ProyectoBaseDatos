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
    class sqlPago_Sueldo
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public sqlPago_Sueldo()
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
        public string insertar(int Admin,int profesor,int horasPagadas,string fecha)
        {
            string ms = "Se agregó correctamente";
            try
            {                
                cmd = new SqlCommand("INSERT INTO CLASES.T_Pago_Sueldo(id_Admnistrador,id_Profesor,horasPagadas,fecha_hora) VALUES(" + Admin + "," + profesor + "," + horasPagadas + ",'" + fecha + "')", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ms = "no se pudo agregar" + ex;
            }
            return ms;
        }

        public string modificar(int Admin, int profesor, int horasPagadas, string fecha,int id)
        {
            string ms = "Se modificó correctamente";
            try
            {
                cmd = new SqlCommand("UPDATE CLASES.T_Pago_Sueldo SET id_Admnistrador=" + Admin + ",id_Profesor=" + profesor +", horasPagadas="+horasPagadas+ ",fecha_hora='" + fecha + "' WHERE id_Pago="+id, cn);
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
                cmd = new SqlCommand("DELETE FROM CLASES.T_Pago_Sueldo WHERE id_Pago=" + id + "", cn);
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
                        da = new SqlDataAdapter("SELECT s.*, nombre_Administrador, nombre_Profesor FROM CLASES.T_Pago_Sueldo s, Usuarios.T_Administrador ad, Usuarios.T_Profesor p where s.id_Admnistrador=ad.id_Administrador AND s.id_Profesor=p.id_Profesor", cn);
                        dt = new DataTable();
                        da.Fill(dt);
                        dgv.DataSource = dt;
                        dgv.Columns["id_Admnistrador"].Visible = false;
                        dgv.Columns["id_Profesor"].Visible = false;
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
                case "Pago_Sueldo":
                    try
                    {
                        da = new SqlDataAdapter("SELECT s.*, nombre_Administrador, nombre_Profesor FROM CLASES.T_Pago_Sueldo s, Usuarios.T_Administrador ad, Usuarios.T_Profesor p where s.id_Admnistrador=ad.id_Administrador AND s.id_Profesor=p.id_Profesor", cn);
                        dt = new DataTable();
                        da.Fill(dt);
                        dgv.DataSource = dt;
                        dgv.Columns["id_Admnistrador"].Visible = false;
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
