<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Cierre_proyecto.aspx.vb" Inherits="ElectroSystem_Web.Cierre_proyecto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    &nbsp;El objetivo de este prototipo es demostrar en que estado queda el proyecto y luego es tenido en cuenta como proyecto cerrado como asi tambien el porcentajes de las tareas.<asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" Text="Cierre Proyecto con Tareas 100%" />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Cierre Proyecto con Tareas sin cumplir 100%" />
    
    </div>
    </form>
</body>
</html>
