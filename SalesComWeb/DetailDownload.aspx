

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="DetailDownload.aspx.cs" Inherits="DetailDownload" EnableEventValidation="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
      
    </style>
    <link href="AutoComplete/CSS/auto-complete.css" rel="stylesheet" />
    <script type="text/javascript" src="AutoComplete/Scripts/auto-complete.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function refreshWindow() {
            ModifyLeftpanel();
        }

        var ReportName = [];

        function GetReportNameList() {

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "DetailDownload.aspx/GetReportName",
                data: "{}",
                dataType: "json",

                success: function (response) {
                    OnSuccess(response);
                },
                error: function (response) {
                    alert("error: " + response.d);
                }
            });
        }

        function OnSuccess(response) {
            ReportName = [];
            for (var i = 0; i < response.d.length; i++) {
                ReportName.push(response.d[i]);
            }

            new autoComplete({
                selector: '#txtReportName',
                minChars: 1,
                source: function (term, suggest) {
                    term = term.toLowerCase();
                    var choices = ReportName;
                    var suggestions = [];
                    for (i = 0; i < choices.length; i++)
                        if (~choices[i].toLowerCase().indexOf(term)) suggestions.push(choices[i]);
                    suggest(suggestions);
                }
            });
        }

        $(document).ready(function () {
            GetReportNameList();
        });

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(GetReportNameList);

    </script>

    <div class="leftPanel"></div>
    <div class="Content">

        <asp:UpdatePanel ID="upCycle" runat="server">
            <Triggers>
            </Triggers>

            <ContentTemplate>

                <div>
                    <div style="float: left;">
                        <table style="width: 800px">
                            <tr>
                                <td style="width: 595px">
                                    <asp:TextBox runat="server" ID="txtReportName" Width="580" placeholder="Report Name ..." ClientIDMode="Static"></asp:TextBox></td>
                                <td style="width: 195px;">
                                    <asp:Button runat="server" ID="btnSubmit" SkinID="btnCommonSkin" Text="Search" OnClick="btnSubmit_Click" ClientIDMode="Static"></asp:Button></td>
                            </tr>
                        </table>
                    </div>                  
                </div>


                <div style="clear: both">

                    <table style="width: 350px">

                        <tr runat="server" id="trPeriodType" visible="true">
                            <td>
                                <asp:Label ID="lblPeriodType" runat="server" Text="Period Type"> </asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPeridType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPeridType_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>


                        <tr runat="server" id="trYear" visible="true">
                            <td>
                                <asp:Label ID="lblYear" runat="server" Text="Year"> </asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPeridType_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>


                        <tr>
                            <td>
                                <asp:Label ID="lblCommissionCycle" runat="server" Text="Due Month"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCommissionCycle" runat="server" OnSelectedIndexChanged="ddlCommissionCycle_SelectedIndexChanged" AutoPostBack="true">
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
                                            <th>#</th>
                                            <th style="text-align: left">Report Name</th>
                                            <th>Month Name</th>
                                          
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
                                     <%#Eval("ReportName")%>&nbsp;
                                    </td>

                                    <td style="text-align: center">
                                         <%#Eval("MonthName")%>&nbsp;
                                    </td>

                                
                                   
                                    <td style="text-align: center">
                                         <%--<asp:LinkButton ID="lbtnDetailsAmount" runat="server" CommandName="DetailsAmount" CommandArgument='<%#Eval("Id")%>' Text="Download" />--%>
                                         <a type="button" href="DetailDownloadLevel.aspx?id=<%#Eval("Id")%>&&mode=edit&TB_iframe=true&height=400&width=450&modal=true"
                                            class="thickbox" title="Report Level">See Details</a>
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

