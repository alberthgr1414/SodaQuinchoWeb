using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    public partial class MantenimientoExpress : System.Web.UI.Page
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

            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Refrescar();
            }

        }

        private void Refrescar()
        {
            try
            {
            ZonaExpress p = new ZonaExpress();
            GridZonaExpress.DataSource = p.Obtener();
            GridZonaExpress.DataBind();
            }
            catch { }
        }

        private void Limpiar()
        {
            txtNombre.Text = "";
            txtPrecio.Text = "";
        }

        protected void GridZonaExpress_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
            
            GridZonaExpress.EditIndex = -1;

            Refrescar();
            }
            catch { }
        }

        protected void GridZonaExpress_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
            
            GridZonaExpress.EditIndex = e.NewEditIndex;

            Refrescar();
            }
            catch { }
        }

        protected void GridZonaExpress_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
            
            ZonaExpress U = new ZonaExpress();
            U.PK_ID_ZONA_EXPRESS = int.Parse(GridZonaExpress.DataKeys[e.RowIndex].Value.ToString());
            U.Eliminar();
            GridZonaExpress.EditIndex = -1;
            Refrescar();
            }
            catch { }

        }

        protected void GridZonaExpress_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {

                ZonaExpress p = new ZonaExpress();
                p.PK_ID_ZONA_EXPRESS = int.Parse(GridZonaExpress.DataKeys[e.RowIndex].Values[0].ToString());
                p.STR_Descripcion = ((TextBox)GridZonaExpress.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
                p.Precio_Express = double.Parse(((TextBox)GridZonaExpress.Rows[e.RowIndex].Cells[3].Controls[0]).Text);

                p.Modificar();
                GridZonaExpress.EditIndex = -1;
                Refrescar();   
            }
            catch 
            {
                

            }
        }

        protected void GridZonaExpress_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnGuardarUsuario_Click(object sender, EventArgs e)
        {

            try
            {
                    ZonaExpress user = new ZonaExpress();
                    user.Precio_Express = double.Parse(txtPrecio.Text);
                    user.STR_Descripcion = txtNombre.Text;
                    user.Nuevo();
                    Refrescar();
                    Limpiar();
                    lblMensaje.Text = "Usuario Guardado";

            }
            catch 
            {

                
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GridZonaExpress_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
            
            GridZonaExpress.PageIndex = e.NewPageIndex;
            ZonaExpress p = new ZonaExpress();
            GridZonaExpress.DataSource = p.Obtener();
            GridZonaExpress.DataBind();
            }
            catch { }
        }
    }
}