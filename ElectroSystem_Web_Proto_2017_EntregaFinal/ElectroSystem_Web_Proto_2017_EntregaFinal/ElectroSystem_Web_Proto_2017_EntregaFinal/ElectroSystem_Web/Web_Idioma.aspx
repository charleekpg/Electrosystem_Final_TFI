<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="Web_Idioma.aspx.vb" Inherits="ElectroSystem_Web.Web_Idioma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script lang="javascript">
function soloLetras(e) {

       key = e.keyCode || e.which;
       tecla = String.fromCharCode(key).toLowerCase();
       letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
       especiales = "8-37-39-46-32";
       tecla_especial = false;
       if (e.keyCode == 32) return false;
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
    <asp:Label ID="lbl_idioma" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="txt_idioma"  runat="server" Enabled="False" MaxLength="10" onkeypress="return soloLetras(event)" onblur="limpia()" ></asp:TextBox>
    <br>
    <br>
    <asp:Button ID="btn_nuevo" runat="server" Text="Button" OnClientClick="confirmar();"/>
    <asp:Button ID="btn_guardar" runat="server" Text="Button" OnClientClick="confirmar();"/>
    <asp:Button ID="btn_eliminar" runat="server" Text="Button" OnClientClick="confirmar();"/>
    <asp:Button ID="btn_cancelar" runat="server" Text="Button" OnClientClick="confirmar();"/>
    <br>
    <br>
        <asp:Label ID="lbl_idiomasensist" runat="server" Text="Label"></asp:Label>
    <asp:DropDownList ID="drp_idioma" runat="server" AutoPostBack="True">
    </asp:DropDownList>
    <br>
    <br>
<div style="width: 70%; padding-right: 90px">
    <asp:GridView style="width: 100%;" ID="grilla_carga" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateEditButton="True" AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField FooterText="id_control" HeaderText="id_control" ReadOnly="True" DataField="id_control" />
            <asp:BoundField FooterText="nombre_traduccion" HeaderText="nombre_traduccion" ApplyFormatInEditMode="True" DataField="nombre_traduccion" />
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
</div>       
</asp:Content>

