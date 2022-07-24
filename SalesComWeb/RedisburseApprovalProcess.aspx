<%@ Page Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="RedisburseApprovalProcess.aspx.cs" Inherits="RedisburseApprovalProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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

        <asp:UpdatePanel ID="upCycle" runat="server">
            <Triggers>
            </Triggers>

            <ContentTemplate>
                <asp:Button ID="btnRefresh" Style="display: none" runat="server" OnClick="btnRefresh_Click" />
                <br />
                <br />  
                <div class="ListViewStyle">
                    <asp:ListView ID="lv" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin" OnItemCommand="lv_ItemCommand" OnItemDataBound="lv_ItemDataBound">
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
                                    <col />
                                </colgroup>
                                <thead>
                                    <tr class="gridheader">
                                        <th>#</th>
                                        <th style="text-align: left">Report Name</th>
                                        <th>Report Duration</th>
                                        <th>Re-disb #</th>
                                        <th>Claim Amt</th>
                                        <th>Withheld</th>
                                        <th>Disburse</th>
                                        <th>Cur. Disb </th>
                                        <th>Cur. Level</th>
                                        <th>Details</th>
                                        <th>Approval</th>
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
                                    <%#Eval("reportname")%>&nbsp;
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("report_duration")%>&nbsp;
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("current_redisburse_number")%>&nbsp;
                                </td>
                                <td style="text-align: right">
                                    <%#Eval("claim_amt")%>&nbsp;
                                </td>
                                <td style="text-align: right">
                                    <%#Eval("withheld_amt")%>&nbsp;
                                </td>
                                <td style="text-align: right">
                                    <%#Eval("disburse_amt")%>&nbsp;
                                </td>

                                <td style="text-align: right">
                                    <%#Eval("curr_disburse_amt")%>&nbsp;
                                </td>

                                <td style="text-align: center">
                                    <%#Eval("approvallevelname")%>&nbsp;
                                </td>

                                <td style="text-align: center">
                                    <asp:LinkButton ID="lbtnDetailsAmount" runat="server" CommandName="DetailsAmount" CommandArgument='<%#Eval("report_cycle_id")%>' Text="Detail" />
                                </td>
                                <td style="text-align: center">

                                    <a type="button" href="RedisburseApprovalAction.aspx?ID=<%#Eval("redisburse_id") %>&RCID= <%#Eval("report_cycle_id")%>&LN=<%#Eval("approvallevelname") %>&LID=<%#Eval("current_level_id") %>&FID=<%#Eval("flow_id") %>&OID=<%#Eval("current_order_id") %>&RN=<%#Eval("reportname") %>&RD=<%#Eval("report_duration") %>&WAM=<%#Eval("withheld_amt") %>&CWAM=<%#Eval("curr_disburse_amt") %>&TB_iframe=true&height=400&width=550"
                                        class="thickbox" title="Disburse Approve or Reject">Approve/Reject</a>

                                </td>

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

