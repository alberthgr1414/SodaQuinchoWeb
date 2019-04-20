using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class Enc_Factura
    {

        public int PK_ID_ENC_FACTURA { get; set; }
        public int FK_ID_TURNO { get; set; }
        public string FECHA_REGISTRO { get; set; }
        public double MONTO { get; set; }
        public int FK_ID_EstadoEncFactura { get; set; }


        public void Nuevo(int FK_ID_TURNO)
        {
            try
            {
                CapaAccesoDatos.EncFacturaDatos.Insertar(FK_ID_TURNO);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void CambioEstado(int Estado, int PK_ID_ENC_FACTURA)
        {
            try
            {

                CapaAccesoDatos.EncFacturaDatos.CambioEstado(Estado, PK_ID_ENC_FACTURA);

            }
            catch (Exception)
            {

                throw;
            }

        }


        public void CambioTipo(int id, int tipo)
        {
            try
            {

                CapaAccesoDatos.EncFacturaDatos.CambioTipo(id, tipo);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void AsignacionNombre(string nombre, int id)
        {
            try
            {

                CapaAccesoDatos.EncFacturaDatos.AsignacionNombre(nombre, id);

            }
            catch (Exception)
            {

                throw;
            }

        }


        public List<Enc_Factura> Obtener()
        {
            List<Enc_Factura> LISTA_USUARIOS = new List<Enc_Factura>();
            DataSet ds = CapaAccesoDatos.EncFacturaDatos.SeleccionarTodos();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Enc_Factura U = new Enc_Factura();
                U.PK_ID_ENC_FACTURA = int.Parse(row["PK_ID_ENC_FACTURA"].ToString());
                U.FK_ID_TURNO = int.Parse(row["FK_ID_TURNO"].ToString());
                U.FECHA_REGISTRO = row["FECHA_REGISTRO"].ToString();
                U.MONTO = double.Parse(row["MONTO"].ToString());
                U.FK_ID_EstadoEncFactura = int.Parse(row["FK_ID_EstadoEncFactura"].ToString());
                LISTA_USUARIOS.Add(U);
            }
            return LISTA_USUARIOS;
        }

        public int ObtenerActivo()
        {
            Enc_Factura U = new Enc_Factura();
            DataSet ds = CapaAccesoDatos.EncFacturaDatos.SeleccionarTodos();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                U.PK_ID_ENC_FACTURA = int.Parse(row["PK_ID_ENC_FACTURA"].ToString());
            }
            return U.PK_ID_ENC_FACTURA;
        }


        public double ObtenerTotal()
        {
            Enc_Factura U = new Enc_Factura();
            DataSet ds = CapaAccesoDatos.EncFacturaDatos.SeleccionarTodos();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                U.MONTO = int.Parse(row["MONTO"].ToString());
            }
            return U.MONTO;
        }


        public double ObtenerTotalPorID(int id)
        {
            Enc_Factura U = new Enc_Factura();
            DataSet ds = CapaAccesoDatos.EncFacturaDatos.SeleccionarPorID(id);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                U.MONTO = int.Parse(row["MONTO"].ToString());
            }
            return U.MONTO;
        }
    }
}
