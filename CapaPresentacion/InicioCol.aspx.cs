using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class InicioCol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Variable de Session
            try
            {
                String nombre = Session["ingresar"].ToString();
            }
            catch 
            {
                Response.Redirect("Login2.aspx");
            }
        }
    }
}