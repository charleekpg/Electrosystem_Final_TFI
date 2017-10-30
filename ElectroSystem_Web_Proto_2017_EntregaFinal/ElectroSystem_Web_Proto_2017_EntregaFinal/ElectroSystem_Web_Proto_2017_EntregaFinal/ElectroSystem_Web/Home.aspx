<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Home.aspx.vb" Inherits="ElectroSystem_Web.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p style="height: 262px; margin-bottom: 56px">
            <asp:LinkButton ID="lnk_login" runat="server">Login</asp:LinkButton>
            <br />
            <asp:LinkButton ID="frm_backupyrestore" runat="server">Backup y Restore</asp:LinkButton>
            <br />
            <asp:LinkButton ID="frm_idioma" runat="server">Idioma</asp:LinkButton>
            <br />
            <asp:LinkButton ID="frm_bitacora" runat="server">Bitacora</asp:LinkButton>
           <br />
            <asp:LinkButton ID="frm_cifrado" runat="server">Cifrado</asp:LinkButton>
            <br />
            <asp:LinkButton ID="frm_Bocamercado" runat="server">Boca Mercado</asp:LinkButton>
            <br />
            <asp:LinkButton ID="frm_evaluardistancia" runat="server">Evaluar Distancia</asp:LinkButton>
            <br />
            <asp:LinkButton ID="lnk_evalplano" runat="server">Evaluacion Plano Electrico</asp:LinkButton>
            <br />
            <asp:LinkButton ID="frm_creacionpresatenc" runat="server">Creacion Presupuesto - Atencion al cliente</asp:LinkButton>
            <br />
            <asp:LinkButton ID="frm_creacionpresumodtec" runat="server">Armado presupuesto modulo tecnico</asp:LinkButton>
            <br />
            <asp:LinkButton ID="frm_armadopresupuestomodcome" runat="server">armado presupuesto modulo comercial</asp:LinkButton>
            <br />
            <asp:LinkButton ID="frm_especificarfechaproy" runat="server">Especificar Fecha de Inicio/Final – Proyecto </asp:LinkButton>
            <br />
            <asp:LinkButton ID="frm_cierreproy" runat="server">Cierre de Proyecto </asp:LinkButton>
            <br />
            <asp:LinkButton ID="frm_generaciongraf" runat="server">Generacion de Grafico</asp:LinkButton>
          <br />
            <asp:LinkButton ID="frm_generacionpresu" runat="server">Generación de Presupuesto </asp:LinkButton>
            <br />
            <asp:LinkButton ID="frm_generacionserv" runat="server">Generación de Certificados de Servicio</asp:LinkButton>
        </p>
    </form>
</body>
</html>
