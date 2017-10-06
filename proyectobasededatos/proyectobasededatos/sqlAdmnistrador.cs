using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace proyectoBasedeDatos
{
    class sqlAdmnistrador
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public sqlAdmnistrador()
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

        public string insertar(string nombre, string telefono,string correo, string direccion, string horaEntrada, string horaSalida)
        {
            string ms = "Se agregó correctamente";
            try
            {
                cmd = new SqlCommand("INSERT INTO USUARIOS.T_Administrador(nombre_Administrador,telefono_Administrador,correo_Administrador, direccion_Administrador,hora_Ent,hora_Sal) VALUES ('" + nombre + "','" + telefono +"','"+correo+ "','" + direccion + "','" + horaEntrada+ "','" + horaSalida + "')", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ms = "no se pudo agregar" + ex;
            }
            return ms;
        }

        public string modificar(string nombre, string telefono, string correo, string direccion, string horaEntrada, string horaSalida, int id)
        {
            string ms = "Se modificó correctamente";
            try
            {
                cmd = new SqlCommand("UPDATE USUARIOS.T_Administrador SET nombre_Administrador='" + nombre + "', telefono_Administrador='" + telefono + "', correo_Administrador='"+correo+"',direccion_Administrador='" + direccion + "', hora_Ent='" + horaEntrada + "', hora_Sal='" + horaSalida + "' WHERE id_Administrador=" + id + "", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ms = "no se pudo modificar" + ex;
            }
            return ms;
        }

        public string elimina(int id)
        {
            string ms = "Se eliminó correctamente";
            try
            {
                cmd = new SqlCommand("DELETE FROM USUARIOS.T_Administrador WHERE id_Administrador=" + id + "", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ms = "no se pudo eliminar" + ex;
            }
            return ms;
        }

        public void cargaDatos(DataGridView dgv)
        {
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
        }
        public void cargaDatosComentario(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("SELECT  nombre_Administrador AS nombre, concat('Administrador','') AS Tipo FROM USUARIOS.T_Administrador", cn);
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

