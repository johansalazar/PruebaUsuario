using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using ProxyServices.Dto;

namespace WCFServiceUsuarios.DataLayer
{
    public class CLs_Sql
    {
        //=================================comun================================================
        /// <summary>
        /// Property that contains the  Database Server
        /// </summary>
        public String _Server_DB = System.Configuration.ConfigurationManager.AppSettings["Server"];
        /// <summary>
        /// Property that contains the Database Id User
        /// </summary>
        public String _User_ID_DB = System.Configuration.ConfigurationManager.AppSettings["User_ID_DB"];
        /// <summary>
        /// Property that contains the Database User Password 
        /// </summary>
        public String _Pasword_DB = System.Configuration.ConfigurationManager.AppSettings["Passwor_Id_User_Db"];
        /// <summary>
        /// Property that contains the Database port
        /// </summary>
        public String _Port_DB = System.Configuration.ConfigurationManager.AppSettings["Port_DB"];
        /// <summary>
        /// Property that contains the Database name
        /// </summary>
        public String _Name_DB = System.Configuration.ConfigurationManager.AppSettings["DB_Name"];


        public SqlConnection conexion = new SqlConnection();

        public SqlConnection ObtenerConexion()
        {
            string bdComun = "";

            bdComun = "Server=" + _Server_DB + ";Database=" + _Name_DB + ";User ID=" + _User_ID_DB + ";Password=" + _Pasword_DB;

            conexion = new SqlConnection(bdComun);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return conexion;
        }

        public bool DescargarConexion()
        {
            conexion.Dispose();
            return true;
        }


        public Usuarios CuUsuario(Usuarios usuario, string action)
        {
            Usuarios ResponseUsuario = new Usuarios();
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_Usuarios", ObtenerConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Usuario", usuario.Id_Usuario);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                cmd.Parameters.AddWithValue("@Action", action);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    ResponseUsuario.Id_Usuario = Convert.ToInt32(row.ItemArray[0]);
                    ResponseUsuario.Nombre = row.ItemArray[1].ToString();
                    ResponseUsuario.FechaNacimiento = Convert.ToDateTime(row.ItemArray[2]);
                    ResponseUsuario.Sexo = row.ItemArray[3].ToString();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(" ERROR: " + ex);
            }
            DescargarConexion();
            return ResponseUsuario;
        }


        public Usuarios DeleteUsuario(Usuarios usuario, string action)
        {
            Usuarios ResponseUsuario = new Usuarios();
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_Usuarios", ObtenerConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Usuario", usuario.Id_Usuario);              
                cmd.Parameters.AddWithValue("@Action", action);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    ResponseUsuario.Id_Usuario = Convert.ToInt32(row.ItemArray[0]);
                    ResponseUsuario.Nombre = row.ItemArray[1].ToString();
                    ResponseUsuario.FechaNacimiento = Convert.ToDateTime(row.ItemArray[2]);
                    ResponseUsuario.Sexo = row.ItemArray[3].ToString();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(" ERROR: " + ex);
            }
            DescargarConexion();
            return ResponseUsuario;
        }



        public List<Usuarios> ObtenerUsuario(string action)
        {
            List<Usuarios> ResponseUsuario = new List<Usuarios>();
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_Usuarios", ObtenerConexion());
                cmd.CommandType = CommandType.StoredProcedure;            
                cmd.Parameters.AddWithValue("@Action", action);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    Usuarios Usuario = new Usuarios();
                    Usuario.Id_Usuario = Convert.ToInt32(row.ItemArray[0]);
                    Usuario.Nombre = row.ItemArray[1].ToString();
                    Usuario.FechaNacimiento = Convert.ToDateTime(row.ItemArray[2]);
                    Usuario.Sexo = row.ItemArray[3].ToString();
                    ResponseUsuario.Add(Usuario);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(" ERROR: " + ex);
            }
            DescargarConexion();
            return ResponseUsuario;
        }
    }
}
