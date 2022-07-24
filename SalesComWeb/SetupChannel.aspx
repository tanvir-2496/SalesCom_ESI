﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="SetupChannel.aspx.cs" Inherits="SetupActivity" %>

<%@ OutputCache Duration="120" VaryByParam="*" %>


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

        <asp:UpdatePanel ID="lstpanel" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnRefresh" Style="display: none" runat="server" OnClick="btnRefresh_Click" />

                <div class="ListViewStyle">
                    <asp:ListView ID="lv" runat="server" ItemPlaceholderID="item" DataSourceID="channelPage" SkinID="ListviewSkin">
                        <LayoutTemplate>
                            <table class="datatable" cellpadding="0" cellspacing="0" border="0px">
                                <colgroup>
                                    <col />
                                    <col />
                                    <col />
                                    <col />
                                </colgroup>
                                <thead>
                                    <tr class="gridheader">
                                        <th>#
                                        </th>
                                        <th>Parent Channel ID
                                        </th>
                                        <th>Channel Type ID
                                        </th>
                                        <th>Channel Name
                                        </th>
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
                                    <%#Eval("ParentChannelName")%>&nbsp;
                                </td>
                                <td>
                                    <%#Eval("ChannelType")%>&nbsp;
                                </td>
                                <td>
                                    <%#Eval("ChannelName")%>&nbsp;
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
                <div class="footer">
                    <asp:Label ID="lblResults" CssClass="gridResults" runat="server" Text="Label"></asp:Label>
                    <div class="pager">
                        <asp:DataPager ID="pager" runat="server" PagedControlID="lv" PageSize="15">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonCssClass="PagerButton" ShowFirstPageButton="true" ShowPreviousPageButton="true" ShowNextPageButton="false" ButtonType="Image" FirstPageImageUrl="~/App_Themes/Theme1/images/first.gif" RenderDisabledButtonsAsLabels="true" FirstPageText="" PreviousPageText="" PreviousPageImageUrl="~/App_Themes/Theme1/images/prev.gif" />
                                <asp:NumericPagerField ButtonCount="5" CurrentPageLabelCssClass="pagerCurrent" NumericButtonCssClass="pagerNumeric" />
                                <asp:NextPreviousPagerField ButtonCssClass="PagerButton" ShowLastPageButton="true" ShowNextPageButton="true" ShowPreviousPageButton="false" ButtonType="Image" NextPageImageUrl="~/App_Themes/Theme1/images/next.gif" LastPageImageUrl="~/App_Themes/Theme1/images/last.gif" LastPageText="" NextPageText="" RenderDisabledButtonsAsLabels="true" />
                            </Fields>
                        </asp:DataPager>
                        <asp:ObjectDataSource ID="channelPage" runat="server" TypeName="Channel" SelectMethod="GetStoreChannel" EnablePaging="true"
                            StartRowIndexParameterName="startrows" MaximumRowsParameterName="pagesize" SelectCountMethod="TotalNumberOfChannel"></asp:ObjectDataSource>
                    </div>
                </div>

            </ContentTemplate>

        </asp:UpdatePanel>
    </div>

</asp:Content>

