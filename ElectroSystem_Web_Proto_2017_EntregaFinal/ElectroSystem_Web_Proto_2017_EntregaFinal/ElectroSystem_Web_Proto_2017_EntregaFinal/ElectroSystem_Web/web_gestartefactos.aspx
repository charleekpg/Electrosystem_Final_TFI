<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_gestartefactos.aspx.vb" Inherits="ElectroSystem_Web.web_gestartefactos" UICulture="en-Us" Culture="en-Us"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <script lang="JavaScript">
     function isNumberKey(evt) {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode == 44 && evt.srcElement.value.split(',').length > 1) { return false; };
         if (charCode != 44 && charCode > 31
           && (charCode < 48 || charCode > 57))
             return false;
         return true;
     }
</script>

      <asp:Label ID="lbl_artefacto" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="txt_descripcionartefacto" runat="server" MaxLength="20"></asp:TextBox>
    <br>
    <asp:RadioButton ID="lbl_relacionboca" runat="server" AutoPostBack="True" />
        <asp:TextBox ID="num_relacionboca" runat="server" onkeypress="return isNumberKey(event)" MaxLength="8" ></asp:TextBox>
       <br>
      <asp:RadioButton ID="lbl_precio" runat="server" AutoPostBack="True" />
        <asp:TextBox ID="num_precio2" runat="server" onkeypress="return isNumberKey(event)" MaxLength="8"></asp:TextBox>
         <br>
    <asp:Button ID="btn_nuevoarte" runat="server" Text="Button" />
        <asp:Button ID="btn_guardararte" runat="server" Text="Button" />
        <asp:Button ID="btn_cancelararte" runat="server" Text="Button" />
           <br>
    <asp:GridView ID="dtg_artefacto" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField FooterText="ID" HeaderText="ID" Visible="False" DataField="ID" />
            <asp:BoundField FooterText="Descripcion" HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField FooterText="Relacion_Bocamercado" HeaderText="Relacion Bocamercado" DataField="Relacion_Bocamercado" DataFormatString="{0:0.00}" />
            <asp:BoundField FooterText="Precio" HeaderText="Precio" DataField="Precio" DataFormatString="{0:c}" />
            <asp:CommandField ShowCancelButton="False" ShowSelectButton="True" />
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
