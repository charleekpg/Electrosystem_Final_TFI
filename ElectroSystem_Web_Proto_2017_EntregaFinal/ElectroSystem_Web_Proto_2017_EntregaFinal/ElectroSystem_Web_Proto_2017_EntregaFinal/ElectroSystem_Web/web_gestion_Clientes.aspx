<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_gestion_Clientes.aspx.vb" Inherits="ElectroSystem_Web.web_gestion_Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script lang="JavaScript">
        function isNumberint(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode < 48 || charCode > 57)
                return false;
            if (charCode == 45) return false;
            return true;
        }
     function soloLetras(e) {

         key = e.keyCode || e.which;
         tecla = String.fromCharCode(key).toLowerCase();
         letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
         especiales = "8-37-39-46-32";
         tecla_especial = false
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
     function isespacio(evt) {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode == 32) return false;
         return true;
     }
</script>



	
	
	
<table style="border-collapse: collapse;    border-spacing: 0;    width: 100%;    border: 0px;">
    <tr>
        <td><asp:RadioButton ID="RDB_personaFisica" runat="server" Checked="True" AutoPostBack="True" /></td>
        <td>&nbsp</td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
        <tr>
        <td><asp:RadioButton ID="rdb_personaJuridica" runat="server" AutoPostBack="True" /></td>
        <td>&nbsp</td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
    <tr>
        <td><asp:Label ID="lbl_razon" runat="server" Text="Label"></asp:Label></td>
        <td><asp:TextBox ID="txt_razon" runat="server" Enabled="False" MaxLength="40" onkeypress="return soloLetras(event)"></asp:TextBox></td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
    <tr>
        <td>        
            <asp:HiddenField ID="id_hiddenfield" runat="server" Visible="False" />
            <asp:Label ID="lbl_nombre" runat="server" Text="Label"></asp:Label>
        </td>
        <td><asp:TextBox ID="txt_nombre" runat="server" Enabled="False" MaxLength="20" onkeypress="return soloLetras(event)"></asp:TextBox></td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
    <tr>
        <td><asp:Label ID="lbl_apellido" runat="server" Text="Label"></asp:Label></td>
        <td><asp:TextBox ID="txt_apellido" runat="server" Enabled="False" MaxLength="20" onkeypress="return soloLetras(event)"></asp:TextBox></td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
    <tr>
        <td><asp:Label ID="lbl_cuit" runat="server" Text="Label"></asp:Label></td>
        <td><asp:TextBox ID="txt_cuit" runat="server" Enabled="False" onkeypress="return isNumberint(event)" MaxLength="11"></asp:TextBox></td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
    <tr>
        <td><asp:Label ID="lbl_dni" runat="server" Text="Label"></asp:Label></td>
        <td><asp:TextBox ID="txt_dni" runat="server" onkeypress="return isNumberint(event)" MaxLength="8"></asp:TextBox></td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
    <tr>
        <td><asp:Label ID="lbl_correo" runat="server" Text="Label"></asp:Label></td>
        <td><asp:TextBox ID="txt_correoelectronico" runat="server" Enabled="False" MaxLength="40" onkeypress="return isespacio(event)" ></asp:TextBox></td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
    <tr>
        <td> <asp:Label ID="lbl_telefono" runat="server" Text="Label"></asp:Label></td>
        <td>
            <asp:TextBox ID="txt_telefono" runat="server" Enabled="False" onkeypress="return isNumberint(event)" MaxLength="12"></asp:TextBox>
            <asp:Button ID="btn_agregartel" runat="server" Text="+" Enabled="False" Height="24px" Width="24px" />
        </td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
    <tr>
        <td>&nbsp</td>
        <td>
            <asp:ListBox ID="dtg_telefonos" runat="server" AutoPostBack="True"></asp:ListBox>
            <br>
            <asp:Button ID="btn_deseleccionar" runat="server" Enabled="False" />
        </td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
    <tr>
        <td><asp:CheckBox ID="chk_clienteespecia" runat="server" Enabled="False" /></td>
        <td>&nbsp</td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
</table>

<br>
<asp:Button ID="btn_nuevo" runat="server" Text="Button" />
<asp:Button ID="btn_guardarcte" runat="server" Text="Button" Enabled="False" />
<asp:Button ID="btn_cancelarcte" runat="server" Text="Button" Enabled="False" />
<asp:Button ID="btn_buscarcte" runat="server" Text="Button" />

</asp:Content>
