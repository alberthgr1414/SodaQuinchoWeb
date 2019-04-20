<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login2.aspx.cs" Inherits="CapaPresentacion.Login2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/Login2css.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <br />
    <br />
    <br />
    <div class="wrapper">
        <form class="form-signin" runat="server">
            <div class="row">
                <div class="modal fade" id="ModalFacturado" tabindex="-1" role="dialog" aria-labelledby="ModalFacturar" aria-hidden="true">
                    <div class="modal-dialog modal-sm" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h6 class="modal-title" id="ModalFacturado1">Error</h6>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div class="row justify-content-sm-center">
                                    <div class="text-center">
                                        <asp:Image ID="Image1" runat="server" Class="text-center" Height="41px" ImageUrl="~/imagen/error.png" Width="50px" heigh="50px" />
                                        <h6>Usuario o Contraseña Incorrecta</h6>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal fade" id="ModalOlvido" tabindex="-1" role="dialog" aria-labelledby="ModalOlvido" aria-hidden="true">
                    <div class="modal-dialog modal-sm" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h6 class="modal-title" id="ModalOlvido1">Olvido de Contraseña</h6>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div class="row justify-content-sm-center">
                                    <div class="text-center">
                                        <asp:Image ID="Image2" runat="server" Class="text-center" Height="41px" ImageUrl="~/imagen/success.png" Width="50px" heigh="50px" />
                                        <h5>La Contraseña fue enviada al Correo Electrocico</h5>
                                        <h6><u>jose.joaquin@gmail.com</u></h6>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <h2 class="form-signin-heading text-center">Soda Quincho</h2>
            <br />
            <asp:TextBox ID="txtUsuario" runat="server" type="text" class="form-control" tooltip-class="username-tooltip" placeholder="Usuario" required="true"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtPass" runat="server" type="password" class="form-control" tooltip-class="password-tooltip" placeholder="Password" required="true"></asp:TextBox>
            <br />
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" class="btn btn-lg btn-primary btn-block" OnClick="btnIngresar_Click" />
            <br />
            <div class="text-center">
            <%--<p><abbr title="Olvido de contraseña" class="initialism text-center">Olvido de contraseña</abbr></p>--%>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Olvido de Contraseña</asp:LinkButton>
            </div>
            <script type="text/javascript" src="js/jquery.js"></script>
            <script type="text/javascript" src="js/bootstrap.min.js"></script>
        </form>
    </div>
</body>
</html>
