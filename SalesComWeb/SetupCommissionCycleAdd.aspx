<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupCommissionCycleAdd.aspx.cs" Inherits="SetupActivityAdd" %>

<%@ Register Src="~/UserControl/datetimePicker/WebUserControl.ascx" TagName="WebUserControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:WebUserControl ID="WebUserControl1" runat="server" />
    <table class="contenttext" style="width: 100%;">

        <tr>
            <td>
                <asp:Label ID="lblDescription" mandatory="true" runat="server" Text="Description"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" SkinID="txtCommonSkin" CssClass="required"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblPeriodStartDate" runat="server" Text="Start Date" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPeriodStartDate" runat="server" SkinID="txtDate" CssClass="date required">
                </asp:TextBox>
                <a id="a2" runat="server">
                    <img src="UserControl/datetimePicker/themes/img.gif" id="btnLetterRefDate" style="cursor: hand;"
                        align="absmiddle" onmouseover="ShowDate(this);" /></a>
            </td>
        </tr>
        <tr>

            <td>
                <asp:Label ID="lblPeriodEndDate" runat="server" Text="End Date" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPeriodEndDate" runat="server" SkinID="txtDate" CssClass="date required">
                </asp:TextBox>
                <a id="a1" runat="server">
                    <img src="UserControl/datetimePicker/themes/img.gif" id="Img1" style="cursor: hand;"
                        align="absmiddle" onmouseover="ShowDate(this);" /></a>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblCycleStatusId" mandatory="true" runat="server" Text="Status"></asp:Label>
            </td>
            <td>
                <%--<asp:TextBox ID="txtCycleStatusId" runat="server" SkinID="txtCommonSkin" CssClass="required"></asp:TextBox>--%>
                <asp:DropDownList ID="ddlCycleStatusId" runat="server" SkinID="ddlCommonSkin" CssClass="required">
                     <asp:ListItem Text="[Select One]" Value ="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Active" Value ="1" ></asp:ListItem>
                    <asp:ListItem Text="Inactive" Value ="2" ></asp:ListItem>
                </asp:DropDownList>
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

