<%@ Page Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" Title="Change Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script type="text/javascript">
  function ValidatePassword()
   {
      var x= fnValidate();
      var p1=document.getElementById('<%=txtUserPassword.ClientID %>');
       var p2=document.getElementById('<%=txtUserConfirmPassword.ClientID %>');
      
    
        $(p1).css("border","solid 1px #C5D3E4");
        $(p2).css("border","solid 1px #C5D3E4");

        if(p1.value!=p2.value)
        {
             $(p1).css("border","solid 1px red");
             $(p2).css("border","solid 1px red");
              return false;
        }
        if(p1.value.length<8)
        {
        $(p1).css("border","solid 1px red");
        return false;
        }
        else if(p2.value.length<8)
        {
        $(p2).css("border","solid 1px red");
        return false;
        }
        
        if(x==false)
        return false ;
        
    }
    
     </script>
  <div class="leftPanel"></div>
  <div class="Content" align ="center"><center>
<table class="contenttext" style="width: 450px; ">
  <tr>
            <td>
                <asp:Label ID="lblBankName" mandatory="true" SkinID="lblCommonSkin" runat="server" Text="Current Password"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password" CssClass="required" SkinID="txtCommonSkin" MaxLength="100">
                </asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label1" mandatory="true" SkinID="lblCommonSkin" runat="server" Text="New Password"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUserPassword" runat="server" TextMode="Password" CssClass="password" SkinID="txtCommonSkin" MaxLength="100">
                </asp:TextBox>
            </td>
        </tr>
        
          <tr>
            <td>
                <asp:Label ID="Label2" mandatory="true" SkinID="lblCommonSkin" runat="server" Text="Confirm Password"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUserConfirmPassword" runat="server" TextMode="Password" CssClass="password" SkinID="txtCommonSkin" MaxLength="100">
                </asp:TextBox>
            </td>
        </tr>
          <tr>
            
            <td colspan="2" class="tdSubmit">
                <asp:Button ID="btnSave"  runat="server" 
                    Text="Save" OnClientClick="return ValidatePassword();" OnClick="btnSave_Click" SkinID="btnCommonSkin" />
            </td>
        </tr>
        <tr>
            
            <td colspan="2">
             <div class="msg">
                <asp:Label ID="lblMsg" runat="server" />
            </div>
            </td>
        </tr>
 </table>
 </center>
</div>
</asp:Content>

