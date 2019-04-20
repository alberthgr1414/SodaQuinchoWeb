<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="MantenimientoExpress.aspx.cs" Inherits="CapaPresentacion.MantenimientoExpress" %>

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
                            <h1>Crear Zona Express</h1>
                        </div>
                        <%-- Nombre Usuario --%>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="lblNombre" class="label-control" runat="server" Text="Nombre"></asp:Label>
                                <asp:TextBox ID="txtNombre" class="form-control" placeholder="Nombre" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="txtNombre" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Nombre Requerido" ValidationGroup="usuario" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <%-- Tipo Usuario --%>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="lblPrecio" class="label-control" runat="server" Text="Precio"></asp:Label>
                                <asp:TextBox ID="txtPrecio" class="form-control" placeholder="Precio" runat="server" onkeypress="return numbersonly(event);"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="txtPrecio" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Precio Requerido" ValidationGroup="usuario" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Button ID="btnGuardarUsuario" Class="btn btn-primary" data-toggle="modal" data-target="#myModal" runat="server" Text="Guardar" OnClick="btnGuardarUsuario_Click" ValidationGroup="usuario" />
                                <asp:Button ID="btnCancelar" Class="btn btn-danger" runat="server" Text="Limpiar" OnClick="btnCancelar_Click" />
                            </div>
                        </div>
                        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                        <br />
                    </div>
                </div>
                <div class="col-md-8 tabla">
                    <div class="col-md-9">
                        <br />
                        <asp:GridView
                            DataKeyNames="PK_ID_ZONA_EXPRESS"
                            CssClass="table table-bordered bs-table"
                            BorderColor="#999999" ID="GridZonaExpress"
                            AutoGenerateColumns="false"
                            OnRowCancelingEdit="GridZonaExpress_RowCancelingEdit"
                            OnRowEditing="GridZonaExpress_RowEditing"
                            OnRowDeleting="GridZonaExpress_RowDeleting"
                            OnRowUpdating="GridZonaExpress_RowUpdating"
                            OnRowDataBound="GridZonaExpress_RowDataBound"
                            runat="server"
                            AllowPaging="true"
                            PageSize="7"
                            OnPageIndexChanging="GridZonaExpress_PageIndexChanging">
                            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#ffffcc" />
                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                            <EmptyDataTemplate>
                                ¡No hay Usuarios con los Parametros Seleccionados!  
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
                                <asp:BoundField ControlStyle-Width="120" DataField="PK_ID_ZONA_EXPRESS" HeaderText="ID ZONA_EXPRESS" Visible="false"></asp:BoundField>
                                <asp:BoundField ControlStyle-Width="120" DataField="STR_Descripcion" HeaderText="Lugar"></asp:BoundField>
                                <asp:BoundField ControlStyle-Width="120" DataField="Precio_Express" HeaderText="Precio"></asp:BoundField>
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
                    <div class="col-md-3">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
