<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupEventRuleExAdd.aspx.cs" Inherits="SetupEventRuleAdd" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <asp:UpdatePanel ID="upreport" runat="server">
        <ContentTemplate>

            <table class="contenttext" style="width: 100%;">

                <tr>
                    <td>
                        <asp:Label ID="lblReportName" runat="server" Text="Report Name"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlReportName" runat="server" SkinID="ddlCommonSkin" AutoPostBack="true" OnSelectedIndexChanged="ddlReportName_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblEventName" mandatory="true" runat="server" Text="Event Name"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEventName" runat="server" SkinID="ddlCommonSkin" CssClass="required">
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label2" mandatory="true" runat="server" Text="Event Rule Name"> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEventRuleName" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeypress="return IsAlphaNumeric(event)">
                        </asp:TextBox>
                    </td>
                </tr>


                <tr>
                    <td>
                        <asp:Label ID="lblSegmentID" mandatory="true" runat="server" Text="Segment"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSegmentID" runat="server" SkinID="ddlCommonSkin" CssClass="required">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMinAmount" mandatory="true" runat="server" Text="Min Amount"> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMinAmount" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeypress="return IsNumberKey(event)">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMaxAmount" mandatory="true" runat="server" Text="Max Amount"> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMaxAmount" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeypress="return IsNumberKey(event)">
                        </asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblAmountTypeID" mandatory="true" runat="server" Text="AmountType"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAmountTypeID" runat="server" SkinID="ddlCommonSkin" CssClass="required">
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblCommissionType" mandatory="true" runat="server" Text="Commission Type"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCommissionType" runat="server" SkinID="ddlCommonSkin" CssClass="required">
                        </asp:DropDownList>
                        <%--               <asp:TextBox ID="txtCommissionType" CssClass="required" runat="server" SkinID="txtCommonSkin">
                </asp:TextBox>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCommissionValue" mandatory="true" runat="server" Text="Commission Value"> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCommissionValue" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeypress="return IsNumberKey(event)">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMaxCommissionPerevent" mandatory="true" runat="server" Text="Max Commission Perevent"> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMaxCommissionPerevent" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeypress="return IsNumberKey(event)">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblValidationRuleID" runat="server" Text="ValidationRule"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlValidationRuleID" runat="server" SkinID="ddlCommonSkin">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" mandatory="true" runat="server" Text="Rule Group"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRuleGroup" runat="server" SkinID="ddlCommonSkin" CssClass="required">
                        </asp:DropDownList>
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
        <asp:Label ID="lblMsg" runat="server" Text="">
    
        </asp:Label>
    </div>

</asp:Content>

