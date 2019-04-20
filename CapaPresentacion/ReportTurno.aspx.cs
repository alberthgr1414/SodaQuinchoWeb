using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace CapaPresentacion
{
    public partial class ReporteTurno : System.Web.UI.Page
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
                try
                {
                VerReporte();
                String today = DateTime.Today.ToString("dd/MM/yyyy");
                TextBox1.Text = today;
                }
                catch { }
            }
        }
            catch { }
            
        }
        public void VerReporte()
        {
            try
            {

                string cadena;
                cadena = TextBox1.Text.ToString();

                if (cadena != "")
                {
                    //Resetear
                    ReportViewer1.Reset();
                    //DataSourse
                    DataTable dt = GetData(DateTime.Parse(cadena));
                    ReportDataSource rds = new ReportDataSource("DataSet1", dt);

                    ReportViewer1.LocalReport.DataSources.Add(rds);

                    //Path
                    ReportViewer1.LocalReport.ReportPath = "ReportTurno.rdlc";

                    //Parametros
                    ReportParameter[] rptParams = new ReportParameter[] {
                   new ReportParameter("fecha",cadena)
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
                    ReportViewer1.LocalReport.ReportPath = "ReportTurno.rdlc";

                    //Parametros
                    ReportParameter[] rptParams = new ReportParameter[] {
                    new ReportParameter("fecha",fecha)
                };
                    ReportViewer1.LocalReport.SetParameters(rptParams);
                    //Refrescar
                    ReportViewer1.LocalReport.Refresh();
                }
            }
            catch {
            }
        }
        public DataTable GetData(DateTime fecha) {
           // ConnectionString
            DataTable dt = new DataTable();
            string str = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            try
            {
                using (SqlConnection cn = new SqlConnection(str))
                {
                    try
                    {
                    
                    SqlCommand cmd = new SqlCommand("PA_REP_TURNO", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@STR_BUSCAR", SqlDbType.DateTime).Value = fecha;

                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt);
                    }
                    catch { }
                }
            }
            catch {
            }

                return dt;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                VerReporte();
            }
            catch
            {
            }
            
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox1.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
        }
    }
}