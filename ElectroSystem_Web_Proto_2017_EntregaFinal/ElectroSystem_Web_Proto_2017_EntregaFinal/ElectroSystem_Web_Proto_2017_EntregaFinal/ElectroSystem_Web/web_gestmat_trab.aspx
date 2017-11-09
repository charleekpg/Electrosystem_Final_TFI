<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_gestmat_trab.aspx.vb" Inherits="ElectroSystem_Web.web_gestarte" %>
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
       for(var i in especiales){
            if(key == especiales[i]){
                tecla_especial = true;
                break;
            }
        }
        if(letras.indexOf(tecla)==-1 && !tecla_especial){
            return false;
        }
    }
</script>
     <asp:Label ID="lbl_descripcion" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="txt_descripcion" runat="server" MaxLength="15" onkeypress="return soloLetras(event)"></asp:TextBox>
    <br>
        <asp:Label ID="lbl_precio" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="num_precio" runat="server" onkeypress="return isNumberKey(event)" MaxLength="9"></asp:TextBox>
        <br>
    <asp:RadioButton ID="rdb_material" runat="server" AutoPostBack="True" />
    <asp:RadioButton ID="rdb_trabajo" runat="server" AutoPostBack="True" />
     <br>
    <asp:GridView ID="dtg_trabajo_material" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField FooterText="ID" HeaderText="ID" Visible="False" DataField="id" ReadOnly="True" />
            <asp:BoundField FooterText="Descripcion" HeaderText="Descripcion" DataField="descripcion" />
            <asp:BoundField FooterText="Precio" HeaderText="Precio" DataField="precio" />
            <asp:BoundField FooterText="Material" HeaderText="Material" DataField="material" Visible="False"/>
            <asp:BoundField FooterText="Trabajoconprecio" HeaderText="Trabajoconprecio" DataField="Trabajoconprecio" Visible="False"/>
            <asp:BoundField FooterText="Cambiodetipo" HeaderText="Cambiodetipo" Visible="False" DataField="Cambiodetipo" />
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
        <br>
 <asp:Button ID="btn_nuevotrab" runat="server" Text="Button" />
 <asp:Button ID="btn_guardartrab" runat="server" Text="Button" />
    <asp:Button ID="btn_cancelartrab" runat="server" Text="Button" />

</asp:Content>
