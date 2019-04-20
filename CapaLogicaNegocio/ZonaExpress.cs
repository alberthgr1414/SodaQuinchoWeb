using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class ZonaExpress
    {
        public int PK_ID_ZONA_EXPRESS { get; set; }
        public string STR_Descripcion { get; set; }
        public double Precio_Express { get; set; }


        public List<ZonaExpress> Obtener()
        {
            List<ZonaExpress> LISTA_USUARIOS = new List<ZonaExpress>();
            DataSet ds = CapaAccesoDatos.ZonaExpressDatos.SeleccionarTodos();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ZonaExpress U = new ZonaExpress();
                U.PK_ID_ZONA_EXPRESS = int.Parse(row["PK_ID_ZONA_EXPRESS"].ToString());
                U.STR_Descripcion = row["STR_Descripcion"].ToString();
                U.Precio_Express = double.Parse(row["Precio_Express"].ToString());
                LISTA_USUARIOS.Add(U);
            }
            return LISTA_USUARIOS;
        }


        public List<Express> ObtenerExpress(int id)
        {
            List<Express> LISTA_USUARIOS = new List<Express>();
            DataSet ds = CapaAccesoDatos.ZonaExpressDatos.SeleccionarEpxress(id);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Express U = new Express();
                U.PK_ID_EXPRESS = int.Parse(row["PK_ID_EXPRESS"].ToString());
                U.FK_ID_ENC_FACTURA = int.Parse(row["FK_ID_ENC_FACTURA"].ToString());
                U.Descripcion = row["Descripcion"].ToString();
                U.fk_zona_express = int.Parse(row["FK_ZONA_EXPRESS"].ToString());
                U.ESTADO = int.Parse(row["ESTADO"].ToString());
                U.fecha =row["fecha_inserta"].ToString();
                LISTA_USUARIOS.Add(U);
            }
            return LISTA_USUARIOS;
        }

        public void Nuevo()
        {
            try
            {
                CapaAccesoDatos.ZonaExpressDatos.Insertar(STR_Descripcion, Precio_Express);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Eliminar()
        {
            ZonaExpressDatos.Eliminar(PK_ID_ZONA_EXPRESS);
        }

        public void Modificar()
        {
            CapaAccesoDatos.ZonaExpressDatos.Modificar(PK_ID_ZONA_EXPRESS,STR_Descripcion,Precio_Express);
        }


        public Double MontoXpress(int id)
        {
            ZonaExpress U = new ZonaExpress();
            DataSet ds = CapaAccesoDatos.ZonaExpressDatos.MontoEpxress(id);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                U.Precio_Express = int.Parse(row["Precio_Express"].ToString());
            }
            return U.Precio_Express;
        }

        public Double MontoXpressFactura(int id)
        {
            ZonaExpress U = new ZonaExpress();
            DataSet ds = CapaAccesoDatos.ZonaExpressDatos.MontoEpxressFactura(id);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                U.Precio_Express = int.Parse(row["Precio_Express"].ToString());
            }
            return U.Precio_Express;
        }
    }
}
