using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ventaDatos;

namespace CapaAccesoDatos
{
    public class TipoUsuarioDatos
    {
        //Obtiene los tipos de usuarios de la base de datos
        public static DataSet SeleccionarTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_CON_TIPO_USUARIO");
            comando.CommandType = CommandType.StoredProcedure;
            DataSet dsCategoria = db.ExecuteReader(comando, "TIPO_USUARIO");
            return dsCategoria;
        }


    }
}
