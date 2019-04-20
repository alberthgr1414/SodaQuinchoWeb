using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaLogicaNegocio
{
    public class TipoUsuario
    {
        // Varibles de el tipo de usuario
        public string PK_ID_TipoUsuario { get; set; }
        public string STR_DESCRIPCION { get; set; }


        //Obtiene todos los tipos de usuarios
        public List<TipoUsuario> ObtenerTodos()
        {
            List<TipoUsuario> ListaTipoUsuario = new List<TipoUsuario>();

            DataSet ds = CapaAccesoDatos.TipoUsuarioDatos.SeleccionarTodos();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                TipoUsuario p = new TipoUsuario();
                p.PK_ID_TipoUsuario = row["PK_ID_TipoUsuario"].ToString();
                p.STR_DESCRIPCION = row["STR_DESCRIPCION"].ToString();
                ListaTipoUsuario.Add(p);
            }

            return ListaTipoUsuario;
        }
    }
}



