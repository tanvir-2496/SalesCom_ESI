<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="SetupEventRuleExApproval.aspx.cs" Inherits="SetupEventRule" %>

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

        <asp:UpdatePanel ID="upddl" runat="server">
            <ContentTemplate>

                <table>

                    <tr>
                        <td>
                            <asp:Label ID="lblReportName" SkinID="lblCommonSkin" runat="server" Text="Report Name"> </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlReportName" runat="server" SkinID="ddlCommonSkin" AutoPostBack="true" OnSelectedIndexChanged="ddlReportName_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>

                    <tr>
                        <td>
                            <asp:Label ID="lblEvent" SkinID="lblCommonSkin" runat="server" Text="Event"> </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEvent" runat="server" SkinID="ddlCommonSkin" AutoPostBack="true" OnSelectedIndexChanged="ddlEvent_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>

                </table>
            </ContentTemplate>
        </asp:UpdatePanel>

<%--        <% if (Permissions.EventRuleAdd)
           { %>
        <div style="text-align: right">
            <input type="button" value="Add New" alt="SetupEventRuleExAdd.aspx?keepThis=false&TB_iframe=true&height=400&width=500"
                class="thickbox" title="Event Rule Add/Modify" />
        </div>
        <% }%>--%>
        <asp:UpdatePanel ID="lstpanel" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnRefresh" Style="display: none" runat="server" OnClick="btnRefresh_Click" />
                <br />
                <div class="ListViewStyle">
                    <asp:ListView ID="lv" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin">
                        <LayoutTemplate>
                            <table id="tbDataTable" class="datatable" cellpadding="0" cellspacing="0" border="0px">
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
                                    <%--<col />--%>
                                </colgroup>
                                <thead>


                                    <tr class="gridheader">
                                        <th>#
                                        </th>
                                        <th>Event Rule Name
                                        </th>
                                        <th>Event
                                        </th>
                                        <th>Segment
                                        </th>
                                        <th>Min Amount
                                        </th>
                                        <th>Max Amount
                                        </th>
                                        <th>Amount Type
                                        </th>
                                        <th>Commission Type
                                        </th>
                                        <th>Commission Value
                                        </th>
                                        <th>Max Com Perevent
                                        </th>
                                        <th>Rule Group
                                        </th>
                                        <th>Validation Rule
                                        </th>

                                        <th>Approval Chain</th>
                                        <th>Current Level</th>


                                        <th>C. L. Status</th>
                                        <%--<th>Edit</th>--%>
                                        <th>Approval</th>

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
                                    <%#Eval("EventRuleName")%>
                                </td>
                                <td>
                                    <%#Eval("EventName")%>
                                </td>
                                <td>
                                    <%#Eval("SegmentName")%>
                                </td>
                                <td>
                                    <%#Eval("MINAMOUNT") %>
                                </td>
                                <td>
                                    <%#Eval("MAXAMOUNT") %>
                                </td>
                                <td>
                                    <%#Eval("AmountTypeName") %>
                                </td>
                                <td>
                                    <%#Eval("CommissionTypeName") %>
                                </td>
                                <td>
                                    <%#Eval("COMMISSIONVALUE") %>
                                </td>
                                <td>
                                    <%#Eval("MAXCOMMISSIONPEREVENT") %>
                                </td>
                                <td>
                                    <%#Eval("RuleGroupName") %>
                                </td>
                                <td>
                                    <%#Eval("ValidationName") %>
                                </td>


                                <td>
                                    <%#Eval("ApprovalName") %>
                                </td>
                                <td>
                                    <%#Eval("ApprovalLevelName") %>
                                </td>

                                <td>
                                    <%#Eval("CurrentStatus") %>
                                </td>

                               <%-- <%#Convert.ToInt16(Eval("STATUS")) == 0 ? String.Format("<td style='text-align: center'> <a type='button' href='SetupEventRuleExAdd.aspx?id={0}&mode=edit&TB_iframe=true&height=400&width=500' class='thickbox' title='Event Ex ADD/MODIFY'>Edit</a></td>", Eval("EVENTRULEID")) : "<td>Not Editable</td>" %>--%>
                                <%#(Convert.ToInt32(Eval("UserId")) == LoginInfo.Current.UserId && Convert.ToInt32(Eval("STATUS")) != 0) ? String.Format("<td style='text-align: center'><a type='button' href='EventRuleApprovalPage.aspx?id={0}&mode=edit&TB_iframe=true&height=400&width=500' class='thickbox' title='Event Rule Approval'>Approval</a></td>", Eval("EVENTRULEID")) : "<td>Unauthorized/Closed</td>" %>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
                <div class="footer">
                    <asp:Label ID="lblResults" CssClass="gridResults" runat="server" Text="Label"></asp:Label>
                    <div class="pager">
                        <asp:DataPager ID="pager" runat="server" PagedControlID="lv" PageSize="8" OnPreRender="pager_PreRender">
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

