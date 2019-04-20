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
    public class DetFacturaDatos
    {
        public static void Insertar(int FK_ID_ENC_FACTURA,int PK_ID_PLATO,int CANTIDAD)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("Default");
                SqlCommand comando = new SqlCommand("PA_MAN_DET_FACTURA_INSERTAR");
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@FK_ID_ENC_FACTURA", FK_ID_ENC_FACTURA);
                comando.Parameters.AddWithValue("@PK_ID_PLATO", PK_ID_PLATO);
                comando.Parameters.AddWithValue("@CANTIDAD", CANTIDAD);
                db.ExecuteNonQuery(comando);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static void CambioEstadoDet(int id, int estado)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("Default");
                SqlCommand comando = new SqlCommand("PA_MAN_ESTADO_DET");
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@estado", estado);
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
            SqlCommand comando = new SqlCommand("PA_CON_FACTURA");
            // Es requerido indicar que el tipo es un StoreProcedure
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "DetFactura");
            return ds;
        }

        public static DataSet SeleccionarPorID(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_CON_FACTURA_POR_ID");
            comando.Parameters.AddWithValue("@id", id);
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "DetFactura");
            return ds;
        }

        public static void Eliminar(int PK_ID_DetFactura)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_MAN_DELETE_DET_FACTURA");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@PK_ID_DetFactura", PK_ID_DetFactura);
            db.ExecuteNonQuery(comando);
        }


    }
}
