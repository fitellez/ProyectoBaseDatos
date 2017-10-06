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

    class sqlComentario
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public sqlComentario()
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
        public string insertar(string usuario, string tipoUsuario, string comentario)
        {
            string ms = "Se agregó correctamente";
            try
            {                
                cmd = new SqlCommand("INSERT INTO CLASES.T_Comentario(usuario_Comentario,tipo_Usuario,comentario) VALUES ('" + usuario + "','" + tipoUsuario + "','" + comentario + "')", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ms = "no se pudo agregar" + ex;
            }
            return ms;
        }
        public string modificar(string usuario, string tipoUsuario, string comentario,int id)
        {
            string ms = "Se modificó correctamente";
            try
            {                
                cmd= new SqlCommand("UPDATE CLASES.T_Comentario SET usuario_Comentario='"+usuario+ "',tipo_Usuario='"+tipoUsuario+ "',comentario='"+comentario+"' WHERE id_Comentario="+id,cn);
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
                cmd = new SqlCommand("DELETE FROM CLASES.T_Comentario WHERE id_Comentario=" + id + "", cn);
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
                da = new SqlDataAdapter("SELECT * FROM CLASES.T_Comentario", cn);
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
