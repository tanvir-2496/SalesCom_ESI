<%@ Page Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="DetailDownloadLevel.aspx.cs" Inherits="DetailDownloadLevel" %>

<%@ Register Src="~/UserControl/datetimePicker/WebUserControl.ascx" TagName="WebUserControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
  
        <asp:UpdatePanel ID="upCycle" runat="server">
           

            <ContentTemplate>


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
                                            <th>Level Name</th>
                                            <th>Download</th>
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

                                    <td style="text-align: center">
                                    <%#Eval("LevelName")%>&nbsp;
                                    </td>

                                   
                                    <td style="text-align: center">
                                         <asp:LinkButton ID="lbtnDetailsAmount" runat="server" CommandName="DetailsAmount" CommandArgument='<%#Eval("DetailId")%>' Text="Download" />
                                         
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


</asp:Content>
