<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupProductChannelAdd.aspx.cs" Inherits="SetupProductChannelAdd" %>

<%@ Register Src="~/UserControl/datetimePicker/WebUserControl.ascx" TagName="WebUserControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:WebUserControl ID="WebUserControl1" runat="server" />
    <table class="contenttext" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblProductChannelName" mandatory="true" runat="server" Text="Product Channel Name"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtProductChannelName" CssClass="required" runat="server" SkinID="txtCommonSkin">
                </asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblEffectiveDate" runat="server" Text="Effective Date" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEffectiveDate" runat="server" SkinID="txtDate" CssClass="date required">
                </asp:TextBox>
                <a id="a2" runat="server">
                    <img src="UserControl/datetimePicker/themes/img.gif" id="btnLetterRefDate" style="cursor: hand;"
                        align="absmiddle" onmouseover="ShowDate(this);" /></a>
            </td>
        </tr>
        <tr>

            <td>
                <asp:Label ID="lblExpiryDate" runat="server" Text="Expiry Date" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtExpiryDate" runat="server" SkinID="txtDate" CssClass="date required">
                </asp:TextBox>
                <a id="a1" runat="server">
                    <img src="UserControl/datetimePicker/themes/img.gif" id="Img1" style="cursor: hand;"
                        align="absmiddle" onmouseover="ShowDate(this);" /></a>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblProcedure" runat="server" Text="Procedure" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtProcedure" runat="server" SkinID="txtCommonSkin" CssClass="required">
                </asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblIsActive" runat="server" Text="Is Active"> </asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chkIsActive" runat="server" Checked="true"></asp:CheckBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblIsDynamic" runat="server" Text="Is Dynamic"> </asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chkIsDynamic" runat="server" Checked="true"></asp:CheckBox>
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
    <div class="msg">
        <asp:Label ID="lblDuplicate" runat="server">
    
        </asp:Label>
    </div>
</asp:Content>

