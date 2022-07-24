<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupLevelUserAdd20.aspx.cs" Inherits="SetupLevelUserAdd20" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">

        function validateEmail(email) {
            var txtBoxEmail = document.getElementById("txtEmail");

            //var re = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
            var re = /^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/;

            if (!re.test(email)) {
                txtBoxEmail.value = '';
                alert('Invalid Mail Address!')
                setTimeout(function () { document.getElementById("txtEmail").focus(); }, 1);
            }
        }

        function validatePhone(phone) {

            var txtBoxMobile = document.getElementById("txtMobile");
            var re = /^\d{10}$/;

            if (!re.test(phone)) {
                txtBoxMobile.value = '';
                alert('Invalid Phone Number!');
                setTimeout(function () { txtBoxMobile.focus(); }, 1);
            }
        }

    </script>

    <style type="text/css">
        .required {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="contenttext" style="width: 100%;">


        <tr>
            <td>
                <asp:Label ID="lblApprovalFlowName" mandatory="true" runat="server" Text="Approval Flow Name" SkinID="lblCommonSkin"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlApprovalFlowName" CssClass="required" runat="server" SkinID="ddlCommonSkin" OnSelectedIndexChanged="ddlApprovalFlowName_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblApprovalLevelName" mandatory="true" runat="server" Text="Approval Level Name" SkinID="lblCommonSkin"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlApprovalLevelName" CssClass="required" runat="server" SkinID="ddlCommonSkin" OnSelectedIndexChanged="ddlApprovalLevelName_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblUserInfo" runat="server" Text="Login Name" SkinID="lblCommonSkin" mandatory="true"> </asp:Label>
                <asp:HiddenField runat="server" ID="userID" />

            </td>
            <td>
                <asp:TextBox runat="server" ID="txtUser" SkinID="txtDate" CssClass="required"></asp:TextBox>
                &nbsp;<asp:Button ID="btnUserSearch" runat="server" OnClick="btnUserSearch_Click" SkinID="btnCommonSkin" Text="Search" />
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="User Full Name" SkinID="lblCommonSkin"> </asp:Label></td>
            <td>
                <asp:Label ID="lbUserName" runat="server" Text=""> </asp:Label>
            </td>
            <td>
                <asp:Label ID="lblFullName" runat="server" Text="" Visible="false"> </asp:Label>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMobile" runat="server" SkinID="lblCommonSkin" Text="Mobile" mandatory="true"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtMobile" runat="server" SkinID="txtCommonSkin" CssClass="required" ClientIDMode="Static" onchange='javascript: validatePhone( this.value );'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEmail" runat="server" SkinID="lblCommonSkin" Text="Email" mandatory="true"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" SkinID="txtCommonSkin" CssClass="required" ClientIDMode="Static" onchange='javascript: validateEmail( this.value );'>
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

</asp:Content>

