<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupChannelEventBatchAdd.aspx.cs" Inherits="SetupActivityAdd" %>

<%@ Register Src="~/UserControl/datetimePicker/WebUserControl.ascx" TagName="WebUserControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:WebUserControl ID="WebUserControl1" runat="server" />
    <table class="contenttext" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblBatchSource" mandatory="true" runat="server" Text="Batch Source"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBatchSource" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeypress="return IsAlphaNumeric(event)">
                </asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblBatchDate" runat="server" Text="BatchDate"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBatchDate" CssClass="date required" runat="server" SkinID="txtDate">
                </asp:TextBox>
                <a id="a3" runat="server">
                    <img src="UserControl/datetimePicker/themes/img.gif" id="Img3" style="cursor: hand;"
                        align="absmiddle" onmouseover="ShowDate(this);" /></a>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblIsReady" runat="server" Text="Is Ready"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlIsReady" runat="server">
                    <asp:ListItem Text="SELECT" Value="SELECT" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="YES" Value="YES"></asp:ListItem>
                    <asp:ListItem Text="NO" Value="NO"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblBatchType" runat="server" Text="Batch Type"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBatchType" runat="server" SkinID="txtCommonSkin" onkeypress="return IsAlphaNumeric(event)">
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

