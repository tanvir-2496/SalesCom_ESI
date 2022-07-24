<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="SetupLevelUser20.aspx.cs" Inherits="SetupLevelUser20" %>

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

                <table style="width: 350px">
                    <tr>
                        <td>
                            <asp:Label ID="lblApprovalName" SkinID="lblCommonSkin" runat="server" Text="Approval Flow"> </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlApprovalName" runat="server" SkinID="ddlCommonSkin" AutoPostBack="true" OnSelectedIndexChanged="ddlApprobalName_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="lblApprovalLevelName" runat="server" Text="Approval Level" SkinID="lblCommonSkin"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlApprovalLevelName" runat="server" SkinID="ddlCommonSkin" AutoPostBack="true" OnSelectedIndexChanged="ddlApprovalLevelName_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                    </tr>


                    <tr>
                        <td>
                            <asp:Label ID="lblUser" runat="server" Text="User name" SkinID="lblCommonSkin"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtUser"></asp:TextBox>
                            <asp:Button ID="btnFilterByUser" runat="server" CssClass="button" Text="Filter" OnClick="btnFilterByUser_Click" />
                        </td>

                    </tr>
                    <tr>
                        <td></td>
                        <td style="color: #f00; font-weight: bolder">
                            <asp:Label ID="lblError" runat="server" Text="" SkinID="lblErrorMsgSkin"></asp:Label>
                        </td>
                        <td>
                            
                            <asp:HiddenField runat="server" ID="userID" />

                        </td>

                    </tr>



                </table>


                <% if (Permissions.LevelUserAdd)
                   { %>
                <div style="text-align: right">
                    <input type="button" value="Add New" alt="SetupLevelUserAdd20.aspx?keepThis=false&TB_iframe=true&height=300&width=450"
                        class="thickbox" title="Level User Add" />
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
                                    <col />
                                </colgroup>
                                <thead>
                                    <tr class="gridheader">
                                        <th>#
                                        </th>
                                        <th style="text-align: left; padding-left: 3px">Flow
                                        </th>
                                        <th>Level
                                        </th>
                                        <th>Username
                                        </th>
                                        <th>Full Name
                                        </th>
                                        <th>Mobile
                                        </th>
                                        <th>Email
                                        </th>
                                        <th>Edit</th>
                                        <th>Delete</th>

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
                                    <%#Eval("APPROVALNAME")%>&nbsp;
                                </td>

                                <td style="text-align: center">
                                    <%#Eval("APPROVALLEVELNAME")%>&nbsp;
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("LoginName")%>&nbsp;
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("USERNAME")%>&nbsp;
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("Mobile")%>&nbsp;
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("Email")%>&nbsp;
                                </td>

                                <td style="text-align: center">
                                    <a type="button" href="SetupLevelUserAdd20.aspx?id= <%#Eval("LevelUserId")%>&mode=edit&TB_iframe=true&height=300&width=450"
                                        class="thickbox" title="Level User Modify">Edit</a>
                                </td>

                                <td style="text-align: center">
                                    <asp:Button ID="btnDelete" class="basicButton" runat="server" Text="Delete" CommandArgument='<%#Eval("LevelUserId")%>' OnClick="btnDelete_Click" OnClientClick="if(!confirm('Are you sure you want to permanently delete this record?')){ return false; };" />
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

