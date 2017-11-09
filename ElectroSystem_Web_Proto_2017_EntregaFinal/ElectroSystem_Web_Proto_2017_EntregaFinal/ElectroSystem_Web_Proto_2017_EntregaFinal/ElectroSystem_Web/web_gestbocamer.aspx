<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_gestbocamer.aspx.vb" Inherits="ElectroSystem_Web.web_gestbocamer" %>

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
</script>
       <asp:Label ID="lbl_precioingresado" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="num_bocamercado" runat="server" onkeypress="return isNumberKey(event)" AutoPostBack="True" MaxLength="6"></asp:TextBox>
     <br>
    <asp:Label ID="lbl_bocamercado" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txt_bocamercado" runat="server" readonly="true" BackColor="#CCCCCC"></asp:TextBox>
            <br>
        <asp:Label ID="lbl_bocaempresa" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txt_bocaempresa" runat="server" ReadOnly="true" BackColor="#CCCCCC"></asp:TextBox>
        <br>
            <asp:Label ID="lbl_bocaextraordinaria" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="txt_bocaextraordinaria" runat="server" ReadOnly="true" BackColor="#CCCCCC"></asp:TextBox>
            <br>
    <asp:Button ID="btn_guardarprboca" runat="server" Text="Button"/>
</asp:Content>
