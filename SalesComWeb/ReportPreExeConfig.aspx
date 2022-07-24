<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="ReportPreExeConfig.aspx.cs" Inherits="SetupActivity" %>


<%@ Register Src="~/UserControl/datetimePicker/WebUserControl.ascx" TagName="WebUserControl"
    TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        select, label {
            display: block;
        }

        label {
            padding: 6px 0px;
            text-shadow: 1px 2px 2px rgba(255, 255, 255, 0.4);
        }
        .tbl-inline input {width: 79% !important;float: left;display: block;height: 18px !important;}

.tbl-inline a {display: block;float: left;width: 10%;}

.tbl-inline {display: block;overflow: hidden;min-width: 120px; max-width: 125px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:WebUserControl ID="WebUserControl1" runat="server" />
    <script type="text/javascript">
        function refreshWindow() {
            ModifyLeftpanel();
        }

    </script>


    <div class="leftPanel"></div>
    <div class="Content">



        <asp:UpdatePanel ID="lstpanel" runat="server">
            <Triggers>
            </Triggers>
            <ContentTemplate>
                <div>
                    <div style="float: left; margin-right: 20px">

                        <label for="ddlYear">Year </label>

                        <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPeridType_SelectedIndexChanged">
                        </asp:DropDownList>

                    </div>
                    <div style="float: left; margin-right: 20px">

                        <label for="ddlPeridType">Period Type </label>

                        <asp:DropDownList ID="ddlPeridType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPeridType_SelectedIndexChanged">
                        </asp:DropDownList>

                    </div>


                    <div style="float: left; margin-right: 20px">

                        <label for="ddlCommissionCycle">Publish Cycle </label>
                        <asp:DropDownList ID="ddlCommissionCycle" runat="server" OnSelectedIndexChanged="ddlCommissionCycle_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>

                    </div>
                    <div style="float: left;">

                        <label for="ddlProvisionCycle">Provision Cycle </label>
                        <asp:DropDownList ID="ddlProvisionCycle" runat="server" OnSelectedIndexChanged="ddlProvisionCycle_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>

                    </div>
                </div>
                <br style="clear: both;" />
                <br />
                <hr />
                <br />

                <div class="ListViewStyle">
                    <asp:ListView ID="lv" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin">
                        <LayoutTemplate>
                            <table class="datatable" cellpadding="0" cellspacing="0" border="0px">
                                <colgroup>
                                    <col />
                                    <col />
                                    <col />
                                    <col />
                                    <col />
                                    <col />
                                    <col />
                                    <col />
                                    <col />
                                    <col />
                                </colgroup>
                                <thead>
                                    <tr class="gridheader">
                                        <th>#</th>
                                        <th>Report Name</th>
                                        <th>Report Type</th>
                                        <th>Base Cycle</th>
                                        <th>Provision Cycle</th>
                                        <th>Publish Cycle</th>
                                        <th>Status</th>
                                        <th>Provision Duration</th>
                                        <th>Report Duration</th>
                                        <th>Maturity Date</th>
                                        <th>Lead Cycle(s)</th>

                                    </tr>
                                </thead>
                                <tbody>
                                    <tr id="itemPlaceholder" runat="server" />
                                    <asp:PlaceHolder runat="server" ID="item"></asp:PlaceHolder>

                                </tbody>

                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr class='<%# Container.DataItemIndex % 2 == 0 ? "row" : "altrow" %>'>
                                <td style="text-align: center">
                                    <%# Container.DataItemIndex +1  %>
                                </td>
                                <td>
                                    <%#Eval("ReportName")%>&nbsp;
                                </td>


                                <td style="text-align: center">
                                    <%#Eval("REPORTGENTYPEID")%>&nbsp;
                                </td>

                                <td style="text-align: center">
                                    <%#Eval("COMMISSIONCYCLE")%>&nbsp;
                                </td>

                                <td style="text-align: center">
                                    <%#Eval("PROVISIONCYCLE")%>&nbsp;
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("PublishCycle")%>&nbsp;
                                </td>
                                <td style="text-align: center">
                                    <input type="checkbox" disabled="true" <%#Eval("STATUS").ToString()=="1"?"checked":"" %> />&nbsp
                                </td>

                                <td style="text-align: center">
                                    <%#Common.DateFormat(Eval("PROVISIONFROMDATE")) %> -    <%#Common.DateFormat(Eval("PROVISIONTODATE")) %>&nbsp
                                </td>

                                <td style="text-align: center">
                                    <%#Common.DateFormat(Eval("REPORTFROMDATE")) %> -  <%#Common.DateFormat(Eval("REPORTTODATE")) %>&nbsp
                                </td>
                                <td style="text-align: center">
                                    <%#Common.DateFormat(Eval("ComMatureDate"))%>&nbsp
                                </td>

                                <td style="text-align: center">
                                    <asp:Button ID="btnLoad" class="loadButtonEx" runat="server" Text="Load" OnClick="btnLoad_Click" CommandArgument='<%#Eval("ReportName") + "," + Eval("ReportId") + "," + Eval("CycleId") + "," + Eval("REPORTFROMDATE") + "," +Eval("REPORTTODATE") +","+Eval("COMMISSIONCYCLE")+","+Eval("MatureDate")+","+Eval("LateReason") %>' />
                                </td>

                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
                <div class="footer">
                    <asp:Label ID="lblResults" CssClass="gridResults" runat="server" Text=""></asp:Label>
                    <div class="pager">
                        <asp:DataPager ID="pager" runat="server" PagedControlID="lv" PageSize="5" OnPreRender="pager_PreRender">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonCssClass="PagerButton" ShowFirstPageButton="true" ShowPreviousPageButton="true" ShowNextPageButton="false" ButtonType="Image" FirstPageImageUrl="~/App_Themes/Theme1/images/first.gif" RenderDisabledButtonsAsLabels="true" FirstPageText="" PreviousPageText="" PreviousPageImageUrl="~/App_Themes/Theme1/images/prev.gif" />
                                <asp:NumericPagerField ButtonCount="5" CurrentPageLabelCssClass="pagerCurrent" NumericButtonCssClass="pagerNumeric" />
                                <asp:NextPreviousPagerField ButtonCssClass="PagerButton" ShowLastPageButton="true" ShowNextPageButton="true" ShowPreviousPageButton="false" ButtonType="Image" NextPageImageUrl="~/App_Themes/Theme1/images/next.gif" LastPageImageUrl="~/App_Themes/Theme1/images/last.gif" LastPageText="" NextPageText="" RenderDisabledButtonsAsLabels="true" />

                            </Fields>
                        </asp:DataPager>
                    </div>
                </div>

                <h4 style="text-align: left" id="lblReportName" runat="server" visible="false"></h4>

                <div class="ListViewStyle" runat="server" visible="false" id="dvLeadCycleDetails">
                    <asp:ListView ID="lvReportCycle" runat="server" ItemPlaceholderID="items" SkinID="ListviewSkin"
                        OnItemEditing="lvReportCycle_ItemEditing" OnItemDataBound="lvReportCycle_ItemDataBound"
                        OnItemCanceling="lvReportCycle_ItemCanceling" OnPagePropertiesChanging="lvReportCycle_PagePropertiesChanging"
                        OnItemCommand="lvReportCycle_ItemCommand" OnItemUpdating="lvReportCycle_ItemUpdating">
                        <LayoutTemplate>
                            <div style="overflow-x:scroll;">

                                <table class="datatable" cellpadding="0" cellspacing="0" border="0px">
                                    <colgroup>

                                        <col />
                                        <col />
                                        <col />
                                        <col />
                                        <col />
                                        <col />
                                        <col />
                                        <col />
                                        <col />
                                        <col />

                                    </colgroup>
                                    <thead>
                                        <tr class="gridheader">
                                            <th>#</th>
                                            <th>Base Cycle</th>
                                            <th>Provision Cycle</th>
                                            <th>Publish Cycle</th>
                                            <th>Status</th>
                                            <th>Provision From</th>
                                            <th>Provision To</th>
                                            <th>Report From</th>
                                            <th>Report To</th>
                                            <th>Maturity Date</th>
                                            <th>Delay Reason</th>
                                            <th>Edit</th>


                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr id="itemPlaceholder" runat="server" />
                                        <asp:PlaceHolder runat="server" ID="items"></asp:PlaceHolder>

                                    </tbody>

                                </table>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr class='<%# Container.DataItemIndex % 2 == 0 ? "row" : "altrow" %>'>
                                <td style="text-align: center">
                                    <%# Container.DataItemIndex +1  %>
                                </td>

                                <td style="text-align: center">
                                    <%#Eval("COMMISSIONCYCLE")%>&nbsp;
                                </td>

                                <td style="text-align: center">
                                    <%#Eval("PROVISIONCYCLE")%>&nbsp;
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("PublishCycle")%>&nbsp;
                                </td>

                                <td style="text-align: center">
                                    <input type="checkbox" disabled="true" <%#Eval("STATUS").ToString()=="1"?"checked":"" %> />&nbsp
                                </td>

                                <td style="text-align: center">
                                    <%#Common.DateFormat(Eval("PROVISIONFROMDATE")) %> &nbsp
                                </td>

                                <td style="text-align: center">
                                    <%#Common.DateFormat(Eval("PROVISIONTODATE")) %>&nbsp
                                </td>

                                <td style="text-align: center">
                                    <%#Common.DateFormat(Eval("REPORTFROMDATE")) %>&nbsp
                                </td>
                                <td style="text-align: center">
                                    <%#Common.DateFormat(Eval("REPORTTODATE")) %>&nbsp
                                </td>
                                <td style="text-align: center">
                                    <%#Common.DateFormat(Eval("ComMatureDate")) %>&nbsp
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("LateReason")%>&nbsp;
                                </td>
                                <td>
                                    <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CommandName="Edit"></asp:LinkButton>
                                </td>

                            </tr>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <tr>

                                <td style="text-align: center">
                                    <%# Container.DataItemIndex +1  %>
                                </td>

                                <td style="text-align: center">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("COMMISSIONCYCLE") %>'></asp:Label>
                                </td>

                                <td style="text-align: center">

                                    <asp:DropDownList ID="ddlProvisionCycle" runat="server">
                                    </asp:DropDownList>

                                </td>

                                <td style="text-align: center">

                                    <asp:DropDownList ID="ddlPublishCycle" runat="server">
                                    </asp:DropDownList>

                                </td>


                                <td style="text-align: center">
                                    <asp:CheckBox runat="server" ID="chkStatus" Checked='<%#Eval("STATUS").ToString()=="1"?true:false %>' />&nbsp
                                </td>


                                <td>
                                    <div class="tbl-inline">
                                    <asp:TextBox ID="txtProvisionFromDate" runat="server" SkinID="txtDate" Text='<%#Common.DateFormat(Eval("PROVISIONFROMDATE")) %>'>
                   
                                    </asp:TextBox>

                                    <a id="a2" runat="server">
                                        <img src="UserControl/datetimePicker/themes/img.gif" id="btnLetterRefDate" style="cursor: hand;"
                                            align="absmiddle" onmouseover="ShowDate(this);" /></a>
                                        </div>
                                </td>

                                <td>
                                    <div class="tbl-inline">
                                    <asp:TextBox ID="txtProvisionToDate" runat="server" SkinID="txtDate" Text='<%#Common.DateFormat(Eval("PROVISIONTODATE")) %>'>
                   
                                    </asp:TextBox>

                                    <a id="a1" runat="server">
                                        <img src="UserControl/datetimePicker/themes/img.gif" id="Img1" style="cursor: hand;"
                                            align="absmiddle" onmouseover="ShowDate(this);" /></a>
                                        </div>
                                </td>

                                <td>
                                    <div class="tbl-inline">
                                    <asp:TextBox ID="txtReportFromDate" runat="server" SkinID="txtDate" Text='<%#Common.DateFormat(Eval("REPORTFROMDATE")) %>'>
                   
                                    </asp:TextBox>

                                    <a id="a3" runat="server">
                                        <img src="UserControl/datetimePicker/themes/img.gif" id="Img2" style="cursor: hand;"
                                            align="absmiddle" onmouseover="ShowDate(this);" /></a>
                                        </div>
                                </td>

                                <td>
                                    <div class="tbl-inline">
                                        <asp:TextBox ID="txtReportToDate" runat="server" SkinID="txtDate" Text='<%#Common.DateFormat(Eval("REPORTTODATE")) %>'>
                   
                                    </asp:TextBox>

                                    <a id="a4" runat="server">
                                        <img src="UserControl/datetimePicker/themes/img.gif" id="Img3" style="cursor: hand;"
                                            align="absmiddle" onmouseover="ShowDate(this);" /></a>
                                    </div>
                                </td>
                                <td>
                                    <div class="tbl-inline">
                                    <asp:TextBox ID="txtMatureDate" runat="server" SkinID="txtDate" Text='<%# CheckMatureDate(Common.DateFormat( Eval("ComMatureDate"))) %>'>
                                    </asp:TextBox>


                                    <a id="a5" runat="server">
                                        <img src="UserControl/datetimePicker/themes/img.gif" id="Img4" style="cursor: hand;"
                                            align="absmiddle" onmouseover="ShowDate(this);" /></a>
                                        </div>
                                </td>
                                <td>
                                     <div class="tbl-inline">
                                    <asp:TextBox ID="txtLateReason" runat="server" SkinID="txtCommonSkin" Text='<%#Eval("LateReason") %>'>
                                    </asp:TextBox>
                                         </div>
                                </td>

                                <td style="text-align: center">
                                    <span onclick="return confirm('Are you sure to update?')">
                                        <asp:LinkButton runat="server" ID="btnUpdate" Text="Update" CommandName="Update" CommandArgument='<%#Eval("CycleReportId") %>' />
                                    </span>
                                    |
                                        <asp:LinkButton runat="server" ID="btnCancel" Text="Cancel" CommandName="Cancel" />
                                </td>

                            </tr>
                        </EditItemTemplate>
                    </asp:ListView>
                </div>

                <div class="footer" runat="server" id="dvLeadCycelPage" visible="false">
                    <asp:Label ID="lblLeadCycleResult" CssClass="gridResults" runat="server" Text=""></asp:Label>
                    <div class="pager">
                        <asp:DataPager ID="dpLeadCycles" runat="server" PagedControlID="lvReportCycle" PageSize="5" OnPreRender="dpLeadCycles_PreRender">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonCssClass="PagerButton" ShowFirstPageButton="true" ShowPreviousPageButton="true" ShowNextPageButton="false" ButtonType="Image" FirstPageImageUrl="~/App_Themes/Theme1/images/first.gif" RenderDisabledButtonsAsLabels="true" FirstPageText="" PreviousPageText="" PreviousPageImageUrl="~/App_Themes/Theme1/images/prev.gif" />
                                <asp:NumericPagerField ButtonCount="5" CurrentPageLabelCssClass="pagerCurrent" NumericButtonCssClass="pagerNumeric" />
                                <asp:NextPreviousPagerField ButtonCssClass="PagerButton" ShowLastPageButton="true" ShowNextPageButton="true" ShowPreviousPageButton="false" ButtonType="Image" NextPageImageUrl="~/App_Themes/Theme1/images/next.gif" LastPageImageUrl="~/App_Themes/Theme1/images/last.gif" LastPageText="" NextPageText="" RenderDisabledButtonsAsLabels="true" />

                            </Fields>
                        </asp:DataPager>
                    </div>
                </div>

                <div class="msg">
                    <br />
                    <asp:Label ID="lblResult" runat="server">
                    </asp:Label>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

    </div>

</asp:Content>

