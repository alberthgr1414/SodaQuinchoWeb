<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prueba2.aspx.cs" Inherits="CapaPresentacion.Prueba2" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8" />
    <title>Ejemplo de seleccionar una fecha con jquery-ui</title>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
 
    <script>
    $(function() {
        $("#fecha").datepicker(
            {
                dateFormat: "dd/mm/yy",
                dayNames: [ "Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado" ],
                dayNamesMin: [ "Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa" ],
                firstDay: 1,
                gotoCurrent: true,
                monthNames: [ "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Deciembre" ]
            }
        );
    });
    </script>
 
    <style>
        #fecha {width:100px;text-align:center;}
    </style>
</head>
<body>
 
<h1>Ejemplo de seleccionar una fecha con jquery-ui</h1>
 
<form>
    <p>Fecha: <input type="text" name="fecha" id="fecha" value=""></p>
</form>
 
<nav>
    Mas información: <a href="http://api.jqueryui.com/datepicker/" target="_blank">http://api.jqueryui.com/datepicker/</a>
    <p><a href="http://www.lawebdelprogramador.com/" target="_blank">http://www.lawebdelprogramador.com/</a></p>
</nav>
 
</body>
</html>