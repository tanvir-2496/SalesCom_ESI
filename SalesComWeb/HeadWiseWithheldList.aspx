<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="HeadWiseWithheldList.aspx.cs" Inherits="HeadWiseWithheldList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #txtDistributorCode {
            padding: 6px;
        }


        .CustomPager span {
            text-align: center;
            color: #0026ff;
            font-weight: bold;
            display: inline-block;
            width: 20px;
            background-color: #F37821;
            margin-right: 3px;
            line-height: 150%;
            border: 2px solid #808080;
        }

        .CustomPager a {
            text-align: center;
            display: inline-block;
            width: 20px;
            background-color: #808080;
            color: #fff;
            font-weight: bold;
            border: 2px solid #808080;
            margin-right: 3px;
            line-height: 150%;
            text-decoration: none;
        }

        .linkButton {
            -webkit-border-radius: 4px;
            -moz-border-radius: 4px;
            border-radius: 4px;
            border: solid 1px #808080;
            text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.4);
            -webkit-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.4), 0 1px 1px rgba(0, 0, 0, 0.2);
            -moz-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.4), 0 1px 1px rgba(0, 0, 0, 0.2);
            box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.4), 0 1px 1px rgba(0, 0, 0, 0.2);
            background: #808080;
            color: #fff;
            padding: 5px 10px;
            text-decoration: none;
            font-size: small;
        }

            .linkButton:hover {
                background: #F37821;
                border: solid 1px #F37821;
                text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.5);
            }

        .imageLoader {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url('../images/loadingAnimation.gif') 50% 50% no-repeat rgba(0, 0, 0, 0.5);
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="leftPanel"></div>

    <div class="Content">
        <div class="imageLoader"></div>
        <table class="contenttext" style="width: 310px;">
            <tr>
                <td style="padding: 3px; vertical-align: middle">
                    <asp:Label ID="lblDistributorCode" mandatory="true" runat="server" Text="Distributor Code"> </asp:Label>
                </td>
                <td style="padding: 3px">
                    <asp:TextBox ID="txtDistributorCode" CssClass="required" runat="server" Font-Bold="true" onkeyup="this.value=this.value.toUpperCase()" ClientIDMode="Static">
                    </asp:TextBox>
                </td>
            </tr>
            <tr class="tdSubmit">
                <td></td>
                <td style="text-align: left; padding-left: 3px">
                    <asp:Button ID="btnSubmit" ClientIDMode="Static" OnClientClick=" if(fnValidate()){LoadData(1, true);}" runat="server" CssClass="button_classA" Text="Show" />
                </td>
            </tr>
        </table>

        <br />
        <div id="gvDiv" style="display: none">
            <asp:GridView ID="gvWithheldList" runat="server" AutoGenerateColumns="false" RowStyle-BackColor="#fff6e6" HeaderStyle-BackColor="#F26D1A" HeaderStyle-ForeColor="White"
                BorderStyle="Solid" Font-Names="Verdana" AlternatingRowStyle-BackColor="#ffffff" CellPadding="7" ClientIDMode="Static">
                <Columns>
                    <asp:BoundField DataField="row_number" HeaderText="#" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="reportname" HeaderText="Report Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="commission_month" HeaderText="Commission Month" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="publish_month" HeaderText="Publish Month" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="report_duration" HeaderText="Report Duration" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="withheld_amount" HeaderText="Withheld Amount" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                    <asp:ButtonField ButtonType="Button" HeaderText="Details" Text="Download" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                </Columns>
            </asp:GridView>
            <br />
            <div class="CustomPager"></div>
        </div>
        <br />
        <div id="exportDetails">
            <table>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </div>

        <div class="errortext"></div>
    </div>

    <script type="text/javascript">
        //"use strict"
        var DistributorCode;
        var CurrentPageIndex;

        $("#btnSubmit").click(function (e) {
            e.preventDefault();
        });

        function LoadData(pIndex, isFirstLoad) {
            CurrentPageIndex = pIndex;
            DistributorCode = $('#txtDistributorCode').val();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "HeadWiseWithheldList.aspx/BindData",
                data: "{'distributorCode':'" + DistributorCode + "', 'pageIndex' :" + pIndex + "}",
                dataType: "json",

                success: function (response) {
                    OnSuccess(response);
                    if (isFirstLoad == true) {

                        ClearExportDetails();
                        if (response.d.length > 0) {
                            $("#exportDetails td:first").append("<a class='linkButton' href='DownloadWithheldDetails.aspx?type=2&recipientCode=" + DistributorCode + "' target='_top' download>Summary</a>");
                            $("#exportDetails td:last").append("<a class='linkButton' href='DownloadWithheldDetails.aspx?type=3&recipientCode=" + DistributorCode + "' target='_top' download>Details</a>");
                        }
                    }
                },
                error: function (response) {
                    alert("error: " + response.d);
                }
            });
        }

        function OnSuccess(response) {

            var rowClass;

            $("[id*=gvWithheldList] tr").not($("[id*=gvWithheldList] tr:first-child")).remove();

            if ($('#gvDiv').hide() && response.d.length > 0) {
                $('#gvDiv').show();
            }

            for (var i = 0; i < response.d.length; i++) {

                rowClass = i % 2 == 0 ? 'rowClass' : 'altrowClass';

                $("#gvWithheldList").append("<tr class='" + rowClass + "' ><td>" + response.d[i].row_number +
                                            "</td><td>" + response.d[i].reportname +
                                            "</td><td align='center'>" + response.d[i].commission_month +
                                            "</td><td align='center'>" + response.d[i].publish_month +
                                            "</td><td align='center'>" + response.d[i].report_duration +
                                            "</td><td align='right'>" + response.d[i].withheld_amount +
                                            "</td><td align='right'> <a href='DownloadWithheldDetails.aspx?type=1&id=" + response.d[i].report_cycle_id + "&fileName=" + response.d[i].reportname + "&reportCycle=" + response.d[i].commission_month + "&recipientCode=" + DistributorCode + "' target='_top' download>Download</a>" +
                                            "</td></tr>");
            }

            var total_rows = response.d.length > 0 ? parseInt(response.d[0].record_count) : 0;

            if (!$(".errortext").is(":empty")) { $(".errortext").empty(); }

            if (total_rows === 0) {
                ClearExportDetails();
                $(".errortext").append("<strong>No data found for \"" + $("#txtDistributorCode").val() + "\"</strong>")
            };

            $(".CustomPager").ASPSnippets_Pager({
                ActiveCssClass: "current",
                PagerCssClass: "CustomPager",
                PageIndex: CurrentPageIndex,
                PageSize: 5,
                RecordCount: total_rows
            });
        }

        $(".CustomPager a").live("click", function () {
            LoadData(parseInt($(this).attr('page')), false);
        });

        function ClearExportDetails() {
            if (!$("#exportDetails td:first").is(":empty")) {
                $("#exportDetails td:first").empty();
                $("#exportDetails td:last").empty();
            }
        }

        $(".imageLoader").bind("ajaxStart", function () {
            $(this).fadeIn(150)
        }).bind("ajaxStop", function () {
            $(this).fadeOut(150);
        });

        function ASPSnippetsPager(a, b) {
            var c = '<a style = "cursor:pointer" page = "{1}">{0}</a>';
            var d = "<span>{0}</span>";
            var e, f, g;
            var g = 5;
            var h = Math.ceil(b.RecordCount / b.PageSize);
            if (b.PageIndex > h) { b.PageIndex = h }
            var i = "";
            if (h > 1) {
                f = h > g ? g : h; e = b.PageIndex > 1 && b.PageIndex + g - 1 < g ? b.PageIndex : 1;
                if (b.PageIndex > g % 2) {
                    if (b.PageIndex == 2) f = 5;
                    else f = b.PageIndex + 2
                }
                else {
                    f = g - b.PageIndex + 1
                }
                if (f - (g - 1) > e) {
                    e = f - (g - 1)
                }
                if (f > h) {
                    f = h; e = f - g + 1 > 0 ? f - g + 1 : 1
                }
                var j = (b.PageIndex - 1) * b.PageSize + 1;
                var k = j + b.PageSize - 1;
                if (k > b.RecordCount) {
                    k = b.RecordCount
                }

                i = "<b>Records " + (j == 0 ? 1 : j) + " - " + k + " of " + b.RecordCount + "</b> ";
                if (b.PageIndex > 1) {
                    i += c.replace("{0}", "<<").replace("{1}", "1"); i += c.replace("{0}", "<").replace("{1}", b.PageIndex - 1)
                }
                for (var l = e; l <= f; l++) {
                    if (l == b.PageIndex) {
                        i += d.replace("{0}", l)
                    }
                    else { i += c.replace("{0}", l).replace("{1}", l) }
                }
                if (b.PageIndex < h) {
                    i += c.replace("{0}", ">").replace("{1}", b.PageIndex + 1); i += c.replace("{0}", ">>").replace("{1}", h)
                }
            }
            a.html(i);
            try {
                a[0].disabled = false
            }
            catch (m) { }
        } (function (a) {
            a.fn.ASPSnippets_Pager = function (b) {
                var c = {}; var b = a.extend(c, b);
                return this.each(function () {
                    ASPSnippetsPager(a(this), b)
                })
            }
        })(jQuery);

    </script>

</asp:Content>
