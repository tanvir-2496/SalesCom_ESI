<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupSegmentTypeAdd.aspx.cs" Inherits="SetupActivityAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="contenttext" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblTypeName" mandatory="true" runat="server" Text="Type Name"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTypeName" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeypress="return IsAlphaNumeric(event)">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblChannelTypeName" mandatory="true" runat="server" Text="Channel Type Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlChannelTypeName" runat="server" SkinID="txtCommonSkin"></asp:DropDownList>
            </td>
        </tr>

        <tr>

            <td class="tdSubmit" colspan="2">
                <asp:Button ID="btnSave" OnClientClick="return fnValidate();" runat="server" Text="Save" OnClick="btnSave_Click" SkinID="btnCommonSkin" />

            </td>
        </tr>
    </table>
    <div class="msg">
        <asp:Label ID="lblMsg" runat="server">
    
        </asp:Label>
    </div>
</asp:Content>

