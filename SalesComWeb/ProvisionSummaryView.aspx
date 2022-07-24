<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="ProvisionSummaryView.aspx.cs" Inherits="PendingApprovalSummaryView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Button ID="btnRefresh" Style="display: none" runat="server" OnClick="btnRefresh_Click" />
    <div class="ListViewStyle">
        <asp:ListView ID="lv" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin" OnItemCommand="lv_ItemCommand">
            <LayoutTemplate>
                <table class="datatable" cellpadding="0" cellspacing="0" border="0px">
                    <colgroup>
                        <col />
                        <col />
                        <col />
                        <col />
                        <col />
                        <col />
                        <%--<col />--%>
                    </colgroup>
                    <thead>


                        <tr class="gridheader">
                            <th>#
                            </th>
                            <th>Channel Code
                            </th>
                            <th>Channel Name
                            </th>
                            <th>Commission Amount

                                        <th>Export</th>
                                <th>Details</th>
                                <%--<th>Details</th>--%>
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
                        <%#Eval("ChannelCode")%>&nbsp;
                    </td>
                    <td>
                        <%#Eval("ChannelName")%>&nbsp;
                    </td>
                    <td>
                        <%#Eval("Commission")%>&nbsp;
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkSelect" runat="server" CommandName="ExportAll" CommandArgument='<%#Eval("ChannelId") + "|" + Eval("CycleReportID")%>' Text="Export" />
                    </td>

                    <%--  <td>
                        <asp:LinkButton ID="lnkExportDetail" runat="server" CommandName="ExportDetail" CommandArgument='<%#Eval("ChannelId") + "|" + Eval("CycleReportID")%>' Text="Amount Details" />
                    </td>--%>
                    <td>
                        <asp:LinkButton ID="lbExportDetailCount" runat="server" CommandName="ExportDetailCount" CommandArgument='<%#Eval("ChannelId") + "|" + Eval("CycleReportID")%>' Text="Brackdown" />

                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <div class="footer">
        <asp:Label ID="lblResults" CssClass="gridResults" runat="server" Text="Label"></asp:Label>
        <div class="pager">
            <asp:DataPager ID="pager" runat="server" PagedControlID="lv" PageSize="15" OnPreRender="pager_PreRender">
                <Fields>
                    <asp:NextPreviousPagerField ButtonCssClass="PagerButton" ShowFirstPageButton="true" ShowPreviousPageButton="true" ShowNextPageButton="false" ButtonType="Image" FirstPageImageUrl="~/App_Themes/Theme1/images/first.gif" RenderDisabledButtonsAsLabels="true" FirstPageText="" PreviousPageText="" PreviousPageImageUrl="~/App_Themes/Theme1/images/prev.gif" />
                    <asp:NumericPagerField ButtonCount="5" CurrentPageLabelCssClass="pagerCurrent" NumericButtonCssClass="pagerNumeric" />
                    <asp:NextPreviousPagerField ButtonCssClass="PagerButton" ShowLastPageButton="true" ShowNextPageButton="true" ShowPreviousPageButton="false" ButtonType="Image" NextPageImageUrl="~/App_Themes/Theme1/images/next.gif" LastPageImageUrl="~/App_Themes/Theme1/images/last.gif" LastPageText="" NextPageText="" RenderDisabledButtonsAsLabels="true" />

                </Fields>
            </asp:DataPager>
        </div>
        <asp:LinkButton ID="linkAllPreview" runat="server" OnClick="linkAllPreview_Click">Details</asp:LinkButton>
        <span>|</span>
        <asp:LinkButton ID="linkDetailBrackdown" runat="server" OnClick="linkDetailBrackdown_Click">Brackdown</asp:LinkButton>
        <span>|</span>
        <asp:LinkButton ID="linkAllDisTributor" runat="server" OnClick="linkAllDisTributor_Click">Combine</asp:LinkButton>
    </div>

    <div class="msg">
        <asp:Label ID="lblMsg" runat="server">
    
        </asp:Label>
    </div>
</asp:Content>

