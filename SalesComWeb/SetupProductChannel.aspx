<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="SetupProductChannel.aspx.cs" Inherits="SetupProductChannel" %>

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


        <% if (Permissions.ActivityAdd)
           { %>
        <div style="text-align: right">
            <input type="button" value="Add New" alt="SetupProductChannelAdd.aspx?keepThis=false&TB_iframe=true&height=300&width=450"
                class="thickbox" title="Product Channel Add" />
        </div>
        <%          }%>
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
                                </colgroup>
                                <thead>


                                    <tr class="gridheader">
                                        <th>#
                                        </th>
                                        <th>Product Channel Name
                                        </th>
                                        <th>Effective Date
                                        </th>
                                        <th>Expire Date
                                        </th>
                                        <th>Procedure
                                        </th>
                                        <th>Is Active
                                        </th>
                                        <th>Is Dynamic
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
                                    <%#Eval("PRODCHHNAME")%>&nbsp;
                                </td>
                                <td>
                                    <%#Common.DateFormat(Eval("EFFECTIVEDATE"))%>&nbsp;
                                </td>

                                <td>
                                    <%#Common.DateFormat(Eval("EXPIREDATE"))%>&nbsp;
                                </td>
                                <td>
                                    <%#Eval("ProcedureName")%>&nbsp;
                                </td>
                                <td>
                                    <input type="checkbox" disabled="disabled" <%#Eval("ISACTIVE").ToString()=="1"?"checked":"" %> />
                                </td>
                                <td>
                                    <input type="checkbox" disabled="disabled" <%#Eval("ISDYNAMIC").ToString()== "Y" ? "checked":"" %> />&nbsp;
                                </td>

                                <td style="text-align: center">
                                    <a type="button" href="SetupProductChannelAdd.aspx?id= <%#Eval("ProductChannelId")%>&mode=edit&TB_iframe=true&height=300&width=450"
                                        class="thickbox" title="Product Channel Modify">Edit</a>
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

