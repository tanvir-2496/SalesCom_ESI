<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="AdHocReportView.aspx.cs" Inherits="AdHocReportView" %>

<%@ Register Src="~/UserControl/datetimePicker/WebUserControl.ascx" TagName="WebUserControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:WebUserControl ID="WebUserControl1" runat="server" />
    <script type="text/javascript">
        function refreshWindow() {
            ModifyLeftpanel();
        }

    </script>

    <div class="leftPanel"></div>
    <div class="Content">

        <asp:UpdatePanel ID="upCycle" runat="server">
            <ContentTemplate>
                <table style="width: 350px;">

                    <tr>
                        <td>
                            <asp:Label ID="lblReportName" runat="server" Text="Report Name" SkinID="lblCommonSkin"> </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlReportname" runat="server" SkinID="ddlLargeSkin">
                            </asp:DropDownList>
                        </td>
                    </tr>


                    <tr>
                        <td>
                            <asp:Label ID="lblStarGererationDate" runat="server" Text="Report Date From" mandatory="true" SkinID="lblCommonSkin"> </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtDate" CssClass="date required">
                            </asp:TextBox>
                            <a id="a2" runat="server">
                                <img src="UserControl/datetimePicker/themes/img.gif" id="btnLetterRefDate" style="cursor: hand;"
                                    align="absmiddle" onmouseover="ShowDate(this);" /></a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEndGenerationdate" runat="server" Text="To " mandatory="true" SkinID="lblCommonSkin"> </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtToDate" runat="server" SkinID="txtDate" CssClass="date required">
                            </asp:TextBox>
                            <a id="a1" runat="server">
                                <img src="UserControl/datetimePicker/themes/img.gif" id="Img1" style="cursor: hand;"
                                    align="absmiddle" onmouseover="ShowDate(this);" /></a>
                        </td>
                    </tr>
                    <tr>
                         <td>
                            <asp:Label ID="Label1" runat="server"  SkinID="lblCommonSkin"> </asp:Label>
                        </td>
                        <td align="left">
                            <asp:Button ID="btnShow" OnClientClick="return fnValidate();" runat="server" Text="Show" OnClick="btnShow_Click" SkinID="btnCommonSkin" ValidationGroup="Date" ClientIDMode="Static" />
                        </td>
                    </tr>

                </table>

                <br />
                <hr />
                <br />

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
                                        <th>#</th>
                                        <th style="text-align: left">Report Name</th>
                                        <th>Report Date</th>
                                        <th>Generation Date</th>
                                        <th>Status</th>
                                        <th>Commission</th>
                                        <th>Details</th>
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
                                    <%#Eval("REPORT_NAME")%>
                                </td>
                                <td style="text-align: center">
                                    <%#Common.DateFormat(Eval("REPORT_DATE"))%>
                                </td>
                                <td style="text-align: center">
                                    <%#Common.DateFormat(Eval("GENERATION_DATE")) %>
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("STATUS")%>
                                </td>
                                <td style="text-align: right">
                                    <%#Eval("COMMISSION_AMOUNT")%>
                                </td>

                                <td style="text-align: center">
                                    <asp:LinkButton ID="lbtnDetailsAmount" runat="server" CommandName="DetailsAmount" CommandArgument='<%#Eval("REPORT_ID")+"," + Eval("CYCLE_ID")%>' Text="Detail" />
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
