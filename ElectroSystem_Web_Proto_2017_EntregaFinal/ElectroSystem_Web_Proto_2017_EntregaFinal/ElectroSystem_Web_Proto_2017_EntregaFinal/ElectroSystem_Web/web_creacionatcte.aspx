<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_creacionatcte.aspx.vb" Inherits="ElectroSystem_Web.web_creacionatcte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script lang="JavaScript">
     function isNumberKey(evt) {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode < 48 || charCode > 57)
             return false;
         return true;
     }
</script>
    <asp:Label ID="lbl_codpresupuesto" runat="server" Text="lbl_budgetcode"></asp:Label>
    <asp:DropDownList ID="cmb_presupuesto" runat="server"></asp:DropDownList>
                <asp:Button ID="btn_cargar_presupuesto" runat="server" style="height: 26px" />
    <br>
    <asp:Label ID="lbl_dnicuit" runat="server"></asp:Label>
    <asp:TextBox ID="txt_dnicuit" runat="server" TextMode="Search" onkeypress="return isNumberKey(event)" MaxLength="11"></asp:TextBox>
                <asp:Button ID="btn_buscar" runat="server" style="height: 26px" />
    <asp:HiddenField ID="id" runat="server" />
    <br>
    <asp:Label ID="lbl_nombre_razonsocial" runat="server"></asp:Label>
        <asp:TextBox ID="txt_nombre_razonsocial" runat="server" ReadOnly="True"></asp:TextBox>
     <br>
       <asp:Label ID="LBL_Parti" runat="server"></asp:Label>
    <asp:DropDownList ID="cbx_parti" runat="server" AutoPostBack="True"></asp:DropDownList>
     <br>
           <asp:Label ID="LBL_Loca" runat="server"></asp:Label>
        <asp:DropDownList ID="cbx_localidad" runat="server"></asp:DropDownList>
         <br>
               <asp:Label ID="LBL_Calle" runat="server"></asp:Label>
            <asp:TextBox ID="txt_calle" runat="server" ></asp:TextBox>
             <br>
                   <asp:Label ID="LBL_Altura" runat="server"></asp:Label>
                <asp:TextBox ID="txt_altura" runat="server" onkeypress="return isNumberKey(event)" MaxLength="7"></asp:TextBox>
                 <br>
                   <asp:Label ID="lbl_piso" runat="server"></asp:Label>
                <asp:TextBox ID="txt_piso" runat="server" onkeypress="return isNumberKey(event)" MaxLength="2" ></asp:TextBox>
                <br>
                   <asp:Label ID="lbl_depto" runat="server" Text="LBL_Parti"></asp:Label>
                <asp:TextBox ID="txt_depto" runat="server" MaxLength="2" ></asp:TextBox>
                    <br>
    <asp:CheckBox ID="CHK_Country" runat="server"/>
                        <br>
                       <asp:Label ID="lbl_dibujotecnico" runat="server"></asp:Label>
    <asp:DropDownList ID="drp_dibujo" runat="server"></asp:DropDownList>
        <asp:Button ID="btn_verdibujo" runat="server"/>

                            <br>
    <asp:Button ID="btn_nuevopresu" runat="server"/>
        <asp:Button ID="btn_guardarpresu" runat="server"/>
            <asp:Button ID="btn_cancelarpresu" runat="server"/>
        <br>
        <br>
    <asp:GridView ID="dtg_ambientes" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="ambiente" FooterText="ambiente" HeaderText="ambiente" />
            <asp:BoundField DataField="sigla" FooterText="bf_sigla" HeaderText="SIGLA" />
            <asp:BoundField DataField="tipo" FooterText="bf_tipo" HeaderText="TIPO" />
            <asp:BoundField DataField="cantidad_bocas" FooterText="bf_cantidadbocas" HeaderText="CANTIDAD_BOCAS" />
            <asp:BoundField DataField="descripcion" FooterText="bf_descripcion" HeaderText="DESCRIPCION" />
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
