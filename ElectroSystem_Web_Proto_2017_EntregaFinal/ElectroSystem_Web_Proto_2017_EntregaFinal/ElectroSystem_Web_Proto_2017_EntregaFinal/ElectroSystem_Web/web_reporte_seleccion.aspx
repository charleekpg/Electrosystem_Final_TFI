<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_reporte_seleccion.aspx.vb" Inherits="ElectroSystem_Web.web_reporte_seleccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Label ID="lbl_codpresupuesto" runat="server" Text="Label"></asp:Label>
<asp:DropDownList ID="cmb_presupuesto" runat="server"></asp:DropDownList>
<asp:Button ID="btn_cargar_presupuesto" runat="server" Text="Button" />
    <br>
<asp:CheckBox ID="chk_valormaterial" runat="server" />
    <br>
    <asp:CheckBox ID="chk_valormano" runat="server" />
    <br>
    <asp:CheckBox ID="chk_valortrabajo" runat="server" />
    <br>
    <asp:CheckBox ID="chk_valorotros" runat="server" />
    <br>
    <asp:CheckBox ID="chk_valorsegvida" runat="server" />
    <br>
    <asp:CheckBox ID="chk_materiales" runat="server" />
    <br>
    <asp:CheckBox ID="chk_artefactos" runat="server" />
    <br>
    <asp:CheckBox ID="chk_trabajos" runat="server" />
    <br>
    <asp:CheckBox ID="chk_porcluz" runat="server" />
     <br>
    <br>
<asp:Button ID="btn_exportarrep" runat="server" Text="Button" />
    <asp:Button ID="btn_cancelar" runat="server" Text="Button" />

</asp:Content>
