<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="KPIUpdate.aspx.cs" Inherits="KPIUpdate" Culture="en-GB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .color_red {
            background-color: red !important;
        }
          .color_green {
            /*background-color: lightgreen !important;*/
            margin: 7px;
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
            margin-top: 5px;
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
            width: 70%;
        }
          .subKpiDropdown {
          width: 95% !important;
          float:right;
        }
        .conditionDropdown {
          width: 90% !important;
          float:right;
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

           /*modal*/
        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            /*overflow: auto;*/ /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }

        /* Modal Content */
        .modal-content {
            background-color: #fefefe;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 700px;
        }

        /* The Close Button */
        .close {
            color: #aaaaaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }

            .close:hover,
            .close:focus {
                color: #000;
                text-decoration: none;
                cursor: pointer;
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
                <div class="hideClass" style="text-align: right; float: right; margin-right: 29px">
                        <input type="button" value="Disable KPI/Sub KPI/Condition" alt="DisableKPISubKPICondition.aspx?keepThis=false&TB_iframe=true&height=600&width=900"
                            class="thickbox" title="New KPI" />
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
                        <button style="margin-left: 28px" id="add_kpi" class="add_more_kpi button" type="button">Add KPI</button>
                        <button style="float: right; margin-right: 28px" id="Submit" onclick="NewKPIConfigure()" class="button" type="button">Save</button>
                    </div>
                </div>
              

                <div id="myModal" class="modal">
                    <!-- Modal content -->
                    <div class="modal-content">
                        <input type="text" name="name" value="12" id="tKPIId" hidden />
                        <input type="text" name="name" value="12" id="tValueId" hidden />
                        <span class="close">&times;</span>
                        <h2>Incentive Payout Setting</h2>
                        <table class="Header">
                            <thead>
                                <tr>
                                    <th style="width: 60px">Operator</th>
                                    <th style="width: 60px">Threshold</th>
                                    <th style="width: 5px">/</th>
                                    <th style="width: 60px">Amount</th>
                                    <th style="width: 50px">At Actual</th>
                                    <th style="width: 100px">Payout Ratio per 1%</th>
                                    <th style="width: 80px">Linear Payout</th>
                                    <th style="width: 40px">Action</th>
                                </tr>
                            </thead>
                            <tbody id="IncentiveTbody">
                                <tr>
                                    <td>
                                        <center>
                                            <select class="tOperator" onchange ="chOperator(event,this)">
                                                <option value="=">=</option>
                                                <option value="<"><</option>
                                                <option value="<="><=</option>
                                                <option value=">">></option>
                                                <option value=">=">>=</option>
                                            </select>
                                        </center>
                                    </td>
                                    <td>
                                        <center>
                                            <input class="tThreshold" style="width: 50px" type="number" />
                                        </center>
                                    </td>
                                    <td><label class="tRelationOperator">=</label></td>
                                    <td>
                                        <center>
                                            <input class="tAmount" style="width: 50px" type="number" />
                                        </center>
                                    </td>
                                    <td>
                                        <input class="tAtActual" onclick="atActual(event,this)" type="checkbox" name="At Actual" value="Y" />
                                    </td>
                                    <td>
                                        <center>
                                            <input class="tRatioAmount" style="width: 50px; display: none" type="number" />
                                        </center>
                                    </td>
                                    <td>
                                        <input class="tIsLinear" onclick="isLinear(event,this)" type="checkbox" name="Is Linear" value="Y" />
                                    </td>
                                    
                                    <td>
                                        <center>
                                            <input class="color_red" onclick="$(this).parent().parent().parent().remove();" type="button" value="X" />
                                        </center>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <div style="padding-left: 10px; margin-bottom: 30px; padding-top: 5px; float: left">
                            <input class="button" type="button" onclick="IncentiveRowAdd()" value="ADD" />
                        </div>

                        <div style="padding-right: 10px; margin-bottom: 30px; padding-top: 5px; float: right">
                            <input class="button" type="button" onclick="IncentiveSave()" value="Submit" />
                        </div>
                        <div style="min-height: 20px"></div>
                    </div>
                </div>


            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <script type="text/javascript">
        function atActual(e,checkbox) {
            var amount = checkbox.parentElement.previousSibling.previousElementSibling.childNodes[1].children["0"];
            if ($(checkbox).is(':checked')) {
                amount.value = "";
                amount.style.display = "none";
            }else {
                amount.style.display = "block";
            }
        };
        function atActual2(e,checkbox) {
            var amount = checkbox.parentElement.previousElementSibling.childNodes[0].children["0"];
            if ($(checkbox).is(':checked')) {
                amount.value = "";
                amount.style.display = "none";
            }else {
                amount.style.display = "block";
            }
        };
        function chOperator(e,checkbox) {
            var selectedValue = $(checkbox).val();
            var relationOperator = checkbox.parentElement.parentElement.nextElementSibling.nextElementSibling.firstElementChild;
            var isLinear = checkbox.parentElement.parentElement.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling.childNodes[1];
            
            relationOperator.textContent = "=";
            if(isLinear.checked)
            {
                relationOperator.textContent = selectedValue;
            }  
        };

        function chOperator2(e,checkbox) {
            var selectedValue = $(checkbox).val();
            var relationOperator = checkbox.parentElement.parentElement.nextElementSibling.nextElementSibling.firstChild;
            var isLinear = checkbox.parentElement.parentElement.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling.childNodes[0];
            
            relationOperator.textContent = "=";
            if(isLinear.checked)
            {
                relationOperator.textContent = selectedValue;
            }  
        };

        function isLinear(e,checkbox) {
            var amount = checkbox.parentElement.previousSibling.previousElementSibling.childNodes[1].children["0"];
            var relationOperator = checkbox.parentElement.previousElementSibling.previousElementSibling.previousElementSibling.previousElementSibling.childNodes[0];
            var selectedOperator = checkbox.parentElement.previousElementSibling.previousElementSibling.previousElementSibling.previousElementSibling.previousElementSibling.previousElementSibling.childNodes[1].childNodes[1];
            
            if ($(checkbox).is(':checked')) {
                amount.value = "";                
                amount.style.display = "block";
                relationOperator.textContent = selectedOperator.value;
            }else {
                amount.value = "";
                amount.style.display = "none";
                relationOperator.textContent = "=";
            }
        };

        function isLinear2(e,checkbox) {
            var amount = checkbox.parentElement.previousElementSibling.childNodes[0].children["0"];
            var relationOperator = checkbox.parentElement.previousElementSibling.previousElementSibling.previousElementSibling.previousElementSibling;
            var selectedOperator = checkbox.parentElement.previousElementSibling.previousElementSibling.previousElementSibling.previousElementSibling.previousElementSibling.previousElementSibling.firstElementChild.firstElementChild;
            
            if ($(checkbox).is(':checked')) {
                amount.value = "";
                amount.style.display = "block";
                relationOperator.textContent = selectedOperator.value;
            }else {
                amount.value = "";
                amount.style.display = "none";
                relationOperator.textContent = "=";
            }
        };
        function IncentiveRowAdd() {
            $('#IncentiveTbody').append('<tr><td><center><select class="tOperator" onchange ="chOperator2(event,this)"><option value="=">=</option><option value="<"><</option><option value="<="><=</option><option value=">">></option><option value=">=">>=</option></select></center></td><td><center><input class="tThreshold" style="width: 50px" type="number" /></center></td><td><label class="tRelationOperator">=</label></td><td><center><input class="tAmount" style="width: 50px" type="number" /></center></td><td><input class="tAtActual" onclick="atActual2(event,this)"  type="checkbox" name="At Actual" value="Y" /></td><td><center><input class="tRatioAmount" style="width: 50px; display: none" type="number" /></center></td><td><input class="tIsLinear" onclick="isLinear2(event,this)" type="checkbox" name="Is Linear" value="Y" /></td><td><center><input class="color_red" OnClick="$(this).parent().parent().parent().remove();" type="button" value="X" /></center></td></tr>');
        }
        function IncentiveSave() {
            var data =  $("#IncentiveTbody")[0].children;
            var thresholdViewId = $('#tKPIId').val();
            var thresholdValue = $('#tValueId').val();
            var stringIncentive ="[";
            var stringIncentiveShow = "";
            for (var i = 0; i < data.length; i++) {
                trData = data[i];
                var Operator = $(trData).find('.tOperator option:selected').val();
                var Threshold = $(trData).find('.tThreshold').val() != "" ? $(trData).find('.tThreshold').val():"0";
                var Amount = $(trData).find('.tAmount').val() != "" ? $(trData).find('.tAmount').val():"0";               
                var RelationOperator = trData.children[2].textContent;
                var AtActual = $(trData).find('.tAtActual').is(':checked');
                var RatioAmount = $(trData).find('.tRatioAmount').val() != "" ? $(trData).find('.tRatioAmount').val():"0";
                var IsLinear = $(trData).find('.tIsLinear').is(':checked');
                stringIncentive += JSON.stringify({IOrder:i, IOperator: Operator, IThreshold: Threshold, IAmount: Amount, IAtActual:AtActual, IRatioAmount: RatioAmount, IIsLinear:IsLinear });
                if (i !=data.length-1 ) {
                    stringIncentive += ",";
                };
                //stringIncentiveShow += (i+1) +". "+ Operator +" " +Threshold+"=" + Amount +", "+ "At Actual: " + AtActual +"|| ";
                if (AtActual) {
                    stringIncentiveShow += Operator + Threshold + "=at actual";
                }else {
                    stringIncentiveShow += Operator + Threshold + RelationOperator + Amount;
                }

                if (IsLinear) {
                    stringIncentiveShow += "(L.R. per 1%: "+RatioAmount+"); ";
                }else {
                    stringIncentiveShow += "; ";
                }

                
            }
            stringIncentive +="]";
            var stringToJSON =JSON.parse(stringIncentive);
            $("#"+thresholdViewId).val(stringIncentiveShow);
            $("#"+thresholdValue).val(stringIncentive);
            modalClose();
        }
        function modalClose() {
            var modal = document.getElementById("myModal");
            modal.style.display = "none";
            $('#IncentiveTbody').find("tr:gt(0)").remove(); 
            
            var threshold = document.getElementsByClassName("tThreshold");
            var amount = document.getElementsByClassName("tAmount");
            var atActual = document.getElementsByClassName("tAtActual");
            var ratioAmount = document.getElementsByClassName("tRatioAmount");
            var isLinear = document.getElementsByClassName("tIsLinear");

            threshold[0].value = "";
            amount[0].style.display = "block";
            amount[0].value = "";
            atActual[0].checked = false;
            ratioAmount[0].style.display = "block";
            ratioAmount[0].value = "";
            isLinear[0].checked = false;
        }
        function ModalShow(id,ValueId) {
            var modal = document.getElementById("myModal");
            modal.style.display = "block";
            $('#tKPIId').val(id);
            $('#tValueId').val(ValueId);
            return false;
        }
        function modalLoad(){
            // Get the modal
            var modal = document.getElementById("myModal");

            // Get the <span> element that closes the modal
            var span = document.getElementsByClassName("close")[0];
           
            // When the user clicks on <span> (x), close the modal
            span.onclick = function() {
                modalClose();
            }

            // When the user clicks anywhere outside of the modal, close it
            window.onclick = function(event) {
                if (event.target == modal) {
                    modal.style.display = "none";
                    $(".tThreshold").val(null);
                }
            }}
        ///--------------------Data----------------------
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
            modalLoad();
            $('#add_kpi').click(function (e) {
                e.preventDefault();
                var firstIndex = getLastInsertedIndex('.kpi_fields_wrap table',9);

                $('.kpi_fields_wrap').append('<table style="margin: auto;" class="contenttext W95" id="kpiTable_' + firstIndex + '"><tr><td class="W100"><button class="button color_red" id="kpiTable_' + firstIndex + '_kpiRemove"  type="button" onclick="removeKpi(this.id)"  >X</button>  KPI</td><td class="W250"><select class="W240" type="text" id="kpiTable_' + firstIndex + '_kpi"></select></td><td class="W100" ><input class="W90"  placeholder="Weightage" type="number" id="kpiTable_' + firstIndex + '_kpiWeightageKpi"/></td><td class="W350"><input class="W340" readonly placeholder="Threshold" type="text" id="kpiTable_' + firstIndex + '_incentivePayoutKpi" /><button type="button" class="button color_green" onClick=ModalShow("kpiTable_' + firstIndex + '_incentivePayoutKpi","kpiTable_' + firstIndex + '_incentivePayoutKpi_Modal")>Configure</button><input hidden class="W340" placeholder="Threshold" type="text" id="kpiTable_' + firstIndex + '_incentivePayoutKpi_Modal" /></td><td class="W205"><div style="float:right"><button style="margin-right: 5px;" id ="addKpiTable_' + firstIndex + '_subKpi" type="button" class="button" onclick="generateSubKpi(this.id)" >Add Sub KPI</button><button id="addKpiTable_' + firstIndex + '_condition" class="button" type="button" onclick="generateKpiCondition(this.id)">Add Condition</button></div></td></tr></<table>');
                loadKPIBySalesGroup('#kpiTable_' + firstIndex + '_kpi');
                // $(".kpi_fields_wrap").scrollTop(350);
                window.scrollTo(0,document.body.scrollHeight);
            });
        });
       
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
                var incentivePayoutJson = ids[i] + "_incentivePayoutKpi_Modal";
                var kpiWeightage = ids[i] + "_kpiWeightageKpi";

                var kpiIdValue = $("#" + kpiId).val();
                var incentivePayoutValue = $("#" + incentivePayout).val();
                var incentivePayoutJsonValue = $("#" + incentivePayoutJson).val();
                var kpiWeightageValue = $("#" + kpiWeightage).val();;

                kpiTable_id.push({ Kpi_id: kpiId, Incentive_Payout: incentivePayout,Incentive_Payout_Json: incentivePayoutJson, Weightage: kpiWeightage });
                KPI.push({ Kpi_id: kpiIdValue, Incentive_Payout: incentivePayoutValue,Incentive_Payout_Json: incentivePayoutJsonValue, Weightage: kpiWeightageValue });

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
            //console.log(KPI);
            //console.log(SubKPI);
            //console.log(Condition);
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
                var json_incentive = kpiValue.INCENTIVE_PAYOUT_JSON;
                //Bind Main KPI DATA
                $('.kpi_fields_wrap').append('<table style="margin: auto;" class="contenttext W95" id="kpiTable_' + firstIndex + '"><tr><td class="W100"><button class="button color_red" id="kpiTable_' + firstIndex + '_kpiRemove"  type="button" onclick="removeKpi(this.id)"  >X</button>  KPI</td><td class="W250"><select class="W240" type="text" id="kpiTable_' + firstIndex + '_kpi"></select></td><td class="W100" ><input class="W90"  placeholder="Weightage" value="' + kpiValue.WEIGHTAGE + '" type="number" id="kpiTable_' + firstIndex + '_kpiWeightageKpi"/></td><td class="W350"><input class="W340" placeholder="Threshold" type="text" readonly value="' + kpiValue.INCENTIVE_PAYOUT + '" id="kpiTable_' + firstIndex + '_incentivePayoutKpi" /><button type="button" class="button color_green" onClick=ModalShow("kpiTable_' + firstIndex + '_incentivePayoutKpi","kpiTable_' + firstIndex + '_incentivePayoutKpi_Modal")>Configure</button><input hidden class="W340"  value="'+ json_incentive +'" placeholder="Threshold" type="text" id="kpiTable_' + firstIndex + '_incentivePayoutKpi_Modal" /> </td><td class="W205"><div style="float:right"><button style="margin-right: 5px;" id ="addKpiTable_' + firstIndex + '_subKpi" type="button" class="button" onclick="generateSubKpi(this.id)" >Add Sub KPI</button><button id="addKpiTable_' + firstIndex + '_condition" class="button" type="button" onclick="generateKpiCondition(this.id)">Add Condition</button></div></td></tr></<table>');
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

                        var subKpiDirective = '<tr class="kpiSubKpi_' + firstIndex + '" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '" ><td><button class="button color_red" id="kpiTable_' + firstIndex + '_removeSubKpi_' + secondIndex + '" type="button" onclick="deleteSubKpi(this.id)" >X</button> Sub KPI</td><td><select class="W240 subKpiDropdown" type="text" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_kpi" ></select></td><td><input class="W90" placeholder="Weightage" value="' + subKpiValue.WEIGHTAGE + '" type="number" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_subKpiWeightage" /></td><td></td><td class="W205"><div style="float:right"><button class="button" style="margin-right: 5px;" id="addKpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition" type="button" onclick="generateSubKpiCondition(this.id)">Add Condition</button></div></td></tr>';
                        $('#kpiTable_' + firstIndex).append(subKpiDirective);

                        //Sub KPI dropdown bind
                        for (i = 0; i < subKpiDropdown.length; i++) {
                            if (subKpiDropdown[i].ParentKpiId == kpiValue.KPI_ID) {
                                //Selected Value
                                if (subKpiValue.KPI_ID == subKpiDropdown[i].Kpi_id) {
                                    var data = "<option value=" + subKpiDropdown[i].Kpi_id + " selected>" + subKpiDropdown[i].Kpi_Name + "</option>"
                                    $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_kpi').append(data);
                                } else {
                                    var data = "<option value=" + subKpiDropdown[i].Kpi_id + ">" + subKpiDropdown[i].Kpi_Name + "</option>"
                                    $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_kpi').append(data);
                                    
                                }
                            }
                        }
                        var subkpiDisable = true;
                        $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_kpi').attr("disabled",subkpiDisable);
                        // secondIndex = 0;
                        thirdIndex = 0;
                        //Bind subKPI Conditon DATA
                        $.each(condition, function () {
                            thirdIndex +=1;
                            var conditionValue = this;
                            if (subKpiValue.KPI_CONFIG_ID == conditionValue.KPI_CONFIG_ID) {
                                var conditionDirective = '<tr class="kpi_' + firstIndex + '_subKpiCondition_' + secondIndex + '" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '"><td><button class="button color_red" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_removeCondition_' + thirdIndex + '" type="button" onclick="deleteSubKpiCondition(this.id)" >X</button> Condition</td><td><select class="W240 conditionDropdown"  type="text" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '_condition" ></select></td><td colspan="3"></td></tr>';
                                $('#kpiTable_' + firstIndex).append(conditionDirective);

                                //subKPI dropdown bind
                                for (i = 0; i < conditionDropdown.length; i++) {
                                    if (conditionDropdown[i].SubKpi_id == subKpiValue.KPI_ID) {
                                        var data = "<option value=" + conditionDropdown[i].Condition_id + ">" + conditionDropdown[i].Condition_Name + "</option>"
                                        $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '_condition').append(data);
                                    }
                                }
                                //subKPI selected value
                                $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '_condition').val(conditionValue.CONDITION_ID);
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
                        var conditionDirective = '<tr class="kpiCondition_' + firstIndex + '" id="kpiTable_' + firstIndex + '_condition_' + secondIndex + '"><td><button class="button color_red" id="kpiTable_' + firstIndex + '_removeCondition_' + secondIndex + '" type="button" onclick="deleteKpiCondition(this.id)" >X</button> Condition</td><td><select class="W240 conditionDropdown"  type="text" id="kpiTable_' + firstIndex + '_condition_' + secondIndex + '_condition"' + ' ></select></td><td colspan="3"></td></tr>';
                        $('#kpiTable_' + firstIndex).append(conditionDirective);

                        //Main KPI dropdown bind
                        for (i = 0; i < conditionDropdown.length; i++) {
                            if (conditionDropdown[i].Kpi_id == kpiValue.KPI_ID) {
                                var data = "<option value=" + conditionDropdown[i].Condition_id + ">" + conditionDropdown[i].Condition_Name + "</option>"
                                $('#kpiTable_' + firstIndex + '_condition_' + secondIndex + '_condition').append(data);
                            }
                        }
                        //Sub kpi selected value
                        $('#kpiTable_' + firstIndex + '_condition_' + secondIndex + '_condition').val(conditionValue.CONDITION_ID);
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
            var subKpiDirective = '<tr class="kpiSubKpi_' + firstIndex + '" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '" ><td><button class="button color_red" id="kpiTable_' + firstIndex + '_removeSubKpi_' + secondIndex + '" type="button" onclick="deleteSubKpi(this.id)" >X</button>  Sub KPI</td><td><select class="W240 subKpiDropdown" type="text" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_kpi" ></select></td><td><input class="W90" placeholder="Weightage" type="number" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_subKpiWeightage" /></td><td></td><td class="W205"><div style="float:right"><button class="button" style="margin-right: 5px;" id="addKpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition" type="button" onclick="generateSubKpiCondition(this.id)">Add Condition</button></div></td></tr>';
            $('#kpiTable_' + firstIndex).append(subKpiDirective);
            loadSubKPIbyKPI(firstIndex,secondIndex);
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
            var conditionDirective = '<tr class="kpiCondition_' + firstIndex + '"  id="kpiTable_' + firstIndex + '_condition_' + secondIndex + '"><td><button class="button color_red" id="kpiTable_' + firstIndex + '_removeCondition_' + secondIndex + '" type="button" onclick="deleteKpiCondition(this.id)" >X</button> Condition</td><td><select class="W240 conditionDropdown"  type="text" id="kpiTable_' + firstIndex + '_condition_' + secondIndex + '_condition"' + ' ></select></td><td colspan="3"></td></tr>';

            $('#kpiTable_' + firstIndex).append(conditionDirective);
            var selectedKPI =   $('#kpiTable_' + firstIndex + '_kpi').val();
            var parentTr = $('#'+ id).parent().parent().parent()[0];
            loadConditionbySubKPI('#kpiTable_' + firstIndex + '_condition_' + secondIndex + '_condition',selectedKPI,parentTr,firstIndex,secondIndex);
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
            var conditionDirective = '<tr class="kpi_' + firstIndex + '_subKpiCondition_' + secondIndex + '" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '"><td><button class="button color_red" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_removeCondition_' + thirdIndex + '" type="button" onclick="deleteSubKpiCondition(this.id)" >X</button> Condition</td><td><select class="W240 conditionDropdown"  type="text" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '_condition" ></select></td><td colspan="3"></td></tr>';
          
            $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex ).after(conditionDirective);
          
            var selectedKPI =   $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_kpi').val();
            var parentTr = $('#'+ id).parent().parent().parent()[0];
            loadConditionbySubKPI('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '_condition',selectedKPI,parentTr,firstIndex,secondIndex);
        }
        function hideCondition(firstIndex, secondIndex) {
            if ($('#kpiTable_' + firstIndex + '_condition_' + secondIndex).length == 0) {
                $('#addKpiTable_' + firstIndex + '_condition').hide();
            }
        }
        function hideSubKPI(firstIndex, secondIndex) {
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

            var firstIndex = id.substring(9, 10); 
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
        function loadSubKPIbyKPI(fIndex,sIndex) {
            var id = '#kpiTable_' + fIndex + '_subKpiTable_' + sIndex + '_kpi'
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
                        hideCondition(fIndex, sIndex);
                    }
                    else {
                        $(htmlId).parent().parent().remove();
                        alert($("#"+kpiId + " option:selected").text() + " has no Sub KPI!");
                    }
                }
            });
        }
        function loadConditionbySubKPI(id,selectKpi,ParentTr,fIndex,sIndex) {
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
                        hideSubKPI(fIndex, sIndex);
                    }
                    else {
                        $(htmlId).parent().parent().remove();
                        alert($("#"+ParentTr.children[1].children[0].id + " option:selected").text() + " has no Condition!");
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


