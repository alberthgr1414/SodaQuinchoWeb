using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaAccesoDatos;
using System.Net.Mail;
using System.Net;

namespace CapaPresentacion
{
    public partial class Login2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
           
            Usuario us = new Usuario();
            List<Usuario> lista = new List<Usuario>();
            string usuario = txtUsuario.Text;
            string pass = txtPass.Text;
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
            catch { }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
            
            MailMessage msj = new MailMessage();

            SmtpClient cli = new SmtpClient();

            string email = "alberthgr1414@gmail.com";

            String Name = "Alberth";

            msj.From = new MailAddress("alberthgr1414@gmail.com");
            msj.To.Add(new MailAddress(email));
            msj.Subject = "Cambio de Contraseña";
            msj.Body = "Este es la contraseña nueva " + Name;
            msj.IsBodyHtml = false;

            cli.Host = "smpt.gamil.com";
            cli.Port = 465;
            cli.Credentials = new NetworkCredential("alberthgr1414@gmail.com", "ajgr1095");
            cli.EnableSsl = true;
            cli.Send(msj);
            }
            catch { }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
            
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalOlvido').modal('show')", true);
            }
            catch { }
        }
    }
}