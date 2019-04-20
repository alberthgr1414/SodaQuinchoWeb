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
    public partial class FacturacionCol : System.Web.UI.Page
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
                Refrescar();
            }
        }

        private void Refrescar()
        {
            try
            {
            
            btnfacturar.Visible = true;
            btnMesa.Visible = true;
            btnExpress.Visible = true;

            CapaLogicaNegocio.Enc_Factura enc = new CapaLogicaNegocio.Enc_Factura();
            int pk_id_enc_fact;
            pk_id_enc_fact = enc.ObtenerActivo();

            ZonaExpress ex = new ZonaExpress();
            List<Express> lstexpress = new List<Express>();
            lstexpress = ex.ObtenerExpress(pk_id_enc_fact);
            if (lstexpress.Count != 0)
            {
                btnfacturar.Visible = false;
                btnMesa.Visible = false;
                btnExpress.Visible = true;
            }

            Mesa nes = new Mesa();
            List<Mesa> mesa = new List<Mesa>();
            mesa = nes.MesaOcupada(pk_id_enc_fact);

            if (mesa.Count != 0)
            {
                btnfacturar.Visible = false;
                btnExpress.Visible = false;
                btnMesa.Visible = true;
            }

            ddlExpress.Items.Clear();

            ddlExpress.Items.Insert(0, new ListItem("<-- Seleccione un Lugar -->", ""));

            DetFactura p = new DetFactura();
            Gridfactura.DataSource = p.Obtener();
            Gridfactura.DataBind();

            DetFactura pA = new DetFactura();
            GridFactura2.DataSource = pA.Obtener();
            GridFactura2.DataBind();

            DetFactura pa = new DetFactura();
            Gridfacturar.DataSource = pa.Obtener();
            Gridfacturar.DataBind();

            Enc_Factura en = new Enc_Factura();
            txtTotalFactura.Text = en.ObtenerTotal().ToString();
            txtTotalFactura2.Text = en.ObtenerTotal().ToString();
            txtTotalFactura3.Text = en.ObtenerTotal().ToString();

            ZonaExpress zona = new ZonaExpress();
            ddlExpress.DataSource = zona.Obtener();
            ddlExpress.DataTextField = "STR_Descripcion";
            ddlExpress.DataValueField = "PK_ID_ZONA_EXPRESS";
            ddlExpress.DataBind();

            DetFactura g1 = new DetFactura();
            GridView1.DataSource = g1.Obtener();
            GridView1.DataBind();
            }
            catch { }
        }

        protected void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
           
            SqlDataSource1.SelectParameters["FK_ID_TipoPlato"].DefaultValue = "3";
            SqlDataSource1.DataBind();
            }
            catch { }
        }

        protected void btnGuardarUsuario2_Click(object sender, EventArgs e)
        {
            //<Con este condigo se puede definir el SP a Ejecutar
            //SqlDataSource1.SelectCommand = "PA_CON_PLATO_POR_TIPO";
            try
            {
            
            SqlDataSource1.SelectParameters["FK_ID_TipoPlato"].DefaultValue = "2";
            SqlDataSource1.DataBind();
            }
            catch { }

        }

        protected void dtlProducto_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
            
            CapaLogicaNegocio.Turno p = new CapaLogicaNegocio.Turno();
            List<CapaLogicaNegocio.Turno> LISTA_TURNO = new List<CapaLogicaNegocio.Turno>();
            LISTA_TURNO = p.ObtenerTodos();
            if (LISTA_TURNO.Count > 0)
            {
                CapaLogicaNegocio.Enc_Factura c = new CapaLogicaNegocio.Enc_Factura();
                List<CapaLogicaNegocio.Enc_Factura> LISTA_ENC = new List<CapaLogicaNegocio.Enc_Factura>();
                LISTA_ENC = c.Obtener();

                if (LISTA_ENC.Count > 0)
                {
                    CapaLogicaNegocio.Enc_Factura en = new CapaLogicaNegocio.Enc_Factura();
                    int pk_id_enc_fact;
                    pk_id_enc_fact = en.ObtenerActivo();

                    CapaLogicaNegocio.DetFactura det = new CapaLogicaNegocio.DetFactura();
                    det.Nuevo(pk_id_enc_fact, int.Parse(e.CommandArgument.ToString()), int.Parse(txtCantidad.Text));
                    txtCantidad.Text = "0";
                }
                else
                {
                    CapaLogicaNegocio.Enc_Factura tc = new CapaLogicaNegocio.Enc_Factura();
                    int pk_id_turno;
                    pk_id_turno = p.ObtenerActivo();
                    tc.Nuevo(pk_id_turno);

                    CapaLogicaNegocio.Enc_Factura en = new CapaLogicaNegocio.Enc_Factura();
                    int pk_id_enc_fact;
                    pk_id_enc_fact = en.ObtenerActivo();

                    CapaLogicaNegocio.DetFactura det = new CapaLogicaNegocio.DetFactura();
                    det.Nuevo(pk_id_enc_fact, int.Parse(e.CommandArgument.ToString()), int.Parse(txtCantidad.Text));
                    txtCantidad.Text = "0";

                }
            }
            else
            {
                Response.Write("<script>alert('Para poder facturar debe de haber un turno abierto');</script>");
            }
            Refrescar();
            }
            catch { }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
            
            if (e.CommandName == "btnTipoPlato")
            {
                // btnGuardarUsuario2.Text = e.CommandArgument.ToString();

                SqlDataSource1.SelectParameters["FK_ID_TipoPlato"].DefaultValue = e.CommandArgument.ToString();
                SqlDataSource1.DataBind();
            }
            }
            catch { }
        }

        protected void Gridfactura_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
            
            DetFactura U = new DetFactura();
            U.PK_ID_DetFactura = int.Parse(Gridfactura.DataKeys[e.RowIndex].Value.ToString());
            U.Eliminar();
            Gridfactura.EditIndex = -1;
            Refrescar();
            }
            catch { }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
            
            Button btn = sender as Button;
            string valor = btn.Text;
            int valoractual = int.Parse(txtCantidad.Text);


            if (valoractual == 1)
            {
                txtCantidad.Text = txtCantidad.Text + valor;
            }
            else
            {
                if (int.Parse(valor) == 0)
                {
                    txtCantidad.Text = "0";
                }
                else
                {
                    txtCantidad.Text = valor;
                }
            }
            }
            catch { }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
            
            CapaLogicaNegocio.Turno p = new CapaLogicaNegocio.Turno();
            List<CapaLogicaNegocio.Turno> LISTA_TURNO = new List<CapaLogicaNegocio.Turno>();
            LISTA_TURNO = p.ObtenerTodos();
            if (LISTA_TURNO.Count > 0)
            {
                CapaLogicaNegocio.Enc_Factura c = new CapaLogicaNegocio.Enc_Factura();
                List<CapaLogicaNegocio.Enc_Factura> LISTA_ENC = new List<CapaLogicaNegocio.Enc_Factura>();
                LISTA_ENC = c.Obtener();

                if (LISTA_ENC.Count > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalFacturar').modal('show')", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalNoProductos').modal('show')", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalNoProductos').modal('show')", true);
            }
            }
            catch { }
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            try
            {
            
            CapaLogicaNegocio.Enc_Factura enc = new CapaLogicaNegocio.Enc_Factura();
            int pk_id_enc_fact;
            pk_id_enc_fact = enc.ObtenerActivo();

            ZonaExpress ex = new ZonaExpress();
            List<Express> lstexpress = new List<Express>();
            lstexpress = ex.ObtenerExpress(pk_id_enc_fact);
            if (lstexpress.Count != 0)
            {

                Enc_Factura ENC = new Enc_Factura();

                int activo = ENC.ObtenerActivo();

                ENC.CambioTipo(activo, 3);

                ENC.CambioEstado(5, activo);

                Refrescar();

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalExpressEnviado').modal('show')", true);
            }
            else
            {
                CapaLogicaNegocio.Turno p = new CapaLogicaNegocio.Turno();
                List<CapaLogicaNegocio.Turno> LISTA_TURNO = new List<CapaLogicaNegocio.Turno>();
                LISTA_TURNO = p.ObtenerTodos();
                if (LISTA_TURNO.Count > 0)
                {
                    CapaLogicaNegocio.Enc_Factura c = new CapaLogicaNegocio.Enc_Factura();
                    List<CapaLogicaNegocio.Enc_Factura> LISTA_ENC = new List<CapaLogicaNegocio.Enc_Factura>();
                    LISTA_ENC = c.Obtener();

                    if (LISTA_ENC.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalExpress').modal('show')", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalNoProductos').modal('show')", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalNoProductos').modal('show')", true);
                }
            }
            }
            catch { }
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            try
            {
            
            CapaLogicaNegocio.Enc_Factura enc = new CapaLogicaNegocio.Enc_Factura();
            int pk_id_enc_fact;
            pk_id_enc_fact = enc.ObtenerActivo();

            Mesa nes = new Mesa();
            List<Mesa> mesa = new List<Mesa>();
            mesa = nes.MesaOcupada(pk_id_enc_fact);

            if (mesa.Count != 0)
            {
                Enc_Factura ENC = new Enc_Factura();

                int activo = ENC.ObtenerActivo();

                Mesa me = new Mesa();

                ENC.CambioEstado(6, ENC.ObtenerActivo());

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalMesaEnviada').modal('show')", true);

                Refrescar();
            }
            else
            {
                CapaLogicaNegocio.Turno p = new CapaLogicaNegocio.Turno();
                List<CapaLogicaNegocio.Turno> LISTA_TURNO = new List<CapaLogicaNegocio.Turno>();
                LISTA_TURNO = p.ObtenerTodos();
                if (LISTA_TURNO.Count > 0)
                {
                    CapaLogicaNegocio.Enc_Factura c = new CapaLogicaNegocio.Enc_Factura();
                    List<CapaLogicaNegocio.Enc_Factura> LISTA_ENC = new List<CapaLogicaNegocio.Enc_Factura>();
                    LISTA_ENC = c.Obtener();

                    if (LISTA_ENC.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalMesa').modal('show')", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalNoProductos').modal('show')", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalNoProductos').modal('show')", true);
                }
            }
            }
            catch { }
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

        protected void Button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txtEfectivo.Text.ToString()) >= int.Parse(txtTotalFactura2.Text.ToString()))
            {
                
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalFacturar').modal('hide');", true);

                    Enc_Factura ENC = new Enc_Factura();

                    int activo = ENC.ObtenerActivo();

                    Express es = new Express();

                    string descripcion = TextBox3.Text.ToString();

                    int zona;

                    if (ddlExpress.SelectedValue.ToString() == "")
                    {
                        zona = 0;
                    }
                    else
                    {
                        zona = int.Parse(ddlExpress.SelectedValue.ToString());
                    }
                    es.Nuevo(ENC.ObtenerActivo(), descripcion, zona);

                    ENC.CambioEstado(7, ENC.ObtenerActivo());

                    Refrescar();

                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalFacturado').modal('show')", true);
                    txtEfectivo.Text = "0";
                    txtCambio.Text = "0";
                
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalFacturar').modal('show')", true);
            }
            }
            catch
            {

            }

        }

        public bool validardatosexpress()
        {
            bool var = false;
            if (
                TextBox2.Text.ToString() == "" ||
                    ddlExpress.SelectedValue.ToString() == "" ||
                    TextBox1.Text.ToString() == ""
                )
            {
                var = true;
            }
            else
            {
                var = false;
            }
            return var;
        }

        public void limpiardatosexpress() {
            TextBox2.Text = "";
            txttotalmodalexpress.Text = "";
            txtTotalFactura3.Text = "";
            txttotalconexpress.Text = "";
            TextBox1.Text = "";
        }

        protected void Button37_Click(object sender, EventArgs e)
        {
            try
            {
                if (validardatosexpress() == false)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalExpress').modal('hide');", true);

                    Enc_Factura ENC = new Enc_Factura();

                    Express es = new Express();

                    int activo = ENC.ObtenerActivo();

                    string descripcion = TextBox1.Text.ToString();

                    int Zona = int.Parse(ddlExpress.SelectedValue.ToString());

                    es.Nuevo(activo, descripcion, Zona);

                    ENC.CambioTipo(activo, 3);

                    ENC.CambioEstado(5, activo);

                    ENC.AsignacionNombre(TextBox2.Text.ToString(), activo);

                    Refrescar();

                    limpiardatosexpress();

                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalExpressEnviado').modal('show')", true);

                    
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalExpress').modal('show')", true);
                }
            }
            catch
            {

            }
        }

        protected void Gridfactura_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void Gridfactura_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
            
            DetFactura pa = new DetFactura();
            Gridfacturar.DataSource = pa.Obtener();
            Gridfacturar.DataBind();
            }
            catch { }
        }

        protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string mesaasignar = e.CommandArgument.ToString();
            txtMesa.Text = mesaasignar;
            Refrescar();
        }

        //Este mae es el de mesas
        protected void Button26_Click(object sender, EventArgs e)
        {
            try
            {

                if (Label10.Text.ToString() == "" || txtMesa.Text.ToString() == "0")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalMesa').modal('show')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#ModalMesa').modal('hide');", true);

                    Enc_Factura ENC = new Enc_Factura();

                    int activo = ENC.ObtenerActivo();        

                    ENC.CambioTipo(ENC.ObtenerActivo(), 3);

                    Mesa me = new Mesa();

                    me.AsignarMesa(int.Parse(txtMesa.Text.ToString()), ENC.ObtenerActivo());

                    ENC.CambioEstado(6, ENC.ObtenerActivo());

                    ENC.AsignacionNombre(TextBox3.Text.ToString(), activo);

                    Refrescar();

                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalMesaEnviada').modal('show')", true);
                }
            }
            catch
            {

            }
        }

        protected void ddlExpress_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            
            int id = int.Parse(ddlExpress.SelectedValue.ToString());
            ZonaExpress z = new ZonaExpress();
            txttotalmodalexpress.Text = z.MontoXpress(id).ToString();
            }
            catch { }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ModalExpress').modal('show')", true);
                Enc_Factura en = new Enc_Factura();
                txttotalconexpress.Text = (en.ObtenerTotal() + Double.Parse(txttotalmodalexpress.Text.ToString())).ToString();
            }
            catch
            {
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
            
            Response.Redirect("FacturacionCol.aspx");
            }
            catch { }
        }
    }
}
