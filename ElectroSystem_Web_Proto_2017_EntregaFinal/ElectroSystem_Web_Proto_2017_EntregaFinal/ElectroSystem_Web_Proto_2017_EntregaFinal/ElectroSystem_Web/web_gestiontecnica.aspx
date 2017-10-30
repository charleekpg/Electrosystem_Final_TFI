<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_gestiontecnica.aspx.vb" Inherits="ElectroSystem_Web.web_gestiontecnica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbl_codpresupuesto" runat="server" Text="lbl_budgetcode"></asp:Label>
    <asp:DropDownList ID="cmb_presupuesto" runat="server"></asp:DropDownList>
    <asp:Button ID="btn_cargar_presupuesto" runat="server" style="height: 26px" />
  <br>
                       <asp:Label ID="lbl_dibujotecnico" runat="server"></asp:Label>
    <asp:TextBox ID="txt_dibujotecnico" runat="server" ReadOnly="true"></asp:TextBox>
        <asp:Button ID="btn_verdibujo" runat="server"/>
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
                            <br>  
    <asp:CheckBox ID="CHK_Instaeleccomple" runat="server" />
        <asp:CheckBox ID="CHK_Depusodomigranesca" runat="server" />

    <asp:GridView ID="dtg_trabajo" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateEditButton="True">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="col_trabajo" FooterText="col_trabajo" HeaderText="col_trabajo" ReadOnly="True" />
            <asp:BoundField DataField="col_promedio" FooterText="col_promedio" HeaderText="col_promedio" ApplyFormatInEditMode="True" DataFormatString="{0:F2} %"/>
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
    <asp:Panel ID="GRPBOX_Arteelec" runat="server" GroupingText="Artefactos Eléctricos" Width="200px">
        <asp:Label ID="LBL_Arteelec" runat="server" Text="Label"></asp:Label>
        <asp:DropDownList ID="cbx_arteprtec" runat="server"></asp:DropDownList>
        <br>
        <asp:Label ID="LBL_Canti" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="num_arteprtec" runat="server" Enabled="False" onkeypress="return isNumberint(event)" MaxLength="3"></asp:TextBox>
        <br>
        <asp:Button ID="btn_addarteleprtec" runat="server" Text="Button" />
      </asp:Panel>
    <br>
     <asp:Panel ID="GRPBBOX_Mate" runat="server" GroupingText="Materiales" Width="200px">
        <asp:Label ID="LBL_Mate" runat="server" Text="Label"></asp:Label>
        <asp:DropDownList ID="cbx_matprtec" runat="server"></asp:DropDownList>
        <br>
        <asp:Label ID="LBL_Cantidad" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="num_matprtec" runat="server" Enabled="False" onkeypress="return isNumberint(event)" MaxLength="3"></asp:TextBox>
        <br>
        <asp:Button ID="btn_addmatprtec" runat="server" Text="Button" />
      </asp:Panel>
         <asp:Panel ID="GRPBox_Trabasin" runat="server" GroupingText="Trabajos" Width="200px">
        <asp:Label ID="LBL_Trabasin" runat="server" Text="Label"></asp:Label>
        <asp:DropDownList ID="cbx_trabprtec" runat="server"></asp:DropDownList>
        <br>
        <asp:Label ID="LBL_Can" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="num_trabprtec" runat="server" Enabled="False" onkeypress="return isNumberint(event)" MaxLength="3"></asp:TextBox>
        <br>
        <asp:Button ID="btn_addtrabprtec" runat="server" Text="Button" />
      </asp:Panel>
    <br>
    <asp:GridView ID="dtg_armattrabprtec" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
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
    <br>
    <asp:Button ID="btn_guardarprte" runat="server" Text="Button" />
    <asp:Button ID="btn_cancelarprtec" runat="server" Text="Button" />

</asp:Content>
