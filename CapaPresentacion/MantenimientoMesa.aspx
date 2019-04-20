<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="MantenimientoMesa.aspx.cs" Inherits="CapaPresentacion.MantenimientoMesa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-1">
    </div>
    <div class="col-md-12 usuario-crear">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4 mantenimiento">
                    <div class="col-md-12 Mantenimiento">
                        <div class="page-header">
                            <h1>Crear Categoria Producto</h1>
                        </div>
                        <%-- Nombre Usuario --%>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="lblNombre" class="label-control" runat="server" Text="Nombre"></asp:Label>
                                <asp:TextBox ID="txtNombre" class="form-control" placeholder="Numero de Mesa" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="txtNombre" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Nombre Requerido" ValidationGroup="usuario" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <%-- Guardar --%>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Button ID="btnGuardarUsuario" Class="btn btn-primary" data-toggle="modal" data-target="#myModal" runat="server" Text="Guardar" OnClick="btnGuardarUsuario_Click" ValidationGroup="usuario" />
                                <asp:Button ID="btnCancelar" Class="btn btn-danger" runat="server" Text="Limpiar" OnClick="" />
                            </div>
                        </div>
                        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                        <br />
                    </div>
                </div>
                <div class="col-md-8 tabla">
                    <div class="col-md-6">
                        <br />
                        <asp:GridView
                            CssClass="table table-bordered bs-table"
                            DataKeyNames="PK_ID_MESA"
                            BorderColor="#999999" ID="GridTipoUsuario"
                            AutoGenerateColumns="false"
                            OnRowCancelingEdit=""
                            OnRowEditing=""
                            OnRowDeleting=""
                            OnRowUpdating=""
                            OnRowDataBound=""
                            runat="server"
                            AllowPaging="true"
                            PageSize="7"
                            OnPageIndexChanging="">
                            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#ffffcc" />
                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                            <EmptyDataTemplate>
                                ¡No hay Mesas con los Parametros Seleccionados!  
                            </EmptyDataTemplate>
                            <Columns>
                                <%--botones de acción sobre los registros...--%>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <%--Botones de eliminar y editar cliente...--%>
                                        <asp:Button ID="btnDelete" runat="server" Text="Quitar" CssClass="btn btn-danger" CommandName="Delete" OnClientClick="return confirm('¿Desea Eliminar Usuario?');" />
                                        <asp:Button ID="btnEdit" runat="server" Text="Editar" CssClass="btn btn-info" CommandName="Edit" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <%--Botones de grabar y cancelar la edición de registro...--%>
                                        <asp:Button ID="btnUpdate" runat="server" Text="Grabar" CssClass="btn btn-success" CommandName="Update" OnClientClick="return confirm('¿Seguro que quiere modificar los datos del Usuario?');" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="btn btn-default" CommandName="Cancel" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <%--campos editables...--%>
                                <asp:BoundField ControlStyle-Width="120" DataField="PK_ID_TipoPlato" HeaderText="ID" Visible="false"></asp:BoundField>
                                <asp:BoundField ControlStyle-Width="120" DataField="STR_NUMERO" HeaderText="Numero"></asp:BoundField>
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
                    <div class="col-md-6">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
