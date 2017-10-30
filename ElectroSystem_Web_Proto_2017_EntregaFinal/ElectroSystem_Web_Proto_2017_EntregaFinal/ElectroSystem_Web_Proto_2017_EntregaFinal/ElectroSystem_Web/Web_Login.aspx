<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Inicio.Master" CodeBehind="Web_Login.aspx.vb" Inherits="ElectroSystem_Web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <td colspan="2">
        <asp:Label ID="label_nombredeusuario" runat="server" Text="Label" style="height:auto; position: absolute; left: 1%"></asp:Label>
        <asp:TextBox ID="txt_usuario" runat="server" style="height:auto; position: absolute; left: 9%" MaxLength="50"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="label_contrasena" runat="server" Text="Label" style="height:auto; position: absolute; left: 1%">
        </asp:Label> <asp:TextBox ID="txt_contraseña" runat="server" TextMode="Password" style="height:auto; position: absolute; left: 9%; top: 64px;" MaxLength="15"></asp:TextBox>
        </td>
        <br />
        <br />
        <asp:Button ID="btn_ingresar" runat="server" Text="Button" style="height:auto; position: absolute; left: 1%" />
        <br />
        <br />
        <br />
        <asp:Label ID="lbl_idioma" runat="server" Text="Label" style="height:auto; position: absolute; left: 1%" ></asp:Label>
        <asp:DropDownList ID="cmb_idioma" runat="server" AutoPostBack="True" style="height:auto; position: absolute; left: 9%">
        </asp:DropDownList>
        <br />
        <br />
    </form>
</asp:Content>
