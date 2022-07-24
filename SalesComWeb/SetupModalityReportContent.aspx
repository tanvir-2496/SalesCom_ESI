<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="SetupModalityReportContent.aspx.cs" Inherits="SetupActivity" %>

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


        <% if (Permissions.ModalityReportContentAdd)
           { %>
        <div style="text-align: right">
            <input type="button" value="Add New" alt="SetupModalityReportContentAdd.aspx?keepThis=false&TB_iframe=true&height=300&width=450"
                class="thickbox" title="Modality Report Content Add" />
        </div>
        <% }%>
        <asp:UpdatePanel ID="lstpanel" runat="server">
            <ContentTemplate>
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
                                    <col />

                                </colgroup>
                                <thead>
                                    <tr class="gridheader">
                                        <th>#</th>
                                        <th>Report Name</th>


                                        <th>File Type</th>
                                        <th>Create Date</th>
                                        <%--   <th>Created By</th>
                                        <th>Update By </th>
                                        <th>Update Date</th>--%>
                                        <th>Is Active</th>
                                        <th>File Content </th>
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


                                <td>
                                    <%#Eval("FileType") %>&nbsp
                                </td>
                                <td>
                                    <%#Convert.ToDateTime(Eval("CreateDate")).ToString("dd-MMM-yyyy")%>&nbsp;
                                </td>
                                <%--  <td>
                                    <%#Eval("CreateBy") %>&nbsp
                                </td>
                                <td>
                                    <%#Eval("UpdateBy")%>&nbsp;
                                </td>
                                <td>
                                    <%#Convert.ToDateTime(Eval("UpdateDate")).ToString("dd-MMM-yyyy") %>&nbsp
                                </td>--%>

                                <td>
                                    <input type="checkbox" disabled="true" <%#Eval("IsActive").ToString()=="True"?"checked":"" %> />
                                </td>
                                <td>
                                    <a href="viewFile.aspx?id=<%# Eval("id")%>&fileex=<%# Eval("FileType")%>&Fname=<%#Eval("ReportName") %>" target="_self">View</a>
                                </td>
                                <td style="text-align: center">
                                    <a type="button" href="SetupModalityReportContentAdd.aspx?id= <%#Eval("ID")%>&mode=edit&TB_iframe=true&height=300&width=450"
                                        class="thickbox" title="Modality Report Content Modify">Edit</a>
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

