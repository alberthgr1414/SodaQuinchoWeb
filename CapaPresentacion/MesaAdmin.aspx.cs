using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio;
using CapaAccesoDatos;

namespace CapaPresentacion
{
    public partial class MesaAdmin : System.Web.UI.Page
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
                txtTotalFactura2.Text = "0";
                txtCambio.Text = "0";
            }
            
        }

        

        protected void Button3_Click(object sender, EventArgs e)
        {

        }
        protected void Button14_Click(object sender, EventArgs e)
        {
            try
            {
            
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalFacturar').modal('show')", true);
            Button btn = sender as Button;

            if (btn.Text == "Pago Completo")
            {
                txtEfectivo.Text = txtTotalFactura2.Text.ToString();
            }
            else
            {
                if (btn.Text == "CE")
                {
                    txtEfectivo.Text = "0";
                }
                else
                {
                    if (btn.Text == "<--")
                    {

                        String cadena = txtEfectivo.Text.ToString();
                        if (cadena.Length == 1)
                        {
                            cadena = cadena.Substring(0, cadena.Length - 1);
                            txtEfectivo.Text = cadena;
                            txtEfectivo.Text = "0";
                        }
                        else
                        {
                            cadena = cadena.Substring(0, cadena.Length - 1);
                            txtEfectivo.Text = cadena;
                        }
                    }
                    else
                    {
                        if (int.Parse(txtEfectivo.Text) == 0)
                        {
                            string valor = btn.Text;
                            txtEfectivo.Text = valor;
                        }
                        else
                        {
                            string valor = btn.Text;
                            txtEfectivo.Text = txtEfectivo.Text.ToString() + valor;
                        }
                    }
                }
            }
        
                txtCambio.Text = (int.Parse(txtEfectivo.Text) - int.Parse(txtTotalFactura2.Text)).ToString();
      

            if (int.Parse(txtCambio.Text) > 0)
            {
            }
            else
            {
                txtCambio.Text = "0";
            }
            }
            catch { }
        }


        protected void dtlProducto_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
            
            if (e.CommandName.ToString() == "3")
            {
                int pk = int.Parse(e.CommandArgument.ToString());
                DetFactura pa = new DetFactura();
                Gridfacturar.DataSource = pa.ObtenerPorID(pk);
                Gridfacturar.DataBind();

                Enc_Factura en = new Enc_Factura();
                txtTotalFactura2.Text = en.ObtenerTotalPorID(pk).ToString();
                txtID.Text = pk.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalFacturar').modal('show')", true);
            }
            else {
                if (e.CommandName.ToString() == "2")
                {
                    int pk = int.Parse(e.CommandArgument.ToString());
                    DetFactura pa = new DetFactura();
                    GridOrden.DataSource = pa.ObtenerPorID(pk);
                    GridOrden.DataBind();

                    txtID.Text = pk.ToString();
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalOrden').modal('show')", true);
                }
                else
                {

                }
            }
            }
            catch { }


        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            try
            {
            
            if (int.Parse(txtEfectivo.Text.ToString()) >= int.Parse(txtTotalFactura2.Text.ToString()))
            {
               
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalFacturar').modal('hide');", true);

                    Enc_Factura ENC = new Enc_Factura();

                    ENC.CambioEstado(3, int.Parse(txtID.Text.ToString()));

                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalFacturado').modal('show')", true);
                    txtEfectivo.Text = "0";
                    txtCambio.Text = "0";
                    Mesa mes = new Mesa();
                    mes.MesaVaciar(int.Parse(txtID.Text.ToString()));
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalOrden').modal('show')", true);

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalFacturar').modal('show')", true);
            }
            }
            catch { }
        }

        protected void GridOrden_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnDelete_Click1(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
            
            int detalle = int.Parse(GridOrden.DataKeys[e.RowIndex].Value.ToString());

            DetFactura det = new DetFactura();
            det.CambioEstadoDet(detalle, 2);

            int id = int.Parse(txtID.Text.ToString());

            DetFactura pa = new DetFactura();
            GridOrden.DataSource = pa.ObtenerPorID(id);
            GridOrden.DataBind();
            }
            catch { }
        }

        protected void Button4_Click1(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridOrden_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
            
            int detalle = int.Parse(GridOrden.DataKeys[e.RowIndex].Value.ToString());

            DetFactura det = new DetFactura();
            det.CambioEstadoDet(detalle, 1);

            int id = int.Parse(txtID.Text.ToString());

            DetFactura pa = new DetFactura();
            GridOrden.DataSource = pa.ObtenerPorID(id);
            GridOrden.DataBind();
            }
            catch { }
        }

        protected void Button3_Command(object sender, CommandEventArgs e)
        {
            try
            {
            
            CapaLogicaNegocio.Enc_Factura c = new CapaLogicaNegocio.Enc_Factura();
            List<CapaLogicaNegocio.Enc_Factura> LISTA_ENC = new List<CapaLogicaNegocio.Enc_Factura>();
            LISTA_ENC = c.Obtener();

            if (LISTA_ENC.Count > 0)
            {
                //Response.Write("<script>alert('No se pueden agregar Producto si una factura se encuentra en proceso de facturacion');</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalFacturaProceso').modal('show')", true);
            }
            else
            {
                CapaLogicaNegocio.Enc_Factura en = new CapaLogicaNegocio.Enc_Factura();
                int pk = int.Parse(e.CommandArgument.ToString());

                en.CambioEstado(1, pk);
                Response.Redirect("FacturacionAdmin.aspx");
            }
            }
            catch { }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("FacturacionAdmin.aspx");
        }
        protected void Button39_Click(object sender, EventArgs e)
        {
            Response.Redirect("MesaAdmin.aspx");
        }
    }
}