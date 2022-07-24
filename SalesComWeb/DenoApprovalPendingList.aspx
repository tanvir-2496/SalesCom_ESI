<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="DenoApprovalPendingList.aspx.cs" Inherits="DenoApprovalPendingList" %>

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

             <asp:Label ID="lbl" runat="server" Text="Report Name" SkinID="lblCommonSkin" mandatory="true"></asp:Label>
            <asp:TextBox ID="search_textbox" Width="300px" runat="server"  />
            <asp:Button ID="btnSearch" runat="server" SkinID="btnCommonSkin" Text="Search" OnClick="btnSearch_Click" />   
           <br />                    
           <br />    
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
                                    <col />
                                    <col />
                                    <col />
                                </colgroup>
                                <thead>


                                    <tr class="gridheader">
                                        <th>#</th>
                                        <th>Report Name</th>                                                                        
                                        <th>Start Date</th>
                                        <th>End Date</th>
                                        <th>Current Status</th>
                                        <%--<th>Approval Status</th>
                                        <th>SR</th>--%>
                                        <th>Campaign Detail</th>
                                        <th>Act</th>

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
                               <%-- <td style="text-align: center">
                                    <%#Eval("CHANNEL_TYPE")%>&nbsp;
                                </td>--%>

                               <%-- <td style="text-align: center">
                                    <%#Eval("PERIOD_TYPE") %>&nbsp
                                </td>--%>
                                <%# DateTime.Compare(Convert.ToDateTime(Eval("START_DATE")),default(DateTime)) != 0 ? String.Format("<td style='text-align:center'>{0}</td>", Convert.ToDateTime(Eval("START_DATE")).ToString("dd-MMM-yyyy")) : "<td style='text-align:center; color:DarkRed'> Undefined </td>" %>

                                <%# DateTime.Compare(Convert.ToDateTime(Eval("END_DATE")),default(DateTime)) != 0 ? String.Format("<td style='text-align:center'>{0}</td>", Convert.ToDateTime(Eval("END_DATE")).ToString("dd-MMM-yyyy")) : "<td style='text-align:center; color:CornflowerBlue'> Till further notice </td>" %>

                               <%-- <td style="text-align: center">
                                   <input type="checkbox" disabled="disabled" <%#Eval("upload_commission_at_pos").ToString() == "Y" ? "checked": "" %> />
                                </td>--%>

                                <td style="text-align: center">
                                    <%#Eval("CURRENT_STATUS") %>&nbsp
                                </td>
                             <%--   <%#Eval("FILETYPE") != null ? String.Format("<td style='text-align:center'><a href='DownloadSR.aspx?id={0}&fileex={1}&Fname={2}&Type=3' target='_blank'>Content</a></td>", Eval("report_approval_id"), Eval("FILETYPE"), Eval("REPORT_NAME")) : "<td style='text-align:center'> No Content </td>"  %>--%>

                                  <td style="text-align: center">
                                   <a  style=""  href="DenoCampaignDetailView.aspx?id=<%#Eval("id")%>&mode=edit&TB_iframe=true&height=500&width=500&modal=true" class="thickbox" title="Deno Drive Campaign Details">View Details</a>
                                  </td>



                                <td style="text-align: center">
                                    <% if (Permissions.CampaignDenoApproveAct)
                                       { %>
                                    <a type="button" href="DenoReportApprovalAct.aspx?ID= <%#Eval("id")%>&RN=<%#Eval("report_name") %>&ALN=<%#Eval("approvallevelname") %>&AF=<%#Eval("approval_flow_id") %>&AL=<%#Eval("approval_level_id") %>&OI=<%#Eval("orderid") %>&DT=<%#Eval("DenoTypeId") %>&TB_iframe=true&height=400&width=650"
                                        class="thickbox" title="Report Approval Process">Approve/Reject</a>
                                    <% }%>
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

