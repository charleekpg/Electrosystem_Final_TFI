<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_cambiar_Pass.aspx.vb" Inherits="ElectroSystem_Web.web_cambiar_Pass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
             <script lang="javascript">
          function isespacio(evt) {
              var charCode = (evt.which) ? evt.which : evt.keyCode;
              if (charCode == 32) return false;
              return true;
          }

</script>
     <asp:Label ID="lbl_password" runat="server" Text="lbl_password"></asp:Label>
    <asp:TextBox ID="txt_contrasena" runat="server" TextMode="Password" MaxLength="50" onkeypress="return isespacio(event)"></asp:TextBox>
    <asp:Button ID="btn_cambiarcontrasena" runat="server" Text="btn_cambiarpass" />
</asp:Content>
