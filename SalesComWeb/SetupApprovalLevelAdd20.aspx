<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupApprovalLevelAdd20.aspx.cs" Inherits="SetupApprovalLevelAdd20" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <%--  <style type="text/css">
        .required {}
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <table class="contenttext" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblApprovalFlowName" mandatory="true" runat="server" Text="Approval Flow Name"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlApprovalFlowName" CssClass="required" runat="server" SkinID="ddlCommonSkin">
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblOrderID" runat="server" Text="Order" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlOrderID" runat="server" SkinID="ddlCommonSkin" CssClass="required" ></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lvlApprovalLevelName" runat="server" Text="Approval Level Name" mandatory="true"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtApprovalLevelName" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>

            <td class="tdSubmit" colspan="2">
                <asp:Button ID="btnSave" OnClientClick="return fnValidate();" runat="server" Text="Save" OnClick="btnSave_Click" SkinID="btnCommonSkin" />

            </td>
        </tr>
        <asp:HiddenField runat="server" ID="userID" />
    </table>

    <div class="msg">
        <asp:Label ID="lblMsg" runat="server">
    
        </asp:Label>
    </div>

</asp:Content>

