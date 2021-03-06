﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_Presupuestovalor.aspx.vb" Inherits="ElectroSystem_Web.web_Presupuestovalor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script lang="JavaScript">
     function isNumberKey(evt) {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode == 44 && evt.srcElement.value.split(',').length > 1) { return false; };
         if (charCode != 44 && charCode > 31
           && (charCode < 48 || charCode > 57))
             return false;
         if (charCode == 45) return false;
         if (charCode == 32) return false;
         return true;
     }
</script>



    <asp:Label ID="lbl_codpresupuesto" runat="server" Text="Label"></asp:Label>
    <asp:DropDownList ID="cmb_presupuesto" runat="server"></asp:DropDownList>
    <asp:Button ID="btn_cargar_presupuesto" runat="server" Text="Button" />
<br>



	<table style="border-collapse: collapse;    border-spacing: 0;    width: 100%;    border: 0px;">
        <tr>
            <td><asp:Label ID="lbl_partidoorigen" runat="server" Text="Label"></asp:Label></td>
            <td><asp:DropDownList ID="cbx_parti" runat="server" AutoPostBack="True"></asp:DropDownList></td>
            <td style="width: 60%;">&nbsp</td>
        </tr>
                <tr>
            <td>&nbsp</td>
            <td>&nbsp</td>
            <td style="width: 60%;">&nbsp</td>
        </tr>
        <tr>
            <td><asp:Label ID="lbl_localidadorigen" runat="server" Text="Label"></asp:Label></td>
            <td><asp:DropDownList ID="cbx_localidad" runat="server"></asp:DropDownList></td>
            <td style="width: 60%;">&nbsp</td>
        </tr>
                <tr>
            <td>&nbsp</td>
            <td>&nbsp</td>
            <td style="width: 60%;">&nbsp</td>
        </tr>

        <tr>
            <td><asp:CheckBox ID="chk_preciosegvida" runat="server" AutoPostBack="True" /></td>
            <td><asp:Label ID="lbl_precsegvida" runat="server" Text="Label"></asp:Label><br />$<asp:TextBox ID="txt_valorseg" runat="server" onkeypress="return isNumberKey(event)" MaxLength="9"></asp:TextBox></td>
            <td style="width: 60%;">&nbsp</td>
        </tr>
                <tr>
            <td>&nbsp</td>
            <td>&nbsp</td>
            <td style="width: 60%;">&nbsp</td>
        </tr>
        <tr>
            <td><asp:CheckBox ID="chk_viatico" runat="server" AutoPostBack="True" /></td>
            <td><asp:Label ID="lbl_precviatico" runat="server" Text="Label"></asp:Label><br />$<asp:TextBox ID="txt_valorvia" runat="server" onkeypress="return isNumberKey(event)" MaxLength="9"></asp:TextBox></td>
            <td style="width: 60%;">&nbsp</td>
        </tr>
                <tr>
            <td>&nbsp</td>
            <td>&nbsp</td>
            <td style="width: 60%;">&nbsp</td>
        </tr>
        <tr>
            <td><asp:CheckBox ID="chk_cobroadel" runat="server" AutoPostBack="True" /></td>
            <td><asp:Label ID="lbl_porcadelanto" runat="server" Text="Label"></asp:Label><br />%<asp:TextBox ID="txt_poradelanto" runat="server" onkeypress="return isNumberKey(event)" MaxLength="5"></asp:TextBox></td>
            <td style="width: 60%;">&nbsp</td>
        </tr>
                        <tr>
            <td>&nbsp</td>
            <td>&nbsp</td>
            <td style="width: 60%;">&nbsp</td>
        </tr>
                <tr>
            <td><asp:CheckBox ID="chk_actuaindice" runat="server" /></td>
            <td>&nbsp</td>
            <td style="width: 60%;">&nbsp</td>
        </tr>


	</table>
             
    <br>
    <asp:Button ID="btn_calcvaltot" runat="server" Text="Button" />   
    <asp:Button ID="btn_guardarpresucom" runat="server" Text="Button" />
    <asp:Button ID="btn_cancelarprtec" runat="server" Text="Button" />   
    <br>   	
    <br>   
    <div style="width: 70%; padding-right: 90px">
        <asp:GridView style="width: 100%;" ID="grd_presupuesto_final" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="cod_presupuesto" FooterText="col_codpresupuesto" HeaderText="col_codpresupuesto" />
                <asp:BoundField DataField="nomb_ape_rs" FooterText="col_nomb_ape_rs" HeaderText="col_nomb_ape_rs" />
                <asp:BoundField DataField="valor_manoobra" FooterText="col_valormanoobra" HeaderText="col_valormanoobra" DataFormatString="{0:c}" />
                <asp:BoundField DataField="valor_material" FooterText="col_valormaterial" HeaderText="col_valormaterial" DataFormatString="{0:c}" />
                <asp:BoundField DataField="valor_trabajoconprecio" FooterText="col_valortrabajoconprecio" HeaderText="col_valortrabajoconprecio" DataFormatString="{0:c}" />
                            <asp:BoundField DataField="valor_segurovida" FooterText="col_valorsegurovida" HeaderText="col_valorsegurovida" DataFormatString="{0:c}" />

                <asp:BoundField DataField="valor_otros" FooterText="col_valorotros" HeaderText="col_valorotros" DataFormatString="{0:c}" />
                            <asp:BoundField DataField="valor_total" FooterText="col_valortotal" HeaderText="col_valortotal" DataFormatString="{0:c}" />

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
