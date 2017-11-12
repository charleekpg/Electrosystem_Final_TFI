<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_gestartefactos.aspx.vb" Inherits="ElectroSystem_Web.web_gestartefactos" UICulture="en-Us" Culture="en-Us"%>
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
     function soloLetras(e) {

         key = e.keyCode || e.which;
         tecla = String.fromCharCode(key).toLowerCase();
         letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
         especiales = "8-37-39-46-32";
         tecla_especial = false;
         for (var i in especiales) {
             if (key == especiales[i]) {
                 tecla_especial = true;
                 break;
             }
         }
         if (letras.indexOf(tecla) == -1 && !tecla_especial) {
             return false;
         }
     }
</script>


<table style="border-collapse: collapse;    border-spacing: 0;    width: 100%;    border: 0px;">
    <tr>
        <td><asp:Label ID="lbl_artefacto" runat="server" Text="Label"></asp:Label></td>
        <td><asp:TextBox ID="txt_descripcionartefacto" runat="server" MaxLength="20" onkeypress="return soloLetras(event)"></asp:TextBox></td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
    <tr>
        <td><asp:RadioButton ID="lbl_relacionboca" runat="server" AutoPostBack="True" /></td>
        <td><asp:TextBox ID="num_relacionboca" runat="server" onkeypress="return isNumberKey(event)" MaxLength="8" ></asp:TextBox></td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
    <tr>
        <td><asp:RadioButton ID="lbl_precio" runat="server" AutoPostBack="True" /></td>
        <td><asp:TextBox ID="num_precio2" runat="server" onkeypress="return isNumberKey(event)" MaxLength="8"></asp:TextBox></td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
</table>      
        
    <br>
    <asp:Button ID="btn_nuevoarte" runat="server" Text="Button" />
    <asp:Button ID="btn_guardararte" runat="server" Text="Button" />
    <asp:Button ID="btn_cancelararte" runat="server" Text="Button" />
    <br><br>
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
