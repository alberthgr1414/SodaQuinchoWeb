using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
using System.Data;
using System.Text.RegularExpressions;

namespace CapaPresentacion
{
    public partial class MantenimientoUsuario : System.Web.UI.Page
    {


        //public int mensaje { get; set; }
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

            try
            {
            
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Refrescar();
                //mensaje = 0;
            }
            }
            catch { }


        }

        protected void chk_OnCheckedChanged(object sender, EventArgs e)
        {
            //// Recorrer las filas del GridView...
            //int i;
            //// Quita el mensaje de información si lo hubiera...
            //lblInfo.Text = "";
            //for (i = 0; i <= GridView_Clientes.Rows.Count - 1; i++)
            //{
            //    CheckBox CheckBoxElim = (CheckBox)GridView_Clientes.Rows(i).FindControl("chkEliminar");
            //    if (CheckBoxElim.Checked)
            //    {
            //        totalItemSeleccionados += 1;
            //        return;
            //    }
            //}
        }

        private void Refrescar()
        {
            try
            {
           
            // Cargar el Combo de Tipo Usuario
            TipoUsuario TipoUsuario = new TipoUsuario();
            ddlTipoUsuario.DataSource = TipoUsuario.ObtenerTodos();
            ddlTipoUsuario.DataTextField = "STR_DESCRIPCION";
            ddlTipoUsuario.DataValueField = "PK_ID_TipoUsuario";
            ddlTipoUsuario.DataBind();

            Estado estado = new Estado();
            ddlEstado.DataSource = estado.ObtenerTodos();
            ddlEstado.DataTextField = "STR_DESCRIPCION";
            ddlEstado.DataValueField = "ID_ESTADO";
            ddlEstado.DataBind();

            Usuario p = new Usuario();
            GridUsuario.DataSource = p.Obtener();
            GridUsuario.DataBind();
            }
            catch { }
        }

        private void Limpiar()
        {
            txtNombre.Text = "";
            ddlTipoUsuario.SelectedIndex = 1;
            txtUsuarioLogin.Text = "";
            txtClave.Text = "";
            ddlEstado.SelectedIndex = 1;
        }



        protected void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica si usuario existe
                List<Usuario> LISTA_USUARIO = new List<Usuario>();
                Usuario Usuario = new Usuario();
                LISTA_USUARIO = Usuario.VerificaUsuario(txtUsuarioLogin.Text);

                if (LISTA_USUARIO.Count != 0)
                {
                    lblMensaje.Text = "Usuario ya Existe";
                    txtNombre.Focus();
                }
                else
                {
                    Usuario user = new Usuario();
                    user.FK_ID_TIPO_USUARIO = int.Parse(ddlTipoUsuario.SelectedValue);
                    user.STR_NOMBRE = txtNombre.Text;
                    user.STR_USUARIO_LOGIN = txtUsuarioLogin.Text;
                    user.STR_CONTRASENA = txtClave.Text;
                    user.Nuevo();
                    Refrescar();
                    Limpiar();
                    //mensaje = 1;
                    lblMensaje.Text = "Usuario Guardado";
                }

            }
            catch 
            {
                lblMensaje.Text = "Usuario ya Existe";
            }
        }

        protected void GridUsuario_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
            
            GridUsuario.EditIndex = -1;

            Refrescar();
            }
            catch { }
        }

        protected void GridUsuario_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
            
            GridUsuario.EditIndex = e.NewEditIndex;

            Refrescar();
            }
            catch { }

        }

        protected void GridUsuario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
            
            Usuario U = new Usuario();
            U.PK_ID_USUARIO = int.Parse(GridUsuario.DataKeys[e.RowIndex].Value.ToString());
            U.Eliminar();
            GridUsuario.EditIndex = -1;
            Refrescar();
            }
            catch { }
        }

        public bool validarTexto(string password )
{

                const int MIN_LENGTH = 8;
                const int MAX_LENGTH = 15;

                if (password == null) throw new ArgumentNullException();

                bool meetsLengthRequirements = password.Length >= MIN_LENGTH && password.Length <= MAX_LENGTH;
                bool hasUpperCaseLetter = false;
                bool hasLowerCaseLetter = false;
                bool hasDecimalDigit = false;

                if (meetsLengthRequirements)
                {
                    foreach (char c in password)
                    {
                        if (char.IsUpper(c)) hasUpperCaseLetter = true;
                        else if (char.IsLower(c)) hasLowerCaseLetter = true;
                        else if (char.IsDigit(c)) hasDecimalDigit = true;
                    }
                }

                bool isValid = meetsLengthRequirements
                            && hasUpperCaseLetter
                            && hasLowerCaseLetter
                            && hasDecimalDigit
                            ;
                return isValid;

            }




        protected void GridUsuario_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Se lanza cuando se hace clic en Actualizar
            try
            {

                Usuario p = new Usuario();
                p.PK_ID_USUARIO = int.Parse(GridUsuario.DataKeys[e.RowIndex].Values[0].ToString());
                p.STR_NOMBRE = ((TextBox)GridUsuario.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
                p.STR_USUARIO_LOGIN = ((TextBox)GridUsuario.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
                p.STR_CONTRASENA = ((TextBox)GridUsuario.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
                p.FK_ID_TIPO_USUARIO = int.Parse(Convert.ToString(((DropDownList)GridUsuario.Rows[e.RowIndex].FindControl("ddlTipoUsuario")).SelectedValue));
                p.ID_ESTADO = int.Parse(Convert.ToString(((DropDownList)GridUsuario.Rows[e.RowIndex].FindControl("ddlEstadoDg")).SelectedValue));

                if (validarTexto(p.STR_CONTRASENA) == true)
                {
                    if (p.PK_ID_USUARIO == 0 || p.STR_NOMBRE == "" || p.STR_USUARIO_LOGIN == "" || p.STR_CONTRASENA == "" || p.ID_ESTADO == 0 || p.FK_ID_TIPO_USUARIO == 0)
                    {

                        Response.Write("<script>window.alert('Debe Rellenar los campos correctamente');</script>");
                    }
                    else
                    {
                        p.Modificar();
                        GridUsuario.EditIndex = -1;
                        Refrescar();
                    }
                    
                }
                else
                {
                    Response.Write("<script>window.alert('Contraseña Incorrecta La contraseña debe de llevar por lo menos 1 mayuscula,una minuscula y un Numero');</script>");
                }


            }
            catch
            {
                

            }

        }

        protected void GridUsuario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
            
            //Evento que se encarga de cargar la información correspondiente en
            //el dropdownlist cuando se selecciona editar
            DropDownList lblTipoUsuario2 = (e.Row.FindControl("ddlTipoUsuario") as DropDownList);
            TipoUsuario tipo = new TipoUsuario();
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {

                lblTipoUsuario2.DataSource = tipo.ObtenerTodos();
                lblTipoUsuario2.DataTextField = "STR_DESCRIPCION";
                lblTipoUsuario2.DataValueField = "PK_ID_TipoUsuario";
                lblTipoUsuario2.DataBind();
                //Seleccionar la categoría ya registrada
                DataRowView dr = e.Row.DataItem as DataRowView;
                string codCategoria = (DataBinder.Eval(e.Row.DataItem, "FK_ID_TIPO_USUARIO")).ToString();
                lblTipoUsuario2.SelectedValue = codCategoria;
            }

            DropDownList lblEstadoDg = (e.Row.FindControl("ddlEstadoDg") as DropDownList);
            Estado Estado = new Estado();
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {

                lblEstadoDg.DataSource = Estado.ObtenerTodos();
                lblEstadoDg.DataTextField = "STR_DESCRIPCION";
                lblEstadoDg.DataValueField = "ID_ESTADO";
                lblEstadoDg.DataBind();
                //Seleccionar la categoría ya registrada
                DataRowView dr = e.Row.DataItem as DataRowView;
                string codCategoria = (DataBinder.Eval(e.Row.DataItem, "Estado")).ToString();
                lblEstadoDg.SelectedValue = codCategoria;
            }
            }
            catch { }

        }

        protected void ddlTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void GridUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
            
            GridUsuario.PageIndex = e.NewPageIndex;
            Usuario p = new Usuario();
            GridUsuario.DataSource = p.Obtener();
            GridUsuario.DataBind();
            }
            catch { }
        }

        protected void GridUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}