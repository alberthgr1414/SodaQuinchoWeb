using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario us = new Usuario();
            List<Usuario> lista = new List<Usuario>();
            string usuario = txtUsuario.Text;
            string pass = txtContrasenna.Text;
            lista = us.Login(usuario, pass);

            int var0 = 0;
            int var1 = 0;
            string var2 = "";

            foreach (Usuario item in lista)
            {
                var0 = item.PK_ID_USUARIO;
                var1 = item.FK_ID_TIPO_USUARIO;
                var2 = item.STR_NOMBRE;

            }
            if (lista.Count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalFacturado').modal('show')", true);
                //Response.Write("<script>window.alert('Usuario o/y Contraseña incorrectos');</script>");
            }
            else
            {
                if (var1 == 1)
                {
                    Session["PK_ID_USUARIO"] = var0;
                    Session["ingresar"] = var2;
                    Response.Redirect("InicioAdministrador.aspx");
                }
                else
                {
                    Session["PK_ID_USUARIO"] = var0;
                    Session["ingresar"] = var2;
                    Response.Redirect("InicioCol.aspx");
                }
            }
        }

        protected void Button39_Click(object sender, EventArgs e)
        {

        }
    }
}