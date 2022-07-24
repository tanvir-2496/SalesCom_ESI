<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupModalityReportContentAdd.aspx.cs" Inherits="SetupModalityReportContentAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="contenttext">

        <tr>
            <td>
                <asp:Label ID="lblReportName" mandatory="true" runat="server" Text="Report Name" SkinID="lblCommonSkin"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtReportName" runat="server" SkinID="txtCommonSkin" CssClass="required" mandatory="true"></asp:TextBox>
            </td>
        </tr>

     

        <tr>
            <td>
                 <asp:Label ID="Label1" runat="server" Text="File" SkinID="lblCommonSkin"  mandatory="true"  > </asp:Label></td>
            <td>

                <asp:FileUpload ID="ImageTypeFileUpLoad" runat="server" type="file" CssClass="required"/>
            </td>
        </tr>
           <tr>
            <td>
                <asp:Label ID="lblIsActive" runat="server" Text="Is Active" SkinID="lblCommonSkin"> </asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chkIsActive" runat="server" Checked="true"></asp:CheckBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lblMessage" runat="server" Text="" SkinID="lblErrorMsgSkin" />
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

