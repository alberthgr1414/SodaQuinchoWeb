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
    public class ExpressDatos
    {

        public static void Insertar(int FK_ID_ENC_FACTURA, string descripcion,int zona)
        {
            try
            {
                int estado = 1;
                Database db = DatabaseFactory.CreateDatabase("Default");
                SqlCommand comando = new SqlCommand("PA_MAN_EXPRESS_INSERTAR");
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@FK_ID_TIPO_USUARIO", FK_ID_ENC_FACTURA);
                comando.Parameters.AddWithValue("@ESTADO", estado);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@zona", zona);
                db.ExecuteNonQuery(comando);
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
