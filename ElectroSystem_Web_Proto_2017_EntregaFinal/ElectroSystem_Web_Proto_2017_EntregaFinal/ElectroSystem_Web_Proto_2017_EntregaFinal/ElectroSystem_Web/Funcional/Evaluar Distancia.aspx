<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Evaluar Distancia.aspx.vb" Inherits="ElectroSystem_Web.Evaluar_Distancia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Localidad Origen<asp:DropDownList ID="drp_origen" runat="server">
        </asp:DropDownList>
        <br />
        Localidad Destino<asp:DropDownList ID="drp_destino" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        Distancia en KM:
        <asp:Label ID="lbl_distancia" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btn_calculardistancia" runat="server" Text="Calcular Distancia" />
    
    </div>
    </form>
</body>
</html>
