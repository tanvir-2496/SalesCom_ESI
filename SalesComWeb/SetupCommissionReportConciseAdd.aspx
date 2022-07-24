<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupCommissionReportConciseAdd.aspx.cs" Inherits="SetupActivityAdd" %>

<%@ Register Src="~/UserControl/datetimePicker/WebUserControl.ascx" TagName="WebUserControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:WebUserControl ID="WebUserControl1" runat="server" />


    <table class="contenttext" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblReportName" mandatory="true" runat="server" Text="Report Name"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtReportName" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeypress="return IsAlphaNumeric(event)">
                </asp:TextBox>
            </td>
        </tr>

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
                <asp:Label ID="lblExpiryDate" runat="server" Text="Expiry Date"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtExpiryDate" runat="server" SkinID="txtDate">
                </asp:TextBox>
                <a id="a1" runat="server">
                    <img src="UserControl/datetimePicker/themes/img.gif" id="Img1" style="cursor: hand;"
                        align="absmiddle" onmouseover="ShowDate(this);" /></a>
            </td>
        </tr>
     

        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="File"> </asp:Label></td>
            <td>

                <asp:FileUpload ID="ImageTypeFileUpLoad" runat="server" type="file" />
            </td>
        </tr>


        <tr>

            <td class="tdSubmit" colspan="2">
                <asp:Button ID="btnSave" OnClientClick="return fnValidate();" runat="server" Text="Save" OnClick="btnSave_Click" SkinID="btnCommonSkin" />

            </td>
        </tr>


    </table>


    <div class="msg">
        <asp:Label ID="lblResult" runat="server">
        </asp:Label>
    </div>


</asp:Content>

