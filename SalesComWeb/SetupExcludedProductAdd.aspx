<%@ Page Title="Event" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupExcludedProductAdd.aspx.cs" Inherits="SetupExcludedProductAdd" Culture="en-GB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 
    <table class="contenttext" style="width: 100%;">

        <tr>
            <td>
                <asp:Label ID="lblReportName" mandatory="true" runat="server" Text="Report Name"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlReportName" CssClass="required" runat="server" SkinID="ddlCommonSkin">
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblProductDetail" runat="server" Text="Product Detail" mandatory="true"> </asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlProductDetail" runat="server" SkinID="ddlCommonSkin" CssClass="required"></asp:DropDownList></td>
        </tr>

        <tr>
            <td class="tdSubmit" colspan="2">
                <asp:Button ID="btnSave" OnClientClick="return fnValidate();" runat="server" Text="Save" OnClick="btnSave_Click" SkinID="btnCommonSkin" ValidationGroup="Date" />
            </td>
        </tr>

    </table>

    <div class="msg">
        <asp:Label ID="lblMsg" runat="server">
        </asp:Label>
    </div>

</asp:Content>

