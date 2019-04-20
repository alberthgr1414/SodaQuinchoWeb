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
    public class TipoPlatoDatos
    {
        public static DataSet SeleccionarTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_CON_TIPO_PLATO");
            comando.CommandType = CommandType.StoredProcedure;
            DataSet dsCategoria = db.ExecuteReader(comando, "TIPO_PLATO");
            return dsCategoria;
        }

        public static DataSet SeleccionarPorTipo(int tipo)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_CON_TIPO_PLATO_X_TIPO");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@PK_ID_TipoPlato", tipo);
            DataSet dsCategoria = db.ExecuteReader(comando, "TIPO_PLATO");
            return dsCategoria;
        }

        public static void Insertar(string STR_Descripcion)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_MAN_TIPO_PLATO_INSERTAR");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@STR_Descripcion", STR_Descripcion);
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
            SqlCommand comando = new SqlCommand("PA_MAN_DELETE_TIPO_PLATO");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@PK_ID_TipoPlato", cod);
            db.ExecuteNonQuery(comando);
        }

        public static void Modificar(int PK_ID_TipoPlato,string STR_Descripcion)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_MAN_ACTUALIZA_TIPO_PLATO");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@PK_ID_TipoPlato", PK_ID_TipoPlato);
            comando.Parameters.AddWithValue("@STR_Descripcion", STR_Descripcion);
            db.ExecuteNonQuery(comando);
        }
    }
}
