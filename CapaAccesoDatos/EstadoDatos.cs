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
    public class EstadoDatos
    {
        public static DataSet SeleccionarTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_CON_ESTADO");
            comando.CommandType = CommandType.StoredProcedure;
            DataSet dsCategoria = db.ExecuteReader(comando, "TIPO_USUARIO");
            return dsCategoria;
        }
    }
}
