<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EjercicioIXml.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p><font size="4"><strong>Transformaciones XSLT</strong></font></p>
            <p>
                <asp:Xml ID="TransformacionXSLT" runat="server" DocumentSource="~/Banco.xml" TransformSource="XSLTFile1.xslt"></asp:Xml>
            </p>
        </div>
    </form>
</body>
</html>
