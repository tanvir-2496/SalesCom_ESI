<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="InitiateClaimApproval.aspx.cs" Inherits="PendingApproval" %>

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
                                </colgroup>
                                <thead>
                                    <tr class="gridheader">
                                        <th>#
                                        </th>
                                        <th style="text-align: left">Report Name
                                        </th>
                                        <th>Commission Month</th>
                                        <th>Status</th>
                                        <th>Commission</th>
                                        <th>Details </th>
                                        <th>Initialize</th>

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
                                    <%#Eval("REPORT_NAME")%>&nbsp;
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("REPORT_DURATION")%>&nbsp;
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("CURRENT_STATUS")%>&nbsp;
                                </td>
                                <td style="text-align: right">
                                    <%#Eval("COMMISSION_AMOUNT")%>&nbsp;
                                </td>
                                <td style="text-align: center">
                                    <asp:LinkButton ID="lbtnDetailsAmount" runat="server" CommandName="DetailsAmount" CommandArgument='<%#Eval("REPORT_CYCLE_ID")+"|"+Eval("REPORT_ID")%>' Text="Detail" />
                                </td>

                                <% if (Permissions.InitiateClaimApprovalUpload)
                                  { %>

                                <%# Convert.ToInt16(Eval("order_id")) == 1 ? String.Format("<td style='text-align: center'><a type='button' href='InitiateClaimSubmit.aspx?RCID={0}&RN={1}&RC={2}&RD={3}&RF={4}&RTI={5}&TB_iframe=true&height=550&width=750'class='thickbox' title='Claim Initiation'>Claim</a></td>", Eval("REPORT_CYCLE_ID"), Eval("REPORT_NAME"), Eval("COMMISSION_AMOUNT"), Eval("REPORT_DURATION"), Eval("FLOW_ID"), Eval("REPORT_TYPE_ID")) : "<td style='text-align:center'> Under Process </td>"  %>
                                <% }
                                  else
                                  { %>

                                <td style="text-align: center"><span>disallowed</span></td>
                                <% } %>
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

