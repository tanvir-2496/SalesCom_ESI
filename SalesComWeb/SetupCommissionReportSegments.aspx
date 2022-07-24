<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="SetupCommissionReportSegments.aspx.cs" Inherits="SetupActivity" %>

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

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <table style="width: 350px">
                    <tr>
                        <td>
                            <asp:Label ID="lblReport" SkinID="lblCommonSkin" runat="server" Text="Report"> </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlReport" runat="server" SkinID="ddlCommonSkin" AutoPostBack="true" OnSelectedIndexChanged="ddlReport_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblSegment" SkinID="lblCommonSkin" runat="server" Text="Segment"> </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSegment" runat="server" SkinID="ddlCommonSkin" AutoPostBack="true" OnSelectedIndexChanged="ddlSegment_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>

                </table>
            </ContentTemplate>
        </asp:UpdatePanel>



        <% if (Permissions.CommsiionReportSegmentsAdd)
           { %>
        <div style="text-align: right">
            <input type="button" value="Add New" alt="SetupCommissionReportSegmentsAdd.aspx?keepThis=false&TB_iframe=true&height=300&width=600"
                class="thickbox" title="Commission Report Segment Add" />
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
                                        <th>Segment Name</th>
                                        <th>Event Type</th>

                                        <th>Min Trg %</th>
                                        <th>Max Trg %</th>

                                        <th>Min Amt</th>
                                        <th>Max Amt</th>
                                          <th>Amount</th>
                                        <th>Segment Amt</th>
                                        <th>Event P</th>

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
                                    <%#Eval("REPORTNAME")%>&nbsp;
                                </td>
                                <td>
                                    <%#Eval("SEGMENTNAME") %>&nbsp;
                                </td>

                                <td>
                                    <%#Eval("EVENTTYPE") %>&nbsp
                                </td>
                                <td>
                                    <%#Eval("MINIMUMTARGETPERCENTAGE") %>&nbsp
                                </td>
                                <td>
                                    <%#Eval("MAXIMUMTARGETPERCENTAGE") %>&nbsp
                                </td>


                                <td>
                                    <%#Eval("MINIMUMTARGETAMOUNT") %>&nbsp
                                </td>
                                <td>
                                    <%#Eval("MAXIMUMTARGETAMOUNT") %>&nbsp
                                </td>



                                 <td>
                                    <%#Eval("AMOUNT") %>&nbsp
                                </td>

                                 <td>
                                    <%#Eval("SEGMENTAMOUNT") %>&nbsp
                                </td>

                                 <td>
                                    <%#Eval("EVENTPERCENTAGE") %>&nbsp
                                </td>


                                <td style="text-align: center">
                                    <a type="button" href="SetupCommissionReportSegmentsAdd.aspx?id= <%#Common.ProcessMyDataItem(Eval("REPORTID"))%>&segId=<%#Common.ProcessMyDataItem(Eval("SEGMENTID")) %>&EvId=<%#Common.ProcessMyDataItem(Eval("EventTypeId")) %>&minP=<%#Common.ProcessMyDataItem(Eval("MinimumTargetPercentage")) %>&mode=edit&TB_iframe=true&height=300&width=600"
                                        class="thickbox" title="Commission Report Segment Modify">Edit</a>
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

