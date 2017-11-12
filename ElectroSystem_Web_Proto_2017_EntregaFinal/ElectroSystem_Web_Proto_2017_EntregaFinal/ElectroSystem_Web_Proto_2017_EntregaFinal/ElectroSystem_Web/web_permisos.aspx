<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_permisos.aspx.vb" Inherits="ElectroSystem_Web.web_permisos" %>

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
    <asp:Label ID="lbl_permiso" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="txtpermiso" runat="server" MaxLength="20" onkeypress="return soloLetras(event)"></asp:TextBox>
    <br>
    <br>
    <asp:Button ID="btn_nuevo" runat="server" Text="Button" />
    <asp:Button ID="btn_guardar" runat="server" Text="Button" />
    <asp:Button ID="btn_eliminar" runat="server" Text="Button" />
    <asp:Button ID="btn_cancelar" runat="server" Text="Button" />
    <br>





    <table style="border-collapse: collapse;    border-spacing: 0;    width: 100%;    border: 0px;">
        <tr>
            <td>
                <asp:Label ID="lbl_roles_modificables" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:ListBox ID="lst_roles_modificables" runat="server" AutoPostBack="True"></asp:ListBox>
            </td>

            <td>
                <asp:Label ID="lbl_roles" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:ListBox ID="lst_roles" runat="server" SelectionMode="Multiple"></asp:ListBox>
            </td>

            <td>
                <asp:Label ID="lbl_patentes" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:ListBox ID="lst_patentes" runat="server" SelectionMode="Multiple" AutoPostBack="False"></asp:ListBox>
            </td>

            <td style="width: 40%;">&nbsp</td>
        </tr>
    </table>
     
</asp:Content>
