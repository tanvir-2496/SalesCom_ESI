<%@ Page Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupReportApprovalAdd.aspx.cs" Inherits="SetupReportApprovalAdd" %>

<%@ Register Src="~/UserControl/datetimePicker/WebUserControl.ascx" TagName="WebUserControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:WebUserControl ID="WebUserControl1" runat="server" />


    <table class="contenttext" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblReportName" mandatory="true" runat="server" Text="Report Name"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtReportName" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeypress="return IsAlphaNumeric(event)">
                </asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblChannelTypeId" runat="server" Text="Channel Type" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlChannelTypeId" runat="server" SkinID="ddlCommonSkin" CssClass="required"></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Approval Flow" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlApprovalFlow" runat="server" SkinID="ddlCommonSkin" CssClass="required"></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblPeriodType" runat="server" Text="Period Type"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlPeriodType" runat="server" SkinID="ddlCommonSkin"></asp:DropDownList>
            </td>
        </tr>
       
         <tr>
            <td>
                <asp:Label ID="lblMatureDate" runat="server" Text="Maturity Date" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMatureDate" runat="server" SkinID="txtDate" CssClass="date required">
                </asp:TextBox>
                <a id="a3" runat="server">
                    <img src="UserControl/datetimePicker/themes/img.gif" id="Img2" style="cursor: hand;"
                        align="absmiddle" onmouseover="ShowDate(this);" /></a>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblEffectiveDate" runat="server" Text="Effective Date" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEffectiveDate" runat="server" SkinID="txtDate" CssClass="date required">
                </asp:TextBox>
                <a id="a2" runat="server">
                    <img src="UserControl/datetimePicker/themes/img.gif" id="btnLetterRefDate" style="cursor: hand;"
                        align="absmiddle" onmouseover="ShowDate(this);" /></a>
            </td>
        </tr>
        <tr>

            <td>
                <asp:Label ID="lblExpiryDate" runat="server" Text="Expiry Date"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtExpiryDate" runat="server" SkinID="txtDate">
                </asp:TextBox>
                <a id="a1" runat="server">
                    <img src="UserControl/datetimePicker/themes/img.gif" id="Img1" style="cursor: hand;"
                        align="absmiddle" onmouseover="ShowDate(this);" /></a>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblposUpload" runat="server" Text="POS Upload"> </asp:Label></td>
            <td>
                <asp:CheckBox runat="server" ID="chkPosUpload" Checked="false" />
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lbldetailRequired" runat="server" Text="Is Detail Required"> </asp:Label></td>
            <td>
                <asp:CheckBox runat="server" ID="chkDetailRequired" Checked="false" />
            </td>
        </tr>

         <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Disburse By EV System" mandatory="true"> </asp:Label>
            </td>
            <td>          
                <asp:RadioButtonList name="input" ID="RadioDisburseByEVSystem"  runat="server">
                    <asp:ListItem  Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
<%--        <tr>
            <td>
                <asp:Label ID="lblDisbursTime" runat="server" Text="Disburse Time" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDisburseTime" onkeypress="return allowOnlyNumbers(event)" runat="server" SkinID="txtAmmount"  >
                </asp:TextBox>
            </td>
        </tr>--%>

        <tr>
            <td>
                <asp:Label ID="lblSelectedDisburseTime" runat="server" Text="Disburse Time" mandatory="true"> </asp:Label>
            </td>
            <td>
                 <asp:DropDownList ID="ddlSelectedDisburseTime" runat="server" SkinID="ddlCommonSkin"></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="SRF"> </asp:Label></td>
            <td>

                <asp:FileUpload ID="ImageTypeFileUpLoad" runat="server" type="file" />
            </td>
        </tr>


        <tr>

            <td class="tdSubmit" colspan="2">
                <asp:Button ID="btnSave" OnClientClick="return fnValidate();" runat="server" Text="Save" OnClick="btnSave_Click" SkinID="btnCommonSkin" />

            </td>
        </tr>


    </table>


    <div class="msg">
        <asp:Label ID="lblResult" runat="server">
        </asp:Label>
    </div>


    <script type="text/javascript">
        $(document).ready(function () {
            ChangeRadioDisburseByEVSystem();
            $("#<%=RadioDisburseByEVSystem.ClientID%>").click(function () {
                ChangeRadioDisburseByEVSystem();
            });
        });

        function ChangeRadioDisburseByEVSystem() {
            var disburseValue = $.trim($("input[name='<%=RadioDisburseByEVSystem.UniqueID%>']:radio:checked").val());
             if (disburseValue == "1") {
                 $("#<%=lblSelectedDisburseTime.ClientID%>").find("label").show();
                $("#<%=ddlSelectedDisburseTime.ClientID%>").attr("disabled", false);
                $("#<%=ddlSelectedDisburseTime.ClientID%>").addClass('required');

            } else {
                $("#<%=lblSelectedDisburseTime.ClientID%>").find("label").hide();
                $("#<%=ddlSelectedDisburseTime.ClientID%>").removeClass('required');
                $("#<%=ddlSelectedDisburseTime.ClientID%>").attr("disabled", true);
                $("#<%=ddlSelectedDisburseTime.ClientID%>").val("");
                $("#<%=ddlSelectedDisburseTime.ClientID%>").css("border", "1px solid #beb9b9")
            }

        }

    </script>

</asp:Content>
