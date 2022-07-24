<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupEventExApproval.aspx.cs" Inherits="PendingApprovalView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="contenttext" width="100%">
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Report Name: " SkinID="lblCommonSkin"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblReportName" runat="server" Text="" ></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Cycle : " SkinID="lblCommonSkin"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblCycle" runat="server" Text="" ></asp:Label></td>
        </tr>
       <%-- <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Flow Name: " SkinID="lblCommonSkin"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblApprovalFlowName" runat="server" Text="" ></asp:Label>
            </td>
        </tr>--%>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Level Name: " SkinID="lblCommonSkin"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblApprovalLevelName" runat="server" Text="" ></asp:Label>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lblCommissionAmount" runat="server" Text="Commission Amount: " SkinID="lblCommonSkin"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblCommissionAmt" runat="server" Text="" ></asp:Label>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lblCommissionWithheld" runat="server" Text="Withheld Amount: " SkinID="lblCommonSkin"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblWithheldAmount" runat="server" Text="" ></asp:Label>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lbl" runat="server" Text="Paybale Amount: " SkinID="lblCommonSkin"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPaybaleAmout" runat="server" Text="" ></asp:Label>
            </td>
        </tr>

      <%--  <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Order Number: " SkinID="lblCommonSkin"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblOrderNumber" runat="server" Text="" ></asp:Label>
            </td>
        </tr>--%>

        <tr>
            <td>
                <asp:Label ID="lblPreviousComments" runat="server" Text="Previous Comments" SkinID="lblCommonSkin"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPreviousComments" runat="server" TextMode="MultiLine" Height="75" Width="200" ReadOnly="True" BackColor="#CCCCCC"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblComments" runat="server" Text="Comments" SkinID="lblCommonSkin"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Height="75" Width="200"></asp:TextBox>
            </td>

        </tr>

        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnApprove" runat="server" Text="Approve" SkinID="btnCommonSkin" OnClick="btnApprove_Click" OnClientClick="if(!confirm('Do you want to approve?')){ return false; };" />

                &nbsp;
         
                <asp:Button ID="btnReject" runat="server" Text="Reject" SkinID="btnCommonSkin" OnClick="btnReject_Click" OnClientClick="if(!confirm('Do you want to reject?')){ return false; };" />
            </td>
        </tr>

    </table>
    <div class="msg">
        <asp:Label ID="lblMsg" runat="server">
    
        </asp:Label>
    </div>
</asp:Content>

