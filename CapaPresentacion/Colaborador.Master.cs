using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class Colaborador : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String nombre = Session["ingresar"].ToString();
            }
            catch 
            {
                Response.Redirect("Login2.aspx");
            }
            if (!Page.IsPostBack)
            {
                
            }
        }

        protected void linkGoSomewhere_Click(object sender, EventArgs e)
        {
            try
            {
                //  cerrar session 
                Session.Remove("login");
                Response.Redirect("Login2.aspx");
            }
            catch 
            {
                
            }
        } 
    }
}