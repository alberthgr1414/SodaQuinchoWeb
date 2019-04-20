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
    public partial class ReporteExpress : System.Web.UI.Page
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

            try
            {
                if (!Page.IsPostBack)
                {
                    VerReporte();
                    String today = DateTime.Today.ToString("dd/MM/yyyy");
                    TextBox1.Text = today;
                }
            }
            catch { }
        }
        public void VerReporte()
        {
            try
            {
            
            if (TextBox1.Text.ToString() != "")
            {
                //Resetear
                ReportViewer1.Reset();
                //DataSourse
                DataTable dt = GetData(DateTime.Parse(TextBox1.Text.ToString()));
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                ReportViewer1.LocalReport.DataSources.Add(rds);

                //Path
                ReportViewer1.LocalReport.ReportPath = "ReporteExpress.rdlc";

                //Parametros
                ReportParameter[] rptParams = new ReportParameter[] {
                   new ReportParameter("fechadesde",TextBox1.Text)
                };
                ReportViewer1.LocalReport.SetParameters(rptParams);
                //Refrescar
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                string fecha = DateTime.Now.ToString("yyyy/MM/dd");
                //Resetear
                ReportViewer1.Reset();
                //DataSourse
                DataTable dt = GetData(DateTime.Parse(fecha));
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                ReportViewer1.LocalReport.DataSources.Add(rds);

                //Path
                ReportViewer1.LocalReport.ReportPath = "ReporteExpress.rdlc";

                //Parametros
                //ReportParameter[] rptParams = new ReportParameter[] {
                //    new ReportParameter("fromDate",txtBuscar.Text)
                //};
                //ReportViewer1.LocalReport.SetParameters(rptParams);
                //Refrescar
                ReportViewer1.LocalReport.Refresh();
            }
            }
            catch { }
        }
        public DataTable GetData(DateTime fecha)
        {
            // ConnectionString
            DataTable dt = new DataTable();
            string str = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(str))
            {
                try
                {
                SqlCommand cmd = new SqlCommand("PA_REP_EXPRESS", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@fechadesde", SqlDbType.DateTime).Value = fecha;

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
            TextBox1.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
        }
    }
}