using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class Express
    {

        public int PK_ID_EXPRESS { get; set; }
        public int FK_ID_ENC_FACTURA { get; set; }
        public int ESTADO { get; set; }
        public string Descripcion { get; set; }
        public int fk_zona_express { get; set; }
        public string fecha { get; set; }



        public void Nuevo(int FK_ID_ENC_FACTURA,string descripcion,int zona)
        {
            try
            {
                CapaAccesoDatos.ExpressDatos.Insertar(FK_ID_ENC_FACTURA, descripcion, zona);

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
