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
    public class TurnoDatos
    {
        public static void AbrirTurno(int FK_ID_USUARIO,double FONDO)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("Default");
                SqlCommand comando = new SqlCommand("PA_TRA_TURNO_ABRIR");
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@FK_ID_USUARIO", FK_ID_USUARIO);
                comando.Parameters.AddWithValue("@FONDO", FONDO);
                db.ExecuteNonQuery(comando);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static void CerrarTurno(int PK_ID_TURNO)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("Default");
                SqlCommand comando = new SqlCommand("PA_TRA_TURNO_CERRAR");
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@PK_ID_TURNO", PK_ID_TURNO);
                db.ExecuteNonQuery(comando);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static DataSet VerificaTurno(int FK_ID_USUARIO, int ESTADO)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_CON_TURNO");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@FK_ID_USUARIO", FK_ID_USUARIO);
            comando.Parameters.AddWithValue("@ESTADO", ESTADO);
            DataSet ds = db.ExecuteReader(comando, "TURNO");
            return ds;
        }

        public static DataSet SeleccionarTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_CON_TURNO_ABIERTO");
            // Es requerido indicar que el tipo es un StoreProcedure
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "Turno");
            return ds;
        }
    }
}
