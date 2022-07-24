<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupChannelTypeAdd.aspx.cs" Inherits="SetupActivityAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <table class="contenttext" style="width:400px; ">
        <tr>
            <td>
                <asp:Label ID="lblChannelType" mandatory="true" runat="server" Text="Channel Type"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtChannelType" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeypress="return IsAlphaNumeric(event);">
                </asp:TextBox>
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

