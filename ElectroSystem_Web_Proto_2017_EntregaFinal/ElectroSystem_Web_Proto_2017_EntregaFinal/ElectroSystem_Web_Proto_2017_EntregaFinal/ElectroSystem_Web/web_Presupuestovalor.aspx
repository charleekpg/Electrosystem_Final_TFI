<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_Presupuestovalor.aspx.vb" Inherits="ElectroSystem_Web.web_Presupuestovalor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script lang="JavaScript">
     function isNumberKey(evt) {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode == 44 && evt.srcElement.value.split(',').length > 1) { return false; };
         if (charCode != 44 && charCode > 31
           && (charCode < 48 || charCode > 57))
             return false;
         if (charCode == 45) return false;
         if (charCode == 32) return false;
         return true;
     }
</script>
    <asp:Label ID="lbl_codpresupuesto" runat="server" Text="Label"></asp:Label>
    <asp:DropDownList ID="cmb_presupuesto" runat="server"></asp:DropDownList>
    <asp:Button ID="btn_cargar_presupuesto" runat="server" Text="Button" />
<br>
    <asp:Panel ID="grp_desdedonde" runat="server">
        <asp:Label ID="LBL_Parti" runat="server" Text="Label"></asp:Label>
    <asp:DropDownList ID="cbx_parti" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br>
               <asp:Label ID="LBL_Loca" runat="server" Text="Label"></asp:Label>
    <asp:DropDownList ID="cbx_localidad" runat="server"></asp:DropDownList>
        <br>
    </asp:Panel>
    <asp:Panel ID="grp_especificacionesadicionales" runat="server">
        <asp:CheckBox ID="chk_actuaindice" runat="server" />
        <br>
                <asp:CheckBox ID="chk_preciosegvida" runat="server" AutoPostBack="True" />
        <br>
                       <asp:Label ID="lbl_precsegvida" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txt_valorseg" runat="server" onkeypress="return isNumberKey(event)" MaxLength="9"></asp:TextBox>
        <br>
                <asp:CheckBox ID="chk_viatico" runat="server" AutoPostBack="True" />
        <br>
                       <asp:Label ID="lbl_precviatico" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txt_valorvia" runat="server" onkeypress="return isNumberKey(event)" MaxLength="9"></asp:TextBox>
         <br>
                <asp:CheckBox ID="chk_cobroadel" runat="server" AutoPostBack="True" />
        <br>
                       <asp:Label ID="lbl_porcadelanto" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txt_poradelanto" runat="server" onkeypress="return isNumberKey(event)" MaxLength="5"></asp:TextBox>
        <br>
        <asp:Button ID="btn_calcvaltot" runat="server" Text="Button" />   
                <asp:Button ID="btn_guardarpresucom" runat="server" Text="Button" />
           <asp:Button ID="btn_cancelarprtec" runat="server" Text="Button" />   
    </asp:Panel>
    <asp:GridView ID="grd_presupuesto_final" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="cod_presupuesto" FooterText="col_codpresupuesto" HeaderText="col_codpresupuesto" />
            <asp:BoundField DataField="nomb_ape_rs" FooterText="col_nomb_ape_rs" HeaderText="col_nomb_ape_rs" />
            <asp:BoundField DataField="valor_manoobra" FooterText="col_valormanoobra" HeaderText="col_valormanoobra" />
            <asp:BoundField DataField="valor_material" FooterText="col_valormaterial" HeaderText="col_valormaterial" />
            <asp:BoundField DataField="valor_trabajoconprecio" FooterText="col_valortrabajoconprecio" HeaderText="col_valortrabajoconprecio" />
                        <asp:BoundField DataField="valor_segurovida" FooterText="col_valorsegurovida" HeaderText="col_valorsegurovida" />

            <asp:BoundField DataField="valor_otros" FooterText="col_valorotros" HeaderText="col_valorotros" />
                        <asp:BoundField DataField="valor_total" FooterText="col_valortotal" HeaderText="col_valortotal" />

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
