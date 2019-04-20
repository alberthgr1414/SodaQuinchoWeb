using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class Estado
    {

        // Varibles de el tipo de usuario
        public int ID_ESTADO { get; set; }
        public string STR_DESCRIPCION { get; set; } 

        public List<Estado> ObtenerTodos()
        {
            List<Estado> ListaTipoUsuario = new List<Estado>();

            DataSet ds = CapaAccesoDatos.EstadoDatos.SeleccionarTodos();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Estado p = new Estado();
                p.ID_ESTADO = int.Parse( row["ESTADO"].ToString());
                p.STR_DESCRIPCION = row["STR_DESCRIPCION"].ToString();
                ListaTipoUsuario.Add(p);
            }

            return ListaTipoUsuario;
        }
    }
}
