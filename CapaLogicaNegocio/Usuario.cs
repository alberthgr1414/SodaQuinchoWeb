using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using System.Data;

namespace CapaLogicaNegocio
{
    public class Usuario
    {
        // Variables del usuario
        public int PK_ID_USUARIO { get; set; }
        public int FK_ID_TIPO_USUARIO { get; set; }
        public string STR_NOMBRE { get; set; }
        public string STR_USUARIO_LOGIN { get; set; }
        public string STR_CONTRASENA { get; set; }
        public string TIPO_USUARIO_DESCRIPCION { get; set; }
        public string ESTADO { get; set; }
        public int ID_ESTADO { get; set; }

        public void Nuevo()
        {
            try
            {
                CapaAccesoDatos.UsuarioDatos.Insertar(FK_ID_TIPO_USUARIO, STR_NOMBRE, STR_USUARIO_LOGIN, STR_CONTRASENA);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Usuario> Obtener()
        {
            List<Usuario> LISTA_USUARIOS = new List<Usuario>();
            DataSet ds = CapaAccesoDatos.UsuarioDatos.SeleccionarTodos();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Usuario U = new Usuario();
                U.PK_ID_USUARIO = int.Parse(row["PK_ID_USUARIO"].ToString());
                U.FK_ID_TIPO_USUARIO = int.Parse(row["FK_ID_TIPO_USUARIO"].ToString());
                U.STR_NOMBRE = row["STR_NOMBRE"].ToString();
                U.STR_USUARIO_LOGIN = row["STR_USUARIO_LOGIN"].ToString();
                U.STR_CONTRASENA = Encriptar.DesEncriptar_pass(row["STR_CONTRASENA"].ToString());
                U.TIPO_USUARIO_DESCRIPCION = row["STR_DESCRIPCION"].ToString();
                U.ESTADO = row["Estado"].ToString();
                LISTA_USUARIOS.Add(U);
            }
            return LISTA_USUARIOS;
        }

        public void Eliminar()
        {
            UsuarioDatos.Eliminar(PK_ID_USUARIO);
        }


        public void Modificar()
        {
            CapaAccesoDatos.UsuarioDatos.Modificar(PK_ID_USUARIO, FK_ID_TIPO_USUARIO, STR_NOMBRE,
    STR_USUARIO_LOGIN, STR_CONTRASENA, ID_ESTADO);
        }


        public List<Usuario> Login(string usuario, string contrasenna)
        {
            List<Usuario> LISTA_USUARIOS = new List<Usuario>();
            DataSet ds = CapaAccesoDatos.UsuarioDatos.UsuarioLogin(usuario, contrasenna);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Usuario p = new Usuario();
                p.PK_ID_USUARIO = int.Parse(row["PK_ID_USUARIO"].ToString());
                p.FK_ID_TIPO_USUARIO = int.Parse(row["FK_ID_TIPO_USUARIO"].ToString());
                p.STR_NOMBRE = row["STR_NOMBRE"].ToString();
                LISTA_USUARIOS.Add(p);

            }

            return LISTA_USUARIOS;
        }


        public List<Usuario> VerificaUsuario(string usuario)
        {
            List<Usuario> LISTA_USUARIOS = new List<Usuario>();
            DataSet ds = CapaAccesoDatos.UsuarioDatos.UsuarioVerifica(usuario);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Usuario p = new Usuario();
                p.STR_NOMBRE = row["STR_NOMBRE"].ToString();
                LISTA_USUARIOS.Add(p);

            }
            return LISTA_USUARIOS;
        }



    }
}
