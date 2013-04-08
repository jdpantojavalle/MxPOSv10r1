<%@ Page Title="" Language="C#" MasterPageFile="~/Styles/Greenpasture/GreenPasture.Master" AutoEventWireup="true" CodeBehind="PaginaEmisor.aspx.cs" Inherits="MxPOS10.Sistema.Paginas.NEW__PaginaEmisor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 221px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:Label ID="Label1" runat="server" 
                style="font-weight: 700; font-size: xx-large" Text="Emisores"></asp:Label>
    </div>

    <br />

    <div>
        <asp:Label ID="Label2" runat="server" 
                style="font-weight: 700; font-size: xx-large" Text="Detalles del emisor"></asp:Label>
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
                        <asp:TextBox ID="txtRFC" runat="server" 
                            Width="234px"></asp:TextBox>
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
                <asp:Button ID="btnReporteEmisores" runat="server" 
                    onclick="btnReporteEmisores_Click" Text="Ver reporte de emisores" 
                    Width="210px" />
            </td>
            <td>
                        <asp:Button ID="btnAgregarEmisor" runat="server" onclick="btnAgregarEmisor_Click" 
                            Text="Agregar" Width="244px" />
                        </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Button ID="btnDomiciliosFiscales" runat="server" 
                    onclick="btnDomiciliosFiscales_Click" Text="Ver domicilios fiscales" 
                    Width="210px" />
            </td>
            <td>
                        <asp:Button ID="btnActualizarEmisor" runat="server" Text="Actualizar" 
                            Width="244px" onclick="btnActualizarEmisor_Click" />
                        </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                        <asp:Button ID="btnEliminarEmisor" runat="server" Text="Eliminar" Width="244px" 
                            onclick="btnEliminarEmisor_Click" />
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
            Text="Emisores registrados"></asp:Label>    
    </div>

    <table style="width:100%;">
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvwEmisores" runat="server" AutoGenerateSelectButton="True" 
                        onselectedindexchanged="gvwEmisores_SelectedIndexChanged">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>

    </asp:Content>
