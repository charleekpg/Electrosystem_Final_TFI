﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_gestion_Clientes.aspx.vb" Inherits="ElectroSystem_Web.web_gestion_Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script lang="JavaScript">
     function isNumberKey(evt) {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode < 48 || charCode > 57)
             return false;
         return true;
     }
</script>
     <asp:RadioButton ID="RDB_personaFisica" runat="server" Checked="True" AutoPostBack="True" />
    <br>
    <asp:RadioButton ID="rdb_personaJuridica" runat="server" AutoPostBack="True" />
    <br>
     <asp:Label ID="lbl_razon" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="txt_razon" runat="server" Enabled="False"></asp:TextBox>
    <br>
    <asp:HiddenField ID="id_hiddenfield" runat="server" Visible="False" />
            <asp:Label ID="lbl_nombre" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txt_nombre" runat="server" Enabled="False" MaxLength="20"></asp:TextBox>
        <br>
                <asp:Label ID="lbl_apellido" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="txt_apellido" runat="server" Enabled="False" MaxLength="20" ></asp:TextBox>
            <br>
                    <asp:Label ID="lbl_cuit" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="txt_cuit" runat="server" Enabled="False" onkeypress="return isNumberKey(event)" MaxLength="11"></asp:TextBox>
                <br>
                        <asp:Label ID="lbl_dni" runat="server" Text="Label"></asp:Label>
                    <asp:TextBox ID="txt_dni" runat="server" onkeypress="return isNumberKey(event)" MaxLength="8"></asp:TextBox>
                    <br>
                            <asp:Label ID="lbl_correo" runat="server" Text="Label"></asp:Label>
                        <asp:TextBox ID="txt_correoelectronico" runat="server" Enabled="False" MaxLength="40"></asp:TextBox>
                        <br>
                                <asp:Label ID="lbl_telefono" runat="server" Text="Label"></asp:Label>
                            <asp:TextBox ID="txt_telefono" runat="server" Enabled="False" onkeypress="return isNumberKey(event)" MaxLength="12"></asp:TextBox>
    <asp:Button ID="btn_agregartel" runat="server" Text="+" Enabled="False" Height="24px" Width="24px" />
    <asp:ListBox ID="dtg_telefonos" runat="server" AutoPostBack="True"></asp:ListBox>
        <asp:Button ID="btn_deseleccionar" runat="server" Enabled="False" />

    <br>
    <asp:CheckBox ID="chk_clienteespecia" runat="server" Enabled="False" />
            <br>
    <asp:Button ID="btn_nuevo" runat="server" Text="Button" />
<asp:Button ID="btn_guardarcte" runat="server" Text="Button" Enabled="False" />
<asp:Button ID="btn_cancelarcte" runat="server" Text="Button" Enabled="False" />
    <asp:Button ID="btn_buscarcte" runat="server" Text="Button" />

</asp:Content>