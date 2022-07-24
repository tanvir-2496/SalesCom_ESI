<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupApprovalFlowAdd.aspx.cs" Inherits="SetupActivityAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <table class="contenttext" style="width:400px; ">
        <tr>
            <td>
                <asp:Label ID="lblApprovalName" mandatory="true" runat="server" Text="Flow Name"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtApprovalName" CssClass="required" runat="server" SkinID="txtCommonSkin">
                </asp:TextBox>
            </td>
        </tr>
          <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Flow Type" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlFlowType" runat="server" SkinID="ddlMediumSkin" CssClass="required"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            
            <td class="tdSubmit" colspan="2">
                <asp:Button ID="btnSave" OnClientClick ="return fnValidate();" runat="server" Text="Save" OnClick="btnSave_Click" SkinID="btnCommonSkin"/>
              
            </td>
        </tr>
    </table>
     <div class="msg" >
    <asp:Label ID="lblMsg" runat="server">
    
    </asp:Label>
    </div>
</asp:Content>

