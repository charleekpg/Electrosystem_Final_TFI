<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_evaluplano.aspx.vb" Inherits="ElectroSystem_Web.web_evaluplano" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script lang="JavaScript">
     function isNumberKey(evt) {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode == 44 && evt.srcElement.value.split(',').length > 1) { return false; };
         if (charCode != 44 && charCode > 31
           && (charCode < 48 || charCode > 57))
             return false;
         if (charCode == 45) return false;
         return true;
     }

     function isNumberint(evt) {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode < 48 || charCode > 57)
             return false;
         if (charCode == 45) return false;

         return true;
     }
</script>
    <asp:Label ID="lbl_numeroambiente" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:TextBox ID="txt_numeroambiente" runat="server" ReadOnly="true" Visible="False"></asp:TextBox>
    <br>
        <asp:Label ID="lbl_tipoambiente" runat="server" Text="Label"></asp:Label>
    <asp:DropDownList ID="drp_ambiente" runat="server"></asp:DropDownList>
     <br>
        <asp:Label ID="lbl_m2" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txt_m2" runat="server" Enabled="False" onkeypress="return isNumberKey(event)" MaxLength="8"></asp:TextBox>
        <br>
            <asp:Label ID="lbl_circiluminacion" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="txt_circiluminacion" runat="server" Enabled="False" onkeypress="return isNumberint(event)" MaxLength="3"></asp:TextBox>
    <asp:CheckBox ID="chk_circiluminacion" runat="server" AutoPostBack="True" />
      <br>
                <asp:Label ID="lbl_circtomacorriente" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="txt_circtomacorriente" runat="server" Enabled="False" onkeypress="return isNumberint(event)" MaxLength="3"></asp:TextBox>
        <asp:CheckBox ID="chk_circtomacorriente" runat="server" AutoPostBack="True" />

      <br>
                    <asp:Label ID="lbl_circiluminaespecial" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="txt_circiluminaespecial" runat="server" Enabled="False" onkeypress="return isNumberint(event)" MaxLength="3"></asp:TextBox>
            <asp:CheckBox ID="chk_circiluminaespecial" runat="server" AutoPostBack="True" />

    <br>
                        <asp:Label ID="lbl_circtomacorrienteespecial" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="txt_circtomacorrienteespecial" runat="server" Enabled="False" onkeypress="return isNumberint(event)" MaxLength="3"></asp:TextBox>
                <asp:CheckBox ID="chk_circtomacorrienteespecial" runat="server" AutoPostBack="True" />

    <br>
            <asp:Label ID="lbl_cantcirciluminacion" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="txt_cantcirciluminacion" runat="server" Enabled="False" onkeypress="return isNumberint(event)" MaxLength="3"></asp:TextBox>

      <br>
                <asp:Label ID="lbl_cantcirctomacorriente" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="txt_cantcirctomacorriente" runat="server" Enabled="False" onkeypress="return isNumberint(event)" MaxLength="3"></asp:TextBox>

      <br>
                    <asp:Label ID="lbl_cantcirciluminaespecial" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="txt_cantcirciluminaespecial" runat="server" Enabled="False" onkeypress="return isNumberint(event)" MaxLength="3"></asp:TextBox>
    <br>
                        <asp:Label ID="lbl_cantcirctomacorrienteespecial" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="txt_cantcirctomacorrienteespecial" runat="server" Enabled="False" onkeypress="return isNumberint(event)" MaxLength="3"></asp:TextBox>
    <br>
        <asp:Button ID="btn_nuevo" runat="server" Text="Button" />

    <asp:Button ID="btnambiente_agregar" runat="server" Text="Button" />
        <asp:Button ID="btn_evaluarplano" runat="server" Text="Button" />
    <asp:Button ID="btn_guardardibujo" runat="server" Text="Button" />
            <asp:Button ID="btn_cancelar" runat="server" Text="Button" />
        <br>
       <br>
    <asp:GridView ID="dtg_ambientes" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="tipo" FooterText="tipo" HeaderText="tipo" />
            <asp:BoundField DataField="metroscuadrados" FooterText="metroscuadrados" HeaderText="metroscuadrados" />
            <asp:BoundField DataField="circuitodeiluminacion" FooterText="circuitodeiluminacion" HeaderText="circuitodeiluminacion" />
            <asp:BoundField DataField="cantidadcircuitosdeiluminacion" FooterText="cantidadcircuitosdeiluminacion" HeaderText="cantidadcircuitosdeiluminacion" />
            <asp:BoundField DataField="circuitodeiluminacionespecial" FooterText="circuitodeiluminacionespecial" HeaderText="circuitodeiluminacionespecial" />
            <asp:BoundField DataField="cantidadcircuitodeiluminacionespecial" FooterText="cantidadcircuitodeiluminacionespecial" HeaderText="cantidadcircuitodeiluminacionespecial" />
            <asp:BoundField DataField="circuitodetomacorriente" FooterText="circuitodetomacorriente" HeaderText="circuitodetomacorriente" />
            <asp:BoundField DataField="cantidadcircuitodetomacorriente" FooterText="cantidadcircuitodetomacorriente" HeaderText="cantidadcircuitodetomacorriente" />
            <asp:BoundField DataField="circuitodetomacorrienteespecial" FooterText="circuitodetomacorrienteespecial" HeaderText="circuitodetomacorrienteespecial" />
            <asp:BoundField DataField="cantidadcircuitodetomacorrienteespecial" FooterText="cantidadcircuitodetomacorrienteespecial" HeaderText="cantidadcircuitodetomacorrienteespecial" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
       <br>
    <br>
    <asp:Label ID="lbl_ambiente_anotacion" runat="server" Text=""></asp:Label>
    <br>
    <asp:GridView ID="dtg_evaluarplano" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField FooterText="ambiente" HeaderText="ambiente" DataField="ambiente" />
            <asp:BoundField FooterText="bf_sigla" HeaderText="SIGLA" DataField="sigla" />
            <asp:BoundField FooterText="bf_tipo" HeaderText="TIPO" DataField="tipo" />
            <asp:BoundField FooterText="bf_cantidadbocas" HeaderText="CANTIDAD_BOCAS" DataField="cantidad_bocas" />
            <asp:BoundField FooterText="bf_descripcion" HeaderText="DESCRIPCION" DataField="descripcion" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:GridView>

</asp:Content>
