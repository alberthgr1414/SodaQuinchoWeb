using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class AperturaTurnoCol : System.Web.UI.Page
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
                CapaLogicaNegocio.Turno p = new CapaLogicaNegocio.Turno();
                GridTurno.DataSource = p.ObtenerTodos();
                GridTurno.DataBind();
            }
            catch
            {

            }
        }

        protected void GridTurno_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GridTurno_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridTurno_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                CapaLogicaNegocio.Turno p = new CapaLogicaNegocio.Turno();
                List<CapaLogicaNegocio.Turno> LISTA_TURNO = new List<CapaLogicaNegocio.Turno>();
                p.PK_ID_TURNO = int.Parse(GridTurno.DataKeys[e.RowIndex].Values[0].ToString());
                p.CerrarTurno(p.PK_ID_TURNO);
                Refrescar();
            }
            catch
            {

            }

        }

        protected void GridTurno_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridTurno_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridTurno_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnAbrirTurno_Click(object sender, EventArgs e)
        {
            try
            {
                CapaLogicaNegocio.Turno p = new CapaLogicaNegocio.Turno();
                List<CapaLogicaNegocio.Turno> LISTA_TURNO = new List<CapaLogicaNegocio.Turno>();
                LISTA_TURNO = p.ObtenerTodos();


                if (LISTA_TURNO.Count > 0)
                {
                    //Response.Write("<script>alert('Existe un Turno Abierto Favor validar');</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalTurno').modal('show')", true);
                }
                else
                {
                    int PK_ID_USUARIO = int.Parse(Session["PK_ID_USUARIO"].ToString());
                    int monto = int.Parse(txtMonto.Text);
                    p.AbrirTurno(PK_ID_USUARIO, monto);
                    //lblMensaje.Text = "Turno Abierto";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalTurnoAbierto').modal('show')", true);
                }
                Refrescar();
            }
            catch
            {
            }
        }
    }
}