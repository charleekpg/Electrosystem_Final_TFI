<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Idioma.aspx.vb" Inherits="ElectroSystem_Web.Idioma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        lovfi<asp:DropDownList ID="drp_idioma" runat="server">
        </asp:DropDownList>
&nbsp;Elegir Idioma<br />
        <asp:Button ID="btn_cambiaridioma" runat="server" style="height: 26px" Text="Cambiar Idioma" />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
