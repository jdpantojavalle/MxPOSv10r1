<%@ Page Title="" Language="C#" MasterPageFile="~/Styles/GreenPasture/GreenPasture.Master" AutoEventWireup="true" CodeBehind="PaginaProveedor.aspx.cs" Inherits="MxPOS10.Sistema.Paginas.PaginaProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" 
            style="font-weight: 700; font-size: xx-large" Text="Proveedores"></asp:Label>
    </div>
    <br />
    <div>
        <asp:Label ID="Label2" runat="server" 
            style="font-weight: 700; font-size: xx-large" 
            Text="Detalles del proveedor seleccionado"></asp:Label>
    </div>
    <table style="width:100%;">
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label6" runat="server" Text="ID"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblID" runat="server" Text="lblID"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label3" runat="server" Text="RFC"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRFC" runat="server" Width="234px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label4" runat="server" Text="Nombre"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" Width="234px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Button ID="btnReporteProveedores" runat="server" 
                    onclick="btnReporteProveedores_Click" Text="Ver reporte de proveedores" />
            </td>
            <td>
                <asp:Button ID="btnAgregarProveedor" runat="server" 
                    onclick="btnAgregarProveedor_Click" Text="Agregar" Width="244px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Button ID="btnProveedoresDomicilios" runat="server" 
                    onclick="btnProveedoresDomicilios_Click" Text="Ver domicilios" 
                    Width="233px" />
            </td>
            <td>
                <asp:Button ID="btnActualizarProveedor" runat="server" 
                    onclick="btnActualizarProveedor_Click" Text="Actualizar" Width="244px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnEliminarProveedor" runat="server" 
                    onclick="btnEliminarProveedor_Click" Text="Eliminar" Width="244px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <div>
        <asp:Label ID="Label5" runat="server" 
            style="font-weight: 700; font-size: xx-large" 
            Text="Proveedores  registrados"></asp:Label>
    </div>
    <table style="width:100%;">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvwProveedores" runat="server" 
                    AutoGenerateSelectButton="True" 
                    onselectedindexchanged="gvwProveedores_SelectedIndexChanged">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
