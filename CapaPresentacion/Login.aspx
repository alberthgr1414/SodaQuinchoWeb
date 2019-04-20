<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CapaPresentacion.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Soda Quincho</title>
<%--    <link rel='stylesheet' href='login/modernizr.js'>--%>
<%--    <link rel="stylesheet" href="login/style.css">--%>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/estilo.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
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
                                <h1>Usaurio y/o contraseña invalida</h1>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <%--<asp:Button ID="Button39" runat="server" Text="Aceptar" type="button" class="btn btn-primary" />--%>
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="form-container flip">
                <%--<form class="login-form" runat="server">--%>
                <h3 class="title">Bienvenido</h3>
                <div class="form-group" id="username">
                    <asp:TextBox ID="txtUsuario" runat="server" type="text" class="form-input" tooltip-class="username-tooltip" placeholder="Usuario" required="true"></asp:TextBox>
                    <span id="username-tool" class="tooltip username-tooltip">Digite el Usuario</span>
                </div>
                <div class="form-group" id="password">
                    <asp:TextBox ID="txtContrasenna" runat="server" type="password" class="form-input" tooltip-class="password-tooltip" placeholder="Password" required="true"></asp:TextBox>
                    <span class="tooltip password-tooltip">Digite la Contraseña</span>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" class="login-button" OnClick="btnIngresar_Click" />
                </div>
            </div>
        </div>
        <script src='login/jquery.min.js'></script>
        <script src='login/Chart.min.js'></script>
        <script src='login/jquery-2.1.4.min.js'></script>
        <script src="login/index.js"></script>
    </form>
</body>

</html>
