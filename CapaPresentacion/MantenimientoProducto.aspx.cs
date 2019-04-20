using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
using System.Data;

namespace CapaPresentacion
{
    public partial class MantenimientoProducto : System.Web.UI.Page
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

            if (!Page.IsPostBack)
            {
                Refrescar();
            }
        }

        private void Refrescar()
        {
            try
            {
           
            // Cargar el Combo de Tipo Plato
            TipoPlato TipoPlato = new TipoPlato();
            ddlTipoPlato.DataSource = TipoPlato.ObtenerTodos();
            ddlTipoPlato.DataTextField = "STR_Descripcion";
            ddlTipoPlato.DataValueField = "PK_ID_TipoPlato";
            ddlTipoPlato.DataBind();

            TipoPlato TipoPlato2 = new TipoPlato();
            ddltipousuariogrid.DataSource = TipoPlato2.ObtenerTodos();
            ddltipousuariogrid.DataTextField = "STR_Descripcion";
            ddltipousuariogrid.DataValueField = "PK_ID_TipoPlato";
            ddltipousuariogrid.DataBind();

            Estado estado = new Estado();
            ddlEstado.DataSource = estado.ObtenerTodos();
            ddlEstado.DataTextField = "STR_DESCRIPCION";
            ddlEstado.DataValueField = "ID_ESTADO";
            ddlEstado.DataBind();

            Plato p = new Plato();
            GridPlato.DataSource = p.ObtenerPorTipo(1);
            GridPlato.DataBind();
            }
            catch { }
        }


        private void Limpiar()
        {
            try
            {
            
            txtNombre.Text = "";
            ddlTipoPlato.SelectedIndex = 1;
            txtPrecio.Text = "";
            ddlEstado.SelectedIndex = 1;
            FileUpload1.Dispose();
            }
            catch { }
        }


        protected void GridPlato_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
            
            GridPlato.EditIndex = -1;

            Refrescar();
            }
            catch { }
        }

        protected void GridPlato_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
            
            GridPlato.EditIndex = e.NewEditIndex;
            Plato plato = new Plato();
            //plato.STR_Nombre_Plato = ((TextBox)GridPlato.Rows[ex.RowIndex].Cells[3].Controls[0]).Text;
            //FileUpload2.
            Refrescar();
            }
            catch { }
        }

        protected void GridPlato_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
           
            Plato U = new Plato();
            U.PK_ID_PLATO = int.Parse(GridPlato.DataKeys[e.RowIndex].Value.ToString());
            U.Eliminar();
            GridPlato.EditIndex = -1;
            Refrescar();
            }
            catch { }
        }

        protected void GridPlato_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
           
            Plato plato = new Plato();
            plato.PK_ID_PLATO = int.Parse(GridPlato.DataKeys[e.RowIndex].Values[0].ToString());
            plato.STR_Nombre_Plato = ((TextBox)GridPlato.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            plato.Precio_Plato = double.Parse(((TextBox)GridPlato.Rows[e.RowIndex].Cells[3].Controls[0]).Text);
            plato.FK_ID_TipoPlato = int.Parse(Convert.ToString(((DropDownList)GridPlato.Rows[e.RowIndex].FindControl("ddlTipoPlato")).SelectedValue));
            plato.ID_ESTADO = int.Parse(Convert.ToString(((DropDownList)GridPlato.Rows[e.RowIndex].FindControl("ddlEstadoDg")).SelectedValue));
            plato.Modificar();
            GridPlato.EditIndex = -1;
            Refrescar();
            }
            catch { }
        }

        protected void GridPlato_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
           
            //Evento que se encarga de cargar la información correspondiente en
            //el dropdownlist cuando se selecciona editar
            DropDownList lblTipoUsuario1 = (e.Row.FindControl("ddlTipoPlato") as DropDownList);
            TipoPlato tipo = new TipoPlato();
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {

                lblTipoUsuario1.DataSource = tipo.ObtenerTodos();
                lblTipoUsuario1.DataTextField = "STR_DESCRIPCION";
                lblTipoUsuario1.DataValueField = "PK_ID_TipoPlato";
                lblTipoUsuario1.DataBind();
                //Seleccionar la categoría ya registrada
                DataRowView dr = e.Row.DataItem as DataRowView;
                string codCategoria = (DataBinder.Eval(e.Row.DataItem, "TipoPlato")).ToString();
                lblTipoUsuario1.SelectedValue = codCategoria;
            }

            DropDownList lblEstadoDg1 = (e.Row.FindControl("ddlEstadoDg") as DropDownList);
            Estado Estado = new Estado();
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {

                lblEstadoDg1.DataSource = Estado.ObtenerTodos();
                lblEstadoDg1.DataTextField = "STR_DESCRIPCION";
                lblEstadoDg1.DataValueField = "ID_ESTADO";
                lblEstadoDg1.DataBind();
                //Seleccionar la categoría ya registrada
                DataRowView dr = e.Row.DataItem as DataRowView;
                string codCategoria = (DataBinder.Eval(e.Row.DataItem, "Estado")).ToString();
                lblEstadoDg1.SelectedValue = codCategoria;
            }
            }
            catch { }
        }

        protected void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = "";
                string nombreArchivo = "";

                if (FileUpload1.HasFile)
                {
                    //si hay una archivo.
                    nombreArchivo = FileUpload1.FileName;
                    ruta = "~/imagen/" + nombreArchivo;
                    FileUpload1.SaveAs(Server.MapPath(ruta));
                }
                else
                {
                    ruta = "~/imagen/" + "plato.png";
                }

                Plato user = new Plato();
                user.FK_ID_TipoPlato = int.Parse(ddlTipoPlato.SelectedValue);
                user.STR_Nombre_Plato = txtNombre.Text;
                user.Precio_Plato = double.Parse(txtPrecio.Text);
                user.ID_ESTADO = int.Parse(ddlEstado.SelectedValue);
                user.foto = ruta;
                user.Nuevo();
                Refrescar();
                Limpiar();
                lblMensaje.Text = "Plato Guardado";
            }
            catch
            {
                lblMensaje.Text = "Plato ya Existe";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
            Limpiar();
            }
            catch { }
        }

        protected void ddltipousuariogrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            Plato p = new Plato();
            GridPlato.DataSource = p.ObtenerPorTipo(int.Parse(ddltipousuariogrid.SelectedValue.ToString()));
            GridPlato.DataBind();
            }
            catch { }
        }

        protected void GridPlato_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
            GridPlato.PageIndex = e.NewPageIndex;
            Plato p = new Plato();
            GridPlato.DataSource = p.ObtenerPorTipo(int.Parse(ddltipousuariogrid.SelectedValue.ToString()));
            GridPlato.DataBind();
            }
            catch { }

        }
    }
}