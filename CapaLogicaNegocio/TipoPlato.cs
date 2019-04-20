using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;

namespace CapaLogicaNegocio
{
    public class TipoPlato
    {
        public int PK_ID_TipoPlato { get; set; }
        public string STR_Descripcion { get; set; }



        public List<TipoPlato> ObtenerTodos()
        {
            List<TipoPlato> ListaTipoUsuario = new List<TipoPlato>();

            DataSet ds = CapaAccesoDatos.TipoPlatoDatos.SeleccionarTodos();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                TipoPlato p = new TipoPlato();
                p.PK_ID_TipoPlato = int.Parse( row["PK_ID_TipoPlato"].ToString());
                p.STR_Descripcion = row["STR_DESCRIPCION"].ToString();
                ListaTipoUsuario.Add(p);
            }

            return ListaTipoUsuario;
        }


        public List<TipoPlato> ObtenerPorTipo(int tipo)
        {
            List<TipoPlato> ListaTipoUsuario = new List<TipoPlato>();

            DataSet ds = CapaAccesoDatos.TipoPlatoDatos.SeleccionarPorTipo(tipo);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                TipoPlato p = new TipoPlato();
                p.PK_ID_TipoPlato = int.Parse(row["PK_ID_TipoPlato"].ToString());
                p.STR_Descripcion = row["STR_DESCRIPCION"].ToString();
                ListaTipoUsuario.Add(p);
            }

            return ListaTipoUsuario;
        }

        public void Nuevo()
        {
            try
            {
                CapaAccesoDatos.TipoPlatoDatos.Insertar(STR_Descripcion);

            }
            catch (Exception)
            {

                throw;
            }

        }
        public void Eliminar()
        {
            TipoPlatoDatos.Eliminar(PK_ID_TipoPlato);
        }

        public void Modificar()
        {
            CapaAccesoDatos.TipoPlatoDatos.Modificar(PK_ID_TipoPlato, STR_Descripcion);
        }


    }
}
