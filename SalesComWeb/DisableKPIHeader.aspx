<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="DisableKPIHeader.aspx.cs" Inherits="DisableKPIHeader" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <table class="contenttext" style="width: 400px;">
            <tr>
                <td>
                    <asp:Label ID="Label1" SkinID="lblCommonSkin" mandatory="true" runat="server" Text="Sales Group"> </asp:Label>
                </td>
                <td>
                    <asp:DropDownList Style="width: 200px" ID="ddlSalesGroup" runat="server" AutoPostBack="true" SkinID="ddlCommonSkin">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSearchName" runat="server" Text="Name" SkinID="lblCommonSkin"> </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSeachName" runat="server" SkinID="txtCommonSkin">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdSubmit" colspan="2">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" SkinID="btnCommonSkin" />
                </td>
            </tr>
        </table>
        <div class="msg">
            <asp:Label ID="lblMsg" runat="server">
    
            </asp:Label>
        </div>
    </center>
    <div class="ListViewStyle">
        <asp:ListView ID="lvKPIView" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin">
            <LayoutTemplate>
                <table class="datatable" cellpadding="0" cellspacing="0" border="0px">
                    <colgroup>
                        <col />
                        <col />
                        <col />
                        <col />
                        <col />
                    </colgroup>
                    <thead>
                        <tr class="gridheader">
                            <th>Serial</th>
                            <th>Sales Group</th>
                            <th>KPI Header Name</th>
                            <th>Status</th>
                            <th>Action</th>
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
                        <%#Eval("SALES_GROUP_NAME")%>
                    </td>
                    <td>
                        <%#Eval("DATA_NAME")%>
                    </td>
                    <td>
                        <%# Eval("IS_ACTIVE").ToString() == "1" ? "Active" : "Deactive"%>
                    </td>
                    <td style="text-align: center">
                         <asp:Button ID="btnDeactivateKPI" class="loadButtonEx" runat="server" Text="Deactive" visible='<%# Eval("IS_ACTIVE").ToString() == "1" %>' OnClick="btnDeactivateKPI_Click" CommandArgument='<%#Eval("MANUALDATACNFG_ID") %>' />
                         <asp:Button ID="btnActivateKPI" class="loadButtonEx" runat="server" Text="Active" visible='<%# Eval("IS_ACTIVE").ToString() != "1" %>' OnClick="btnActivateKPI_Click" CommandArgument='<%#Eval("MANUALDATACNFG_ID") %>' />
                       
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <div class="footer">
        <asp:Label ID="lblResults" CssClass="gridResults" runat="server" Text="Label"></asp:Label>
        <div class="pager">
            <asp:DataPager ID="pager" runat="server" PagedControlID="lvKPIView" PageSize="10" OnPreRender="pager_PreRender">
                <Fields>
                    <asp:NextPreviousPagerField ButtonCssClass="PagerButton" ShowFirstPageButton="true" ShowPreviousPageButton="true" ShowNextPageButton="false" ButtonType="Image" FirstPageImageUrl="~/App_Themes/Theme1/images/first.gif" RenderDisabledButtonsAsLabels="true" FirstPageText="" PreviousPageText="" PreviousPageImageUrl="~/App_Themes/Theme1/images/prev.gif" />
                    <asp:NumericPagerField ButtonCount="5" CurrentPageLabelCssClass="pagerCurrent" NumericButtonCssClass="pagerNumeric" />
                    <asp:NextPreviousPagerField ButtonCssClass="PagerButton" ShowLastPageButton="true" ShowNextPageButton="true" ShowPreviousPageButton="false" ButtonType="Image" NextPageImageUrl="~/App_Themes/Theme1/images/next.gif" LastPageImageUrl="~/App_Themes/Theme1/images/last.gif" LastPageText="" NextPageText="" RenderDisabledButtonsAsLabels="true" />
                </Fields>
            </asp:DataPager>
        </div>
    </div>
</asp:Content>


