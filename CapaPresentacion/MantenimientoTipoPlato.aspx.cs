using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    public partial class MantenimientoTipoPlato : System.Web.UI.Page
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

        private void Limpiar()
        {
            txtNombre.Text = "";
        }

        private void Refrescar()
        {
            TipoPlato p = new TipoPlato();
            GridTipoUsuario.DataSource = p.ObtenerTodos();
            GridTipoUsuario.DataBind();
        }

        protected void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                    TipoPlato user = new TipoPlato();
                    user.STR_Descripcion = txtNombre.Text;
                    user.Nuevo();
                    Refrescar();
                    Limpiar();
                    lblMensaje.Text = "Usuario Guardado";

            }
            catch (Exception ex)
            {

                lblMensaje.Text = "Algo Ocurrio" + ex;
            }
        }

        protected void GridTipoPlato_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridTipoUsuario.EditIndex = -1;

            Refrescar();
        }

        protected void GridTipoPlato_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridTipoUsuario.EditIndex = e.NewEditIndex;

            Refrescar();
        }

        protected void GridTipoPlato_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TipoPlato U = new TipoPlato();
            U.PK_ID_TipoPlato = int.Parse(GridTipoUsuario.DataKeys[e.RowIndex].Value.ToString());
            U.Eliminar();
            GridTipoUsuario.EditIndex = -1;
            Refrescar();
        }

        protected void GridTipoPlato_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Se lanza cuando se hace clic en Actualizar
            try
            {
                TipoPlato p = new TipoPlato();
                p.PK_ID_TipoPlato = int.Parse(GridTipoUsuario.DataKeys[e.RowIndex].Values[0].ToString());
                p.STR_Descripcion = ((TextBox)GridTipoUsuario.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
                p.Modificar();
                GridTipoUsuario.EditIndex = -1;
                Refrescar();
            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }

        protected void GridTipoPlato_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void GridTipoUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridTipoUsuario.PageIndex = e.NewPageIndex;
            TipoPlato p = new TipoPlato();
            GridTipoUsuario.DataSource = p.ObtenerTodos();
            GridTipoUsuario.DataBind();
        }
    }
}