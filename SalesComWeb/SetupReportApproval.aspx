<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="SetupReportApproval.aspx.cs" Inherits="SetupReportApproval" %>

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
    <asp:UpdatePanel ID="lstpanel" runat="server">
        <Triggers></Triggers>
        <ContentTemplate>
            <div class="Content">
                <%--<asp:Label runat="server">Report Name</asp:Label>--%>
                                 
                        <%--<p class="text-muted">Report Name</p>--%>
                        <asp:Label ID="lbl" runat="server" Text="Report Name" SkinID="lblCommonSkin" mandatory="true"></asp:Label>
                        <asp:TextBox ID="search_textbox" Width="300px" runat="server" AutoPostBack="True" />
                        <asp:Button ID="btnSearxh" runat="server" SkinID="btnCommonSkin" OnClick="btnSearch_Click" Text="Search" />
                    
                    <% if (Permissions.ReportApprovalAdd)
                       { %>
                    <div style="text-align: right;">


                        <input type="button" value="Add New" alt="SetupReportApprovalAdd.aspx?keepThis=true&TB_iframe=true&height=400&width=450"
                            class="thickbox" title="Commission Report Add" />
                    </div>
                    <% }%>
                

                <%--    <asp:UpdatePanel ID="lstpanel" runat="server">
            <Triggers></Triggers>
            <ContentTemplate>--%>




                <asp:Button ID="btnRefresh" Style="display: none" runat="server" OnClick="btnRefresh_Click" />
                <div class="ListViewStyle">
                    <asp:ListView ID="lv" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin" OnSorting="lvEffectiveDate_Sorting">
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
                                        <th>Report Name</th>
                                        <th>Channel Type</th>
                                        <th>Period Type</th>

                                        <th id="Th1">
                                            <asp:LinkButton ID="lbeffectiveDate" CommandArgument="EFFECTIVE_DATE" CommandName="Sort" Text="Effective Date" runat="server" />
                                        </th>

                                        <%--<th>Effective Date</th>--%>
                                        <th>Expire Date</th>
                                        <th>Approval Status</th>
                                        <th>Sync Status</th>
                                        <th>SR</th>
                                        <th>Ev Disburse</th>
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
                            <tr class='<%# Container.DataItemIndex % 2 == 0 ? "row" : "altrow" %>' style="width: 100%">
                                <td style="text-align: center">
                                    <%# Container.DataItemIndex +1  %>
                                </td>
                                <td>
                                    <%#Eval("REPORT_NAME")%>&nbsp;
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("CHANNEL_TYPE")%>&nbsp;
                                </td>

                                <td style="text-align: center">
                                    <%#Eval("PERIOD_TYPE") %>&nbsp
                                </td>
                                <%# DateTime.Compare(Convert.ToDateTime(Eval("EFFECTIVE_DATE")),default(DateTime)) != 0 ? String.Format("<td style='text-align:center'>{0}</td>", Convert.ToDateTime(Eval("EFFECTIVE_DATE")).ToString("dd-MMM-yyyy")) : "<td style='text-align:center; color:DarkRed'> Undefined </td>" %>

                                <%# DateTime.Compare(Convert.ToDateTime(Eval("EXPIRE_DATE")),default(DateTime)) != 0 ? String.Format("<td style='text-align:center'>{0}</td>", Convert.ToDateTime(Eval("EXPIRE_DATE")).ToString("dd-MMM-yyyy")) : "<td style='text-align:center; color:CornflowerBlue'> Till further notice </td>" %>

                                <td style="text-align: center">
                                    <%#Eval("CURRENT_STATUS") %>&nbsp
                                </td>

                                <td style="text-align: center">
                                    <%#Eval("SYNCHED") %>
                                </td>

                                <%#Eval("FILETYPE") != null ? String.Format("<td style='text-align:center'><a href='DownloadSR.aspx?id={0}&fileex={1}&Fname={2}&Type=3' target='_blank'>Content</a></td>", Eval("report_approval_id"), Eval("FILETYPE"), Eval("REPORT_NAME")) : "<td style='text-align:center'> No Content </td>"  %>

                                <td style="text-align: center">
                                    <%# Convert.ToInt16(Eval("DisburseByEv")) == 1 ? "Yes" : ""%>
                                </td>

                                <% if (Permissions.ReportApprovalModify)
                                   { %>
                                <%--<%#Convert.ToInt16(Eval("STATUS")) == 0 ? String.Format("<td style='text-align: center'> <a type='button' href='SetupReportApprovalAdd.aspx?id={0}&mode=edit&TB_iframe=true&height=300&width=450' class='thickbox' title='Report Approval Modify'>Edit</a></td>", Eval("report_approval_id")) : "<td style='text-align: center' >Not Editable</td>" %>--%>
                                <%#Convert.ToInt16(Eval("STATUS")) == 0 ? String.Format("<td style='text-align: center'> <a type='button' href='SetupReportApprovalAdd.aspx?id={0}&mode=edit&TB_iframe=true&height=400&width=450&modal=true' class='thickbox' title='Report Approval Modify'>Edit</a></td>", Eval("report_approval_id")) : "<td style='text-align: center' >Not Editable</td>" %>


                                <% }
                                   else
                                   {%>
                                <td></td>
                                <%} %>
                            </tr>


                        </ItemTemplate>
                    </asp:ListView>
                </div>
                <div class="footer">
                    <asp:Label ID="lblResults" CssClass="gridResults" runat="server" Text="Label"></asp:Label>
                    <div class="pager">
                        <asp:DataPager ID="pager" runat="server" PagedControlID="lv" PageSize="12" OnPreRender="pager_PreRender">
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

