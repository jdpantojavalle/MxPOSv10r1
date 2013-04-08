<%@ Page Title="" Language="C#" MasterPageFile="~/Styles/GreenPasture/GreenPasture.Master" AutoEventWireup="true" CodeBehind="ReporteEmisorDomicilioFiscal.aspx.cs" Inherits="MxPOS10.Sistema.Reportes.Emisores.ReporteEmisorDomicilioFiscal" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <rsweb:ReportViewer ID="rpvEmisoresDomiciliosFiscales" runat="server" 
        Width="1113px" Font-Names="Verdana" Font-Size="8pt" 
        InteractiveDeviceInfos="(Colección)" WaitMessageFont-Names="Verdana" 
        WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="Sistema\Reportes\Emisores\ReporteEmisorDomicilioFiscal.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="odsEmisoresDomiciliosFiscales" 
                    Name="dsEmisoresDomiciliosFiscales" />
            </DataSources>
        </LocalReport>
</rsweb:ReportViewer>

<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:ObjectDataSource ID="odsEmisoresDomiciliosFiscales" runat="server" 
        SelectMethod="ObtenerEmisor" 
        TypeName="MxPOS10.Sistema.Reportes.Emisores.ReporteEmisor">
        <SelectParameters>
            <asp:QueryStringParameter Name="idEmisor" QueryStringField="idEmisor" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>



</asp:Content>
