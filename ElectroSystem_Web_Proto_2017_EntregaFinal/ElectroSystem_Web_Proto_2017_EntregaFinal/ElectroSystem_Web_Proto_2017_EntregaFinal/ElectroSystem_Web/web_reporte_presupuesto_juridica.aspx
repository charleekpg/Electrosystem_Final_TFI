<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="web_reporte_presupuesto_juridica.aspx.vb" Inherits="ElectroSystem_Web.web_reporte_presupuesto_juridica" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="Reporte\Reporte_Presupuesto_Persona_Juridica.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="" Name="presupuesto_mano_obra" />
                    <rsweb:ReportDataSource DataSourceId="" Name="presupuesto_trabajos_adicionales" />
                    <rsweb:ReportDataSource DataSourceId="" Name="presupuesto" />
                    <rsweb:ReportDataSource DataSourceId="" Name="presupuesto_domicilio" />
                    <rsweb:ReportDataSource DataSourceId="" Name="presupuesto_cliente" />
                    <rsweb:ReportDataSource DataSourceId="" Name="presupuesto_localidad" />
                    <rsweb:ReportDataSource DataSourceId="" Name="presupuesto_partido" />
                    <rsweb:ReportDataSource DataSourceId="" Name="presupuesto_nombreapellido" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
    
    </div>
    </form>
</body>
</html>
