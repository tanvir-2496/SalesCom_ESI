<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupSimValidationRuleAdd.aspx.cs" Inherits="SetupActivityAdd" %>
<%@ Register Src="~/UserControl/datetimePicker/WebUserControl.ascx" TagName="WebUserControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
          <uc2:WebUserControl ID="WebUserControl1" runat="server" />
    <table class="contenttext" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblValidationName" mandatory="true" runat="server" Text="Validation Name"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtValidationName" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeypress="return IsAlphaNumeric(event)">
                </asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblEffectiveDate" runat="server" Text="Effective Date" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEffectiveDate" CssClass="date required" runat="server" SkinID="txtDate">
                </asp:TextBox>
                <a id="a2" runat="server">
                                <img src="UserControl/datetimePicker/themes/img.gif" id="btnLetterRefDate" style="cursor: hand;"
                                    align="absmiddle" onmouseover="ShowDate(this);" /></a>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblExpireDate" runat="server" Text="Expire Date" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtExpireDate" runat="server" SkinID="txtDate" CssClass="date required">
                </asp:TextBox>
                <a id="a1" runat="server">
                                <img src="UserControl/datetimePicker/themes/img.gif" id="Img1" style="cursor: hand;"
                                    align="absmiddle" onmouseover="ShowDate(this);" /></a>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblProcedure" runat="server" Text="Procedure"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtProcedure" runat="server" SkinID="txtCommonSkin" onkeypress="return IsAlphaNumeric(event)">
                </asp:TextBox>
            </td>
        </tr>

       

         <tr>
            <td>
                <asp:Label ID="lblActivityId" runat="server" Text="Activity" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlActivity" runat="server" CssClass="required" SkinID="ddlCommonSkin"></asp:DropDownList>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lblIsActive" runat="server" Text="Is Active"> </asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chkIsActive" runat="server" Checked="true"/>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lblIsDynamic" runat="server" Text="Is Dynamic"> </asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chkIsDynamic" runat="server" Checked="true"/>
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

