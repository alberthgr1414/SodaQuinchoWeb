<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="ReporteFactura.aspx.cs" Inherits="CapaPresentacion.ReporteFactura" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="row">
        <div class="col-md-2">
            <div class="col-md-1"></div>
            <div class="col-md-10 text-center">
                <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
                <h4>Fecha Desde</h4>
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" OnSelectionChanged="Calendar1_SelectionChanged">
                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                    <WeekendDayStyle BackColor="#CCCCFF" />
                </asp:Calendar>
                <asp:TextBox ID="txtdesde" runat="server" enabled="false" Width="100%"></asp:TextBox>
                <h4>Fecha Hasta</h4>
                <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" OnSelectionChanged="Calendar2_SelectionChanged">
                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                    <WeekendDayStyle BackColor="#CCCCFF" />
                </asp:Calendar>
                <asp:TextBox ID="txthasta" runat="server" enabled="false" Width="100%"></asp:TextBox>
                <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Buscar" OnClick="btnBuscar_Click" Width="100%" />
            </div>
            <div class="col-md-1"></div>
        </div>
        <div class="col-md-10 ">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="800px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
        <LocalReport ReportPath="ReporteFactura.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetData" TypeName="CapaPresentacion.Soda_QuinchoDataSet3TableAdapters.PA_REP_FACTURATableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" SelectMethod="GetData" TypeName="CapaPresentacion.Soda_Quincho2DataSetTableAdapters.PA_REP_TURNOTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" SelectMethod="GetData" TypeName="CapaPresentacion.Soda_QuinchoDataSetTableAdapters.PA_REP_PLATOTableAdapter"></asp:ObjectDataSource>

        </div>
        <div class="col-md-2"></div>
    </div>




<%--    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Label ID="Label1" runat="server" Text="Fecha Desde"></asp:Label>
    <asp:TextBox ID="txtdesde" runat="server"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text="Fecha Hasta"></asp:Label>
    <asp:TextBox ID="txthasta" runat="server"></asp:TextBox>
    <asp:Button ID="Button2" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="800px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
        <LocalReport ReportPath="ReporteFactura.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetData" TypeName="CapaPresentacion.Soda_QuinchoDataSet3TableAdapters.PA_REP_FACTURATableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="CapaPresentacion.Soda_Quincho2DataSetTableAdapters.PA_REP_TURNOTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="CapaPresentacion.Soda_QuinchoDataSetTableAdapters.PA_REP_PLATOTableAdapter"></asp:ObjectDataSource>--%>



</asp:Content>
