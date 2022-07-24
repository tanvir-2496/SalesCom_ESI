<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupChannelAdd.aspx.cs" Inherits="SetupActivityAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="contenttext" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblParentChannelID" mandatory="true" runat="server" Text="Parent Channel ID"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtParentChannelID" CssClass="required" runat="server" SkinID="txtCommonSkin">
                </asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblChannelTypeID" runat="server" Text="Channel Type"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtChannelTypeID" CssClass="required" runat="server" SkinID="txtCommonSkin">
                </asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblChannelName" runat="server" Text="Channel Name"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtChannelName" runat="server" SkinID="txtCommonSkin">
                </asp:TextBox>
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

