

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="CdpReport.aspx.cs" Inherits="CdpReport" %>

<%@ Register Src="~/UserControl/datetimePicker/WebUserControl.ascx" TagName="WebUserControl"
    TagPrefix="uc2" %>
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
    <uc2:WebUserControl ID="WebUserControl1" runat="server" />
    <script type="text/javascript">
        function refreshWindow() {
            ModifyLeftpanel();
        }

    </script>

    <div class="leftPanel"></div>
    <div class="Content">

      
                <table style="width: 350px;">
                    <tr>
                        <td>
                            <asp:Label ID="lblStarGererationDate" runat="server" Text="Report Date From" mandatory="true" SkinID="lblCommonSkin"> </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFromDate" mandatory="true" runat="server" SkinID="txtDate" CssClass="date required">
                            </asp:TextBox>
                            <a id="a2" runat="server">
                                <img src="UserControl/datetimePicker/themes/img.gif" id="btnLetterRefDate" style="cursor: hand;"
                                    align="absmiddle" onmouseover="ShowDate(this);" /></a>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label6" runat="server" Text="Report Date To" mandatory="true" SkinID="lblCommonSkin"> </asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtToDate" mandatory="true" runat="server" SkinID="txtDate" CssClass="date required">
                            </asp:TextBox>
                            <a id="a6" runat="server">
                                <img src="UserControl/datetimePicker/themes/img.gif" id="Img5" style="cursor: hand;"
                                    align="absmiddle" onmouseover="ShowDate(this);" /></a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Disburse Date From" mandatory="true" SkinID="lblCommonSkin"> </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDisburseFromDate" mandatory="true" runat="server" SkinID="txtDate" CssClass="date required">
                            </asp:TextBox>
                            <a id="a3" runat="server">
                                <img src="UserControl/datetimePicker/themes/img.gif" id="Img2" style="cursor: hand;"
                                    align="absmiddle" onmouseover="ShowDate(this);" /></a>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label8" runat="server" Text="Disburse Date To" mandatory="true" SkinID="lblCommonSkin"> </asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtDisburseToDate" mandatory="true" runat="server" SkinID="txtDate" CssClass="date required">
                            </asp:TextBox>
                            <a id="a8" runat="server">
                                <img src="UserControl/datetimePicker/themes/img.gif" id="Img7" style="cursor: hand;"
                                    align="absmiddle" onmouseover="ShowDate(this);" /></a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblReportName" runat="server" mandatory="true" Text="Report Name" SkinID="lblCommonSkin"> </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlReportname" mandatory="true" runat="server" SkinID="ddlLargeSkin">
                            </asp:DropDownList>
                        </td>
                    </tr>


                    <tr>
                        <td>
                            <asp:Label ID="lblReportType" runat="server" Text="Report Type" SkinID="lblCommonSkin"> </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlReportType" runat="server" SkinID="ddlLargeSkin">
                                <asp:ListItem Text="---All---" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Success" Value="200"></asp:ListItem>
                                <asp:ListItem Text="Fail" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>


                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" SkinID="lblCommonSkin"> </asp:Label>
                        </td>
                        <td align="left">
                            <asp:Button ID="btnReport" runat="server" Text="View" OnClick="btnReport_Click" SkinID="btnCommonSkin" ClientIDMode="Static" />
                            
                            <asp:Button ID="DownloadReport" Style="width: 150px;" runat="server" Text="Export to Excel" OnClick="btnExportToExcel_Click" SkinID="btnCommonSkin"  />
                        </td>
                    </tr>

                </table>

                <br />
                <hr />
                <br />

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

                                </colgroup>
                                <thead>
                                    <tr class="gridheader">
                                        <th>#</th>
                                        <th style="text-align: center">MSISDN</th>
                                        <th style="text-align: center">Retailer Code</th>
                                        <th style="text-align: center">Disburse Amount</th>
                                        <th style="text-align: center">Report Date</th>
                                        <th style="text-align: center">Generate Date</th>
                                        <th style="text-align: center">Topup Date</th>
                                        <th style="text-align: center">Disburse Status</th>
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
                                    <%#Eval("topup_msisdn")%>
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("retailer_code")%>
                                </td>


                                <td style="text-align: right">
                                    <%#Eval("disburse_amount")%>
                                </td>

                                <td style="text-align: center">
                                    <%#Eval("report_date")%>
                                </td>

                                <td style="text-align: center">
                                      <%--  <%#(Eval("create_date"))%>--%>
                                    <%#Common.DateFormat(Eval("create_date"))%>
                                </td>
                                <td style="text-align: center">
                                    <%--   <%#(Eval("disburse_date")) %>--%>
                                    <%#Common.DateFormat(Eval("disburse_date")) %>
                                </td>

                                <td style="text-align: center">
                                    <%#Eval("response_status")%>
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


<script type="text/javascript">

$("#btnReport").click(function (e) {

function GetDate(str) {
    ;
    var arr = str.split('-');
    //var months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
    //var i = 1;
    //for (i; i <= months.length; i++) {
    //    if (months[i] == arr[1]) {
    //        break;
    //    }
    //}
    var formatddate = arr[2] + '/' + arr[1] + '/' + arr[0];
    return formatddate;
}


var txtFromDate = $('#<%=txtFromDate.ClientID %>').val();
var txtToDate = $('#<%=txtToDate.ClientID %>').val();
var txtDisburseFromDate = $('#<%=txtDisburseFromDate.ClientID %>').val();
var txtDisburseToDate = $('#<%=txtDisburseToDate.ClientID %>').val();
var ddlReportname = $('#<%=ddlReportname.ClientID %>').val();

           
var startDate = GetDate(txtFromDate);
var endDate = GetDate(txtToDate);
var DisburseFromDate = GetDate(txtDisburseFromDate);
var DisburseToDate = GetDate(txtDisburseToDate);

if (ddlReportname == -1) {
    e.preventDefault();
    alert("Please Select Report Name");
}

if (txtFromDate == "" && txtToDate == "" && txtDisburseFromDate == "" && txtDisburseToDate == "")
{
    e.preventDefault();
    alert("Please Enter Atleast Report Date or Disburse Date");
}
         
if (txtFromDate != "" || txtToDate != "") {
    if (txtFromDate == "") {
        e.preventDefault();
        alert("Please Enter Report From Date.");
    }
    else if (txtToDate == "") {
        e.preventDefault();
        alert("Please Enter Report To  Date.");
    }
    else if (startDate > endDate) {
        e.preventDefault();
        alert("Report from date can not be greater than to date.");
    }
}

if (txtDisburseFromDate != "" || txtDisburseToDate != "") 
{
    if (txtDisburseFromDate == "") {
        e.preventDefault();
        alert("Please Enter Disburse From Date.");
    }
    else if (txtDisburseToDate == "") {
        e.preventDefault();
        alert("Please Enter Disburse To  Date.");
    }
    else if (DisburseFromDate > DisburseToDate) {
        e.preventDefault();
        alert("Disburse from date can not be greater than to date.");
    }
}

});

    </script>

</asp:Content>

