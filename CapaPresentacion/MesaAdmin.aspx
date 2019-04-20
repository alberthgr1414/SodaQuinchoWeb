<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="MesaAdmin.aspx.cs" Inherits="CapaPresentacion.MesaAdmin" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ScriptManager ID="ScriptManager1" runat="server"></ajaxToolkit:ScriptManager>
    <div class="row">
        <div class="col-lg-1 col-sm-11 col-md-1">
        </div>
        <div class="col-lg-10 col-sm-10 col-md-10">
            <div class="Contenedor">
                <div class="modal fade" id="ModalOrden" tabindex="-1" role="dialog" aria-labelledby="ModalOrden" aria-hidden="true">
                    <div class="modal-dialog modal-lg" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="ModalOrden1">Orden</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-lg-2 col-sm-2 col-md-2">
                                        </div>
                                        <div class="col-lg-8 col-sm-8 col-md-8">
                                            <ajaxToolkit:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <div class="row">
                                                        <div class="col-md-12 productos">
                                                            <div class="col-md-12">
                                                                <asp:GridView
                                                                    DataKeyNames="PK_ID_DetFactura"
                                                                    CssClass="table table-bordered bs-table"
                                                                    AllowPaging="true"
                                                                    BorderColor="#999999" ID="GridOrden"
                                                                    AutoGenerateColumns="false"
                                                                    runat="server"
                                                                    PageSize="7"
                                                                    OnRowDeleting="btnDelete_Click1"
                                                                    OnRowUpdating="GridOrden_RowUpdating"
                                                                    >
                                                                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                                                    <EditRowStyle BackColor="#ffffcc" />
                                                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                                    <EmptyDataTemplate>
                                                                        ¡No hay Productos Agregados!  
                                                                    </EmptyDataTemplate>
                                                                    <Columns>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px">
                                                                            <ItemTemplate>
                                                                                <asp:Button ID="btnDelete" runat="server" Text="✔" CssClass="btn btn-succes" CommandName="Delete" CommandArgument="1"/>
                                                                                <asp:Button ID="Button4" runat="server" Text="X" CssClass="btn btn-danger" CommandName="Update"  CommandArgument="2" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField ControlStyle-Width="120" DataField="PK_ID_DetFactura" HeaderText="ID Plato" Visible="false"></asp:BoundField>
                                                                        <asp:BoundField ControlStyle-Width="120" DataField="estado_det" HeaderText="Estado"></asp:BoundField>
                                                                        <asp:BoundField ControlStyle-Width="120" DataField="STR_PLATO" HeaderText="Nombre"></asp:BoundField>
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
                                                    <asp:Label ID="Label11" runat="server" Text="" Visible="false"></asp:Label>
                                                </ContentTemplate>
                                            </ajaxToolkit:UpdatePanel>
                                        </div>
                                        <div class="col-lg-2 col-sm-2 col-md-2">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="Button32" runat="server" Text="Salir" type="button" class="btn btn-danger" />
                            </div>
                        </div>
                    </div>
                </div>



                             <div class="modal fade" id="ModalFacturaProceso" tabindex="-1" role="dialog" aria-labelledby="ModalFacturaProcesos" aria-hidden="true">
            <div class="modal-dialog modal-sm" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="ModalFacturaProceso1">Alerta</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row justify-content-md-center">
                            <div class="thank-you-pop">
                                <asp:Image ID="Image3" runat="server" Height="41px" ImageUrl="~/imagen/error.png" Width="47px" />
                                <h4>Hay una Factura en Proceso</h4>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button5" runat="server" Text="Ir a Facturacion" type="button" class="btn btn-success" OnClick="Button5_Click" />
                        <br />
                        <asp:Button ID="Button2" runat="server" Text="Aceptar" type="button" class="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>




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
                        <asp:Button ID="Button39" runat="server" Text="Aceptar" type="button" class="btn btn-primary"  OnClick="Button39_Click" />
                    </div>
                </div>
            </div>
        </div>
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
                                            <asp:Label ID="txtID" runat="server" Text="" Visible="false"></asp:Label>
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
            </div>

            <div class="container">
                <h3>Facturas en Mesa</h3>
            </div>
            <asp:DataList ID="dtlProducto" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="5" RepeatDirection="Horizontal" CellPadding="0" DataKeyField="PK_ID_ENC_FACTURA" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="None" BorderWidth="3px" ForeColor="Black" GridLines="Both" OnItemCommand="dtlProducto_ItemCommand">
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="White" />
                <ItemTemplate>
                    <table class="w-100" border="1">
                        <tr>
                            <td colspan="1">
                                <asp:Label ID="Label7" runat="server" Text="Mesa= #" Style="width: 50%;"></asp:Label>
                            </td>
                            <td colspan="1">
                                <asp:Label ID="Label6" runat="server" BorderStyle="None" BorderWidth="2px" Text='<%# Eval("Mesa") %>' Style="width: 50%;"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                <asp:Label ID="Label4" runat="server" Text="Cliente=" Style="width: 50%;"></asp:Label>
                            </td>
                            <td colspan="1">
                                <asp:Label ID="lblPlato" runat="server" Text='<%# Eval("Cliente") %>' Style="width: 50%;"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                <asp:Label ID="Label3" runat="server" Text="Vendedor=" Style="width: 50%;"></asp:Label>
                            </td>
                            <td colspan="1">
                                <asp:Label ID="Label1" runat="server" BorderStyle="None" BorderWidth="2px" Text='<%# Eval("Agente") %>' Style="width: 50%;"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                <asp:Label ID="Label5" runat="server" Text="Total Factura=" Style="width: 50%;"></asp:Label>
                            </td>
                            <td colspan="1">
                                <asp:Label ID="Label2" runat="server" BorderStyle="None" BorderWidth="2px" Text='<%# Eval("Total") %>' Style="width: 50%;"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="Button3" runat="server" Class="btn btn-primary" Text="Agregar Productos" Style="width: 100%;" OnClick="Button3_Click" CommandName="1" CommandArgument='<%# Eval("PK_ID_ENC_FACTURA") %>' OnCommand="Button3_Command" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="Button1" runat="server" class="btn btn-warning" Text="Ver Orden" Style="width: 100%;" CommandName="2" CommandArgument='<%# Eval("PK_ID_ENC_FACTURA") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="Button2" runat="server" class="btn btn-success" Text="Facturar" CommandName="3" Style="width: 100%;" CommandArgument='<%# Eval("PK_ID_ENC_FACTURA") %>' />
                            </td>
                        </tr>
                    </table>
                    <br />
                </ItemTemplate>
                                <FooterTemplate>
                    <asp:Label ID="lblEmpty" Text="No hay Mesas en la cola" runat="server" BorderStyle="None" BorderColor="White" Visible='<%#bool.Parse((dtlProducto.Items.Count==0).ToString())%>' BackColor="White">
                    </asp:Label>
                </FooterTemplate>
                <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            </asp:DataList>
        </div>
        <div class="col-lg-1 col-sm-11 col-md-1">
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="PA_CON_FACTURA_ESTADO_MESA" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="FK_ID_EstadoEncFactura" QueryStringField="FK_ID_EstadoEncFactura" DefaultValue="6" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
