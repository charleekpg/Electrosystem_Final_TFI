<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Definicion Boca Mercado.aspx.vb" Inherits="ElectroSystem_Web.Definicion_Boca_Mercado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Precio valor boca mercado
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        Precio valor boca empresa
        <asp:Label ID="lbl_bocaempresa" runat="server" Text="Label"></asp:Label>
&nbsp;<br />
        precio valor boca extraordinaria
        <asp:Label ID="lbl_bocaextraordinaria" runat="server" Text="Label"></asp:Label>
&nbsp;<br />
        <br />
        <asp:Button ID="btn_guardar" runat="server" Text="Guardar" />
    </form>
</body>
</html>
