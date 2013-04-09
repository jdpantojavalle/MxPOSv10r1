<%@ Page Title="" Language="C#" MasterPageFile="~/Styles/GreenPasture/GreenPasture.Master" AutoEventWireup="true" CodeBehind="PaginaProveedorDomicilio.aspx.cs" Inherits="MxPOS10.Sistema.Paginas.PaginaProveedorDomicilio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">


        .style2
        {
            width: 115px;
        }
        .style3
        {
            width: 182px;
        }
        .style1
        {
            font-size: large;
            font-weight: bold;
        }
        .style4
        {
            font-size: medium;
        }
        .style6
        {
            width: 581px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" 
                    style="font-size: xx-large; font-weight: 700" 
            Text="Proveedor seleccionado"></asp:Label>
    </div>
    <table style="width:100%;">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label2" runat="server" CssClass="style1" Text="ID"></asp:Label>
            </td>
            <td class="style3">
                <asp:Label ID="Label3" runat="server" CssClass="style1" Text="RFC"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" CssClass="style1" Text="Nombre"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="lblIDProveedor" runat="server" CssClass="style4" 
                    Text="lblIDProveedor"></asp:Label>
            </td>
            <td class="style3">
                <asp:Label ID="lblRFCProveedor" runat="server" CssClass="style4" 
                    Text="lblRFCProveedor"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblNombreProveedor" runat="server" CssClass="style4" 
                    Text="lblNombreProveedor"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <div>
        <asp:Label ID="Label5" runat="server" 
                    style="font-size: xx-large; font-weight: 700" 
                        Text="Detalles del domicilio"></asp:Label>
    </div>
    <table style="width:100%;">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label18" runat="server" Text="Calle" CssClass="style4"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtCalle" runat="server"
                            Width="234px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label19" runat="server" Text="Número exterior" 
                    CssClass="style4"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtNumeroExterior" runat="server" 
                            Width="234px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label20" runat="server" Text="Número interior" 
                    CssClass="style4"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtNumeroInterior" runat="server" 
                            Width="234px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label21" runat="server" Text="Colonia" CssClass="style4"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtColonia" runat="server"
                            Width="234px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label12" runat="server" Text="Localidad" 
                    CssClass="style4"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtLocalidad" runat="server" 
                            Width="234px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label14" runat="server" Text="Referencia" 
                    CssClass="style4"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtReferencia" runat="server" 
                            Width="234px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label13" runat="server" Text="Municipio" 
                    CssClass="style4"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtMunicipio" runat="server" 
                            Width="234px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label15" runat="server" Text="Estado" 
                    CssClass="style4"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtEstado" runat="server" 
                            Width="234px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label16" runat="server" Text="Pais" CssClass="style4"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtPais" runat="server"
                            Width="234px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label17" runat="server" Text="Codigo postal" 
                    CssClass="style4"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtCodigoPostal" runat="server" 
                            Width="234px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Button ID="btnReporteProveedoresDomicilios" runat="server" onclick="btnReporteProveedoresDomicilios_Click" 
                            Text="Ver reporte de domicilios" Width="244px" />
            </td>
            <td class="style3">
                <asp:Button ID="btnAgregarDomicilio" runat="server" onclick="btnAgregarDomicilio_Click" 
                            Text="Agregar" Width="244px" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Button ID="btnActualizarDomicilio" runat="server" onclick="btnActualizarDomicilio_Click" 
                            Text="Actualizar" Width="244px" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Button ID="btnEliminarDomicilio" runat="server" Text="Eliminar" 
                            Width="244px" onclick="btnEliminarDomicilio_Click" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
    </table>
    <div>
        <asp:Label ID="Label6" runat="server" 
                    style="font-size: xx-large; font-weight: 700" 
                    Text="Domicilios registrados"></asp:Label>
    </div>
    <table style="width:100%;">
        <tr>
            <td class="style6">

                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                <asp:GridView ID="gvwProveedoresDomicilios" runat="server" AutoGenerateSelectButton="True" 
        Width="1013px" onselectedindexchanged="gvwProveedoresDomicilios_SelectedIndexChanged">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
