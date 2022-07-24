<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="SetupEvent.aspx.cs" Inherits="SetupActivity" %>

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
                <div>
                    <table>

                        <tr>
                            <td>
                                <asp:Label ID="lblReportName" runat="server" Text="Report Name" SkinID="lblCommonSkin" ></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlReportName" runat="server" SkinID="ddlCommonSkin" AutoPostBack="true" OnSelectedIndexChanged="ddlReportName_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Channel Type" SkinID="lblCommonSkin" ></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlChannelType" runat="server" SkinID="ddlCommonSkin" AutoPostBack="true" OnSelectedIndexChanged="ddlChannelType_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="lblEventName" runat="server" Text="Event Name" SkinID="lblCommonSkin" mandatory="true"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtEventName" runat="server" SkinID="txtCommonSkin" CssClass="required"></asp:TextBox>
                            </td>
                             <td>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" SkinID="btnCommonSkin" OnClick="btnSearch_Click" /></td>
                        </tr>
                       <%-- <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" SkinID="btnCommonSkinLarge" OnClick="btnSearch_Click" /></td>
                        </tr>--%>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Label ID="lblNotFound" runat="server" SkinID="lblErrorMsgSkin"></asp:Label></td>
                        </tr>

                        


                    </table>
                </div>


                <% if (Permissions.EventAdd)
                   { %>
                <div style="text-align: right">
                    <input type="button" value="Add New" alt="SetupEventAdd.aspx?keepThis=false&TB_iframe=true&height=300&width=450"
                        class="thickbox" title="Event Add" />
                </div>
                <% }%>

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
                                </colgroup>
                                <thead>


                                    <tr class="gridheader">
                                        <th>#
                                        </th>
                                          <th>Report Name
                                        </th>
                                        <th>Event Name
                                        </th>
                                        <th>Event Type
                                        </th>
                                        <th>Channel Type
                                        </th>
                                        <th>Effective Date
                                        </th>
                                        <th>Expiry Date
                                        </th>
                                           <th>Product Channel Name
                                        </th>

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
                                    <%#Eval("EventName")%>&nbsp;
                                </td>
                                <td>
                                    <%#Eval("EventType")%>&nbsp;
                                </td>
                                <td>
                                    <%#Eval("ChannelType")%>&nbsp;
                                </td>
                                <td>
                                    <%#Common.DateFormat(Eval("EffectiveDate"))%>&nbsp;
                                </td>
                                <td>
                                    <%# Common.DateFormat(Eval("ExpiryDate")) %>&nbsp
                                </td>
                                <td>
                                    <%#Eval("ProdChhName") %>&nbsp
                                </td>


                                <td style="text-align: center">
                                    <a type="button" href="SetupEventAdd.aspx?id= <%#Eval("EventID")%>&mode=edit&TB_iframe=true&height=300&width=450"
                                        class="thickbox" title="Event Modify">Edit</a>
                                </td>

                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
                <div class="footer">
                    <asp:Label ID="lblResults" CssClass="gridResults" runat="server" Text="Label"></asp:Label>
                    <div class="pager">
                        <asp:DataPager ID="pager" runat="server" PagedControlID="lv" PageSize="10" OnPreRender="pager_PreRender">
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

