<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="PendingApproval.aspx.cs" Inherits="PendingApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
       
        select, label {
            display: block;
        }

        label {
            padding: 6px 0px;
            text-shadow: 1px 2px 2px rgba(255, 255, 255, 0.4);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function refreshWindow() {
            ModifyLeftpanel();
            document.getElementById('<%= btnRefresh.ClientID %>').click();
        }

    </script>

    <div class="leftPanel"></div>
    <div class="Content">


        <div style="text-align: right">

            <p>
                <a class="tooltip" href="#">Report Quick Facts<span class="classic">XYZ_C - COUNT
                    <br />
                    XYZ_A - AMOUNT</span></a>
            </p>

        </div>

        <asp:UpdatePanel ID="upCycle" runat="server">
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

                        <label for="ddlReportPublishedMonth">Due Month </label>

                        <asp:DropDownList ID="ddlReportPublishedMonth" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlReportPublishedMonth_SelectedIndexChanged">
                        </asp:DropDownList>

                    </div>
                    <div style="float: left;">

                        <label for="ddlCommissionCycle">Base Month </label>

                        <asp:DropDownList ID="ddlCommissionCycle" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCommissionCycle_SelectedIndexChanged">
                        </asp:DropDownList>

                    </div>
                </div>
                <br style="clear: both;" />
                <br />
                <hr />
                <br />
                <asp:Button ID="btnRefresh" Style="display: none" runat="server" OnClick="btnRefresh_Click" />
                <div class="ListViewStyle">
                    <asp:ListView ID="lv" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin">
                        <LayoutTemplate>
                            <table class="datatable" cellpadding="0" cellspacing="0" border="0px">
                                <colgroup>
                                    <col />
                                    <col />
                                    <%--<col />--%>
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
                                        <th style="text-align: left">Report Name</th>
                                        <th>Duration</th>
                                        <%--  <th>Publish Month</th>--%>
                                        <th>Level</th>
                                        <th>Commission</th>
                                        <th>Approval</th>
                                        <th>Particulars</th>
                                        <th>SR Content</th>

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
                                    <%#Eval("REPORT_NAME")%>
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("BASE_MOTH")%>
                                </td>
                                <%--    <td style="text-align: center">
                                    <%#Eval("PUBLISH_MONTH") %>
                                </td>--%>
                                <td style="text-align: center">
                                    <%#Eval("CURRENT_LEVEL")%>
                                </td>
                                <td style="text-align: right">
                                    <%#Eval("COM_AMOUNT")%>
                                </td>
                                <td style="text-align: center">
                                    <a type="button" href="CommissionApprovalProcess.aspx?ID= <%#Eval("ID")%>&RCI=<%#Eval("REPORT_CYCLE_ID") %>&LN=<%#Eval("CURRENT_LEVEL") %>&LID=<%#Eval("LEVEL_ID") %>&FID=<%#Eval("FLOW_ID") %>&CID=<%#Eval("CLAIM_FLOW_ID") %>&OID=<%#Eval("ORDER_ID") %>&RN=<%#Eval("REPORT_NAME") %>&RC=<%#Eval("BASE_MOTH") %>&RPC=<%#Eval ("PUBLISH_MONTH") %>&COM=<%#Eval("COM_AMOUNT") %>&TB_iframe=true&height=400&width=550"
                                        class="thickbox" title="Approval Process">Approve/Reject</a>
                                </td>
                                <td style="text-align: center">
                                    <a type="button" href="PendingApprovalSummaryView.aspx?id= <%#Eval("ID")%>&CycleID=<%#Eval("REPORT_CYCLE_ID")%>&TB_iframe=true&height=500&width=750"
                                        class="thickbox" title="Commission Particulars">Particulars</a>
                                </td>

                                <%#Eval("FILE_TYPE") != null ? String.Format("<td style='text-align:center'><a href='DownloadSR.aspx?id={0}&fileex={1}&Fname={2}' target='_blank'>Content</a></td>", Eval("REPORT_ID"), Eval("FILE_TYPE"), Eval("REPORT_NAME")) : "<td style='text-align:center'> No Content </td>"  %>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
                <div class="footer">
                    <asp:Label ID="lblResults" CssClass="gridResults" runat="server" Text="Label"></asp:Label>
                    <div class="pager">
                        <asp:DataPager ID="pager" runat="server" PagedControlID="lv" PageSize="10" OnPreRender="pager_PreRender">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonCssClass="PagerButton" ShowFirstPageButton="true" ShowPreviousPageButton="true" ShowNextPageButton="false" ButtonType="Image" FirstPageImageUrl="~/App_Themes/Theme1/images/first.gif" RenderDisabledButtonsAsLabels="true" FirstPageText="" PreviousPageText="" PreviousPageImageUrl="~/App_Themes/Theme1/images/prev.gif" />
                                <asp:NumericPagerField ButtonCount="5" CurrentPageLabelCssClass="pagerCurrent" NumericButtonCssClass="pagerNumeric" />
                                <asp:NextPreviousPagerField ButtonCssClass="PagerButton" ShowLastPageButton="true" ShowNextPageButton="true" ShowPreviousPageButton="false" ButtonType="Image" NextPageImageUrl="~/App_Themes/Theme1/images/next.gif" LastPageImageUrl="~/App_Themes/Theme1/images/last.gif" LastPageText="" NextPageText="" RenderDisabledButtonsAsLabels="true" />

                            </Fields>
                        </asp:DataPager>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

