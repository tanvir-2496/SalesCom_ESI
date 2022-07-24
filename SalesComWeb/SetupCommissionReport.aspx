<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="SetupCommissionReport.aspx.cs" Inherits="SetupActivity" %>

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


        <% if (Permissions.CommissionReportAdd)
           { %>
        <div style="text-align: right">
            <input type="button" value="Add New" alt="SetupCommissionReportAdd.aspx?keepThis=false&TB_iframe=true&height=400&width=450"
                class="thickbox" title="Commission Report Add" />
        </div>
        <% }%>
        <asp:UpdatePanel ID="lstpanel" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnRefresh" Style="display: none" runat="server" OnClick="btnRefresh_Click" />

                <asp:Label ID="lbl" runat="server" Text="Report Name" SkinID="lblCommonSkin" mandatory="true"></asp:Label>
                        <asp:TextBox ID="search_textbox" Width="300px" runat="server" AutoPostBack="True" />
                        <asp:Button ID="btnSearxh" runat="server" SkinID="btnCommonSkin" OnClick="btnSearch_Click" Text="Search" />

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
                                </colgroup>
                                <thead>
                                    <tr class="gridheader">
                                        <th>#</th>
                                        <th style="text-align: left; padding-left: 3px">Name</th>
                                        <th>Report Type</th>
                                        <th>Channel Type</th>
                                        <th>POS Upload</th>
                                        <th>Is Active</th>
                                        <th>SR</th>
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
                                <td style="padding-left: 3px">
                                    <%#Eval("ReportName")%>&nbsp;
                                </td>
                               <td style="text-align: center;">
                                    <%#Eval("report_type_name")%>&nbsp;
                                </td>
                                <td style="text-align: center;">
                                    <%#Eval("ChannelType")%>&nbsp;
                                </td>
                                <td style="text-align: center;">
                                    <input type="checkbox" disabled="disabled" <%#Eval("upload_commission_at_pos").ToString() == "Y" ? "checked": "" %> />
                                </td>
                                <td style="text-align: center;">
                                    <input type="checkbox" disabled="disabled" <%#Eval("IsActive").ToString()=="1"?"checked":"" %> />&nbsp
                                </td>
                                <%#Eval("FileType") != null ? String.Format("<td style='text-align:center'><a href='DownloadSR.aspx?id={0}&fileex={1}&Fname={2}' target='_blank'>Content</a></td>", Eval("ReportId"), Eval("FileType"), Eval("ReportName")) : "<td style='text-align:center'> No Content </td>"  %>
                                
                                <td style="padding-left: 3px;width:20%">
                                    <%#Eval("SMSContent")%>&nbsp;
                                </td>
                                <td style="text-align: center;">
                                    <%#Eval("DisburseTime")%>&nbsp;
                                </td>

                                 <td style="text-align: center">
                                    <a type="button" href="SetupCommissionReportAdd.aspx?id= <%#Eval("ReportId")%>&mode=edit&TB_iframe=true&height=400&width=450"
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

