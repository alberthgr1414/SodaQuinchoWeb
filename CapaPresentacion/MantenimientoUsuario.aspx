<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="MantenimientoUsuario.aspx.cs" Inherits="CapaPresentacion.MantenimientoUsuario" %>

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
                            <h1>Crear Usuario</h1>
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
                                <asp:Label ID="lblTipoUsuario" class="label-control" runat="server" Text="Tipo Usuario"></asp:Label>
                                <asp:DropDownList Class="dropdown-header" ID="ddlTipoUsuario" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Tipo de Usuario Requerido" ControlToValidate="ddlTipoUsuario" ForeColor="Red" ValidationGroup="usuario"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <%-- Usuario Login --%>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="lblUsuarioLogin" class="label-control" runat="server" Text="Usuario Login"></asp:Label>
                                <asp:TextBox ID="txtUsuarioLogin" class="form-control" placeholder="Usuario Login" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Usuario Requerido" ControlToValidate="txtUsuarioLogin" ForeColor="Red" ValidationGroup="usuario"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <%-- Usuario Contraseña --%>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="Label1" class="label-control" runat="server" Text="Contraseña"></asp:Label>
                                <asp:TextBox ID="txtClave" type="password" class="form-control" placeholder="Contraseña" runat="server" pattern="(?=.*\d)(?=.*[a-záéíóúüñ]).*[A-ZÁÉÍÓÚÜÑ].*.{7,15}" title="Debe tener al menos una mayúscula, una minúscula, Mínimo 8 y Máximo 15 caracteres"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Contraseña Requerida" ControlToValidate="txtClave" ForeColor="Red" ValidationGroup="usuario"></asp:RequiredFieldValidator>
                                <!-- Password field -->
                            </div>
                        </div>
                        <%--                        <div class="row">
                            <div class="form-check">
                                <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged"  />
                            </div>
                        </div>--%>
                        <%-- Estado --%>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="lblEstado" class="label-control" runat="server" Text="Estado"></asp:Label>
                                <asp:DropDownList Class="dropdown-header" ID="ddlEstado" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Estado Requerido" ControlToValidate="ddlEstado" ForeColor="Red" ValidationGroup="usuario"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <%-- Guardar --%>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Button ID="btnGuardarUsuario" Class="btn btn-primary" data-toggle="modal" data-target="#myModal" runat="server" Text="Guardar" OnClick="btnGuardarUsuario_Click" ValidationGroup="usuario" />
                                <asp:Button ID="btnCancelar" Class="btn btn-danger" runat="server" Text="Limpiar" OnClick="btnCancelar_Click" />
                            </div>
                        </div>
                        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                        <br />
                        <%-- Inicio Ventana Modal --%>
                        <%--                        <div class="container">
                            <div class="modal fade" id="myModal" role="dialog">
                                <div class="modal-dialog">

                                    <!-- Modal content-->
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h4 class="modal-title">
                                                <% 
                                                    //object myVar;
                                                    //myVar = Request.QueryString;
                                                    if (mensaje == 0)
                                                    {
                                                        Response.Write("ERROR");
                                                    }
                                                    else {
                                                        Response.Write("BIEN");
                                                    }

                                                %>
                                                Modal Header

                                            </h4>
                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        </div>
                                        <div class="modal-body">
                                            <p>Some text in the modal.</p>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                    </div>
                </div>
                <div class="col-md-8 tabla">
                    <br />
                    <div class="col-md-12">
                        <asp:GridView
                            CssClass="table table-bordered bs-table"
                            DataKeyNames="PK_ID_USUARIO"
                            BorderColor="#999999" ID="GridUsuario"
                            AutoGenerateColumns="false"
                            OnRowCancelingEdit="GridUsuario_RowCancelingEdit"
                            OnRowEditing="GridUsuario_RowEditing"
                            OnRowDeleting="GridUsuario_RowDeleting"
                            OnRowUpdating="GridUsuario_RowUpdating"
                            OnRowDataBound="GridUsuario_RowDataBound"
                            runat="server"
                            AllowPaging="true"
                            PageSize="7" 
                            OnPageIndexChanging="GridUsuario_PageIndexChanging" OnSelectedIndexChanged="GridUsuario_SelectedIndexChanged">

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
                                <asp:BoundField ControlStyle-Width="120" DataField="PK_ID_USUARIO" HeaderText="ID USUARIO" Visible="false"></asp:BoundField>
                                <asp:BoundField ControlStyle-Width="120" DataField="STR_NOMBRE" HeaderText="Nombre"></asp:BoundField>
                                <asp:BoundField ControlStyle-Width="120" DataField="STR_USUARIO_LOGIN" HeaderText="Usuario"></asp:BoundField>
                                <asp:BoundField ControlStyle-Width="120" DataField="STR_CONTRASENA" HeaderText="Contraseña"></asp:BoundField>
                                <asp:TemplateField HeaderText="Tipo Usuario" HeaderStyle-Width="120">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlTipoUsuario" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTipoUsuario" runat="server" Text='<%# Eval("TIPO_USUARIO_DESCRIPCION") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado" HeaderStyle-Width="120">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlEstadoDg" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("ESTADO") %>'></asp:Label>
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
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


