<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_bitacora.aspx.vb" Inherits="ElectroSystem_Web.web_bitacora" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <asp:CheckBox ID="chk_fechadesde" runat="server" AutoPostBack="True"/>
                <asp:TextBox ID="dtp_fechadesde" runat="server" TextMode="Date"></asp:TextBox>
  <br>
                  <asp:CheckBox ID="chk_fechahasta" runat="server" AutoPostBack="True" Enabled="False" />
           <asp:TextBox ID="dtp_fechahasta" runat="server" TextMode="Date"></asp:TextBox>
  <br>
                <asp:CheckBox ID="chk_nombredeusuario" runat="server" AutoPostBack="True" />
                <asp:DropDownList ID="cbx_usuario" runat="server" Enabled="False" Width="120px"></asp:DropDownList>
  <br>
                <asp:CheckBox ID="chk_codigodeevento" runat="server" AutoPostBack="True" />
                <asp:DropDownList ID="cbx_codigoevento" runat="server" Enabled="False" Width="120px"></asp:DropDownList>
  <br>
                <asp:Button ID="btn_buscar" runat="server" Text="Button" />
  <br>
            <div id="tabla" Class='grilla'>
                <asp:GridView ID="GVGrillaEventos" Font-Names="Verdana" Font-Size="Small" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="978px" PageSize="20" AllowPaging="True">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="usuario.ip" HeaderText="IP" FooterText="col_ip" />
                            <asp:BoundField DataField="usuario.Nombre_usuario" HeaderText="Usuario" FooterText="col_usuario" />
                            <asp:BoundField DataField="fecha_hora" HeaderText="Fecha y hora" FooterText="col_fechora" />
                            <asp:BoundField DataField="codigo_evento" HeaderText="Codigo de Evento" FooterText="col_codevento" />
                            <asp:BoundField DataField="criticidad" HeaderText="Criticidad" FooterText="col_criticidad" />
                            <asp:BoundField DataField="descripcion_evento" HeaderText="Evento" FooterText="col_evento" />
                            <asp:BoundField DataField="informacion_adicional" HeaderText="Información Adicional" FooterText="col_infoadicional" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
            </div>
            
   
</asp:Content>
