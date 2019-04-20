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
    public class EncFacturaDatos
    {

        public static void Insertar(int FK_ID_TURNO)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("Default");
                SqlCommand comando = new SqlCommand("PA_MAN_ENC_FACTURA_INSERTAR");
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@FK_ID_TURNO", FK_ID_TURNO);
                db.ExecuteNonQuery(comando);
            }
            catch (Exception)
            {
                throw;
            }

        }


        public static void CambioEstado(int Estado,int PK_ID_ENC_FACTURA)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("Default");
                SqlCommand comando = new SqlCommand("PA_MAN_ACTUALIZA_ESTADO_ENC_FACTURA");
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Estado", Estado);
                comando.Parameters.AddWithValue("@PK_ID_ENC_FACTURA", PK_ID_ENC_FACTURA);
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
            SqlCommand comando = new SqlCommand("PA_CON_ENC_FACTURA");
            // Es requerido indicar que el tipo es un StoreProcedure
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "EncFactura");
            return ds;
        }

        public static DataSet CambioTipo(int id,int tipo)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_MAN_ENC_FACTURA_TIPO");
            // Es requerido indicar que el tipo es un StoreProcedure
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@tipo", tipo);
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "EncFactura");
            return ds;
        }

        public static DataSet SeleccionarPorID(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_CON_ENC_FACTURA_POR_ID");
            // Es requerido indicar que el tipo es un StoreProcedure
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            DataSet ds = db.ExecuteReader(comando, "EncFactura");
            return ds;
        }

        public static void AsignacionNombre(string nombre,int id)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("Default");
                SqlCommand comando = new SqlCommand("PA_MAN_NOMBRE_ENC");
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@id", id);
                db.ExecuteNonQuery(comando);
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
