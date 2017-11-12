<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Electrosystem.Master" CodeBehind="web_creacionatcte.aspx.vb" Inherits="ElectroSystem_Web.web_creacionatcte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script lang="JavaScript">
         function isNumberint(evt) {
             var charCode = (evt.which) ? evt.which : evt.keyCode;
             if (charCode < 48 || charCode > 57)
                 return false;
             if (charCode == 45) return false;
             return true;
         }
         function soloLetras(e) {

             key = e.keyCode || e.which;
             tecla = String.fromCharCode(key).toLowerCase();
             letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
             especiales = "8-37-39-46-32";
             tecla_especial = false;
             if (charCode == 32) return false;

             for (var i in especiales) {
                 if (key == especiales[i]) {
                     tecla_especial = true;
                     break;
                 }
             }
             if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                 return false;
             }
         }

</script>



	<table style="border-collapse: collapse;    border-spacing: 0;    width: 100%;    border: 0px;">

    <tr>
        <td>
            <asp:Label ID="lbl_codpresupuesto" runat="server" Text="lbl_budgetcode"></asp:Label>
            <br />
            <asp:DropDownList ID="cmb_presupuesto" runat="server"></asp:DropDownList>
            <asp:Button ID="btn_cargar_presupuesto" runat="server" style="height: 26px" />
        </td>
        <td>&nbsp</td>
        <td style="width: 60%;">&nbsp</td>
    </tr>

    <tr>
        <td><asp:HiddenField ID="id" runat="server" />&nbsp</td>
        <td>&nbsp</td>
        <td style="width: 60%;">&nbsp</td>
    </tr>

    <tr>
        <td>
            <asp:Label ID="lbl_dnicuit" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="txt_dnicuit" runat="server" TextMode="Search" onkeypress="return isNumberint(event)" MaxLength="11"></asp:TextBox>
            <asp:Button ID="btn_buscar" runat="server" style="height: 26px" />
        </td>
        <td>&nbsp</td>
        <td style="width: 60%;">&nbsp</td>
    </tr>

    <tr>
        <td>&nbsp</td>
        <td>&nbsp</td>
        <td style="width: 60%;">&nbsp</td>
    </tr
    <tr>
        <td><asp:Label ID="lbl_nombre_razonsocial" runat="server"></asp:Label></td>
        <td><asp:TextBox ID="txt_nombre_razonsocial" runat="server" ReadOnly="True"></asp:TextBox></td>
        <td style="width: 60%;">&nbsp</td>
    </tr>

    <tr>
        <td>&nbsp</td>
        <td>&nbsp</td>
        <td style="width: 60%;">&nbsp</td>
    </tr
    <tr>
        <td><asp:Label ID="LBL_Parti" runat="server"></asp:Label></td>
        <td><asp:DropDownList style="width:170px;" ID="cbx_parti" runat="server" AutoPostBack="True"></asp:DropDownList></td>
        <td style="width: 60%;">&nbsp</td>
    </tr>

           
        
    <tr>
        <td>&nbsp</td>
        <td>&nbsp</td>
        <td style="width: 60%;">&nbsp</td>
    </tr
    <tr>
        <td><asp:Label ID="LBL_Loca" runat="server"></asp:Label></td>
        <td><asp:DropDownList style="width:170px;" ID="cbx_localidad" runat="server"></asp:DropDownList></td>
        <td style="width: 60%;">&nbsp</td>
    </tr>   
    
    <tr>
        <td>&nbsp</td>
        <td>&nbsp</td>
        <td style="width: 60%;">&nbsp</td>
    </tr
    <tr>
        <td><asp:Label ID="LBL_Calle" runat="server"></asp:Label></td>
        <td><asp:TextBox ID="txt_calle" runat="server" ></asp:TextBox></td>
        <td style="width: 60%;">&nbsp</td>
    </tr>     

    <tr>
        <td>&nbsp</td>
        <td>&nbsp</td>
        <td style="width: 60%;">&nbsp</td>
    </tr>
    <tr>
        <td><asp:Label ID="LBL_Altura" runat="server"></asp:Label></td>
        <td><asp:TextBox ID="txt_altura" runat="server" onkeypress="return isNumberint(event)" MaxLength="7"></asp:TextBox></td>
        <td style="width: 60%;">&nbsp</td>
    </tr>   

    <tr>
        <td>&nbsp</td>
        <td>&nbsp</td>
        <td style="width: 60%;">&nbsp</td>
    </tr>
    <tr>
        <td><asp:Label ID="lbl_piso" runat="server"></asp:Label></td>
        <td><asp:TextBox ID="txt_piso" runat="server" onkeypress="return isNumberint(event)" MaxLength="2" ></asp:TextBox></td>
        <td style="width: 60%;">&nbsp</td>
    </tr> 

    <tr>
        <td>&nbsp</td>
        <td>&nbsp</td>
        <td style="width: 60%;">&nbsp</td>
    </tr>
    <tr>
        <td><asp:Label ID="lbl_depto" runat="server" Text="LBL_Parti"></asp:Label></td>
        <td><asp:TextBox ID="txt_depto" runat="server" MaxLength="2" onkeypress="return soloLetras(event)"  ></asp:TextBox></td>
        <td style="width: 60%;">&nbsp</td>
    </tr> 

    <tr>
        <td>&nbsp</td>
        <td>&nbsp</td>
        <td style="width: 60%;">&nbsp</td>
    </tr>
    <tr>
        <td><asp:CheckBox ID="CHK_Country" runat="server"/></td>
        <td>&nbsp</td>
        <td style="width: 60%;">&nbsp</td>
    </tr> 

    <tr>
        <td>&nbsp</td>
        <td>&nbsp</td>
        <td style="width: 60%;">&nbsp</td>
    </tr>
    <tr>
        <td><asp:Label ID="lbl_dibujotecnico" runat="server"></asp:Label></td>
        <td><asp:DropDownList ID="drp_dibujo" runat="server"></asp:DropDownList><asp:Button ID="btn_verdibujo" runat="server"/></td>
        <td style="width: 60%;">&nbsp</td>
    </tr> 



</table>
	


                       


                            <br>
    <asp:Button ID="btn_nuevopresu" runat="server"/>
        <asp:Button ID="btn_guardarpresu" runat="server"/>
            <asp:Button ID="btn_cancelarpresu" runat="server"/>
        <br>
        <br>
    <asp:GridView ID="dtg_ambientes" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="ambiente" FooterText="ambiente" HeaderText="ambiente" />
            <asp:BoundField DataField="sigla" FooterText="bf_sigla" HeaderText="SIGLA" />
            <asp:BoundField DataField="tipo" FooterText="bf_tipo" HeaderText="TIPO" />
            <asp:BoundField DataField="cantidad_bocas" FooterText="bf_cantidadbocas" HeaderText="CANTIDAD_BOCAS" />
            <asp:BoundField DataField="descripcion" FooterText="bf_descripcion" HeaderText="DESCRIPCION" />
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
</asp:Content>
