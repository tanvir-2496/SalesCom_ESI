<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupAdHocReportAdd.aspx.cs" Inherits="SetupActivityAdd" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    


    <table class="contenttext" style="width: 100%;">
        <!-- Addition!-->
        <tr>
            <td>
                <asp:Label ID="lblUpdatedReortName" runat="server" Text="Report Name"> </asp:Label>
            </td>
            <td>
               <asp:Label ID="ddlUpdatedReortName" runat="server" Text="Name"> </asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblReportName" runat="server" Text="Name"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtReportName" runat="server">
                </asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblSetupReportId" runat="server" Text="Report Name" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSetupReportId" runat="server" SkinID="ddlCommonSkin" CssClass="required" AutoPostBack="true"  OnSelectedIndexChanged="ddlGetReportInformation"></asp:DropDownList>
            </td>
        </tr>
         <!-- Addition!-->
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
                <asp:Label ID="Label2" runat="server" Text="Period" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlPeriod" runat="server" SkinID="ddlCommonSkin" CssClass="required"></asp:DropDownList>
            </td>
        </tr>


        <tr>
            <td>
                <asp:Label ID="lblReportGenType" runat="server" Text="Report Gen Type" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlReportGentType" runat="server" SkinID="ddlCommonSkin" CssClass="required"></asp:DropDownList>
            </td>
        </tr>


        <tr>
            <td>
                <asp:Label ID="lblApprovalFlow" runat="server" Text="Approval Flow" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlApprovalFlow" runat="server" SkinID="ddlCommonSkin" CssClass="required"></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblClaimApprovalFlow" runat="server" Text="Claim Flow" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlCliamApprovalFlow" runat="server" SkinID="ddlCommonSkin" CssClass="required"></asp:DropDownList>
            </td>
        </tr>


        <tr>
            <td>
                <asp:Label ID="lblDisburseApprobvalFlow" runat="server" Text="Disburse Flow" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlDisburseApprovalFlow" runat="server" SkinID="ddlCommonSkin" CssClass="required"></asp:DropDownList>
            </td>
        </tr>



        <tr>
            <td>
                <asp:Label ID="lblIsActive" runat="server" Text="Is Active"> </asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chkIsActive" runat="server" Checked="true" />
            </td>
        </tr>

          <tr>
            <td>
                <asp:Label ID="lblDisburseByEVSystem" runat="server" Text="Disburse By EV System" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="RadioDisburseByEVSystem"  CssClass="required" runat="server">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSMSContent" mandatory="true" runat="server" Text="SMS Content"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSMSContent" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeypress="return IsAlphaNumeric(event)">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDisbursTime" runat="server" Text="Disburse Time"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDisburseTime" runat="server" SkinID="txtAmmount" >
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="File"> </asp:Label></td>
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
            //ChangeRadioDisburseByEVSystem();
            $("#<%=RadioDisburseByEVSystem.ClientID%>").click(function () {
               // ChangeRadioDisburseByEVSystem();
            });
        });
        function ChangeRadioDisburseByEVSystem() {
            var disburseValue = $.trim($("input[name='<%=RadioDisburseByEVSystem.UniqueID%>']:radio:checked").val());
            if (disburseValue == "1") {
                $("#<%=lblSMSContent.ClientID%>").find("label").show();
                $("#<%=lblDisbursTime.ClientID%>").find("label").show();
                $("#<%=txtSMSContent.ClientID%> , #<%=txtDisburseTime.ClientID%>").attr("disabled", false);
                $("#<%=txtSMSContent.ClientID%> , #<%=txtDisburseTime.ClientID%>").addClass('required');

            } else {
                $("#<%=lblSMSContent.ClientID%>").find("label").hide();
                $("#<%=lblDisbursTime.ClientID%>").find("label").hide();
                $("#<%=txtSMSContent.ClientID%> , #<%=txtDisburseTime.ClientID%>").removeClass('required');
                $("#<%=txtSMSContent.ClientID%> , #<%=txtDisburseTime.ClientID%>").attr("disabled", true);
                $("#<%=txtSMSContent.ClientID%> , #<%=txtDisburseTime.ClientID%>").val("");
                $("#<%=txtSMSContent.ClientID%> , #<%=txtDisburseTime.ClientID%>").css("border", "1px solid #beb9b9")
            }

        }

    </script>

</asp:Content>

