<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupCommissionReportAdd.aspx.cs" Inherits="SetupActivityAdd" %>


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
                <asp:Label ID="lblReportType" runat="server" Text="Report Type" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlReportType" runat="server" SkinID="ddlCommonSkin" CssClass="required"></asp:DropDownList>
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
                <asp:Label ID="Label2" runat="server" Text="Period" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlPeriod" runat="server" SkinID="ddlCommonSkin" CssClass="required"></asp:DropDownList>
            </td>
        </tr>
    

        <tr>
            <td>
                <asp:Label ID="lblReportGenType" runat="server" Text="Report Gene Type"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlReportGentType" runat="server" SkinID="ddlCommonSkin"></asp:DropDownList>
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
                <asp:Label ID="lblProvisioningDay" runat="server" Text="Provisioning Day" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtProvisioningDay" CssClass="required" runat="server" SkinID="txtAmmount">
                </asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblGenerationDay" runat="server" Text="Generation Day" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtGenerationDay" runat="server" SkinID="txtAmmount" CssClass="required">
                </asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblDelayDay" runat="server" Text="Delay Day" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDelayDay" runat="server" SkinID="txtAmmount" CssClass="required">
                </asp:TextBox>
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
                <asp:Label ID="Label4" runat="server" Text="Disburse By EV System"> </asp:Label>
            </td>
            <td>          
                <asp:RadioButtonList name="input" ID="RadioDisburseByEVSystem"  runat="server">
                    <asp:ListItem  Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>

         <tr>
            <td>
                <asp:Label ID="lblSMSContent" runat="server" Text="SMS Content" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSMSContent" CssClass="required"  runat="server" SkinID="txtCommonSkin" onkeypress="return IsAlphaNumeric(event)">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDisbursTime" runat="server" Text="Disburse Time" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDisburseTime" runat="server" SkinID="txtAmmount" >
                </asp:TextBox>
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



    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>

            <asp:Panel ID="plEvent" runat="server" Visible="true">
                <table>

                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Event"> </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEvent" runat="server" SkinID="ddlCommonSkin"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnAdd" runat="server" Text="Add" SkinID="btnCommonSkin" OnClick="btnAdd_Click" />
                        </td>
                    </tr>

                </table>
                <div class="msg">
                    <asp:Label ID="lblMsg" runat="server">
    
                    </asp:Label>
                </div>
                <div class="ListViewStyle">
                    <asp:ListView ID="lvEOMaster" runat="server" SkinID="ListviewSkin" OnItemCommand="lvEOMaster_ItemCommand">
                        <LayoutTemplate>
                            <table class="datatable" cellpadding="0" cellspacing="0" border="0">
                                <tr class="gridheader">
                                    <th>#
                                    </th>
                                    <th>Event Name
                                    </th>
                                    <th>Delete
                                    </th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server" />
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr class='<%# Container.DataItemIndex % 2 == 0 ? "row" : "altrow" %>'>
                                <td style="text-align: center">
                                    <%# Container.DataItemIndex +1  %>
                                </td>
                                <td style="text-align: center" visible="false">
                                    <%# Eval("EventName")%>&nbsp;
                                </td>
                                <td style="text-align: center">

                                    <asp:LinkButton ID="lnkDel" Text="Delete" OnClientClick="if(!confirm('Do you want to delete?')){ return false; };" runat="server" CommandName="Del" CommandArgument='<%# Eval("EventID").ToString() +"|"+ Eval("ReportID").ToString()%>'></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
                <div class="footer">
                    <asp:Label ID="lblResults" CssClass="gridResults" runat="server" Text="Label"></asp:Label>
                    <div class="pager">
                        <asp:DataPager ID="pager" runat="server" PagedControlID="lvEOMaster" PageSize="15">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonCssClass="PagerButton" ShowFirstPageButton="true"
                                    ShowPreviousPageButton="true" ShowNextPageButton="false" ButtonType="Image" FirstPageImageUrl="~/App_Themes/Theme1/images/first.gif"
                                    RenderDisabledButtonsAsLabels="true" FirstPageText="" PreviousPageText="" PreviousPageImageUrl="~/App_Themes/Theme1/images/prev.gif" />
                                <asp:NumericPagerField ButtonCount="5" CurrentPageLabelCssClass="pagerCurrent" NumericButtonCssClass="pagerNumeric" />
                                <asp:NextPreviousPagerField ButtonCssClass="PagerButton" ShowLastPageButton="true"
                                    ShowNextPageButton="true" ShowPreviousPageButton="false" ButtonType="Image" NextPageImageUrl="~/App_Themes/Theme1/images/next.gif"
                                    LastPageImageUrl="~/App_Themes/Theme1/images/last.gif" LastPageText="" NextPageText=""
                                    RenderDisabledButtonsAsLabels="true" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>

    </asp:UpdatePanel>
    <script type="text/javascript">
        $(document).ready(function () {
           // ChangeRadioDisburseByEVSystem();
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

            } else
            {
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

