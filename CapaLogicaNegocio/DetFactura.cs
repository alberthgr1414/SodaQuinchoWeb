using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;

namespace CapaLogicaNegocio
{
    public class DetFactura
    {
        public int PK_ID_DetFactura { get; set; }
        public int FK_ID_ENC_FACTURA { get; set; }
        public string STR_PLATO { get; set; }
        public int CANTIDAD { get; set; }
        public int TOTAL { get; set; }
        public int ESTADO_DET_FACTURA { get; set; }
        public int PK_ID_PLATO { get; set; }
        public String estado_det { get; set; }

    public void Nuevo(int FK_ID_ENC_FACTURA, int PK_ID_PLATO, int CANTIDAD)
        {
            try
            {
                if (CANTIDAD == 0)
                {
                    CANTIDAD = 1;
                }
                CapaAccesoDatos.DetFacturaDatos.Insertar(FK_ID_ENC_FACTURA, PK_ID_PLATO, CANTIDAD);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void CambioEstadoDet(int id, int estado)
        {
            try
            {
                CapaAccesoDatos.DetFacturaDatos.CambioEstadoDet(id, estado);
            }
            catch (Exception)
            {

                throw;
            }

        }


        public List<DetFactura> Obtener()
        {
            List<DetFactura> LISTA_USUARIOS = new List<DetFactura>();
            DataSet ds = CapaAccesoDatos.DetFacturaDatos.SeleccionarTodos();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                DetFactura U = new DetFactura();
                U.PK_ID_DetFactura = int.Parse(row["PK_ID_DetFactura"].ToString());
                U.FK_ID_ENC_FACTURA = int.Parse(row["FK_ID_ENC_FACTURA"].ToString());
                U.STR_PLATO = row["STR_PLATO"].ToString();
                U.CANTIDAD = int.Parse(row["CANTIDAD"].ToString());
                U.TOTAL = int.Parse(row["TOTAL"].ToString());
                U.ESTADO_DET_FACTURA = int.Parse(row["ESTADO_DET_FACTURA"].ToString());
                LISTA_USUARIOS.Add(U);
            }
            return LISTA_USUARIOS;
        }

        public List<DetFactura> ObtenerPorID(int id)
        {
            List<DetFactura> LISTA_USUARIOS = new List<DetFactura>();
            DataSet ds = CapaAccesoDatos.DetFacturaDatos.SeleccionarPorID(id);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                DetFactura U = new DetFactura();
                U.PK_ID_DetFactura = int.Parse(row["PK_ID_DetFactura"].ToString());
                U.FK_ID_ENC_FACTURA = int.Parse(row["FK_ID_ENC_FACTURA"].ToString());
                U.STR_PLATO = row["STR_PLATO"].ToString();
                U.CANTIDAD = int.Parse(row["CANTIDAD"].ToString());
                U.TOTAL = int.Parse(row["TOTAL"].ToString());
                U.ESTADO_DET_FACTURA = int.Parse(row["ESTADO_DET_FACTURA"].ToString());
                U.estado_det = row["STR_DESCRIPCION"].ToString();
                LISTA_USUARIOS.Add(U);
            }
            return LISTA_USUARIOS;
        }

        public void Eliminar()
        {
           DetFacturaDatos.Eliminar(PK_ID_DetFactura);
        }
    }
}
