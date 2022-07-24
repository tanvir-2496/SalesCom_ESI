<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="KPIUpdate1.aspx.cs" Inherits="KPIUpdate" Culture="en-GB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .color_red {
            background-color: red !important;
        }

        .container {
            margin-top: 00px;
        }

        .Header {
            font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 95%;
            margin: auto;
            margin-top: 10px !important;
            table-layout: fixed;
        }

            .Header td, .Header th {
                border: 1px solid #ddd;
                padding: 8px;
            }

            .Header tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            .Header tr:hover {
                background-color: #ddd;
            }

            .Header th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: #F37821;
                color: white;
            }

        .contenttext {
            font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 95%;
            margin: auto;
            margin-top: 10px !important;
            table-layout: fixed;
            border: 1.5px solid #fcdfcb !important;
        }

            .contenttext td, .contenttext th {
                /*border: 1px solid #ddd;*/
                padding: 8px;
            }

            .contenttext tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            .contenttext tr:hover {
                background-color: #ddd;
            }

            .contenttext th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: #F37821;
                color: white;
            }


        .W10 {
            width: 10%;
        }

        .W90 {
            width: 100%;
        }

        .W205 {
            width: 25%;
        }

        .W250 {
            width: 25%;
        }

        .W240 {
            width: 100%;
        }

        .W350 {
            width: 30%;
        }

        .W340 {
            width: 100%;
        }

        /*.footertext {
            display: none;
        }*/
        .reportHeader {
          color:#732400;
        }
        
        .Content {
            height: auto !important;
            min-height:456px !important;
        }

        .tr#masterContainer td {
            border: solid 0px !important;
        }
        body {
          overflow-x: hidden;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="leftPanel"></div>
    <div class="Content">
        <asp:UpdatePanel ID="lstpanel" runat="server">
            <ContentTemplate>
                <center>
                    <h2 class="reportHeader SuccessDiv">KPI EDIT</h2>
                </center>
                <div class="hideClass" style="text-align: right; float: right; margin-right: 3%">
                    <input type="button" value="New KPI" alt="SetupKpiAdd.aspx?keepThis=false&TB_iframe=true&height=300&width=450"
                        class="thickbox" title="New KPI" />
                    <input type="button" value="New Sub KPI" alt="SetupSubKpiAdd.aspx?keepThis=false&TB_iframe=true&height=300&width=450"
                        class="thickbox" title="New Sub KPI" />
                    <input type="button" value="New Condition" alt="SetupConditionAdd.aspx?keepThis=false&TB_iframe=true&height=300&width=450"
                        class="thickbox" title="New Condition" />
                </div>
                  <div style="text-align: center; margin: 10px auto; padding: 10px; font-size: 20px; color: #d49800" id="successMessage"></div>
                <div class="SuccessDiv">
                    <div>
                        <table class="Header W95">
                            <tr class="Kpi">
                                <th class="W100">Indicator</th>
                                <th class="W250">KPI/Sub KPI/Condition</th>
                                <th class="W100">Weightage</th>
                                <th class="W350">Incentive Payout</th>
                                <th class="W205">Action</th>
                            </tr>
                        </table>
                    </div>
                    <div class="kpi_fields_wrap SuccessDiv">
                        <%--Table Insert Here--%>
                    </div>
                    <div>
                        <button style="margin-left: 2%" id="add_kpi" class="add_more_kpi button" type="button">Add KPI</button>
                        <button style="float: right; margin-right: 2%" id="Submit" onclick="NewKPIConfigure()" class="button" type="button">Save</button>
                    </div>
                </div>
              
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <script type="text/javascript">
        var kpiTable_id = [];
        var subKpiTable_id = [];
        var condition_id = [];
        var selectedYear = 0;
        var selectedQuarter = 0;
        var selectedSChannel = 0;

        var KPI = [];
        var SubKPI = [];
        var Condition = [];
        var KPIDropDown = [];
        var SubKPIDropDown = [];
        var ConditionDropDown = [];
        var firstIndex = 0;
        var secondIndex = 0;
        var thirdIndex = 0;

        function getLastInsertedIndex(className,start) {
            var ids = $(className).map(function () {
                return $(this).attr('id');
            });
            var kpiIndex = [];
            var maxValue = 0;
            if (ids.length > 0) {
                for (var i = 0; i < ids.length; i++) {
                    var id = ids[i].substring(start, ids[i].length+1)
                    kpiIndex.push(parseInt(id));
                }
                maxValue = Math.max(...kpiIndex) //no error here!!
            }
            return maxValue +1;
        }

        $(document).ready(function () {
            loadData();
            $('#add_kpi').click(function (e) {
                e.preventDefault();
                var firstIndex = getLastInsertedIndex('.kpi_fields_wrap table',9);

                $('.kpi_fields_wrap').append('<table style="margin: auto;" class="contenttext W95" id="kpiTable_' + firstIndex + '"><tr><td class="W100"><button class="button color_red" id="kpiTable_' + firstIndex + '_kpiRemove"  type="button" onclick="removeKpi(this.id)"  >X</button>  KPI</td><td class="W250"><select class="W240" type="text" id="kpiTable_' + firstIndex + '_kpi"></select></td><td class="W100" ><input class="W90"  placeholder="Weightage" type="number" id="kpiTable_' + firstIndex + '_kpiWeightageKpi"/></td><td class="W350"><input class="W340" placeholder="Threshold" type="text" id="kpiTable_' + firstIndex + '_incentivePayoutKpi" /></td><td class="W205"><div style="float:right"><button style="margin-right: 5px;" id ="addKpiTable_' + firstIndex + '_subKpi" type="button" class="button" onclick="generateSubKpi(this.id)" >Add Sub KPI</button><button id="addKpiTable_' + firstIndex + '_condition" class="button" type="button" onclick="generateKpiCondition(this.id)">Add Condition</button></div></td></tr></<table>');
                loadKPIBySalesGroup('#kpiTable_' + firstIndex + '_kpi');
                // $(".kpi_fields_wrap").scrollTop(350);
                window.scrollTo(0,document.body.scrollHeight);
            });
        });
        //$(document).ready(function () {
        //    loadData();
        //    //Add New KPI 
        //    $('#add_kpi').click(function (e) {
        //        e.preventDefault();
        //        var firstIndex = $('.kpi_fields_wrap table').length + 1;
        //        $('.kpi_fields_wrap').append('<table class="contenttext W95" id="kpiTable_' + firstIndex + '"><tr><td class="W10"><button class="button color_red" id="kpiTable_' + firstIndex + '_kpiRemove"  type="button" onclick="removeKpi(this.id)" >X</button></td><td class="W200"><select class="W190" type="text" id="kpiTable_' + firstIndex + '_kpi"></select></td><td class="W200"><input class="W190" placeholder="Threshold" type="text" id="kpiTable_' + firstIndex + '_incentivePayoutKpi" /></td><td class="W350" ><input class="W340"  placeholder="KPI Weightage" type="text" id="kpiTable_' + firstIndex + '_kpiWeightageKpi"/></td><td class="W205"><button style="margin-right: 5px;" id ="addKpiTable_' + firstIndex + '_subKpi" type="button" class="button" onclick="generateSubKpi(this.id)" >Add Sub KPI</button><button id="addKpiTable_' + firstIndex + '_condition" class="button" type="button" onclick="generateKpiCondition(this.id)">Add Condition</button></td></tr></<table>');

        //        //$('.kpi_fields_wrap').append('<table class="contenttext" id="kpiTable_' + firstIndex + '"><tr><td  class="W10"><button class="button" id="kpiTable_' + firstIndex + '_kpiRemove" style="background-color:red"  type="button" onclick="removeKpi(this.id)" >X</button></td><td  class="W200"><select  class="W190" type="text" id="kpiTable_' + firstIndex + '_kpi"></select></td><td  class="W200"><input  class="W190" placeholder="Threshold" type="text" id="kpiTable_' + firstIndex + '_incentivePayoutKpi" /></td><td  class="W350"><input  class="W340" placeholder="KPI Weightage" type="text" id="kpiTable_' + firstIndex + '_kpiWeightageKpi"/></td><td class="W205"><button id ="addKpiTable_' + firstIndex + '_subKpi" type="button" class="button" onclick="generateSubKpi(this.id)" >Add Sub KPI</button><button id="addKpiTable_' + firstIndex + '_condition" class="button" type="button" onclick="generateKpiCondition(this.id)">Add Condition</button></td></tr></<table>');
        //        loadKPIBySalesGroup('#kpiTable_' + firstIndex + '_kpi');
        //    });
        //    loadKPIBySalesGroup("#kpiTable_1_kpi");
        //});

        // Update KPI Start
        function NewKPIConfigure() {

            window.scrollTo(0, 0);

            clearAllData();
            var ids = $('.contenttext').map(function () {
                return $(this).attr('id');
            });
            //table all
            for (var i = 0; i < ids.length; i++) {

                var kpiId = ids[i] + "_kpi";
                var incentivePayout = ids[i] + "_incentivePayoutKpi";
                var kpiWeightage = ids[i] + "_kpiWeightageKpi";

                var kpiIdValue = $("#" + kpiId).val();
                var incentivePayoutValue = $("#" + incentivePayout).val();
                var kpiWeightageValue = $("#" + kpiWeightage).val();;

                kpiTable_id.push({ Kpi_id: kpiId, Incentive_Payout: incentivePayout, Weightage: kpiWeightage });
                KPI.push({ Kpi_id: kpiIdValue, Incentive_Payout: incentivePayoutValue, Weightage: kpiWeightageValue });

                var trSubKpi = $("#" + ids[i] + ' tr');
                for (var j = 1; j < trSubKpi.length; j++) {
                    var trClassName = $(trSubKpi[j]).map(function () {
                        var className = $(this).attr('class');
                        return className.substring(0, 9);
                    });
                    //Check KPI or SubKPI
                    if (trClassName[0] == "kpiSubKpi") {
                        var x = trSubKpi[j];
                        var rowIds = $(x).map(function () {
                            return $(this).attr('id');
                        });

                        var mainKpiId = kpiId;
                        var subKpiId = rowIds[0] + "_kpi";
                        var subKpiWeightage = rowIds[0] + "_subKpiWeightage";

                        var mainKpiIdValue = kpiIdValue;
                        var subKpiIdValue = $("#" + subKpiId).val();
                        var subKpiWeightageValue = $("#" + subKpiWeightage).val();

                        subKpiTable_id.push({ Kpi_id: mainKpiId, SubKpi_id: subKpiId, Weightage: subKpiWeightage });
                        SubKPI.push({ Kpi_id: mainKpiIdValue, SubKpi_id: subKpiIdValue, Weightage: subKpiWeightageValue });
                    } else {
                        //KPI has condition only
                        var trClassName = $(trSubKpi[j]).map(function () {
                            var className = $(this).attr('class');
                            return className.substring(0, 12);
                        });
                        if (trClassName[0] == "kpiCondition") {
                            var x = trSubKpi[j];
                            var rowIds = $(x).map(function () {
                                return $(this).attr('id');
                            });

                            var mainKpiId = kpiId;
                            var mainKpiIdValue = kpiIdValue;
                            var subKpiIdValue = 0;
                            var ConditionTableId = rowIds[0] + "_condition";
                            var conditionIdValue = $("#" + ConditionTableId).val();

                            condition_id.push({ Kpi_id: mainKpiId, SubKpi_id: 0, Condition_id: ConditionTableId });
                            Condition.push({ Kpi_id: mainKpiIdValue, SubKpi_id: subKpiIdValue, Condition_id: conditionIdValue });
                        } else {
                            //Sub KPI Condition
                            var x = trSubKpi[j];
                            var rowIds = $(x).map(function () {
                                return $(this).attr('id');
                            });
                            var mainKpiId = kpiId;
                            var mainKpiIdValue = kpiIdValue;
                            var subKpiId = rowIds[0].substring(0, 24);
                            var subKpiIdValue = $("#" + subKpiId + "_kpi").val();
                            var ConditionTableId = rowIds[0] + "_condition";
                            var conditionIdValue = $("#" + ConditionTableId).val();

                            condition_id.push({ Kpi_id: mainKpiId, SubKpi_id: subKpiId[0], Condition_id: ConditionTableId });
                            Condition.push({ Kpi_id: mainKpiIdValue, SubKpi_id: subKpiIdValue, Condition_id: conditionIdValue });
                        }
                    }
                }
            }
            console.log(KPI);
            console.log(SubKPI);
            console.log(Condition);
            SaveKPIData(KPI, SubKPI, Condition)
        }

        function SaveKPIData(kpi, subKpi, condition) {
            var isValid = ValidateData(kpi, subKpi);
            if (!isValid) {
                return;
            }
            var rCycleId = getParameterByName("reportCycleId");
            var ReportId = parseInt(rCycleId);
            var monthId = getParameterByName("Month");
            var month = parseInt(monthId)

            var d = { MainKPI: kpi, SubKPI: subKpi, Condition: condition, ReportCycleId: ReportId, Month: month };
            var Data = Sys.Serialization.JavaScriptSerializer.serialize(d)

            $.ajax({
                url: "KPIUpdate.aspx/UpdateKpiConfigurationData",
                data: Data,
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (mydata) {
                    MessageShow(mydata.d);
                }
            });
        };
        function ValidateData(kpi, subKpi) {
            var kpiWeightage = 0;
            var msz = "";
            var isValid = true;
            for (var i = 0; i < kpi.length; i++) {
                var x = kpi[i];
                kpiWeightage += parseInt(x.Weightage);
                if (x.Incentive_Payout == "") {
                    isValid = false
                    msz = "Threshold can not be empty!!";
                }
                if (x.Weightage == "") {
                    isValid = false
                    msz = "Weightage can not be empty!!";
                }
            }

            if (kpiWeightage > 100) {
                msz = "KPI Weightage is not valid!!";
                isValid = false
            }
            var rCycleId = getParameterByName("reportCycleId");
            var ReportId = parseInt(rCycleId);
            var monthId = getParameterByName("Month");
            var month = parseInt(monthId)
            if (ReportId < 1) {
                msz = "Url not match";
                isValid = false
            }
            if (month < 1) {
                msz = "Url not match";
                isValid = false
            }
            if (!isValid) {
                alert(msz);
            }
            return isValid;
        };

        function clearAllData() {
            KPI = [];
            SubKPI = [];
            Condition = [];
            kpiTable_id = [];
            subKpiTable_id = [];
            condition_id = [];
            selectedYear = 0;
            selectedQuarter = 0;
            selectedSChannel = 0;
            firstIndex = 0;
            secondIndex = 0;
            thirdIndex = 0;
        };
        function MessageShow(result) {
            if (parseInt(result.Type) == 1) {
                setTimeout(function () {
                    window.location.href = "KPIApproval.aspx";
                    $('#successMessage').text("Redirect!!");
                }, 5000);
                $('.hideClass').hide();
                $('.SuccessDiv').hide();
                $('#successMessage').text(result.Message);
            } else {
                setTimeout(function () {
                    $('.hideClass').show(500);
                    $('#successMessage').text("");
                }, 3000);
                $('.hideClass').hide();
                $('#successMessage').text(result.Message);
            }
        }
        // Update KPI End

        //Load KPI Data Start
        function loadData() {
            var rCycleId = getParameterByName("reportCycleId");
            var ReportId = parseInt(rCycleId);
            var monthId = getParameterByName("Month");
            var month = parseInt(monthId)
            var urlParams = new URLSearchParams(location.search);
            var report = urlParams.get('ReportName');
            $(".reportHeader").text(report);
            var Data = JSON.stringify({ reportCycleId: ReportId, month: month });
            $.ajax({
                url: "KPIUpdate.aspx/GetKPIWithCondition",
                data: Data,
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (mydata) {
                    var data = mydata.d;
                    var kpi = data.KPIs;
                    var subKpi = data.SubKPIs;
                    var condition = data.Conditions;
                    var KPIDropDown = data.KPIDropdown;
                    var SubKPIDropDown = data.SubKPIDropdown;
                    var ConditionDropDown = data.ConditionDropdown;
                    bindData(kpi, subKpi, condition, KPIDropDown, SubKPIDropDown, ConditionDropDown);
                }
            });
        }
        function bindData(kpi, subKpi, condition, kpiDropdown, subKpiDropdown, conditionDropdown) {
            $.each(kpi, function () {
                var kpiValue = this;
                firstIndex += 1;
                secondIndex = 0;
                //Bind Main KPI DATA
              //  $('.kpi_fields_wrap').append('<table class="contenttext W95" id="kpiTable_' + firstIndex + '"><tr><td class="W10"><button class="button color_red" id="kpiTable_' + firstIndex + '_kpiRemove"  type="button" onclick="removeKpi(this.id)" >X</button></td><td class="W200"><select class="W190" type="text" id="kpiTable_' + firstIndex + '_kpi"></select></td><td class="W200"><input class="W190" placeholder="Threshold" type="text" value="' + kpiValue.INCENTIVE_PAYOUT + '" id="kpiTable_' + firstIndex + '_incentivePayoutKpi" /></td><td class="W350"><input class="W340" placeholder="KPI Weightage" value="' + kpiValue.WEIGHTAGE + '" type="text" id="kpiTable_' + firstIndex + '_kpiWeightageKpi"/></td><td class="W205"><button style="margin-right: 5px;" id ="addKpiTable_' + firstIndex + '_subKpi" type="button" class="button" onclick="generateSubKpi(this.id)" >Add Sub KPI</button><button id="addKpiTable_' + firstIndex + '_condition" class="button" type="button" onclick="generateKpiCondition(this.id)">Add Condition</button></td></tr></<table>');
                $('.kpi_fields_wrap').append('<table style="margin: auto;" class="contenttext W95" id="kpiTable_' + firstIndex + '"><tr><td class="W100"><button class="button color_red" id="kpiTable_' + firstIndex + '_kpiRemove"  type="button" onclick="removeKpi(this.id)"  >X</button>  KPI</td><td class="W250"><select class="W240" type="text" id="kpiTable_' + firstIndex + '_kpi"></select></td><td class="W100" ><input class="W90"  placeholder="Weightage" value="' + kpiValue.WEIGHTAGE + '" type="number" id="kpiTable_' + firstIndex + '_kpiWeightageKpi"/></td><td class="W350"><input class="W340" placeholder="Threshold" type="text" value="' + kpiValue.INCENTIVE_PAYOUT + '" id="kpiTable_' + firstIndex + '_incentivePayoutKpi" /></td><td class="W205"><div style="float:right"><button style="margin-right: 5px;" id ="addKpiTable_' + firstIndex + '_subKpi" type="button" class="button" onclick="generateSubKpi(this.id)" >Add Sub KPI</button><button id="addKpiTable_' + firstIndex + '_condition" class="button" type="button" onclick="generateKpiCondition(this.id)">Add Condition</button></div></td></tr></<table>');
                //Main KPI Dropdown
                for (i = 0; i < kpiDropdown.length; i++) {
                    if (kpiDropdown[i].Kpi_id == kpiValue.KPI_ID) {
                        var data = "<option value=" + kpiDropdown[i].Kpi_id + " selected>" + kpiDropdown[i].Kpi_Name + "</option>"
                        $('#kpiTable_' + firstIndex + '_kpi').append(data);
                    } else {
                        var data = "<option value=" + kpiDropdown[i].Kpi_id + ">" + kpiDropdown[i].Kpi_Name + "</option>"
                        $('#kpiTable_' + firstIndex + '_kpi').append(data);
                    }
                }
                $("#kpiTable_"+ firstIndex + "_kpi").attr("disabled",true);
                //Bind Sub KPI DATA
                $.each(subKpi, function () {
                    var subKpiValue = this;
                    secondIndex += 1;
                    if (subKpiValue.PARENT_KPI_ID == kpiValue.KPI_ID) {

                       // var subKpiDirective = '<tr class="kpiSubKpi_' + firstIndex + '" id= "kpi_' + firstIndex + '_subkpi_' + secondIndex + '"><td><button class="button color_red" id="kpiTable_' + firstIndex + '_removeSubKpi_' + secondIndex + '" type="button" onclick="deleteSubKpi(this.id)">X</button></td><td class="W200"></td><td><select class="W190" type="text" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '"' + ' ></select></td><td><input class="W340" placeholder="Sub KPI Weightage" value="' + subKpiValue.WEIGHTAGE + '" type="text" id="kpiTable_' + firstIndex + '_subKpiWeightage_' + secondIndex + '"' + '/></td><td class="W205"><button class="button"  style="margin-right: 5px;" id="addKpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition" type="button" onclick="generateSubKpiCondition(this.id)">Add Condition</button></td></tr>';
                        var subKpiDirective = '<tr class="kpiSubKpi_' + firstIndex + '" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '" ><td><button class="button color_red" id="kpiTable_' + firstIndex + '_removeSubKpi_' + secondIndex + '" type="button" onclick="deleteSubKpi(this.id)" >X</button> Sub KPI</td><td><select class="W240" type="text" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_kpi" ></select></td><td><input class="W90" placeholder="Weightage" value="' + subKpiValue.WEIGHTAGE + '" type="number" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_subKpiWeightage" /></td><td></td><td class="W205"><div style="float:right"><button class="button" style="margin-right: 5px;" id="addKpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition" type="button" onclick="generateSubKpiCondition(this.id)">Add Condition</button></div></td></tr>';

                        $('#kpiTable_' + firstIndex).append(subKpiDirective);

                        //Sub KPI dropdown bind
                        for (i = 0; i < subKpiDropdown.length; i++) {
                            if (subKpiDropdown[i].ParentKpiId == kpiValue.KPI_ID) {
                                //Selected Value
                                if (subKpiValue.KPI_ID == subKpiDropdown[i].Kpi_id) {
                                    var data = "<option value=" + subKpiDropdown[i].Kpi_id + " selected>" + subKpiDropdown[i].Kpi_Name + "</option>"
                                    //   $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex).append(data);
                                    $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_kpi').append(data);
                                } else {
                                    var data = "<option value=" + subKpiDropdown[i].Kpi_id + ">" + subKpiDropdown[i].Kpi_Name + "</option>"
                                    //  $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex).append(data);
                                    $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_kpi').append(data);
                                    
                                }
                            }
                        }
                        $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_kpi').attr("disabled",true);
                        // secondIndex = 0;
                        thirdIndex = 0;
                        //Bind subKPI Conditon DATA
                        $.each(condition, function () {
                            var conditionValue = this;
                            if (subKpiValue.KPI_CONFIG_ID == conditionValue.KPI_CONFIG_ID) {
                                //secondIndex += 1;
                                thirdIndex += 1;
                                //  var conditionDirective = '<tr class="kpiCondition_' + firstIndex + '" id="kpi_' + firstIndex + '_subKpi_' + firstIndex + '_condition_' + secondIndex + '"><td><button class="button" id="kpiTable_' + firstIndex + '_removeCondition_' + secondIndex + '" type="button" onclick="deleteKpiCondition(this.id)">X</button></td><td></td><td></td><td><select style="width:200px" type="text" id="kpiTable_' + firstIndex + '_condition_' + secondIndex + '"' + ' ></select></td><td></td></tr>';
                               // var conditionDirective = '<tr class="kpi_' + firstIndex + '_subKpiCondition_' + secondIndex + '" id = "kpi_' + firstIndex + '_subKpi_' + secondIndex + '_condition_' + thirdIndex + '"><td><button class="button color_red" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_removeCondition_' + thirdIndex + '" type="button" onclick="deleteSubKpiCondition(this.id)" >X</button></td><td></td><td></td><td><select class="W340" type="text" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '"' + ' ></select></td><td></td></tr>';
                                var conditionDirective = '<tr class="kpi_' + firstIndex + '_subKpiCondition_' + secondIndex + '" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '"><td><button class="button color_red" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_removeCondition_' + thirdIndex + '" type="button" onclick="deleteSubKpiCondition(this.id)" >X</button> Condition</td><td><select class="W240"  type="text" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '_condition" ></select></td><td colspan="3"></td></tr>';

                                $('#kpiTable_' + firstIndex).append(conditionDirective);

                                //subKPI dropdown bind
                                for (i = 0; i < conditionDropdown.length; i++) {
                                    if (conditionDropdown[i].SubKpi_id == subKpiValue.KPI_ID) {
                                        var data = "<option value=" + conditionDropdown[i].Condition_id + ">" + conditionDropdown[i].Condition_Name + "</option>"
                                        // $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex).append(data);
                                        $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '_condition').append(data);
                                    }
                                }
                                //subKPI selected value
                                //$('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex).val(conditionValue.CONDITION_ID);
                                $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '_condition').val(conditionValue.CONDITION_ID);
                              //  $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '_condition').attr("disabled",true);
                            }

                        })
                    }
                });

                secondIndex = 0;
                //Bind MainKPI Conditon DATA
                $.each(condition, function () {
                    var conditionValue = this;
                    if (kpiValue.KPI_CONFIG_ID == conditionValue.KPI_CONFIG_ID) {
                        secondIndex += 1;
                       // var conditionDirective = '<tr class="kpiCondition_' + firstIndex + '" id="kpi_' + firstIndex + '_condition_' + secondIndex + '"><td><button class="button color_red" id="kpiTable_' + firstIndex + '_removeCondition_' + secondIndex + '" type="button" onclick="deleteKpiCondition(this.id)">X</button></td><td></td><td></td><td><select class="W340" type="text" id="kpiTable_' + firstIndex + '_condition_' + secondIndex + '"' + ' ></select></td><td></td></tr>';
                        var conditionDirective = '<tr class="kpiCondition_' + firstIndex + '" id="kpi_' + firstIndex + '_condition_' + secondIndex + '"><td><button class="button color_red" id="kpiTable_' + firstIndex + '_removeCondition_' + secondIndex + '" type="button" onclick="deleteKpiCondition(this.id)" >X</button> Condition</td><td><select class="W240"  type="text" id="kpiTable_' + firstIndex + '_condition_' + secondIndex + '_condition"' + ' ></select></td><td colspan="3"></td></tr>';

                        $('#kpiTable_' + firstIndex).append(conditionDirective);

                        //Main KPI dropdown bind
                        for (i = 0; i < conditionDropdown.length; i++) {
                            if (conditionDropdown[i].Kpi_id == kpiValue.KPI_ID) {
                                var data = "<option value=" + conditionDropdown[i].Condition_id + ">" + conditionDropdown[i].Condition_Name + "</option>"
                                // $('#kpiTable_' + firstIndex + '_condition_' + secondIndex).append(data);
                                $('#kpiTable_' + firstIndex + '_condition_' + secondIndex + '_condition').append(data);
                              
                            }
                        }
                        //Sub kpi selected value
                        // $('#kpiTable_' + firstIndex + '_condition_' + secondIndex).val(conditionValue.CONDITION_ID);
                        $('#kpiTable_' + firstIndex + '_condition_' + secondIndex + '_condition').val(conditionValue.CONDITION_ID);
                       // $('#kpiTable_' + firstIndex + '_condition_' + secondIndex + '_condition').attr("disabled",true);
                    }

                })
            });
        }
        //Load KPI Data End

        //Button Event Start
        function generateSubKpi(id) {
            var firstIndex = id.substring(12, 13);
            var numberIdArray = [];
            var secondIndex;
            if ($('.kpiSubKpi_' + firstIndex).length == 0) {
                var secondIndex = 1;
            }
            else {
                var ids = $('.kpiSubKpi_' + firstIndex).map(function () {
                    var numberId = this.id.substring(this.id.lastIndexOf('_') + 1, this.id.length + 1);
                    numberIdArray.push(parseInt(numberId));
                    return this.id;
                }).get();
                secondIndex = Math.max.apply(Math, numberIdArray) + 1;
            }

            var subKpiDirective = '<tr class="kpiSubKpi_' + firstIndex + '" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '" ><td><button class="button color_red" id="kpiTable_' + firstIndex + '_removeSubKpi_' + secondIndex + '" type="button" onclick="deleteSubKpi(this.id)" >X</button>  Sub KPI</td><td><select class="W240" type="text" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_kpi" ></select></td><td><input class="W90" placeholder="Weightage" type="number" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_subKpiWeightage" /></td><td></td><td class="W205"><div style="float:right"><button class="button" style="margin-right: 5px;" id="addKpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition" type="button" onclick="generateSubKpiCondition(this.id)">Add Condition</button></div></td></tr>';
            $('#kpiTable_' + firstIndex).append(subKpiDirective);
         
            loadSubKPIbyKPI('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_kpi');
            hideCondition(firstIndex, secondIndex);
            $(".kpi_fields_wrap").scrollTop(350);
        }
     
        function generateKpiCondition(id) {
            var firstIndex = id.substring(12, 13);
            var numberIdArray = [];
            var secondIndex;
            if ( $('.kpiCondition_' + firstIndex).length == 0) {
                var secondIndex = 1;
            }
            else {
                var ids = $('.kpiCondition_' + firstIndex).map(function () {
                    var numberId = this.id.substring(this.id.lastIndexOf('_') + 1, this.id.length + 1);
                    numberIdArray.push(parseInt(numberId));
                    return this.id;
                }).get();
                secondIndex = Math.max.apply(Math, numberIdArray) + 1;
            }

            var conditionDirective = '<tr class="kpiCondition_' + firstIndex + '" id="kpi_' + firstIndex + '_condition_' + secondIndex + '"><td><button class="button color_red" id="kpiTable_' + firstIndex + '_removeCondition_' + secondIndex + '" type="button" onclick="deleteKpiCondition(this.id)" >X</button> Condition</td><td><select class="W240"  type="text" id="kpiTable_' + firstIndex + '_condition_' + secondIndex + '_condition"' + ' ></select></td><td colspan="3"></td></tr>';

            $('#kpiTable_' + firstIndex).append(conditionDirective);
            var selectedKPI =   $('#kpiTable_' + firstIndex + '_kpi').val();
            hideSubKPI(firstIndex, secondIndex);
            var parentTr = $('#'+ id).parent().parent().parent()[0];
            loadConditionbySubKPI('#kpiTable_' + firstIndex + '_condition_' + secondIndex + '_condition',selectedKPI,parentTr);
        }
        function generateSubKpiCondition(id) {
            var firstIndex = id.substring(12, 13);

            var secondIndex = id.substring(26, 27);
            var numberIdArray = [];
            var thirdIndex;
            if ($('.kpi_' + firstIndex + '_subKpiCondition_' + secondIndex).length == 0) {
                thirdIndex = 1;
            }
            else
            {
                var ids = $('.kpi_' + firstIndex + '_subKpiCondition_' + secondIndex).map(function () {
                    var numberId = this.id.substring(this.id.lastIndexOf('_') + 1, this.id.length + 1);
                    numberIdArray.push(parseInt(numberId));
                    return this.id;
                }).get();
                thirdIndex = Math.max.apply(Math, numberIdArray) + 1;
            }
            var conditionDirective = '<tr class="kpi_' + firstIndex + '_subKpiCondition_' + secondIndex + '" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '"><td><button class="button color_red" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_removeCondition_' + thirdIndex + '" type="button" onclick="deleteSubKpiCondition(this.id)" >X</button> Condition</td><td><select class="W240"  type="text" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '_condition" ></select></td><td colspan="3"></td></tr>';
          
            $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex ).after(conditionDirective);
          
            var selectedKPI =   $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_kpi').val();
            hideSubKPI(firstIndex, secondIndex);
            var parentTr = $('#'+ id).parent().parent().parent()[0];
            loadConditionbySubKPI('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '_condition',selectedKPI,parentTr);
            // $(".kpi_fields_wrap").scrollTop(350);
        }
        function hideCondition(firstIndex, secondIndex) {
            if ($('#kpiTable_' + firstIndex + '_condition_' + secondIndex).length == 0) {
                $('#addKpiTable_' + firstIndex + '_condition').hide();
            }
        }
        function hideSubKPI(firstIndex, secondIndex) {
            
            //if ($('#kpiTable_' + firstIndex + '_subKpi_' + secondIndex).length == 0) {
            //    $('#addKpiTable_' + firstIndex + '_subKpi').hide();
            //}
            if ($('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex).length == 0) {
                $('#addKpiTable_' + firstIndex + '_subKpi').hide();
            }
        }
        function deleteSubKpi(id) {
            var firstIndex = id.substring(9, 10);

            var secondIndex = id.substring(24, 25);
            
            var kpiId =id.substring(0, 10);
            $("#"+kpiId+"_kpi").attr("disabled",false);

            $('#' + id).parent().parent().remove();
            $(".kpi_" + firstIndex + "_subKpiCondition_" + secondIndex).remove();
            if ($('.kpiSubKpi_' + firstIndex).length == 0) {
                $('#addKpiTable_' + firstIndex + '_condition').show();
            }
        }
        function removeKpi(id) {
            $('#' + id).parent().parent().parent().parent().remove();
        }
        function deleteKpiCondition(id) {
            var kpiId =id.substring(0, 10);
            $("#"+kpiId+"_kpi").attr("disabled",false);

            var firstIndex = id.substring(9, 10); //kpiTable_1_removeCondition_1
            $('#' + id).parent().parent().remove();
            if ($('.kpiCondition_' + firstIndex).length == 0) {
                $('#addKpiTable_' + firstIndex + '_subKpi').show();
            }
        }
        function deleteSubKpiCondition(id) {
            var kpiId =id.substring(0, 24);
            $("#"+kpiId+"_kpi").attr("disabled",false);
            $('#' + id).parent().parent().remove();
        }
        //Button Event End

        //cascade Dropdown Function Start
        function loadKPIBySalesGroup(id) {
            var rCycleId = getParameterByName("reportCycleId");
            var ReportId = parseInt(rCycleId);
            var Data = JSON.stringify({ ReportCycleId: ReportId });

            $.ajax({
                url: "KPIUpdate.aspx/GETKPIBYReportCycleId",
                data: Data,
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (mydata) {
                    $.each(mydata.d, function () {
                        $(id).append("<option value=" + this.Kpi_id + ">" + this.Kpi_Name + "</option>");
                    });
                }
            });
        }
        function loadSubKPIbyKPI(id) {
            var htmlId = id;
            var id = id.substring(0, 12);
            var kpiId = id + "kpi"
            var selectKpi = $(kpiId).val();
            var Data = JSON.stringify({ KPIId: selectKpi });

            $.ajax({
                url: "KpiConfigure.aspx/GETKPIBySubKpiId",
                data: Data,
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (mydata) {
                    if (mydata.d.length > 0) {
                        $(kpiId).attr('disabled',true);
                        $.each(mydata.d, function () {
                            $(htmlId).append("<option value=" + this.Kpi_id + ">" + this.Kpi_Name + "</option>");
                        });
                    }
                    else {
                        $(htmlId).parent().parent().remove();
                        // hideSubKPI();
                        alert($(selectKpi + " option:selected").text() + " has no Sub KPI!");
                    }
                }
            });
        }
        function loadConditionbySubKPI(id,selectKpi,ParentTr) {
            var htmlId = id;
            var Data = JSON.stringify({ KPIId: selectKpi });

            $.ajax({
                url: "KpiConfigure.aspx/GETConditionByKpiId",
                data: Data,
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (mydata) {
                    if (mydata.d.length > 0) {
                        var dropdownId = ParentTr.children[1].children[0].id;
                        $('#'+dropdownId).attr('disabled',true);
                        $.each(mydata.d, function () {
                            $(htmlId).append("<option value=" + this.Condition_id + ">" + this.Condition_Name + "</option>");
                        });
                    }
                    else {
                        $(htmlId).parent().parent().remove();
                        alert($(htmlId + " option:selected").text() + " has no Condition!");
                        hideCondition();
                    }
                }
            });
        }
       
        //cascade Dropdown Function End
        function getParameterByName(name, url) {
            if (!url) url = window.location.href;
            name = name.replace(/[\[\]]/g, '\\$&');
            var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
                results = regex.exec(url);
            if (!results) return null;
            if (!results[2]) return '';
            return decodeURIComponent(results[2].replace(/\+/g, ' '));
        }
    </script>
</asp:Content>


