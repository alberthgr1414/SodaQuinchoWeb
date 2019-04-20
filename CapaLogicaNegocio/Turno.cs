using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class Turno
    {
        public int PK_ID_TURNO { get; set; }
        public int FK_ID_USUARIO { get; set; }
        public string FECHA_APERTURA { get; set; }
        public string FECHA_CIERRE { get; set; }
        public double FONDO { get; set; }
        public Boolean ESTADO { get; set; }
        public int cierre { get; set; }
        public int Total { get; set; }




        public void AbrirTurno(int FK_ID_USUARIO,int FONDO)
        {
            try
            {
                CapaAccesoDatos.TurnoDatos.AbrirTurno(FK_ID_USUARIO, FONDO);

            }
            catch (Exception)
            {

                throw;
            }

        }
        public void CerrarTurno(int PK_ID_TURNO)
        {
            try
            {
                CapaAccesoDatos.TurnoDatos.CerrarTurno(PK_ID_TURNO);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Turno> VerificaTurno(int FK_ID_USUARIO, int estado)
        {
            List<Turno> LISTA_TURNO = new List<Turno>();
            DataSet ds = CapaAccesoDatos.TurnoDatos.VerificaTurno(FK_ID_USUARIO, estado);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Turno p = new Turno();
                p.PK_ID_TURNO = int.Parse(row["PK_ID_TURNO"].ToString());
                p.FK_ID_USUARIO = int.Parse(row["FK_ID_USUARIO"].ToString());
                p.FECHA_APERTURA =  row["FECHA_APERTURA"].ToString();
                p.FECHA_CIERRE =row["FECHA_CIERRE"].ToString();
                p.ESTADO = bool.Parse(row["ESTADO"].ToString());
                LISTA_TURNO.Add(p);
            }
            return LISTA_TURNO;
        }

        public List<Turno> ObtenerTodos()
        {
            List<Turno> LISTA_USUARIOS = new List<Turno>();
            DataSet ds = CapaAccesoDatos.TurnoDatos.SeleccionarTodos();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Turno U = new Turno();
                U.PK_ID_TURNO = int.Parse(row["PK_ID_TURNO"].ToString());
                U.FK_ID_USUARIO = int.Parse(row["FK_ID_USUARIO"].ToString());
                U.FECHA_APERTURA = row["FECHA_APERTURA"].ToString();
                U.FECHA_CIERRE =row["FECHA_CIERRE"].ToString();
                U.FONDO = int.Parse(row["FONDO"].ToString());
                U.ESTADO = bool.Parse(row["ESTADO"].ToString());
                U.cierre = int.Parse(row["CIERRE"].ToString());
                U.Total = int.Parse(row["Total"].ToString());
                LISTA_USUARIOS.Add(U);
            }
            return LISTA_USUARIOS;
        }



        public int ObtenerActivo()
        {
            DataSet ds = CapaAccesoDatos.TurnoDatos.SeleccionarTodos();
            Turno U = new Turno();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                U.PK_ID_TURNO = int.Parse(row["PK_ID_TURNO"].ToString());
            }
            return U.PK_ID_TURNO;
        }

    }
    }
