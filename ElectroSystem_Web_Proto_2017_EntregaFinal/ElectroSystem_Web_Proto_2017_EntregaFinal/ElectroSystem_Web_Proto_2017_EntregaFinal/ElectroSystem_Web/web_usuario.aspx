<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_usuario.aspx.vb" Inherits="ElectroSystem_Web.web_usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbl_username" runat="server" Text="Label"></asp:Label><asp:TextBox ID="txt_usuario" runat="server"></asp:TextBox>
    <br>
    <asp:Label ID="lbl_password" runat="server" Text="Label"></asp:Label><asp:TextBox ID="txt_password" runat="server"></asp:TextBox>
    <br>
    <asp:CheckBox ID="chk_bloqueado" runat="server" />
<br>
    <asp:Label ID="lbl_idioma" runat="server" Text="Label"></asp:Label>
    <asp:DropDownList ID="drp_idioma" runat="server"></asp:DropDownList>
<br>
        <asp:Label ID="lbl_roles" runat="server" Text="Label"></asp:Label>
    <asp:DropDownList ID="drp_roles" runat="server"></asp:DropDownList>
    <br>

    <asp:ListBox ID="lst_users" runat="server" AutoPostBack="True"></asp:ListBox>
    <br>
    <asp:Button ID="btn_nuevous" runat="server" Text="Button" /> &nbsp; <asp:Button ID="btn_guardarus" runat="server" Text="Button" /> &nbsp; <asp:Button ID="btn_eliminar" runat="server" Text="Button" /> &nbsp; <asp:Button ID="btn_cancelarus" runat="server" Text="Button" />
</asp:Content>
