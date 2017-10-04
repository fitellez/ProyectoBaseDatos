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
    class sqlProfesor
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public sqlProfesor()
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

        public string insertar(string nombre, string telefono, string direccion, int totalHoras,float pagoPorHora)
        {
            string ms = "Se inserto";
            try
            {
                cmd = new SqlCommand("INSERT INTO USUARIOS.T_Profesor(nombre_Profesor,telefono_Profesor,direccion_Profesor,total_Horas,pago_Horas)VALUES('" + nombre + "','" + telefono + "','" + direccion + "'," + totalHoras + "," + pagoPorHora.ToString().Replace(',', '.') + ")", cn);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                ms = "no se pudo insertar" + ex;
            }
            return ms;
        }

        public string modificar(string nombre, string telefono, string direccion, int totalHoras, float pagoPorHora, int id)
        {
            string ms = "Se modifico";
            try
            {
                cmd = new SqlCommand("UPDATE USUARIOS.T_Profesor SET nombre_Profesor='" + nombre + "', telefono_Profesor='" + telefono + "',direccion_Profesor='" + direccion + "',total_Horas=" + totalHoras + ",pago_Horas=" + pagoPorHora.ToString().Replace(',', '.') + " WHERE id_Profesor=" + id + "", cn);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                ms = "no se pudo modificar" + ex;
            }
            return ms;
        }

        public string elimina(int id)
        {
            string ms = "Se elimino";
            try
            {
                cmd = new SqlCommand("DELETE FROM USUARIOS.T_Profesor WHERE id_Profesor=" + id + "",cn);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                ms = "no se pudo eliminar" + ex;
            }
            return ms;
        }

        public void cargaDatos(DataGridView dgv)
        {
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
        }
        public void cargaDatosComentario(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("SELECT  nombre_Profesor AS nombre, concat('Profesor','') AS Tipo FROM USUARIOS.T_Profesor", cn);
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
