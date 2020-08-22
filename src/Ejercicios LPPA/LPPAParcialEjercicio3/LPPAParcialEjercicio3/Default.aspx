<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LPPAParcialEjercicio3._Default" %>

<!DOCTYPE html>
<html>
    <head runat="server">
        <title>Financiera</title>
        <script>
            function verificar() {
                var form = document.getElementById("form1");
                var apellido = form.apellido.value;
                var edad = form.edad.value;
                var sueldo = form.sueldo.value;

                if (apellido == "" && edad == "") {
                    alert("Debe ingresar correctamente los datos");
                    form.apellido.focus();
                    return;
                }

                if (apellido !== "" && edad == "") {
                    alert("Hola " + apellido + ", debe ingresar su edad");
                    form.edad.focus();
                    return;
                }

                if (apellido == "" && edad !== "") {
                    alert("Debe ingresar su apellido");
                    form.apellido.focus();
                    return;
                }

                if (sueldo == "") {
                    alert("Debe ingresar un rango de sueldo");
                    form.sueldo.focus();
                    return false;
                }

                form.submit();
            }
        </script>
    </head>
    <body>
        <form id="form1" method="post" action="calcprestamo.aspx">
            <div>
                Ingrese su apellido<br />
                <input type="text" name="apellido" id="apellido" />
            </div>
            <br />
            <div>
                Ingrese su edad<br />
                <input type="text" name="edad" id="edad" size="20" />
            </div>
            <br />
            <div>
                ¿Cuál es el rango en que se encuentra su sueldo?<br />
                <select id="sueldo" name="sueldo">
                    <option value="">Seleccione el rango...</option>
                    <option value="A">Menor o igual a $36000</option>
                    <option value="B">Entre $36001 y $72000</option>
                    <option value="C">Mayor a $72000</option>
                </select>
            </div>            
            <br />
            <input type="button" value="Verificar y enviar" onclick="javascript:verificar();" />
        </form>
    </body>
</html>
