<%@ Page Title="" Language="C#" MasterPageFile="~/Colaborador.Master" AutoEventWireup="true" CodeBehind="InicioCol.aspx.cs" Inherits="CapaPresentacion.InicioCol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron text-center">
  <h1>
      <% 
       Response.Write("Bienvenido " +"("+ Session["ingresar"].ToString()+")");
      %>
  </h1>
  <p>As iniciado session como Colaborador Regular!</p> 
</div>
</asp:Content>
