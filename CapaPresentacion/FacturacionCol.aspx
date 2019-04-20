<%@ Page Title="" Language="C#" MasterPageFile="~/Colaborador.Master" AutoEventWireup="true" CodeBehind="FacturacionCol.aspx.cs" Inherits="CapaPresentacion.FacturacionCol" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <%-- Modal Factura --%>
    <div class="Contenedor">
        <div class="modal fade" id="ModalFacturar" tabindex="-1" role="dialog" aria-labelledby="ModalFacturar" aria-hidden="true">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Facturar</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="container-fluid">
                            <ajaxToolkit:ScriptManager ID="ScriptManager1" runat="server"></ajaxToolkit:ScriptManager>
                            <ajaxToolkit:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td colspan="3">
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td colspan="1" style="width: 33.33%;">
                                                                    <asp:Button ID="Button14" runat="server" Height="80px" OnClick="Button14_Click" Text="1" Style="width: 100%;" />
                                                                </td>
                                                                <td colspan="1" style="width: 33.33%;">
                                                                    <asp:Button ID="Button15" runat="server" Height="80px" OnClick="Button14_Click" Text="2" Style="width: 100%;" />
                                                                </td>
                                                                <td colspan="1" style="width: 33.33%;">
                                                                    <asp:Button ID="Button16" runat="server" Height="80px" OnClick="Button14_Click" Text="3" Style="width: 100%;" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="1" style="width: 33.33%;">
                                                                    <asp:Button ID="Button17" runat="server" Height="80px" OnClick="Button14_Click" Text="4" Style="width: 100%;" />
                                                                </td>
                                                                <td colspan="1" style="width: 33.33%;">
                                                                    <asp:Button ID="Button18" runat="server" Height="80px" OnClick="Button14_Click" Text="5" Style="width: 100%;" />
                                                                </td>
                                                                <td colspan="1" style="width: 100%;">
                                                                    <asp:Button ID="Button19" runat="server" Height="80px" OnClick="Button14_Click" Text="6" Style="width: 100%;" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="1" style="width: 33.33%;">
                                                                    <asp:Button ID="Button20" runat="server" Height="80px" OnClick="Button14_Click" Text="7" Style="width: 100%;" />
                                                                </td>
                                                                <td colspan="1" style="width: 33.33%;">
                                                                    <asp:Button ID="Button21" runat="server" Height="80px" OnClick="Button14_Click" Text="8" Style="width: 100%;" />
                                                                </td>
                                                                <td colspan="1" style="width: 33.33%;">
                                                                    <asp:Button ID="Button22" runat="server" Height="80px" OnClick="Button14_Click" Text="9" Style="width: 100%;" />
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td colspan="1" style="width: 33.33%;">
                                                                    <asp:Button ID="Button24" runat="server" Height="80px" OnClick="Button14_Click" Text="<--" Style="width: 100%;" />
                                                                </td>
                                                                <td colspan="1" style="width: 33.33%;">
                                                                    <asp:Button ID="Button23" runat="server" Height="80px" OnClick="Button14_Click" Text="0" Style="width: 100%;" />
                                                                </td>
                                                                <td colspan="1" style="width: 33.33%;">
                                                                    <asp:Button ID="Button25" runat="server" Height="80px" OnClick="Button14_Click" Text="CE" Style="width: 100%;" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" style="width: 33.33%;">
                                                                    <asp:Button ID="Button1" runat="server" Height="80px" OnClick="Button14_Click" Text="Pago Completo" Style="width: 100%;" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td colspan="1">
                                                        <br />
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="row">
                                                            <asp:Label ID="Label3" runat="server" Text="Total:"></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTotalFactura2" runat="server" Enabled="False" Width="212px">0</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="row">
                                                            <asp:Label ID="Label4" runat="server" Text="Efectivo:"></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEfectivo" runat="server" Enabled="False" Width="212px">0</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="row">
                                                            <asp:Label ID="Label5" runat="server" Text="Cambio:"></asp:Label>
                                                        </div>
                                                        <td>
                                                            <asp:TextBox ID="txtCambio" runat="server" Enabled="False" Width="212px">0</asp:TextBox>
                                                        </td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="col-md-6 productos">
                                            <div class="col-sm-4 factura">
                                                <div class="col-md-12">
                                                    <asp:GridView
                                                        DataKeyNames="PK_ID_DetFactura"
                                                        CssClass="table table-bordered bs-table"
                                                        AllowPaging="true"
                                                        BorderColor="#999999" ID="Gridfacturar"
                                                        AutoGenerateColumns="false"
                                                        runat="server"
                                                        PageSize="7">
                                                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#ffffcc" />
                                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                        <EmptyDataTemplate>
                                                            ¡No hay Productos Agregados!  
                                                        </EmptyDataTemplate>
                                                        <Columns>
                                                            <asp:BoundField ControlStyle-Width="120" DataField="PK_ID_DetFactura" HeaderText="ID Plato" Visible="false"></asp:BoundField>
                                                            <asp:BoundField ControlStyle-Width="120" DataField="STR_PLATO" HeaderText="Nombre"></asp:BoundField>
                                                            <asp:BoundField ControlStyle-Width="120" DataField="TOTAL" HeaderText="Total"></asp:BoundField>
                                                            <asp:BoundField ControlStyle-Width="120" DataField="CANTIDAD" HeaderText="Cantidad"></asp:BoundField>
                                                        </Columns>
                                                        <FooterStyle BackColor="#CCCCCC" Font-Size="Large" ForeColor="Black" />
                                                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                        <SortedDescendingHeaderStyle BackColor="#000065" />
                                                        <AlternatingRowStyle BackColor="#DCDCDC" />
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </ajaxToolkit:UpdatePanel>
                        </div>
                        <br />
                        <div class="alert alert-warning alert-dismissible fade show">
                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                            <strong>Ojo!</strong> Para poder facturar se debe de digitar un monto primero.
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button11" runat="server" Text="Facturar" type="button" class="btn btn-primary" OnClick="Button11_Click" />
                        <asp:Button ID="Button13" runat="server" Text="Cancelar" type="button" class="btn btn-danger" />
                    </div>
                </div>
            </div>
        </div>
        <%-- Modal Factura --%>
        <div class="modal fade" id="ModalFacturado" tabindex="-1" role="dialog" aria-labelledby="ModalFacturar" aria-hidden="true">
            <div class="modal-dialog modal-sm" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="ModalFacturado1">Facturado</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row justify-content-md-center">
                            <div class="thank-you-pop">
                                <asp:Image ID="Image1" runat="server" Height="41px" ImageUrl="~/imagen/success.png" Width="47px" />
                                <h1>Facturado</h1>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button39" runat="server" Text="Aceptar" type="button" class="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="ModalNoProductos" tabindex="-1" role="dialog" aria-labelledby="ModalFacturar" aria-hidden="true">
            <div class="modal-dialog modal-sm" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="ModalNoProductos1">Alerta</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row justify-content-md-center">
                            <div class="thank-you-pop">
                                <asp:Image ID="Image3" runat="server" Height="41px" ImageUrl="~/imagen/warning.png" Width="47px" />
                                <h4>Favor agregar Productos a la Factura</h4>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button2" runat="server" Text="Aceptar" type="button" class="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>

        <%-- Modal Express Enviado --%>
        <div class="modal fade" id="ModalExpressEnviado" tabindex="-1" role="dialog" aria-labelledby="ModalExpressEnviado" aria-hidden="true">
            <div class="modal-dialog modal-sm" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="ModalExpressEnviado1">Facturado</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row justify-content-md-center">
                            <div class="thank-you-pop">
                                <asp:Image ID="Image2" runat="server" Height="41px" ImageUrl="~/imagen/success.png" Width="47px" />
                                <h1>Express Enviado</h1>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button12" runat="server" Text="Aceptar" type="button" class="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
        <%-- Modal Mesa Enviada --%>
        <div class="modal fade" id="ModalMesaEnviada" tabindex="-1" role="dialog" aria-labelledby="ModalMesaEnviada" aria-hidden="true">
            <div class="modal-dialog modal-sm" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h3 class="modal-title" id="ModalMesaEnviada1">Factura en Mesa</h3>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row justify-content-md-center">
                            <div class="thank-you-pop">
                                <asp:Image ID="Image4" runat="server" Height="41px" ImageUrl="~/imagen/success.png" Width="47px" />
                                <h4>Factura Estacionada en Mesa</h4>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button3" runat="server" Text="Aceptar" type="button" class="btn btn-primary" OnClick="Button3_Click"/>
                    </div>
                </div>
            </div>
        </div>
        <%-- Modal Express --%>

        <div class="modal fade" id="ModalExpress" tabindex="-1" role="dialog" aria-labelledby="ModalExpress" aria-hidden="true">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="ModalExpress1">Servicio Express</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-md-7">
                                    <div class="row">
                                        <table border="0" width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label9" runat="server" Text="Nombre del Cliente: "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBox2" runat="server" Width="100%"></asp:TextBox>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <br />
                                                </td>
                                                <td>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Lugar de Entrega: " Width="100%"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList Class="dropdown-header" ID="ddlExpress" AppendDataBoundItems="true" runat="server" Width="100%"  OnSelectedIndexChanged="ddlExpress_SelectedIndexChanged" onchange="ddlExpress_SelectedIndexChanged">  
                                                    </asp:DropDownList>
                                                    <asp:Button ID="Button4" runat="server" Text="Agregar" type="button" class="btn btn-success" OnClick="Button4_Click" />
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <br />
                                                </td>
                                                <td>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label12" runat="server" Text="Monto Xpress: "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txttotalmodalexpress" Enabled="False" runat="server" Width="100%"></asp:TextBox>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <br />
                                                </td>
                                                <td>
                                                    <br />
                                                </td>
                                            </tr>
                                                                                        <tr>
                                                <td>
                                                    <asp:Label ID="Label11" runat="server" Text="Total Factura: " Width="100%"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTotalFactura3" Enabled="False" runat="server" Width="100%"></asp:TextBox>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <br />
                                                </td>
                                                <td>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                             <td>
                                                    <asp:Label ID="Label13" runat="server" Text="Total Factura con Express: " Width="100%"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txttotalconexpress" Enabled="False" runat="server" Width="100%"></asp:TextBox>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <br />
                                                </td>
                                                <td>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="Descripcion Lugar: "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="200px" Width="100%"></asp:TextBox>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <br />
                                                </td>
                                                <td>
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <%--<asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine"></asp:TextBox>--%>
                                </div>
                                <div class="col-md-5 ">
                                    <asp:GridView
                                        DataKeyNames="PK_ID_DetFactura"
                                        CssClass="table table-bordered bs-table"
                                        AllowPaging="true"
                                        BorderColor="#999999" ID="GridView1"
                                        AutoGenerateColumns="false"
                                        OnRowDeleting="Gridfactura_RowDeleting"
                                        runat="server"
                                        PageSize="7" OnPageIndexChanging="Gridfactura_PageIndexChanging" OnSelectedIndexChanging="Gridfactura_SelectedIndexChanging">
                                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <EmptyDataTemplate>
                                            ¡No hay Productos Agregados!  
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:BoundField ControlStyle-Width="120" DataField="PK_ID_DetFactura" HeaderText="ID Plato" Visible="false"></asp:BoundField>
                                            <asp:BoundField ControlStyle-Width="120" DataField="STR_PLATO" HeaderText="Nombre"></asp:BoundField>
                                            <asp:BoundField ControlStyle-Width="120" DataField="TOTAL" HeaderText="Total"></asp:BoundField>
                                            <asp:BoundField ControlStyle-Width="120" DataField="CANTIDAD" HeaderText="Cantidad"></asp:BoundField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCCCC" Font-Size="Large" ForeColor="Black" />
                                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#000065" />
                                        <AlternatingRowStyle BackColor="#DCDCDC" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                         <div class="alert alert-warning alert-dismissible fade show">
                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                            <strong>Ojo!</strong> Para poder enviar el express se debe deben de llenar todos los campos.
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button37" runat="server" Text="Enviar Express" type="button" class="btn btn-success" OnClick="Button37_Click" />
                        <asp:Button ID="Button38" runat="server" Text="Cancelar" type="button" class="btn btn-danger" />
                    </div>
                </div>
            </div>
        </div>
        <%-- Modal Mesa --%>
        <div class="modal fade" id="ModalMesa" tabindex="-1" role="dialog" aria-labelledby="ModalMesa" aria-hidden="true">

            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="ModalMesa1">Numero de Mesa</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="row">
                                        <asp:Label ID="Label10" runat="server" Text="Nombre del Cliente"></asp:Label>
                                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                    </div>
                                    <br />
                                    <ajaxToolkit:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource3" RepeatColumns="3" RepeatDirection="Horizontal" CellPadding="0" DataKeyField="PK_ID_MESA" OnItemCommand="DataList2_ItemCommand" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="None" BorderWidth="3px" ForeColor="Black" GridLines="Both">
                                                <FooterStyle BackColor="#CCCCCC" />
                                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                <ItemStyle BackColor="White" />
                                                <ItemTemplate>
                                                    <table class="auto-style1">
                                                        <tr>
                                                            <td colspan="4">
                                                               <asp:Button CommandName="Mesas" ID="Mesas" runat="server" Height="100px" Text='<%# Eval("STR_NUMERO") %>' Width="100px" CommandArgument='<%# Eval("PK_ID_MESA") %>' ImageAlign="Middle" Enabled='<%# Eval("OCUPADO").ToString()== "1" ? false : true  %>' BackColor='<%# Eval("OCUPADO").ToString()== "1" ? System.Drawing.Color.LightCoral : System.Drawing.Color.LightGreen%>' />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                </ItemTemplate>
                                                <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                            </asp:DataList>
                                            <asp:Label ID="Label7" runat="server" Text="Numero de Mesa:"></asp:Label>
                                            <asp:TextBox ID="txtMesa" runat="server" Enabled="False" Width="50px">0</asp:TextBox>
                                        </ContentTemplate>
                                    </ajaxToolkit:UpdatePanel>

                                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="PA_CON_MESA" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                </div>
                                <div class="col-md-6">
                                    <asp:GridView
                                        DataKeyNames="PK_ID_DetFactura"
                                        CssClass="table table-bordered bs-table"
                                        AllowPaging="true"
                                        BorderColor="#999999" ID="GridFactura2"
                                        AutoGenerateColumns="false"
                                        OnRowDeleting="Gridfactura_RowDeleting"
                                        runat="server"
                                        PageSize="7" OnPageIndexChanging="Gridfactura_PageIndexChanging" OnSelectedIndexChanging="Gridfactura_SelectedIndexChanging">
                                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <EmptyDataTemplate>
                                            ¡No hay Productos Agregados!  
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <%--botones de acción sobre los registros...--%>
                                            <%--<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px">
                                                <ItemTemplate>--%>
                                            <%--Botones de eliminar y editar cliente...--%>
                                            <%--<asp:Button ID="btnDelete" runat="server" Text="X" CssClass="btn btn-danger" CommandName="Delete" OnClientClick="return confirm('¿Desea Eliminar el Producto?');" />--%>
                                            <%--                     </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <%--campos editables...--%>
                                            <asp:BoundField ControlStyle-Width="120" DataField="PK_ID_DetFactura" HeaderText="ID Plato" Visible="false"></asp:BoundField>
                                            <asp:BoundField ControlStyle-Width="120" DataField="STR_PLATO" HeaderText="Nombre"></asp:BoundField>
                                            <asp:BoundField ControlStyle-Width="120" DataField="TOTAL" HeaderText="Total"></asp:BoundField>
                                            <asp:BoundField ControlStyle-Width="120" DataField="CANTIDAD" HeaderText="Cantidad"></asp:BoundField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCCCC" Font-Size="Large" ForeColor="Black" />
                                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#000065" />
                                        <AlternatingRowStyle BackColor="#DCDCDC" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <br />
                                              <div class="alert alert-warning alert-dismissible fade show">
                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                            <strong>Ojo!</strong> Para poder enviar la Mesa se deben de llenar todos los campos.
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button26" runat="server" Text="Enviar a Mesa" type="button" class="btn btn-success" OnClick="Button26_Click" />
                        <asp:Button ID="Button27" runat="server" Text="Cancelar" type="button" class="btn btn-danger" />
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-12 col-md-5 col-lg-5 productos">
                    <div class="text-center">
                        <asp:Button ID="Cantidad_1" runat="server" OnClick="Button1_Click1" Text="1" class="btn btn-primary btn-lg" />
                        <asp:Button ID="Cantidad_2" runat="server" OnClick="Button1_Click1" Text="2" class="btn btn-primary btn-lg" />
                        <asp:Button ID="Cantidad_3" runat="server" OnClick="Button1_Click1" Text="3" class="btn btn-primary btn-lg" />
                        <asp:Button ID="Cantidad_4" runat="server" OnClick="Button1_Click1" Text="4" class="btn btn-primary btn-lg" />
                        <asp:Button ID="Cantidad_5" runat="server" OnClick="Button1_Click1" Text="5" class="btn btn-primary btn-lg" />
                        <asp:Button ID="Cantidad_6" runat="server" OnClick="Button1_Click1" Text="6" class="btn btn-primary btn-lg" />
                        <asp:Button ID="Cantidad_7" runat="server" OnClick="Button1_Click1" Text="7" class="btn btn-primary btn-lg" />
                        <asp:Button ID="Cantidad_8" runat="server" OnClick="Button1_Click1" Text="8" class="btn btn-primary btn-lg" />
                        <asp:Button ID="Cantidad_9" runat="server" OnClick="Button1_Click1" Text="9" class="btn btn-primary btn-lg" />
                        <asp:Button ID="Cantidad_0" runat="server" OnClick="Button1_Click1" Text="0" class="btn btn-primary btn-lg" />
                        <br />
                    </div>
                </div>
                <div class="col-sm-12 col-md-3 col-lg-3 tipoplato">
                    <div class="text-center">
                        <asp:Label ID="Label1" runat="server" Text="Cantidad :"></asp:Label>
                        <asp:TextBox ID="txtCantidad" runat="server" Enabled="False" Width="42px">0</asp:TextBox>
                    </div>
                    <br />
                </div>
                <div class="col-sm-12 col-md-4 col-lg-4 factura">
                    <div class="text-center">
                        <asp:Label ID="Label2" runat="server" Text="Total Factura :"></asp:Label>
                        <asp:TextBox ID="txtTotalFactura" runat="server" Enabled="False" Width="212px">0</asp:TextBox>
                    </div>
                </div>
                <div class="w-100"></div>
                <div class="col-sm-12 col-md-5 col-lg-5  productos">
                    <asp:DataList ID="dtlProducto" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="4" RepeatDirection="Horizontal" CellPadding="0" DataKeyField="PK_ID_PLATO" OnItemCommand="dtlProducto_ItemCommand" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="None" BorderWidth="3px" ForeColor="Black" GridLines="Both">
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <ItemStyle BackColor="White" />
                        <ItemTemplate>
                            <table class="auto-style1">
                                <tr>
                                    <td>
                                        <asp:ImageButton CommandName="imgPlato" ID="imgPlato" runat="server" Height="100px" ImageUrl='<%# Eval("foto") %>' Width="100%" CommandArgument='<%# Eval("PK_ID_PLATO") %>' ImageAlign="Middle" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="lblPlato" runat="server" Text='<%# Eval("STR_Nombre_Plato") %>' BorderStyle="None" BorderWidth="2px"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </ItemTemplate>
                        <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    </asp:DataList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="PA_CON_PLATO_POR_TIPO" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="FK_ID_TipoPlato" QueryStringField="FK_ID_TipoPlato" DefaultValue="1" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="btnGuardarUsuario" Class="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardarUsuario_Click" Visible="false" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="btnGuardarUsuario2" Class="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardarUsuario2_Click" Visible="false" />
                        </div>
                    </div>
                </div>
                <div class="col-sm-12 col-md-3 col-lg-3 tipoplato text-center">
                    <asp:DataList ID="DataList1" runat="server" DataKeyField="PK_ID_TipoPlato" DataSourceID="SqlDataSource2" RepeatColumns="2" Width="100%" CellPadding="0" OnItemCommand="DataList1_ItemCommand">
                        <ItemTemplate>
                            <asp:Button ID="btnTipoPlato" runat="server" CommandArgument='<%# Eval("PK_ID_TipoPlato") %>' Height="100px" Text='<%# Eval("STR_DESCRIPCION") %>' Width="160px" CommandName="btnTipoPlato" />
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="PA_CON_TIPO_PLATO" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </div>
                <div class="col-sm-12 col-md-4 col-lg-4 factura text-center">
                    <div class="col-md-12 text-center ">
                        <asp:GridView
                            DataKeyNames="PK_ID_DetFactura"
                            CssClass="table table-bordered bs-table"
                            AllowPaging="true"
                            BorderColor="#999999" ID="Gridfactura"
                            AutoGenerateColumns="false"
                            OnRowDeleting="Gridfactura_RowDeleting"
                            runat="server"
                            PageSize="8" OnPageIndexChanging="Gridfactura_PageIndexChanging" OnSelectedIndexChanging="Gridfactura_SelectedIndexChanging">
                            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#ffffcc" />
                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                            <EmptyDataTemplate>
                                ¡No hay Productos Agregados!  
                            </EmptyDataTemplate>
                            <Columns>
                                <%--botones de acción sobre los registros...--%>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <%--Botones de eliminar y editar cliente...--%>
                                        <asp:Button ID="btnDelete" runat="server" Text="X" CssClass="btn btn-danger" CommandName="Delete" OnClientClick="return confirm('¿Desea Eliminar el Producto?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--campos editables...--%>
                                <asp:BoundField ControlStyle-Width="120" DataField="PK_ID_DetFactura" HeaderText="ID Plato" Visible="false"></asp:BoundField>
                                <asp:BoundField ControlStyle-Width="120" DataField="STR_PLATO" HeaderText="Nombre"></asp:BoundField>
                                <asp:BoundField ControlStyle-Width="120" DataField="TOTAL" HeaderText="Total"></asp:BoundField>
                                <asp:BoundField ControlStyle-Width="120" DataField="CANTIDAD" HeaderText="Cantidad"></asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" Font-Size="Large" ForeColor="Black" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#0000A9" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#000065" />
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                        </asp:GridView>
                        <br />
                    </div>
                </div>
                <div class="w-100"></div>
                <div class="col-sm-12 col-md-5 col-lg-5 productos text-center">
                </div>
                <div class="col-sm-12 col-md-3 col-lg-3 tipoplato text-center">
                </div>
                <div class="col-sm-12 col-md-4 col-lg-4 factura text-center">
                    <asp:Button runat="server" ID="btnfacturar" Text="Facturar" type="button" class="btn btn-primary" data-toggle="modal" OnClick="Unnamed1_Click" />
                    <asp:Button runat="server" ID="btnExpress" Text="Enviar Express" type="button" class="btn btn-success" data-toggle="modal" OnClick="Unnamed2_Click" />
                    <asp:Button runat="server" ID="btnMesa" Text="Orden Mesa" type="button" class="btn btn-warning" data-toggle="modal" OnClick="Unnamed3_Click" />
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
