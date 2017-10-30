<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Especificar_Fecha.aspx.vb" Inherits="ElectroSystem_Web.Especificar_Fecha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        TODO SERÁ ASI, SOLO SE DISTINGUE PARA MOSTRAR EL FUNCIONAMIENTO DEL ALGORITMO CON UNO Y CON OTRO<br />
        <br />
        Fecha Inicio<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        <br />
        Fecha final calculada<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Calcular con cantidad de bocas similar" />
&nbsp;&nbsp;&nbsp; ACA CON 13 BOCAS!! AGARRA PARA CALCULAR LOS QUE TIENE 13 BOCAS<br />
        <asp:Button ID="btn_sindatos" runat="server" Text="Calcular con limite superior inferior bocas" />
&nbsp;ACA CON 27 BOCAS (USA EL DE 26 BOCAS)<br />
        <asp:Button ID="btn_sindatos0" runat="server" Text="Calcular sin datos previos" />
&nbsp;ACA SE LE PONE UNA BOCA NO TIENE DATOS ASOCIADOS.
    
    </div>
    </form>
</body>
</html>
