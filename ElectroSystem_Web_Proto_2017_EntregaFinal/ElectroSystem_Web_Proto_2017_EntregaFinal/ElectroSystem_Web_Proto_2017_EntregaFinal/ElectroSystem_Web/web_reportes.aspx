<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_reportes.aspx.vb" Inherits="ElectroSystem_Web.web_reportes" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:panel ID="grp_top5" runat="server">
        <asp:Label ID="lbl_top5" runat="server" Text="Label"></asp:Label>
              <br>
        <asp:DropDownList ID="cbx_top5" runat="server" AutoPostBack="True"></asp:DropDownList>
         <br>
        <br>
        <asp:Chart ID="chart_top5" runat="server" BackColor="230, 230, 230" BorderlineColor="Transparent">
            <Series>
                <asp:Series Name="Series1" ChartType="Pie" Legend="Legend1"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" BackColor="230, 230, 230"></asp:ChartArea>
            </ChartAreas>
            <Legends>
                <asp:Legend Name="Legend1" BackColor="230, 230, 230">
                </asp:Legend>
            </Legends>
        </asp:Chart>
             <br>
        <br>
    </asp:Panel>
    <asp:Panel ID="grp_clicritico" runat="server">
       <asp:CheckBox ID="chk_fechadesde" runat="server" AutoPostBack="True" />
              <br>
                   <asp:TextBox ID="dtp_fechadesde" runat="server" TextMode="Date"></asp:TextBox>
        <br>
        <asp:CheckBox ID="chk_fechahasta" runat="server" />
              <br>          
         <asp:TextBox ID="dtp_fechahasta" runat="server" TextMode="Date"></asp:TextBox>
        <br>
        <asp:RadioButton ID="rdb_valor" runat="server" AutoPostBack="True" />
        <asp:RadioButton ID="rdb_cantidadpre" runat="server" AutoPostBack="True" />
        <br>
        <asp:Button ID="btn_clientecrit" runat="server" Text="Button" />
        <br> 
        <asp:Chart ID="chart_clicritico" runat="server" BackColor="230, 230, 230">
            <Series>
                <asp:Series Name="Series1" IsVisibleInLegend="False" LabelBackColor="224, 224, 224" LabelForeColor="Silver" Legend="Legend1"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" BackColor="230, 230, 230"></asp:ChartArea>
            </ChartAreas>
            <Legends>
                <asp:Legend Name="Legend1" BackColor="230, 230, 230">
                </asp:Legend>
            </Legends>
        </asp:Chart>
        <br>
        
    </asp:Panel>
</asp:Content>
