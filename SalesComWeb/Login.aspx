<%@ Page Language="C#" MasterPageFile="~/MasterPages/Login.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="Banglalink » Login"   %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">

    if(parent.location.href != window.location.href)
    {
   
      parent.location.href = window.location.href.split('?')[0];
    }
    
     function AdjustWidth(ddl) 
    {    
        var maxWidth = 0;    
        for (var i = 0; i < ddl.length; i++) 
        {        
            if (ddl.options[i].text.length > maxWidth) 
            {            
                maxWidth = ddl.options[i].text.length;        
            }    
        }    
        
        ddl.style.width = maxWidth * 8 + "px";
        
    }
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

<center >
<div id="loginBox" >
<div id="loginHeader">banglalink</div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
<div style="height:200px">
<div id ="loginControls">
<table style="margin:10px 0px 0px 10px;">
<tr>
<td width="120px">User name</td>
<td width="100%">&nbsp;</td>
</tr>
<tr>
<%--<td><asp:TextBox ID ="txtLogin" runat="server" AutoPostBack="true"
        ontextchanged="txtLogin_TextChanged" ></asp:TextBox></td>--%>
    <td><asp:TextBox ID ="txtLogin" runat="server" ></asp:TextBox></td>

<td>&nbsp;</td>
</tr>
<tr>
<td>Password</td>
<td>&nbsp;</td>
</tr>
<tr>
<td><asp:TextBox ID ="txtPassword" runat="server"  TextMode="Password"></asp:TextBox></td>
<td>&nbsp;</td>
</tr>

  <%--  <tr>
                            <td align="left">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblCenter" runat="server" Text="Center" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="ddlCenter" runat="server" Visible="false" Width="200px" onmouseover="AdjustWidth(this)">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtLogin" EventName="TextChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                &nbsp;
                            </td>
</tr>
                  --%>      
<tr>
<td><asp:Button ID ="btnLogin" runat="server" Text="Login" 
        SkinID="btnCommonSkin" onclick="btnLogin_Click" style="float:left;"/></td>
<td>&nbsp;</td>
</tr>
<tr>
<td colspan="2" style="padding-top:10px">
<asp:Label ID ="lblMsg" style="color:Red;" runat="server" SkinID="lblErrorMsgSkin"></asp:Label>
</td>
</tr>
</table>


</div>
<div id ="loginLogo">
<%--<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" width="400" height="200" title="intro">
  <param name="movie" value="images/intro.swf" />
  <param name="quality" value="high" />
  <embed src="images/intro.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="400" height="200"></embed>
</object>--%>
</div>
</div>
<div id="loginFooter">Commission Management</div>



</div>
</center>




</asp:Content>

