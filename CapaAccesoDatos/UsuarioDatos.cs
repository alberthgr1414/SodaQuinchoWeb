using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventaDatos;

namespace CapaAccesoDatos
{
    public class UsuarioDatos
    {
        public static void Insertar(int FK_ID_TIPO_USUARIO, string STR_NOMBRE, string STR_USUARIO,string STR_CONTRASENA)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("Default");
                SqlCommand comando = new SqlCommand("PA_MAN_USUARIO_INSERTAR");
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@FK_ID_TIPO_USUARIO", FK_ID_TIPO_USUARIO);
                comando.Parameters.AddWithValue("@STR_NOMBRE", STR_NOMBRE);
                comando.Parameters.AddWithValue("@STR_USUARIO", STR_USUARIO);
                comando.Parameters.AddWithValue("@STR_CONTRASENA", Encriptar.Encriptar_pass(STR_CONTRASENA));
                db.ExecuteNonQuery(comando);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static DataSet SeleccionarTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_CON_USUARIO");
            // Es requerido indicar que el tipo es un StoreProcedure
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "Usuario");
            return ds;
        }
        public static void Eliminar(int cod)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_MAN_DELETE_USUARIO");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@PK_ID_USUARIO", cod);
            db.ExecuteNonQuery(comando);
        }

       public static void Modificar(int PK_ID_USUARIO,int FK_ID_TIPO_USUARIO,string STR_NOMBRE,
    string STR_USUARIO_LOGIN,string STR_CONTRASENA, int ESTADO)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_MAN_ACTUALIZA_USUARIO");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@PK_ID_USUARIO", PK_ID_USUARIO);
            comando.Parameters.AddWithValue("@FK_ID_TIPO_USUARIO", FK_ID_TIPO_USUARIO);
            comando.Parameters.AddWithValue("@STR_NOMBRE", STR_NOMBRE);
            comando.Parameters.AddWithValue("@STR_USUARIO_LOGIN", STR_USUARIO_LOGIN);
            comando.Parameters.AddWithValue("@STR_CONTRASENA", Encriptar.Encriptar_pass(STR_CONTRASENA));
            comando.Parameters.AddWithValue("@ESTADO", ESTADO);
            db.ExecuteNonQuery(comando);
        }


        public static DataSet UsuarioLogin(string usuario, string contrasenna)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_CON_LOGIN_USUARIO");
            // Es requerido indicar que el tipo es un StoreProcedure
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@STR_USUARIO", usuario);
            comando.Parameters.AddWithValue("@STR_CONTRASENA", Encriptar.Encriptar_pass(contrasenna));
            DataSet ds = db.ExecuteReader(comando, "Usuario");
            return ds;
        }

        public static DataSet UsuarioVerifica(string usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_CON_VERIFICA_USUARIO");
            // Es requerido indicar que el tipo es un StoreProcedure
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@STR_USUARIO", usuario);
            DataSet ds = db.ExecuteReader(comando, "Usuario");
            return ds;
        }

    }
}
