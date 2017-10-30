<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Evaluar Plano.aspx.vb" Inherits="ElectroSystem_Web.Evaluar_Plano" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Metros cuadrados
        <asp:TextBox ID="txt_m2" runat="server"></asp:TextBox>
        <br />
        Circuitos de Iluminacion <asp:TextBox ID="txt_ilumina" runat="server"></asp:TextBox>
        <br />
        Circuito de Toma Corriente
        <asp:TextBox ID="txt_tc" runat="server"></asp:TextBox>
        <br />
        Circuito de Iluminacion Uso Especial
        <asp:TextBox ID="txt_iluminaue" runat="server"></asp:TextBox>
        <br />
        Circuito de Toma Corriente Uso Especial
        <asp:TextBox ID="txt_tcue" runat="server"></asp:TextBox>
        <br />
        Tipo de Ambiente<asp:DropDownList ID="drp_ambiente" runat="server">
        </asp:DropDownList>
&nbsp;<br />
        Cantidad de Bocas por Circuito Toma Corriente<asp:TextBox ID="txt_bocatc" runat="server"></asp:TextBox>
        <br />
        Cantidad de Bocas por Circuito Iluminacion<asp:TextBox ID="txt_bocailumina" runat="server"></asp:TextBox>
        <br />
        Cantidad de Bocas por Circuito Iluminacion UE<asp:TextBox ID="txt_bocailuminaue" runat="server"></asp:TextBox>
        <br />
        Cantidad de Bocas por Circuito Toma Corriente Uso Especial<asp:TextBox ID="txt_bocatcue" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="btn_evaluarplano" runat="server" Text="Evaluar Plano" />
    
    </div>
    </form>
</body>
</html>
