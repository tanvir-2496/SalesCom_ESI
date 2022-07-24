<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="ReportWiseWithheldList.aspx.cs" Inherits="ReportWiseWithheldList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
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

        <table style="width: 250px; display: none" id="tblFilterControls">
            <tr>
                <td>
                    <strong>Period Type</strong>
                </td>
                <td>
                    <select id="ddlPeridType"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Year</strong>
                </td>
                <td>
                    <select id="ddlYear"></select>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Due Month</strong>
                </td>
                <td>
                    <select id="ddlCommissionCycle"></select>
                </td>
            </tr>
        </table>

        <br />
        <div id="gvDiv" style="display: none">
            <asp:GridView ID="gvWithheldList" runat="server" AutoGenerateColumns="false" RowStyle-BackColor="#fff6e6" HeaderStyle-BackColor="#F26D1A" HeaderStyle-ForeColor="White"
                BorderStyle="Solid" Font-Names="Verdana" AlternatingRowStyle-BackColor="#ffffff" CellPadding="7" ClientIDMode="Static" Font-Size="X-Small">
                <Columns>
                    <asp:BoundField DataField="row_number" HeaderText="#" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="reportname" HeaderText="Report Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="report_duration" HeaderText="Report Duration" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="current_redisburse_number" HeaderText="Re-disb #" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="claim_amt" HeaderText="Claim" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="withheld_amt" HeaderText="Withheld" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="disburse_amt" HeaderText="Disburse" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField DataField="current_redisbure_amount" HeaderText="Cur. Disb" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField DataField="approvallevelname" HeaderText="Cur. Level" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:ButtonField ButtonType="Button" HeaderText="Details" Text="Download" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:ButtonField ButtonType="Button" HeaderText="Re-disburse" Text="Re-disburse" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                </Columns>
            </asp:GridView>
            <br />
            <div class="CustomPager"></div>
        </div>

    </div>
    <script type="text/javascript">
        "use strict"
        var SelectedCommissionCycleId;
        var CurrentPageIndex = 1;
           
        
        $.ajax({
            type: "POST",
            url: "ReportWiseWithheldList.aspx/GetYear",
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                var ddlYear = $("#ddlYear");
                ddlYear.empty();
                $.each(r.d, function () {
                    ddlYear.append($('<option>').text(this).attr('value', this));
                });
            }
        });

        $.ajax({
            type: "POST",
            url: "ReportWiseWithheldList.aspx/GetPeriodType",
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                var ddlPeriodType = $("#ddlPeridType");
                ddlPeriodType.empty().append("<option selected='selected' value='-1'> [Slecet One] </option>");
                $.each(r.d, function () {
                    ddlPeriodType.append($('<option>').text(this.PeriodTypeName).attr('value', this.PeriodTypeId));
                });

                $("#tblFilterControls").show();
            }
        });

        $("#ddlPeridType, #ddlYear").change(function () {

            var selectedPeriodTypeId = $("#ddlPeridType option:selected").attr('value');
            var selectYear = $("#ddlYear option:selected").attr('value');
            var ddlCommissionCycle = $("#ddlCommissionCycle");
            if (selectedPeriodTypeId > 0 && selectYear) {

                $.ajax({
                    type: "POST",
                    url: "ReportWiseWithheldList.aspx/GetCommissionCycleByYear",
                    data: "{'periodTypeId':" + selectedPeriodTypeId + ", " + 'year:' + selectYear + " }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (r) {
                        ddlCommissionCycle.empty();
                        $.each(r.d, function () {
                            ddlCommissionCycle.append($('<option>').text(this.CycleDescription).attr('value', this.CycleId));
                        });

                        SelectedCommissionCycleId = $("#ddlCommissionCycle option:selected").attr('value');
                        if (SelectedCommissionCycleId) {
                            LoadData(SelectedCommissionCycleId, 1);
                        }
                        else {
                            if ($('#gvDiv').show()) {
                                $('#gvDiv').hide();
                            }
                        }
                    }
                });
            }
            else {
                ddlCommissionCycle.empty();
                if ($('#gvDiv').show()) {
                    $('#gvDiv').hide();
                }
            }
        });

        function LoadData(selectedCommissionCycleId, pageIndex) {
            $.ajax({
                type: "POST",
                url: "ReportWiseWithheldList.aspx/BindData",
                data: "{'cycleId':" + selectedCommissionCycleId + ", " + 'pageIndex:' + pageIndex + " }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    OnSuccess(r, pageIndex);
                }
            });
        }

        function OnSuccess(response, pageIndex) {
            var rowClass;
            var tdRedisburse;
            var tdCurrentDisburse;

            $("[id*=gvWithheldList] tr").not($("[id*=gvWithheldList] tr:first-child")).remove();

            if ($('#gvDiv').hide() && response.d.length > 0) {
                $('#gvDiv').show();
            }

            for (var i = 0; i < response.d.length; i++) {

                rowClass = i % 2 == 0 ? 'rowClass' : 'altrowClass';
                tdRedisburse = response.d[i].current_order_id > 1 ? "</td><td align='center'><strong>Under Process</strong>" : "</td><td align='center'> <a type='button' onclick ='ShowModal(this)' href='RCID=" + response.d[i].report_cycle_id + "&RD=" + response.d[i].report_duration + "&RN=" + response.d[i].reportname + "&CWA=" + response.d[i].withheld_amt + "&DFLOW=" + response.d[i].disburse_approval_flowid + "&CORD=" + response.d[i].current_order_id + "&CDNum="+response.d[i].current_redisburse_number + "' class='thickbox' >Re-disburse</a>";
                tdCurrentDisburse = response.d[i].current_redisbure_amount == 0 ? "</td><td align='right'>N/A" : "</td><td align='right'>" + response.d[i].current_redisbure_amount_ch;

                $("#gvWithheldList").append("<tr class='" + rowClass + "' ><td>" + response.d[i].row_number +
                                            "</td><td>" + response.d[i].reportname +
                                            "</td><td align='center'>" + response.d[i].report_duration +
                                            "</td><td align='center'>" + response.d[i].current_redisburse_number +
                                            "</td><td align='right'>" + response.d[i].claim_amt +
                                            "</td><td align='right'>" + response.d[i].withheld_amt_ch +
                                            "</td><td align='right'>" + response.d[i].disburse_amt +
                                            tdCurrentDisburse +
                                            "</td><td align='center'>" + response.d[i].approvallevelname +
                                            "</td><td align='center'> <a href='DownloadWithheldDetails.aspx?type=4&reportCycle=" + response.d[i].report_cycle_id + "&reportName=" + response.d[i].reportname + "&commissiomCycle=" + response.d[i].commissiom_cycle + "' target='_top' download>Download</a>" +
                                            tdRedisburse
                                            + "</td></tr>");
            }

            var total_rows = response.d.length > 0 ? parseInt(response.d[0].record_count) : 0;
            $(".CustomPager").ASPSnippets_Pager({
                ActiveCssClass: "current",
                PagerCssClass: "CustomPager",
                PageIndex: pageIndex,
                PageSize: 4,
                RecordCount: total_rows
            });
        }

        $("#ddlCommissionCycle").change(function () {
            SelectedCommissionCycleId = $("#ddlCommissionCycle option:selected").attr('value');
            if (SelectedCommissionCycleId) {
                LoadData(SelectedCommissionCycleId, 1);
            }
        });

        function ShowModal(e) {
            var hrefText = "ReportWiseRedisburseInitiation.aspx?" + $(e).attr('href') + "&TB_iframe=true&&height=500&width=750";
            $(e).attr('href', '#');
            tb_show('Re-disburse Initiation', hrefText);
        }

        $(".CustomPager a").live("click", function () {
            CurrentPageIndex = parseInt($(this).attr('page'));
            LoadData(SelectedCommissionCycleId, CurrentPageIndex, false);
        });

        $(".imageLoader").bind("ajaxStart", function () {
            $(this).fadeIn(150)
        }).bind("ajaxStop", function () {
            $(this).fadeOut(150);
        });

        function refreshWindow() {
            SelectedCommissionCycleId = $("#ddlCommissionCycle option:selected").attr('value');
            if (SelectedCommissionCycleId) {
                LoadData(SelectedCommissionCycleId, CurrentPageIndex);
            }
        };

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


