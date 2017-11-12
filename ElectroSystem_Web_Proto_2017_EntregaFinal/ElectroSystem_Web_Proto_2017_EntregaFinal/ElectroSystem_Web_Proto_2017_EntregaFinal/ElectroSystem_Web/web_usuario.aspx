<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_usuario.aspx.vb" Inherits="ElectroSystem_Web.web_usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <script lang="javascript">
          function isespacio(evt) {
              var charCode = (evt.which) ? evt.which : evt.keyCode;
              if (charCode == 32) return false;
              return true;
          }

</script>




	
	
	
<table style="border-collapse: collapse;    border-spacing: 0;    width: 100%;    border: 0px;">
    <tr>
        <td>
            <asp:Label ID="lbl_username" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:TextBox size="20px" ID="txt_usuario" runat="server" MaxLength="50" onkeypress="return isespacio(event)"></asp:TextBox></td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
    <tr>
        <td>&nbsp</td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lbl_password" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:TextBox size="20px" ID="txt_password" runat="server" MaxLength="50" onkeypress="return isespacio(event)"></asp:TextBox>
        </td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
    <tr>
        <td>&nbsp</td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
    <tr>
        <td><asp:CheckBox ID="chk_bloqueado" runat="server" /></td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
    <tr>
        <td>&nbsp</td>
        <td style="width: 20%;">&nbsp</td>
    </tr>


    <tr>
        <td>
            <asp:Label ID="lbl_idioma" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:DropDownList style="width:170px;" ID="drp_idioma" size="5px" runat="server"></asp:DropDownList>
        </td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
    <tr>
        <td>&nbsp</td>
        <td style="width: 20%;">&nbsp</td>
    </tr>


    <tr>
        <td>
            <asp:Label ID="lbl_roles" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:DropDownList ID="drp_roles" runat="server"></asp:DropDownList>
        </td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
    <tr>
        <td>&nbsp</td>
        <td style="width: 20%;">&nbsp</td>
    </tr>


    <tr>
        <td>
            <asp:Label ID="lbl_usuarios" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:ListBox ID="lst_users" runat="server" AutoPostBack="True"></asp:ListBox>
        </td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
    <tr>
        <td>&nbsp</td>
        <td style="width: 20%;">&nbsp</td>
    </tr>
</table>

    <br>
    <br>
    <asp:Button ID="btn_nuevous" runat="server" Text="Button" /> &nbsp; <asp:Button ID="btn_guardarus" runat="server" Text="Button" /> &nbsp; <asp:Button ID="btn_eliminar" runat="server" Text="Button" /> &nbsp; <asp:Button ID="btn_cancelarus" runat="server" Text="Button" />
</asp:Content>
