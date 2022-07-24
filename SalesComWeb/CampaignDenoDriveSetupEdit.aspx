
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="CampaignDenoDriveSetupEdit.aspx.cs" Inherits="CampaignDenoDriveSetupEdit" %>

<%@ Register Src="~/UserControl/datetimePicker/WebUserControl.ascx" TagName="WebUserControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:WebUserControl ID="WebUserControl1" runat="server" />
    <table class="contenttext" style="width: 100%;">

         <tr>
            <td>
                <asp:Label ID="lblChannelTypeId" runat="server" Text="Channel Type" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlChannelTypeId" runat="server" SkinID="ddlCommonSkin" CssClass="required"></asp:DropDownList>
            </td>
         </tr>

        <tr>
            <td>
                <asp:Label ID="lblCampainName" mandatory="true" runat="server" Text="Campaign Name"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCampainName" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeypress="return IsAlphaNumeric(event)">
                </asp:TextBox>
            </td>
        </tr>


        <tr>
            <td>
                <asp:Label ID="lblCampainStartDate" runat="server" Text="Campaign Start Date" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCampainStartDate" runat="server" SkinID="txtDate" CssClass="date required">
                </asp:TextBox>
                <a id="a2" runat="server">
                    <img src="UserControl/datetimePicker/themes/img.gif" id="btnLetterRefDate" style="cursor: hand;"
                        align="absmiddle" onmouseover="ShowDate(this);" /></a>
            </td>
        </tr>
        <tr>

            <td>
                <asp:Label ID="lblCampainEndDate" runat="server" Text="Campaign End Date" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCampainEndDate" runat="server" SkinID="txtDate" CssClass="date required">
                </asp:TextBox>
                <a id="a1" runat="server">
                    <img src="UserControl/datetimePicker/themes/img.gif" id="Img1" style="cursor: hand;"
                        align="absmiddle" onmouseover="ShowDate(this);" /></a>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblUpperCap" mandatory="true" runat="server" Text="Upper Cap"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUpperCap" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeypress="return IsNumeric(event)">
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
    <div class="msg">
        <asp:Label ID="lblDuplicate" runat="server">
    
        </asp:Label>
    </div>
</asp:Content>

