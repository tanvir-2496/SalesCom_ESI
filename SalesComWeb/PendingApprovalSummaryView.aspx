<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="PendingApprovalSummaryView.aspx.cs" Inherits="PendingApprovalSummaryView" %>

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

                    </colgroup>
                    <thead>


                        <tr class="gridheader">
                            <th>#</th>
                            <th>Code</th>
                            <th style="text-align: left; padding-left: 5px">Name</th>
                            <th>Commission</th>
                            <th>Summary</th>
                            <th>Details</th>
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
                    <td style="text-align: left; padding-left: 5px">
                        <%#Eval("ChannelName")%>&nbsp;
                    </td>
                    <td>
                        <%#Eval("Commission")%>&nbsp;
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkSelect" runat="server" CommandName="ExportSummary" CommandArgument='<%#Eval("ChannelCode")%>' Text="Download" />
                    </td>

                    <td>
                        <asp:LinkButton ID="lnkExportDetail" runat="server" CommandName="ExportDetails" CommandArgument='<%#Eval("ChannelId") + "|" + Eval("ChannelCode")%>' Text="Download" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <div class="footer">


        <asp:Label ID="lblResults" CssClass="gridResults" runat="server" Text=""></asp:Label>

        <div class="pager">
            <asp:DataPager ID="pager" runat="server" PagedControlID="lv" PageSize="20" OnPreRender="pager_PreRender">
                <Fields>
                    <asp:NextPreviousPagerField ButtonCssClass="PagerButton" ShowFirstPageButton="true" ShowPreviousPageButton="true" ShowNextPageButton="false" ButtonType="Image" FirstPageImageUrl="~/App_Themes/Theme1/images/first.gif" RenderDisabledButtonsAsLabels="true" FirstPageText="" PreviousPageText="" PreviousPageImageUrl="~/App_Themes/Theme1/images/prev.gif" />
                    <asp:NumericPagerField ButtonCount="5" CurrentPageLabelCssClass="pagerCurrent" NumericButtonCssClass="pagerNumeric" />
                    <asp:NextPreviousPagerField ButtonCssClass="PagerButton" ShowLastPageButton="true" ShowNextPageButton="true" ShowPreviousPageButton="false" ButtonType="Image" NextPageImageUrl="~/App_Themes/Theme1/images/next.gif" LastPageImageUrl="~/App_Themes/Theme1/images/last.gif" LastPageText="" NextPageText="" RenderDisabledButtonsAsLabels="true" />

                </Fields>
            </asp:DataPager>
            <span style="padding-left: 10px; text-align: right">
                <asp:LinkButton ID="lbCompact" runat="server" OnClick="lbCompact_Click" Font-Bold="true">Compact</asp:LinkButton>
                <span style="font-weight: bold">|</span>
                <asp:LinkButton ID="lbSummary" runat="server" OnClick="lbSummary_Click" Font-Bold="true">Summary</asp:LinkButton>
                <span style="font-weight: bold">|</span>
                <asp:LinkButton ID="lbDetails" runat="server" OnClick="lbDetails_Click" Font-Bold="true">Details</asp:LinkButton>
            </span>

        </div>
    </div>


    <div class="msg">
        <asp:Label ID="lblMsg" runat="server">
    
        </asp:Label>
    </div>
</asp:Content>

