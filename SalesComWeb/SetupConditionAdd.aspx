<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupConditionAdd.aspx.cs" Inherits="SetupConditionAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <table class="contenttext" style="width: 400px;">
            <tr>
                <td>
                    <asp:Label ID="Label1" SkinID="lblCommonSkin" mandatory="true" runat="server" Text="Sales Group"> </asp:Label>
                </td>
                <td>
                    <asp:DropDownList Style="width: 200px" ID="ddlSalesGroup" runat="server" AutoPostBack="true" SkinID="ddlCommonSkin" OnSelectedIndexChanged="ddl_SalesGroup_IndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="lblKpiName" SkinID="lblCommonSkin" mandatory="true" runat="server" Text="KPI Name"> </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlKpiName" runat="server" SkinID="ddlCommonSkin" CssClass="required" OnSelectedIndexChanged="ddlKpiName_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSubKpiName" SkinID="lblCommonSkin" runat="server" Text="Sub KPI Name"> </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSubKpiName" runat="server" SkinID="ddlCommonSkin" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblConditionName" mandatory="true" runat="server" Text="Condition Name" SkinID="lblCommonSkin"> </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtConditionName" CssClass="required" runat="server" SkinID="txtCommonSkin">
                    </asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="lblDisplayName" mandatory="true" runat="server" Text="Display Name" SkinID="lblCommonSkin"> </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDisplayName" CssClass="required" runat="server" MaxLength="15" SkinID="txtCommonSkin">
                    </asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="lblConditionRemarks" mandatory="true" runat="server" Text="Remarks" SkinID="lblCommonSkin"> </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtConditionRemarks" CssClass="required" runat="server" SkinID="txtCommonSkin">
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
    </center>
    <div style="text-align: left; width: 90%;">
        <ul>
            <li>Red asterisk(<b style="color: red">*</b>) sign means that filling in the field is mandatory in order to continue.</li>
            <li>Display Name is recommended to use short form of Condition Name.</li>
        </ul>
    </div>
</asp:Content>

