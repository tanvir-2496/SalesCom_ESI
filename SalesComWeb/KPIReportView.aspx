<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="KPIReportView.aspx.cs" Inherits="KPIReportView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .W200 {
            width: 200px;
        }
    </style>
    <link href="AutoComplete/CSS/auto-complete.css" rel="stylesheet" />
    <script type="text/javascript" src="AutoComplete/Scripts/auto-complete.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function refreshWindow() {
            ModifyLeftpanel();
        }
    </script>

    <div class="leftPanel"></div>
    <div class="Content">

        <asp:UpdatePanel ID="upCycle" runat="server">
            <Triggers>
            </Triggers>

            <ContentTemplate>
                <div>
                    <div style="float: right; padding: 5px;">
                        
                    </div>
                </div>

                <div style="clear: both">
                    <table style="width: 350px">
                        
                          <tr id="Tr1" runat="server" visible="true">
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Sales Group"> </asp:Label>
                            </td>
                            <td>
                            <asp:DropDownList CssClass="W200" ID="ddlSalesGroup" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_SalesGroup_IndexChanged">
                            </asp:DropDownList>
                            </td>
                        </tr>
                        <tr id="Tr2" runat="server" visible="true">
                            <td>
                                <asp:Label ID="lblReportType" runat="server" Text="Report Type"> </asp:Label>
                            </td>
                            <td>
                            <asp:DropDownList CssClass="W200" ID="ddlReportType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_IndexChanged">
                            <asp:ListItem Text="[Select One]" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Quarterly" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Monthly" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Arrear_1" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Arrear_2" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Arrear_3" Value="5"></asp:ListItem>
                            </asp:DropDownList>
                            </td>
                        </tr>
                        <tr runat="server" visible="true">
                            <td>
                                <asp:Label ID="lblSalesChannel" runat="server" Text="Sales Channel"> </asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList CssClass="W200" ID="ddlSalesChannel" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_IndexChanged">
                                <asp:ListItem Text="[Select One]" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr runat="server" visible="true">
                            <td>
                                <asp:Label ID="lblYear" runat="server" Text="Year"> </asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList class="W200" ID="ddlYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_IndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr runat="server" visible="true">
                            <td>
                                <asp:Label ID="lblQuarter" runat="server" Text="Quarter"> </asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlQuarter" runat="server" AutoPostBack="true" class="W200" OnSelectedIndexChanged="ddl_IndexChanged">
                                    <asp:ListItem Text="[Select One]" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Q1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Q2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Q3" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Q4" Value="4"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr id="Tr3" runat="server" visible="true">
                            <td>
                                <asp:Label ID="lblMonth" runat="server" Text="Month"> </asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="true" class="W200" OnSelectedIndexChanged="ddl_IndexChanged">
                                    <asp:ListItem Text="[Select One]" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="M1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="M2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="M3" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                    </table>

                    <div class="ListViewStyle">
                        <asp:ListView ID="lv" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin" OnItemCommand="lv_ItemCommand" OnItemDataBound="lv_ItemDataBound">
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
                                            <th style="width:3%">#</th>
                                            <th style="text-align: left; width: 40%">Report Name</th>
                                            <th style="width:30%">Status</th>
                                            <th style="width:10%">Details </th>
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
                                        <%#Eval("report_name")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%#Eval("current_level")%>
                                    </td>
                                    <td style="text-align: center">
                                        <asp:LinkButton ID="lbtnDetailsAmount" runat="server" CommandName="DetailsAmount" CommandArgument='<%#Eval("report_cycle_id")%>' Text="Detail" />
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
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
