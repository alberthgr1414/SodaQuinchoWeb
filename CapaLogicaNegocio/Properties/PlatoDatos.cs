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
    public class PlatoDatos
    {
        public static DataSet SeleccionarTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_CON_PLATO");
            // Es requerido indicar que el tipo es un StoreProcedure
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "Plato");
            return ds;
        }

        public static void Insertar(int FK_ID_TipoPlato,string STR_Nombre_Plato, double Precio_Plato, int ESTADO,string foto)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("Default");
                SqlCommand comando = new SqlCommand("PA_MAN_PLATO_INSERTAR");
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@FK_ID_TipoPlato", FK_ID_TipoPlato);
                comando.Parameters.AddWithValue("@STR_Nombre_Plato", STR_Nombre_Plato);
                comando.Parameters.AddWithValue("@Precio_Plato", Precio_Plato);
                comando.Parameters.AddWithValue("@ESTADO", ESTADO); 
                comando.Parameters.AddWithValue("@foto", @foto); 
                db.ExecuteNonQuery(comando);
            }
            catch (Exception)
            {
                throw;
            }

        }


        public static void Eliminar(int cod)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_MAN_DELETE_PLATO");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@PK_ID_PLATO", cod);
            db.ExecuteNonQuery(comando);
        }


        public static void Modificar(int PK_ID_PLATO,int FK_ID_TipoPlato,string STR_Nombre_Plato,int ID_ESTADO,double Precio_Plato)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_MAN_ACTUALIZA_PLATO");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@PK_ID_PLATO", PK_ID_PLATO);
            comando.Parameters.AddWithValue("@FK_ID_TipoPlato", FK_ID_TipoPlato);
            comando.Parameters.AddWithValue("@STR_Nombre_Plato", STR_Nombre_Plato);
            comando.Parameters.AddWithValue("@ID_ESTADO", ID_ESTADO);
            comando.Parameters.AddWithValue("@Precio_Plato", Precio_Plato);
            db.ExecuteNonQuery(comando);
        }


        public static DataSet SeleccionarTodosPorTipo(int tipo)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_CON_PLATO_POR_TIPO");
            // Es requerido indicar que el tipo es un StoreProcedure
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@FK_ID_TipoPlato", tipo);
            DataSet ds = db.ExecuteReader(comando, "Plato");
            return ds;
        }
    }
}
