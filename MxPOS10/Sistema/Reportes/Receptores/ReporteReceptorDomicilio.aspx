<%@ Page Title="" Language="C#" MasterPageFile="~/Styles/GreenPasture/GreenPasture.Master" AutoEventWireup="true" CodeBehind="ReporteReceptorDomicilio.aspx.cs" Inherits="MxPOS10.Sistema.Reportes.Receptores.ReporteReceptorDomicilio" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <rsweb:ReportViewer ID="rpvReceptoresDomicilios" runat="server" 
        Width="1113px" Font-Names="Verdana" Font-Size="8pt" 
        InteractiveDeviceInfos="(Colección)" WaitMessageFont-Names="Verdana" 
        WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="Sistema\Reportes\Receptores\ReporteReceptorDomicilio.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="odsReceptoresDomicilios" 
                    Name="dsReceptoresDomicilios" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:ObjectDataSource ID="odsReceptoresDomicilios" runat="server" 
        SelectMethod="ObtenerReceptor" 
        TypeName="MxPOS10.Sistema.Reportes.Receptores.ReporteReceptor">
        <SelectParameters>
            <asp:QueryStringParameter Name="idReceptor" QueryStringField="idReceptor" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
