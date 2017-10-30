<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_permisos.aspx.vb" Inherits="ElectroSystem_Web.web_permisos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbl_permiso" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="txtpermiso" runat="server"></asp:TextBox>
    <br>
    <br>
    <asp:Button ID="btn_nuevo" runat="server" Text="Button" />
    <asp:Button ID="btn_guardar" runat="server" Text="Button" />
    <asp:Button ID="btn_eliminar" runat="server" Text="Button" />
    <asp:Button ID="btn_cancelar" runat="server" Text="Button" />
    <br>
        <asp:Label ID="lbl_roles_modificables" runat="server" Text="Label"></asp:Label>

    <asp:ListBox ID="lst_roles_modificables" runat="server" AutoPostBack="True"></asp:ListBox>
    <br>
     <br>
     <br>
            <asp:Label ID="lbl_patentes" runat="server" Text="Label"></asp:Label>
    <asp:ListBox ID="lst_patentes" runat="server" SelectionMode="Multiple" AutoPostBack="False"></asp:ListBox>
     <br>
               <asp:Label ID="lbl_roles" runat="server" Text="Label"></asp:Label>
     <asp:ListBox ID="lst_roles" runat="server" SelectionMode="Multiple"></asp:ListBox>
</asp:Content>
