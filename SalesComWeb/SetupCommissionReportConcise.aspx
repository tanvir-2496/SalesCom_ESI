﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="SetupCommissionReportConcise.aspx.cs" Inherits="SetupActivity" %>

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


        <% if (Permissions.CommissionReportConciseAdd)
           { %>
        <div style="text-align: right">
            <input type="button" value="Add New" alt="SetupCommissionReportConciseAdd.aspx?keepThis=false&TB_iframe=true&height=400&width=450"
                class="thickbox" title="Commission Report Add" />
        </div>
        <% }%>
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
                                        <th>Report Name</th>
                                        <th>Effective Date</th>
                                        <th>End Date</th>
                                        <th>Channel Type</th>
                                        <th>SR</th>
                                        <th>Edit</th>
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
                                <%# DateTime.Compare(Convert.ToDateTime(Eval("StartDate")),default(DateTime)) != 0 ? String.Format("<td style='text-align:center'>{0}</td>", Convert.ToDateTime(Eval("StartDate")).ToString("dd-MMM-yyyy")) : "<td style='text-align:center; color:DarkRed'> Undefined </td>" %>

                                <%# DateTime.Compare(Convert.ToDateTime(Eval("EndDate")),default(DateTime)) != 0 ? String.Format("<td style='text-align:center'>{0}</td>", Convert.ToDateTime(Eval("EndDate")).ToString("dd-MMM-yyyy")) : "<td style='text-align:center; color:CornflowerBlue'> Till further notice </td>" %>

                                <td>
                                    <%#Eval("ChannelType")%>&nbsp;
                                </td>

                                <%#Eval("FileType") != null ? String.Format("<td style='text-align:center'><a href='DownloadSR.aspx?id={0}&fileex={1}&Fname={2}' target='_self'>Content</a></td>", Eval("ReportId"), Eval("FileType"), Eval("ReportName")) : "<td style='text-align:center'> No Content </td>"  %>

                                <td style="text-align: center">
                                    <a type="button" href="SetupCommissionReportConciseAdd.aspx?id= <%#Eval("ReportId")%>&mode=edit&TB_iframe=true&height=400&width=450"
                                        class="thickbox" title="Commission Report Modify">Edit</a>
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
                </div>

            </ContentTemplate>

        </asp:UpdatePanel>
    </div>

</asp:Content>

