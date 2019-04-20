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
    public class ZonaExpressDatos
    {

        public static DataSet SeleccionarTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_CON_ZONA_EXPRESS");
            // Es requerido indicar que el tipo es un StoreProcedure
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "ZONA_EXPRESS");
            return ds;
        }

        public static DataSet SeleccionarEpxress(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_CON_EXPRESS_EXIST");
            comando.Parameters.AddWithValue("@v_id", id);
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "EXPRESS");
            return ds;
        }


        public static DataSet MontoEpxress(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_CON_EXPRESS_MONTO");
            comando.Parameters.AddWithValue("@v_id", id);
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "EXPRESS");
            return ds;
        }

        public static DataSet MontoEpxressFactura(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_CON_EXPRESS_MONTO_FACTURA");
            comando.Parameters.AddWithValue("@v_id", id);
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "EXPRESS");
            return ds;
        }

        public static void Insertar(string STR_Descripcion, double Precio_Express)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("Default");
                SqlCommand comando = new SqlCommand("PA_MAN_ZONA_EXPRESS_INSERTAR");
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@STR_Descripcion", STR_Descripcion);
                comando.Parameters.AddWithValue("@Precio_Express", Precio_Express);
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
        SqlCommand comando = new SqlCommand("PA_MAN_DELETE_ZONA_EXPRESS");
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.AddWithValue("@PK_ID_ZONA_EXPRESS", cod);
        db.ExecuteNonQuery(comando);
    }


        public static void Modificar(int PK_ID_ZONA_EXPRESS, string STR_Descripcion, Double Precio_Express)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_MAN_ACTUALIZA_ZONA_EXPRESS");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@PK_ID_ZONA_EXPRESS", PK_ID_ZONA_EXPRESS);
            comando.Parameters.AddWithValue("@STR_Descripcion", STR_Descripcion);
            comando.Parameters.AddWithValue("@Precio_Express", Precio_Express);
            db.ExecuteNonQuery(comando);
        }



    }
}
