<%@ Page Title="" Language="C#" MasterPageFile="~/Colaborador.Master" AutoEventWireup="true" CodeBehind="AperturaTurnoCol.aspx.cs" Inherits="CapaPresentacion.AperturaTurnoCol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
            <div class="modal fade" id="ModalTurno" tabindex="-1" role="dialog" aria-labelledby="ModalTurno" aria-hidden="true">
            <div class="modal-dialog modal-sm" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="ModalTurno1">Alerta</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row justify-content-md-center">
                            <div class="thank-you-pop">
                                <asp:Image ID="Image3" runat="server" Height="41px" ImageUrl="~/imagen/warning.png" Width="47px" />
                                <h4>Ya Existe un Turno Abierto</h4>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button2" runat="server" Text="Aceptar" type="button" class="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>

                        <div class="modal fade" id="ModalTurnoAbierto" tabindex="-1" role="dialog" aria-labelledby="ModalTurnoAbierto" aria-hidden="true">
            <div class="modal-dialog modal-sm" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="ModalTurnoAbierto1">Alerta</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row justify-content-md-center">
                            <div class="thank-you-pop">
                                <asp:Image ID="Image1" runat="server" Height="41px" ImageUrl="~/imagen/success.png" Width="47px" />
                                <h4>Turno Abierto</h4>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button1" runat="server" Text="Aceptar" type="button" class="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6 ">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-md-2 ">
                        </div>
                        <div class="col-md-8 mantenimiento">
                            <div class="page-header">
                                <h1>Apertura de Turno</h1>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Label ID="lblNombre" class="label-control" runat="server" Text="Monto"></asp:Label>
                                    <asp:TextBox ID="txtMonto" Text="0" class="form-control" placeholder="Monto de Apertura" runat="server" onkeypress="return numbersonly(event);"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="txtMonto" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Monto Requerido" ValidationGroup="usuario" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Button ID="btnAbrirTurno" Class="btn btn-primary" runat="server" Text="Abrir Turno" OnClick="btnAbrirTurno_Click" />
                                    <asp:Button ID="btnCancelar" Class="btn btn-danger" runat="server" Text="Cancelar" />
                                </div>
                            </div>
                            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                            <br />
                        </div>
                        <div class="col-md-2">
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="col-md-8">
                    <div class="col-md-12">
                        <asp:GridView
                            DataKeyNames="PK_ID_TURNO"
                            CssClass="table table-bordered bs-table"
                            AllowPaging="true"
                            BorderColor="#999999" ID="GridTurno"
                            AutoGenerateColumns="false"
                            OnRowCancelingEdit="GridTurno_RowCancelingEdit"
                            OnRowEditing="GridTurno_RowEditing"
                            OnRowDeleting="GridTurno_RowDeleting"
                            OnRowUpdating="GridTurno_RowUpdating"
                            OnRowDataBound="GridTurno_RowDataBound" runat="server"
                            OnPageIndexChanging="GridTurno_PageIndexChanging"
                            PageSize="7">
                            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#ffffcc" />
                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                            <EmptyDataTemplate>
                                ¡No hay Turno Abierto!  
                            </EmptyDataTemplate>
                            <Columns>
                                <%--botones de acción sobre los registros...--%>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <%--Botones de eliminar y editar cliente...--%>
                                        <asp:Button ID="btnDelete" runat="server" Text="Cerrar Turno" CssClass="btn btn-danger" CommandName="Delete" OnClientClick="return confirm('¿Desea Cerrar el Turno?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--campos editables...--%>
                                <asp:BoundField ControlStyle-Width="120" DataField="FECHA_APERTURA" HeaderText="Fecha Apertura"></asp:BoundField>
                                <asp:BoundField ControlStyle-Width="120" DataField="FONDO" HeaderText="Monto Aperturado"></asp:BoundField>
                                <asp:BoundField ControlStyle-Width="120" DataField="CIERRE" HeaderText="Monto Facturas"></asp:BoundField>
                                <asp:BoundField ControlStyle-Width="120" DataField="Total" HeaderText="Cierre de Caja"></asp:BoundField>
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
            </div>
        </div>
    </div>
</asp:Content>
