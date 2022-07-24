﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="ClaimApprovalProcess.aspx.cs" Inherits="PendingApproval" %>

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

        <asp:UpdatePanel ID="upCycle" runat="server">
            <Triggers>
            </Triggers>

            <ContentTemplate>
                <asp:Button ID="btnRefresh" Style="display: none" runat="server" OnClick="btnRefresh_Click" />
                <table style="width: 350px">

                    <tr runat="server" id="trPeriodType" visible="true">
                        <td>
                            <asp:Label ID="lblPeriodType" runat="server" Text="Period Type"> </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPeridType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPeridType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>


                    <tr runat="server" id="trYear" visible="true">
                        <td>
                            <asp:Label ID="lblYear" runat="server" Text="Year"> </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPeridType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>


                    <tr>
                        <td>
                            <asp:Label ID="lblCommissionCycle" runat="server" Text="Due Month"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCommissionCycle" runat="server" OnSelectedIndexChanged="ddlCommissionCycle_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>

                </table>



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
                                </colgroup>
                                <thead>
                                    <tr class="gridheader">
                                        <th>#</th>
                                        <th style="text-align: left">Report Name</th>
                                        <th>Duration</th>
                                        <th>Status</th>
                                        <th>Commission</th>
                                        <th>Discard</th>
                                        <th>Claim</th>
                                        <th>Details </th>
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
                                    <%#Eval("REPORTNAME")%>&nbsp;
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("REPORT_DURATION")%>&nbsp;
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("CURRENT_STATUS")%>&nbsp;
                                </td>
                                <td style="text-align: right">
                                    <%#Eval("REPORT_AMT")%>&nbsp;
                                </td>
                                <td style="text-align: right">
                                    <%#Eval("DISCARD_AMT")%>&nbsp;
                                </td>
                                <td style="text-align: right">
                                    <%#Eval("CLAIM_AMT")%>&nbsp;
                                </td>
                                <td style="text-align: center">
                                    <asp:LinkButton ID="lbtnDetailsAmount" runat="server" CommandName="DetailsAmount" CommandArgument='<%#Eval("REPORT_CYCLE_ID")%>' Text="Detail" />
                                </td>
                                <td style="text-align: center">

                                    <%if (Permissions.ClaimApprovalOperation)
                                      {%>
                                    <a type="button" href="ClaimApprovalAction.aspx?ID=<%#Eval("ID") %>&RCID= <%#Eval("REPORT_CYCLE_ID")%>&LN=<%#Eval("level_name") %>&LID=<%#Eval("LEVEL_ID") %>&FID=<%#Eval("FLOW_ID") %>&DFID=<%#Eval("DISBURSE_FLOW_ID") %>&OID=<%#Eval("ORDERID") %>&RN=<%#Eval("REPORTNAME") %>&RD=<%#Eval("REPORT_DURATION") %>&RAM=<%#Eval("REPORT_AMT") %>&DAM=<%#Eval("DISCARD_AMT") %>&CAM=<%#Eval("CLAIM_AMT") %>&TB_iframe=true&height=400&width=550"
                                        class="thickbox" title="Claim Approve or Reject">Approve/Reject</a>
                                    <%}
                                      else
                                      { %>
                                    <span>disallowed</span>
                                    <%} %>
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

