<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="ViewCommissionReportTarget.aspx.cs" Inherits="SetupActivity" Culture="en-GB" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <div class="leftPanel"></div>
    <div class="Content">


        <div>
            <% if (Permissions.ImportCommissionTargetAdd)
               { %>
            <div style="text-align: right">
                <asp:Button runat="server" ID="btnExport" Text="Import Commission Target" SkinID="btnCommonSkinCustom" OnClick="btnExport_Click" />
            </div>
            <% }%>
        </div>
        <asp:UpdatePanel ID="upReportname" runat="server">
            <ContentTemplate>
                <div>
                    <table class="contenttext" style="width: 100%;">
                        <tr>
                            <td>

                                <asp:Label ID="lblReportName" runat="server" Text="Report Name" SkinID="lblCommonSkin"></asp:Label>

                                <asp:DropDownList ID="ddlReportName" runat="server" SkinID="ddlCommonSkin" CssClass="required" OnSelectedIndexChanged="ddlReportName_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true">
                                </asp:DropDownList>

                            </td>
                        </tr>


                        <tr>
                            <td>
                                <asp:Label ID="lblEventType" runat="server" Text="Event Type" SkinID="lblCommonSkin"> </asp:Label>
                                <asp:DropDownList ID="ddlEventType" runat="server" SkinID="ddlCommonSkin" CssClass="required" ClientIDMode="Static">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td>

                                <asp:Label ID="lblReportCycle" runat="server" Text="Report Cycle" SkinID="lblCommonSkin"> </asp:Label>
                                <asp:DropDownList ID="ddlReportCycle" runat="server" SkinID="ddlCommonSkin" CssClass="required" ClientIDMode="Static">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="lblShowPreviousData" runat="server" Text="" SkinID="lblCommonSkin"> </asp:Label>
                                <asp:Button ID="btnShowPreviousImportData" runat="server" Text="Show" OnClick="btnShowPreviousImportData_Click" SkinID="btnCommonSkin" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div>

            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <%--<asp:Button ID="Button1" Style="display: none" runat="server" OnClick="btnRefresh_Click" />--%>
                    <div class="ListViewStyle">
                        <asp:ListView ID="lvImportedData" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin">
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
                                            <th>REPORT NAME
                                            </th>
                                            <th>CODE
                                            </th>
                                            <th>NAME
                                            </th>
                                            <th>CYCLE
                                            </th>
                                            <th>EVENT TYPE
                                            </th>
                                            <th>TARGET VALUE
                                            </th>
                                            <th>IMPORTED BY
                                            </th>
                                            <th>IMPORT DATE
                                            </th>


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
                                        <%#:Eval("CHANNELCODE") %>
                                    </td>
                                    <td>
                                        <%#Eval("CHANNELNAME")%>&nbsp;
                                    </td>
                                    <td>
                                        <%#Eval("CYCLEDESCRIPTION") %>&nbsp;
                                    </td>
                                    <td>
                                        <%#Eval("EVENTTYPE")%>&nbsp;
                                    </td>
                                    <td>
                                        <%#Eval("TARGETVALUE")%>&nbsp;
                                    </td>
                                    <td>
                                        <%#Eval("IMPORTEDBY")%>&nbsp;
                                    </td>
                                    <td>
                                        <%#Convert.ToDateTime(Eval("IMPORTDATE")).ToString("dd-MMM-yyyy")%>&nbsp;
                                    </td>

                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                    <div class="footer">
                        <asp:Label ID="lblResult" CssClass="gridResults" runat="server" Text=""></asp:Label>
                        <div class="pager">
                            <asp:DataPager ID="dpImportedData" runat="server" PagedControlID="lvImportedData" PageSize="15" OnPreRender="pager_PreRender">
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

    </div>



</asp:Content>

