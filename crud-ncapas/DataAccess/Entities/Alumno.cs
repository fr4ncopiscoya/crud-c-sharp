using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccess.Connection;
using Common.Attributes;

namespace DataAccess.Entities
{
    public class Alumno
    {
        //Variables
        conn_bd conn = new conn_bd();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataTable dt = new DataTable();

        public DataTable Mostrar()
        {
            try
            {
                cmd.Connection = conn.OpenConnection();
                cmd.CommandText = "SP_Mostrar";
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            catch (Exception ex)  
            {
                String errmsg = ex.ToString();
            }

            finally
            {
                cmd.Connection = conn.CloseConnection();
            }
            return dt;
        }

        public void Insertar(Attributes obj)
        {
            try
            {
                cmd.Connection = conn.OpenConnection();
                cmd.CommandText = "SP_Insertar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@alu_id", obj.Id);
                cmd.Parameters.AddWithValue("@alu_name", obj.Name);
                cmd.Parameters.AddWithValue("@alu_lastname", obj.Lastname);
                cmd.Parameters.AddWithValue("@alu_sexo", obj.Sexo);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }

            catch (Exception ex)
            {
                String errmsg = ex.ToString();
            }

            finally
            {
                cmd.Connection = conn.CloseConnection();
            }
        }

        public void Modificar(Attributes obj)
        {
            try
            {
                cmd.Connection = conn.OpenConnection();
                cmd.CommandText = "SP_Modificar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@alu_id", obj.Id);
                cmd.Parameters.AddWithValue("@alu_name", obj.Name);
                cmd.Parameters.AddWithValue("@alu_lastname", obj.Lastname);
                cmd.Parameters.AddWithValue("@alu_sexo", obj.Sexo);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }

            catch (Exception ex)
            {
                String errmsg = ex.ToString();
            }

            finally
            {
                cmd.Connection = conn.CloseConnection();
            }
        }

        public void Eliminar(Attributes obj)
        {
            try
            {
                cmd.Connection= conn.OpenConnection();
                cmd.CommandText = "SP_Eliminar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@alu_id", obj.Id);
                cmd.ExecuteReader();
                cmd.Parameters.Clear();
            }
            catch(Exception ex)
            {
                String errmsg = ex.ToString();
            }
            finally
            {
                cmd.Connection = conn.CloseConnection();
            }
        }


        public DataTable Search(String Search)
        {
            try
            {
                cmd.Connection = conn.OpenConnection();
                cmd.CommandText = "SP_Buscar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Buscar" , Search);
                dr = cmd.ExecuteReader();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt.Load(dr);
            }
            catch (Exception ex)
            {
                String errmsg = ex.ToString();
            }

            finally
            {
                cmd.Connection = conn.CloseConnection();
            }
            return dt;
        }

    }
}
