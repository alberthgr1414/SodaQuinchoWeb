﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class Administrador : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void linkGoSomewhere_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Remove("login");
                Response.Redirect("Login2.aspx");
            }
            catch
            {
                
            }
        }
    }
}