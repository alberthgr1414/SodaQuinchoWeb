using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class Mesa
    {

        public int PK_ID_MESA { get; set; }
        public int STR_NUMERO { get; set; }
        public int PK_ENC_FACTURA { get; set; }

        public void AsignarMesa(int mesa, int id)
        {
            try
            {

                CapaAccesoDatos.MesaDatos.AsignarMesa(mesa, id);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Mesa> MesaOcupada(int id)
        {
            List<Mesa> LISTA_USUARIOS = new List<Mesa>();
            DataSet ds = CapaAccesoDatos.MesaDatos.MesaOcupada(id);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Mesa U = new Mesa();
                U.PK_ENC_FACTURA = int.Parse(row["PK_ENC_FACTURA"].ToString());
                U.PK_ID_MESA = int.Parse(row["PK_ID_MESA"].ToString());
                U.STR_NUMERO = int.Parse(row["STR_NUMERO"].ToString());
                LISTA_USUARIOS.Add(U);
            }
            return LISTA_USUARIOS;
        }

        public void MesaVaciar(int id)
        {
            CapaAccesoDatos.MesaDatos.Mesavaciar(id);
        }

        public List<Mesa> MesasDisponibles()
        {
            List<Mesa> LISTA_USUARIOS = new List<Mesa>();
            DataSet ds = CapaAccesoDatos.MesaDatos.MesasDisponibles();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Mesa U = new Mesa();
                U.STR_NUMERO = int.Parse(row["STR_NUMERO"].ToString()); 
                LISTA_USUARIOS.Add(U);
            }
            return LISTA_USUARIOS;
        }
    }
}
