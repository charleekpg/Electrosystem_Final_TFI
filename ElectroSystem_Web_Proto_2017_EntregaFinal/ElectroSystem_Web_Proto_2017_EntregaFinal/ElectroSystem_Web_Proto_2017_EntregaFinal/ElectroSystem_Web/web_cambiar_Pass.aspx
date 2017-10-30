<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_cambiar_Pass.aspx.vb" Inherits="ElectroSystem_Web.web_cambiar_Pass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbl_password" runat="server" Text="lbl_password"></asp:Label>
    <asp:TextBox ID="txt_contrasena" runat="server" TextMode="Password" MaxLength="12"></asp:TextBox>
    <asp:Button ID="btn_cambiarcontrasena" runat="server" Text="btn_cambiarpass" />
</asp:Content>
