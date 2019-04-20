<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="MantenimientoProducto.aspx.cs" Inherits="CapaPresentacion.MantenimientoProducto" %>

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
                            <h1>Crear Producto</h1>
                        </div>
                        <%-- Nombre Plato --%>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="lblNombre" class="label-control" runat="server" Text="Nombre"></asp:Label>
                                <asp:TextBox ID="txtNombre" class="form-control" placeholder="Nombre" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Nombre Requerido" ControlToValidate="txtNombre" ForeColor="Red" ValidationGroup="usuario"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <%-- Tipo Plato --%>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="lblTipoPlato" class="label-control" runat="server" Text="Tipo plato"></asp:Label>
                                <asp:DropDownList Class="dropdown-header" ID="ddlTipoPlato" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <%-- Precio --%>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="lblPrecio" class="label-control" runat="server" Text="Precio"></asp:Label>
                                <asp:TextBox ID="txtPrecio" class="form-control" placeholder="Precio" runat="server" onkeypress="return numbersonly(event);"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Precio Requerido" ControlToValidate="txtPrecio" ForeColor="Red" ValidationGroup="usuario"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <%-- Estado --%>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="lblEstado" class="label-control" runat="server" Text="Estado"></asp:Label>
                                <asp:DropDownList Class="dropdown-header" ID="ddlEstado" runat="server">
                                    <asp:ListItem Value="1"> Activo </asp:ListItem>
                                    <asp:ListItem Value="2"> Inactivo </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <img id="imgprw" alt="Antes de insertar" width="100px" height="100px" />
                        <asp:FileUpload ID="FileUpload1" runat="server" onchange="imagepreview(this);" />
                        <br />
                        <br />

                        <%-- Guardar --%>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Button ID="btnGuardarUsuario" Class="btn btn-primary" data-toggle="modal" data-target="#myModal" runat="server" Text="Guardar" OnClick="btnGuardarUsuario_Click" ValidationGroup="usuario" />
                                <asp:Button ID="btnCancelar" Class="btn btn-danger" runat="server" Text="Limpiar" OnClick="btnCancelar_Click" />
                            </div>
                        </div>
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="lblMensaje" class="label-control" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-8 tabla">
                    <div class="col-md-12">
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <asp:DropDownList Class="dropdown-header" ID="ddltipousuariogrid" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddltipousuariogrid_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <asp:GridView
                            DataKeyNames="PK_ID_PLATO"
                            CssClass="table table-bordered bs-table"
                            AllowPaging="true"
                            BorderColor="#999999" ID="GridPlato"
                            AutoGenerateColumns="false"
                            OnRowCancelingEdit="GridPlato_RowCancelingEdit"
                            OnRowEditing="GridPlato_RowEditing"
                            OnRowDeleting="GridPlato_RowDeleting"
                            OnRowUpdating="GridPlato_RowUpdating"
                            OnRowDataBound="GridPlato_RowDataBound" runat="server"
                            OnPageIndexChanging="GridPlato_PageIndexChanging"
                            PageSize="7">
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
                                <asp:BoundField ControlStyle-Width="120" DataField="PK_ID_PLATO" HeaderText="ID Plato" Visible="false"></asp:BoundField>
                                <asp:BoundField ControlStyle-Width="120" DataField="STR_Nombre_Plato" HeaderText="Nombre"></asp:BoundField>
                                <asp:BoundField ControlStyle-Width="120" DataField="Precio_Plato" HeaderText="Plato"></asp:BoundField>
                                <asp:TemplateField HeaderText="Tipo Plato" HeaderStyle-Width="120">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlTipoPlato" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTipoPlato" runat="server" Text='<%# Eval("TipoPlato") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado" HeaderStyle-Width="120">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlEstadoDg" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("estado") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px">
                                                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" Height="122px"
                                            ImageUrl='<%#Eval("foto")%>' Width="148px" />
                                        <br />
                                    </ItemTemplate>
                            </asp:TemplateField>
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
