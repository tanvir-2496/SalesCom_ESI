<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="SetupAdHocReport.aspx.cs" Inherits="SetupActivity" %>

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


        <% if (Permissions.AdhocReportAdd)
           { %>
        <div style="text-align: right">
            <input type="button" value="Add New" alt="SetupAdHocReportAdd.aspx?keepThis=false&TB_iframe=true&height=400&width=450"
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



                                </colgroup>
                                <thead>

                                    <tr class="gridheader">
                                        <th>#
                                        </th>
                                        <th>Report Name
                                        </th>
                                        <th>Channel Type
                                        </th>
                                        <th>Is Active
                                        </th>
                                        <th>Approval Flow
                                        </th>
                                        <th>SR
                                        </th>
                                        <th>SMS Content</th>
                                        <th>Disburse Time</th>
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
                                    <%#Eval("report_name")%>&nbsp;
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("channeltype")%>&nbsp;
                                </td>
                                <td style="text-align: center">
                                    <input type="checkbox" disabled="true" <%#Eval("is_active").ToString()=="1"?"checked":"" %> />&nbsp
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("approvalname") %>&nbsp
                                </td>

                                <%#Eval("FILE_TYPE") != null ? String.Format("<td style='text-align:center'><a href='DownloadSR.aspx?id={0}&fileex={1}&Fname={2}&Type=2' target='_blank'>Content</a></td>", Eval("AD_HOC_REPORT_ID"), Eval("FILE_TYPE"), Eval("REPORT_NAME")) : "<td style='text-align:center'> No Content </td>"  %>
                                <td style="padding-left: 3px;width:25%">
                                    <%#Eval("SMSContent")%>&nbsp;
                                </td>
                                <td style="text-align: center;">
                                    <%#Eval("DisburseTime")%>&nbsp;
                                </td>
                                <td style="text-align: center">
                                    <a type="button" href="SetupAdHocReportAdd.aspx?id= <%#Eval("ad_hoc_report_id")%>&mode=edit&TB_iframe=true&height=400&width=450"
                                        class="thickbox" title="Ad-Hoc Report Modify">Edit</a>
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

