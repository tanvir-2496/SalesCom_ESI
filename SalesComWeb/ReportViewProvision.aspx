<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="ReportViewProvision.aspx.cs" Inherits="PendingApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function refreshWindow() {
            ModifyLeftpanel();
          
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
            <Triggers>
            </Triggers>
            <ContentTemplate>
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
                    <tr >
                        <td>
                            <asp:Label ID="lblReportPublishedMonth" runat="server" Text="Report Month"> </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlReportPublishedMonth" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlReportPublishedMonth_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>

                </table>


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

                                </colgroup>
                                <thead>
                                    <tr class="gridheader">
                                        <th>#
                                        </th>
                                        <th style="text-align: left">Report Name
                                        </th>
                                        <th>Commission month</th>
                                        <th>Commission Amt
                                        </th>
                                        <th>Details </th>
                                        <th>Summary</th>


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
                                <td style="text-align: center"><%#Eval("BaseMonth") %></td>

                                <td style="text-align: right">
                                    <%#Eval("TotalAmount")%>&nbsp;
                                </td>

                                <td style="text-align: center">
                                    <asp:LinkButton ID="lbtnDetailsAmount" runat="server" CommandName="DetailsAmount" CommandArgument='<%#Eval("CycleReportID")%>' Text="Details" />
                                </td>

                                <td style="text-align: center">
                                    <a type="button" href="ProvisionSummaryView.aspx?id=10&CycleID=<%#Eval("CycleReportId")%>&TB_iframe=true&height=500&width=750"
                                        class="thickbox" title="Provision Summary">Summary</a>
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
