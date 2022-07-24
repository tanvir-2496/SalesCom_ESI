<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="ViewChannelWithdrawal.aspx.cs" Inherits="SetupActivity" %>

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

      

        <div>
            <% if (Permissions.ChannelWithdrawalAdd)
               { %>
            <div style="text-align: right">
                <asp:Button runat="server" ID="btnExport" Text="Import Withdrawal Channel" SkinID="btnCommonSkinLarge" OnClick="btnExport_Click" />
            </div>
            <% }%>
        </div>
        <div>
            <asp:UpdatePanel ID="upReport" runat="server">
                <ContentTemplate>
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblReportName" runat="server" SkinID="lblCommonSkin" Text="Report Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlReportName" runat="server" SkinID="ddlCommonSkin" AutoPostBack="true" OnSelectedIndexChanged="ddlReportName_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl" runat="server" SkinID="lblCommonSkin" Text="Report Cycle"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlReportCycle" runat="server" SkinID="ddlCommonSkin"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                     <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" SkinID="btnCommonSkin" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>

            </asp:UpdatePanel>
            <br />
        </div>
        <asp:UpdatePanel ID="lstpanel" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnRefresh" Style="display: none" runat="server" OnClick="btnRefresh_Click" />
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

                                </colgroup>

                                <thead>
                                    <tr class="gridheader">
                                        <th>#</th>
                                        <th>Reference Number</th>
                                        <th>Report Name</th>
                                        <th>Channel Code</th>
                                        <th>Channel Name</th>
                                        <th>Imported By</th>
                                        <th>Import Date</th>


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
                                <td><%#Eval("ReferenceNumber") %></td>
                                <td>
                                    <%#Eval("ReportName")%>&nbsp;
                                </td>
                                <td>
                                    <%#Eval("ChannelCode") %>&nbsp
                                </td>
                                <td>
                                    <%#Eval("ChannelName") %>&nbsp
                                </td>
                                <td>
                                    <%#Eval("ImportedBy") %>&nbsp
                                </td>

                                <td><%#Common.DateFormat(Eval("ImportDate")) %> </td>

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
                </div>

            </ContentTemplate>

        </asp:UpdatePanel>
    </div>

</asp:Content>

