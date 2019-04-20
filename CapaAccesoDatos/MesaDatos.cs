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
    public class MesaDatos
    {
        public static void AsignarMesa(int mesa, int id)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("Default");
                SqlCommand comando = new SqlCommand("PA_MAN_MESA_ASIGNAR");
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@mesa", mesa);
                db.ExecuteNonQuery(comando);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static DataSet MesaOcupada(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_CON_MESA_OCUPADA");
            // Es requerido indicar que el tipo es un StoreProcedure
            comando.Parameters.AddWithValue("@v_id", id);
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "MESA");
            return ds;
        }

        public static void Mesavaciar(int cod)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_MA_MESA_VACIAR");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@v_id", cod);
            db.ExecuteNonQuery(comando);
        }

        public static DataSet MesasDisponibles()
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_CON_MESAS_DISPONIBLES");
            // Es requerido indicar que el tipo es un StoreProcedure
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "Usuario");
            return ds;
        }


    }
}
