<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Solicitud de Préstamo</title>
</head>
<body>
    <form id="form1" method="post" action="calcprestamo.aspx" runat="server">
        <div>
            <div>
                Ingrese su apellido<br />
                <asp:TextBox 
                    ID="apellido" 
                    runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RFV1"
                    text="El apellido debe llenarse"
                    controltovalidate="apellido"
                    runat="server" />
                <br />
                <asp:RegularExpressionValidator
                    id="REV1"
                    ControlToValidate="apellido"
                    text="El apellido debe ser letras, o estar escrito correctamente"
                    validationexpression="([A-Z]*[a-z]*[á]*[é]*[í]*[ó]*[ú]*[ ]*)+"
                    runat="server"/>
                <br />

                
            </div>
            <br />
            <div>
                Ingrese su edad<br />
                <asp:TextBox 
                    ID="edad" 
                    runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RFV2"
                    text="La edad debe llenarse"
                    controltovalidate="edad"
                    runat="server" />
                <br />
                <asp:RegularExpressionValidator
                    id="REV2"
                    ControlToValidate="edad"
                    text="La edad debe ser de 1 a 99 años"
                    validationexpression="[1-9][0-9]|[1-9]"
                    runat="server"/>
                <br />

            </div>
            <br />
            <div>
                ¿Cuál es el rango en que se encuentra su sueldo?<br />
                
                <asp:DropDownList 
                   ID="sueldo" 
                   runat="server">
                        <asp:listitem text="Seleccione el rango..." value="X"></asp:listitem>
                        <asp:listitem text="Menor o igual a $36000" value="A"></asp:listitem>
                        <asp:listitem text="Entre $36001 y $72000" value="B"></asp:listitem>
                        <asp:listitem text="Mayor a $72000" value="C"></asp:listitem>
                </asp:DropDownList>
               <asp:RequiredFieldValidator
                   ID="RFV3"
                   text="Seleccione un rango por favor"
                   controltovalidate="sueldo"
                   runat="server" 
                   InitialValue="X"/>
                <br />
                <br />
                <br />
                
                </div>            
            <br />
            <asp:Button 
                ID="Button1" 
                runat="server" 
                OnClick="Button1_Click" 
                Text="Verificar y Enviar" />

        </div>
    </form>
</body>
</html>
