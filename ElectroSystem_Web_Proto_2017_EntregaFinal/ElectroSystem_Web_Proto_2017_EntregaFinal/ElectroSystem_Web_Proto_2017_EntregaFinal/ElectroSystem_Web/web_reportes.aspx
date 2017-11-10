<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_reportes.aspx.vb" Inherits="ElectroSystem_Web.web_reportes" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:panel ID="grp_top5" runat="server">
        <asp:Label ID="lbl_top5" runat="server" Text="Label"></asp:Label>
        <asp:DropDownList ID="cbx_top5" runat="server"></asp:DropDownList>
         <br>
        <asp:Chart ID="chart_top5" runat="server">
            <Series>
                <asp:Series Name="Series1"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
             <br>
        <br>
    </asp:Panel>
    <asp:Panel ID="grp_clicritico" runat="server">
       <asp:CheckBox ID="chk_fechadesde" runat="server" AutoPostBack="True" />
                   <asp:TextBox ID="dtp_fechadesde" runat="server" TextMode="Date"></asp:TextBox>
        <br>
        <asp:CheckBox ID="chk_fechahasta" runat="server" />
                   <asp:TextBox ID="dtp_fechahasta" runat="server" TextMode="Date"></asp:TextBox>
        <br>
        <asp:RadioButton ID="rdb_valor" runat="server" />
        <asp:RadioButton ID="rdb_cantidadpre" runat="server" />
        <br>
        <asp:Button ID="btn_clientecrit" runat="server" Text="Button" />
        <br> 
        <asp:Chart ID="chart_clicritico" runat="server">
            <Series>
                <asp:Series Name="Series1" IsVisibleInLegend="False" LabelBackColor="224, 224, 224" LabelForeColor="Silver"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <br>
        
    </asp:Panel>
</asp:Content>
