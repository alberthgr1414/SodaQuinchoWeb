using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class Plato
    {
        public int PK_ID_PLATO { get; set; }
        public int FK_ID_TipoPlato { get; set; }
        public string TipoPlato { get; set; }
        public string STR_Nombre_Plato { get; set; }
        public double Precio_Plato { get; set; }
        public string foto { get; set; }
        public string ESTADO { get; set; }
        public int ID_ESTADO { get; set; }




        public List<Plato> Obtener()
        {
            List<Plato> LISTA_USUARIOS = new List<Plato>();
            DataSet ds = CapaAccesoDatos.PlatoDatos.SeleccionarTodos();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Plato U = new Plato();
                U.PK_ID_PLATO = int.Parse(row["PK_ID_PLATO"].ToString());
                U.TipoPlato = row["STR_Descripcion"].ToString();
                U.STR_Nombre_Plato = row["STR_Nombre_Plato"].ToString();
                U.Precio_Plato = double.Parse( row["Precio_Plato"].ToString());
                U.foto = row["foto"].ToString();
                U.ESTADO =row["STR_DESCRIPCION_ESTADO"].ToString();
                LISTA_USUARIOS.Add(U);
            }
            return LISTA_USUARIOS;
        }

        public List<Plato> ObtenerPorTipo(int tipo)
        {
            List<Plato> LISTA_USUARIOS = new List<Plato>();
            DataSet ds = CapaAccesoDatos.PlatoDatos.SeleccionarTodosPorTipo(tipo);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Plato U = new Plato();
                U.PK_ID_PLATO = int.Parse(row["PK_ID_PLATO"].ToString());
                U.TipoPlato = row["STR_Descripcion"].ToString();
                U.STR_Nombre_Plato = row["STR_Nombre_Plato"].ToString();
                U.Precio_Plato = double.Parse(row["Precio_Plato"].ToString());
                U.foto = row["foto"].ToString();
                U.ESTADO = row["STR_DESCRIPCION_ESTADO"].ToString();
                LISTA_USUARIOS.Add(U);
            }
            return LISTA_USUARIOS;
        }

        public void Nuevo()
        {
            try
            {
                CapaAccesoDatos.PlatoDatos.Insertar(FK_ID_TipoPlato, STR_Nombre_Plato, Precio_Plato, ID_ESTADO,foto);

            }
            catch (Exception)
            {

                throw;
            }

        }


        public void Eliminar()
        {
            PlatoDatos.Eliminar(PK_ID_PLATO);
        }



        public void Modificar()
        {
            CapaAccesoDatos.PlatoDatos.Modificar(PK_ID_PLATO, FK_ID_TipoPlato, STR_Nombre_Plato,ID_ESTADO, Precio_Plato);
        }


        public List<Plato> ObtenerPorTipo()
        {
            List<Plato> LISTA_USUARIOS = new List<Plato>();
            DataSet ds = CapaAccesoDatos.PlatoDatos.SeleccionarTodos();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Plato U = new Plato();
                U.PK_ID_PLATO = int.Parse(row["PK_ID_PLATO"].ToString());
                U.STR_Nombre_Plato = row["STR_Nombre_Plato"].ToString();
                U.foto = row["foto"].ToString();
                LISTA_USUARIOS.Add(U);
            }
            return LISTA_USUARIOS;
        }

    }
}
