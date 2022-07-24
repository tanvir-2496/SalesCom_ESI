<%@ Page Title="Event" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupEventAdd.aspx.cs" Inherits="SetupEventAdd" Culture="en-GB" %>

<%@ Register Src="~/UserControl/datetimePicker/WebUserControl.ascx" TagName="WebUserControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function validate() {
            var effDate = Date.parse(document.getElementById("txtEffectiveDate").value);
            var expDate = Date.parse(document.getElementById("txtExpiryDate").value);
            if (effDate != null && expDate != null) {

                if (effDate > expDate) {
                    alert("Expiry date cannot be bigger than effective date.");
                    document.getElementById("txtExpiryDate").value = '';
                    document.getElementById("txtExpiryDate").focus();
                    return false;
                }
            }
            return true;
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:WebUserControl ID="WebUserControl1" runat="server" />
    <table class="contenttext" style="width: 100%;">

        <tr>
           <tr>
                <td>
                    <asp:Label ID="lblReportName" runat="server" Text="Report Name" mandatory="true"> </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlReportName" runat="server" SkinID="ddlCommonSkin" CssClass="required"></asp:DropDownList>
                </td>
         </tr>

            <td>
                <asp:Label ID="lblEventName" mandatory="true" runat="server" Text="Event Name"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEventName" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeypress="return IsAlphaNumeric(event);">
                </asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblEventTypeID" runat="server" Text="Event Type ID" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlEventTypeID" runat="server" SkinID="ddlCommonSkin" CssClass="required"></asp:DropDownList>
            </td>
        </tr>



        <tr>
            <td>
                <asp:Label ID="lblEffectiveDate" runat="server" Text="Effective Date" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEffectiveDate" runat="server" SkinID="txtDate" CssClass="date required" ClientIDMode="Static">
                   
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
                <%--<asp:TextBox ID="txtExpiryDate" runat="server" SkinID="txtDate" ClientIDMode="Static" onChange="validate()">--%>
                <asp:TextBox ID="txtExpiryDate" runat="server" SkinID="txtDate" ClientIDMode="Static" onChange="CompareDate('txtEffectiveDate', 'txtExpiryDate');">
                </asp:TextBox>
                <a id="a1" runat="server">
                    <img src="UserControl/datetimePicker/themes/img.gif" id="Img1" style="cursor: hand;"
                        align="absmiddle" onmouseover="ShowDate(this);" /></a>
            </td>
        </tr>

        <%--  <tr>
            <td>
                <asp:Label ID="lblFrequency" runat="server" Text="Frequency"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFrequency" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeypress="return IsNumberKey(event)">
                </asp:TextBox>
            </td>
        </tr>--%>

        <tr>
            <td>
                <asp:Label ID="lblChannelType" runat="server" Text="Channel Type" mandatory="true"> </asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlChannelType" runat="server" SkinID="ddlCommonSkin" CssClass="required"></asp:DropDownList></td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblProductChannelName" runat="server" Text="Product Channel Name"> </asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlProductChannelName" runat="server" SkinID="ddlCommonSkin"></asp:DropDownList></td>
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

