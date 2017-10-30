<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Armado_PresupuestoTecnico.aspx.vb" Inherits="ElectroSystem_Web.Armado_PresupuestoTecnico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        &nbsp;
        <asp:LinkButton ID="link_cargarpresu" runat="server">Cargar ultimo Presupuesto</asp:LinkButton>
&nbsp;CLICKEAR ESTO PRIMERO. ANTES SE TUVO QUE PASAR POR EL MODULO Creacion AT Cliente<br />
        Numero de Presupuesto:
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:LinkButton ID="lnk_cargardibujo" runat="server">Cargar Dibujo tecnico</asp:LinkButton>
&nbsp;CLICKEAR ESTO SEGUNDO. ANTES SE TUVO QUE PASAR POR EL MODULO EVALUAR PLANO<br />
        <br />
        <asp:CheckBox ID="chk_deptogranescala" runat="server" Text="Departamento para uso domiciliario a gran escala" />
    
        <asp:CheckBox ID="chk_instalacioncompleja" runat="server" Text="Instalacion Compleja" />
        <br />
        <asp:GridView ID="grd_tareas" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        &quot;ESTO PERMANECE ESTATICO A LOS FINES DEL PROTOTIPO PERO EL USUARIO PODRÁ INGRESAR LOS PORCENTAJES QUE DESEE&quot;
        <br />
        <br />
        Artefacto Electrico <asp:DropDownList ID="drp_artefacto" runat="server">
        </asp:DropDownList>
        <br />
        Cantidad<asp:TextBox ID="txt_artefacto" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Button ID="btn_artefacto" runat="server" Text="Agregar Artefacto" />
        <br />
        Materiales<asp:DropDownList ID="drp_material" runat="server">
        </asp:DropDownList>
        <br />
        Cantidad<asp:TextBox ID="txt_cantidad" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btn_material" runat="server" Text="Agregar Material" />
        <br />
        Trabajo Con precio Estipulado<asp:DropDownList ID="drp_trabajoconprecio" runat="server">
        </asp:DropDownList>
        <br />
        Cantidad<asp:TextBox ID="txt_trabajoconprecio" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btn_trabajo" runat="server" Text="Agregar trabajo" />
        <br />
        <br />
        <asp:GridView ID="grd_artefactos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <br />
        <asp:Button ID="btn_guardar" runat="server" Text="Guardar" />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
