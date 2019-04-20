<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="InicioAdministrador.aspx.cs" Inherits="CapaPresentacion.InicioAdministrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron text-center">
  <h1>
      <% 
       Response.Write("Bienvenido " +"("+ Session["ingresar"].ToString()+")");
      %>
  </h1>
  <p>As iniciado session como Administrador!</p> 
</div>
</asp:Content>
