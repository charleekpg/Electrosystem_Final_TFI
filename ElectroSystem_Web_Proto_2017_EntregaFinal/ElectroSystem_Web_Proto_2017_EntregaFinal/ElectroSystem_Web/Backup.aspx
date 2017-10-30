<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Backup.aspx.vb" Inherits="ElectroSystem_Web.Backup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Nombre de Backup
        <asp:TextBox ID="txt_nombrebackup" runat="server"></asp:TextBox>
        <br />
        Directorio<asp:TextBox ID="txt_directorio" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btn_backup" runat="server" Text="Hacer Backup" />
        <br />
        <br />
        Directorio Restore<br />
        <asp:Label ID="lblBakcup" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Black" Text="BackUp"></asp:Label>
        <asp:DropDownList ID="cmbBackups" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Black">
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnRestaurar" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Black" Text="Restaurar" />
        <br />
    
    </div>
    </form>
</body>
</html>
