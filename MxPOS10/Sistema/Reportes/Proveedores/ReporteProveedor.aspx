<%@ Page Title="" Language="C#" MasterPageFile="~/Styles/GreenPasture/GreenPasture.Master" AutoEventWireup="true" CodeBehind="ReporteProveedor.aspx.cs" Inherits="MxPOS10.Sistema.Reportes.Proveedores.ReporteProveedor" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <rsweb:ReportViewer ID="rpvProveedores" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Colección)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1118px">
        <LocalReport ReportPath="Sistema\Reportes\Proveedores\ReporteProveedor.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="odsProveedores" Name="dsProveedores" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:ObjectDataSource ID="odsProveedores" runat="server" 
        SelectMethod="ObtenerProveedoresActivos" 
        TypeName="MxPOS10.Sistema.Entidades.EntidadProveedor">
    </asp:ObjectDataSource>
</asp:Content>
