<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.master" CodeBehind="Web_Backup.aspx.vb" Inherits="ElectroSystem_Web.Web_Backup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbl_nombrebackup" runat="server" Text="lbl_nombrebackup"></asp:Label>
<asp:DropDownList ID="drp_backups" runat="server">
</asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="btn_hacerbackup" runat="server" Text="Button" />
&nbsp;
    <asp:Button ID="btn_recupero" runat="server" Text="btn_recupero" />
</asp:Content>
