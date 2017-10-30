<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Armado_PresupuestoComercial.aspx.vb" Inherits="ElectroSystem_Web.Armado_PresupuestoComercial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:LinkButton ID="link_cargarpresu" runat="server">Cargar ultimo Presupuesto</asp:LinkButton>
&nbsp;CLICKEAR ESTO PRIMERO. ANTES SE TUVO QUE PASAR POR EL MODULO Armado_PresupuestoComercial<br />
        Numero de Presupuesto:
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        Valor de Mano de Obra <asp:TextBox ID="txt_valormano" runat="server"></asp:TextBox>
&nbsp;NO COMPLETAR<br />
        Valor de Materiales<asp:TextBox ID="txt_materiales" runat="server"></asp:TextBox>
        NO COMPLETAR<br />
        Valor de Trabajo con Precio estipulado<asp:TextBox ID="txt_precioestipula" runat="server"></asp:TextBox>
&nbsp;NO COMPLETAR<br />
        Precio seguro de vida<asp:TextBox ID="txt_precioseguro" runat="server"></asp:TextBox>
&nbsp;<br />
        Precio de viatico<asp:TextBox ID="txt_viatico" runat="server"></asp:TextBox>
        <br />
        Porcentaje de adelanto por luz de obra<asp:TextBox ID="txt_porcentajeadelanto" runat="server"></asp:TextBox>
        <br />
    
    </div>
    <div>
    
        Localidad Origen<asp:DropDownList ID="drp_origen" runat="server">
        </asp:DropDownList>
        &nbsp;<br />
        Localidad Destino<asp:DropDownList ID="drp_destino" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        Distancia en KM:
        <asp:Label ID="lbl_distancia" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btn_guardarcalcular" runat="server" Text="Guardar y Calcular" />
    
    </div>
    </form>
</body>
</html>
