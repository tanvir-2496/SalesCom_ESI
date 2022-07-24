<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupReportReplicationAdd.aspx.cs" Inherits="SetupActivityAdd" %>

<%@ Register Src="~/UserControl/datetimePicker/WebUserControl.ascx" TagName="WebUserControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:WebUserControl ID="WebUserControl1" runat="server" />

    <asp:UpdatePanel ID="upCycle" runat="server">

        <Triggers>
        </Triggers>

        <ContentTemplate>
            <table class="contenttext" style="width: 100%;">
                <tr>
                    <td>
                        <asp:Label ID="lblReportName" mandatory="true" runat="server" Text="Reference Report Name"> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtReportName" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeypress="return IsAlphaNumeric(event)" ReadOnly="true">
                        </asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblNewReportName" mandatory="true" runat="server" Text="New Report Name"> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNewReportName" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeypress="return IsAlphaNumeric(event)">
                        </asp:TextBox>
                    </td>
                </tr>

                <tr runat="server" id="trPeriodType">
                    <td>
                        <asp:Label ID="lblPeriodType" runat="server" Text="Period Type"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPeridType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPeridType_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblCommissionCycle" runat="server" Text="Commission Cycle" mandatory="true"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCommissionCycle" runat="server" AutoPostBack="true" CssClass="required">
                        </asp:DropDownList>
                    </td>
                </tr>



                <tr>
                    <td>
                        <asp:Label ID="lblEffectiveDate" runat="server" Text="Effective Date"> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEffectiveDate" runat="server" SkinID="txtDate">
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

                    <td class="tdSubmit" colspan="2">
                        <asp:Button ID="btnSave" OnClientClick="return fnValidate();" runat="server" Text="Save" OnClick="btnSave_Click" SkinID="btnCommonSkin" />

                    </td>
                </tr>


            </table>

        </ContentTemplate>




    </asp:UpdatePanel>



    <div class="msg">
        <asp:Label ID="lblResult" runat="server">
        </asp:Label>
    </div>

</asp:Content>

