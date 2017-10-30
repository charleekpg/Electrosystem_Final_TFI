<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="ElectroSystem_Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Ingrese Nombre de usuario
        <asp:TextBox ID="txt_nombreusuario" runat="server"></asp:TextBox>
        <br />
        Ingrese contraseña
        <asp:TextBox ID="txt_contrasena" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btn_login" runat="server" Text="Ingresar" />
        <br />
        <br />
        <br />
        USUARIO: carlos2018<br />
        Pass: pepe<br />
        Fallidas: 0<br />
        <br />
        USUARIO: carlos2019<br />
        Pass: hola<br />
        Fallidas: 3<br />
        <br />
        USUARIO: carlos2020<br />
        Pass: pepe2<br />
        Fallidas: 2<br />
        <br />
    
    </div>
    </form>
</body>
</html>
