using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class ReporteFactura : System.Web.UI.Page
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
                String today = DateTime.Today.ToString("dd/MM/yyyy");
                txtdesde.Text = today;
                txthasta.Text = today;
                VerReporte();
            }
        }

        public void VerReporte()
        {
            try
            {
            
            if (txtdesde.Text.ToString() != "" && txthasta.Text.ToString() != "")
            {
                //Resetear
                ReportViewer1.Reset();
                //DataSourse
                DataTable dt = GetData(DateTime.Parse(txtdesde.Text.ToString()), DateTime.Parse(txthasta.Text.ToString()));
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                ReportViewer1.LocalReport.DataSources.Add(rds);

                //Path
                ReportViewer1.LocalReport.ReportPath = "ReporteFactura.rdlc";

                //Parametros
                ReportParameter[] rptParams = new ReportParameter[] {
                   new ReportParameter("fechadesde",txtdesde.Text),
                   new ReportParameter("fechahasta",txthasta.Text)
                };
                ReportViewer1.LocalReport.SetParameters(rptParams);
                //Refrescar
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                string fecha = DateTime.Now.ToString("yyyy/MM/dd");

                DateTime fecha2 = DateTime.Parse(fecha);

                fecha2 = fecha2.AddDays(1);

                string fecha3 = fecha2.ToString("yyyy/MM/dd");

                //Resetear
                ReportViewer1.Reset();
                //DataSourse
                DataTable dt = GetData(DateTime.Parse(fecha), DateTime.Parse(fecha3));
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                ReportViewer1.LocalReport.DataSources.Add(rds);

                //Path
                ReportViewer1.LocalReport.ReportPath = "ReporteFactura.rdlc";

                //Parametros
                ReportParameter[] rptParams = new ReportParameter[] {
                   new ReportParameter("fechadesde",fecha),
                   new ReportParameter("fechahasta",fecha3)
                };
                ReportViewer1.LocalReport.SetParameters(rptParams);
                //Refrescar
                ReportViewer1.LocalReport.Refresh();
            }
            }
            catch { }
        }
        public DataTable GetData(DateTime fechadesde, DateTime fechahasta)
        {

            DataTable dt = new DataTable();
            string str = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(str))
            {
                try
                {
                SqlCommand cmd = new SqlCommand("PA_REP_FACTURA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@fechadesde", SqlDbType.DateTime).Value = fechadesde;
                cmd.Parameters.Add("@fechahasta", SqlDbType.DateTime).Value = fechahasta;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                }
                catch { }
            }

            return dt;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {        
            VerReporte();
            }
            catch { }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtdesde.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
        }
        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txthasta.Text = Calendar2.SelectedDate.ToString("dd/MM/yyyy");
        }
    }
}