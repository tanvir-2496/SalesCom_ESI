<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master"  AutoEventWireup="true" CodeFile="KPIView.aspx.cs" Inherits="KPIView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        /*.SubKpi 
        {
            background-color: #FFF8DC;
           
        }
        .Kpi {
            background-color:#edd679 
        }
        .Condition {
            background-color: #ded7ba;
        }*/
        .container {
        margin-top:00px;
        }
        .contenttext {
        width:1200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="leftPanel"></div>
    <div class="Content">
        <asp:UpdatePanel ID="lstpanel" runat="server">
            <ContentTemplate>

                    <div class="kpi_fields_wrap container">
                      <%--Table Insert Here--%>
                    </div>
                   
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <%--<div style="background: #cbc7c7; color: #f00; font-weight: bolder; width: 100%; height: 16px; position: fixed; left: 0; bottom: 0">
        <asp:Label ID="lblResult" runat="server" SkinID="lblErrorMsgSkin"></asp:Label>
    </div>--%>

    <script type="text/javascript">
        var KPI = [];
        var SubKPI = [];
        var Condition = [];
        var KPIDropDown = [];
        var SubKPIDropDown = [];
        var ConditionDropDown = [];
        var firstIndex = 0;
        var secondIndex = 0;
        var thirdIndex = 0;
        $(document).ready(function () {
            loadData();
        });
        function loadData() {
            var rCycleId = getParameterByName("reportCycleId");
            var ReportId = parseInt(rCycleId);
            var monthId = getParameterByName("Month");
            var month = parseInt(monthId)
            var Data = JSON.stringify({ reportCycleId: ReportId, month: month });
            $.ajax({
                url: "KPIView.aspx/GetKPIWithCondition",
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
                $('.kpi_fields_wrap').append('<table style="margin:auto" class="contenttext" id="kpiTable_' + firstIndex + '"><tr class = "Kpi"><td  style="width: 200px;"><b style="width: 150px;"   id="kpiTable_' + firstIndex + '_kpi" disabled>KPI: <i>' + kpiValue.KPI_NAME + '</i></b></td><td style="width: 300px;"><lebel disabled placeholder="Threshold" type="text"  id="kpiTable_' + firstIndex + '_incentivePayoutKpi" ><b>Threshold:</b> ' + kpiValue.INCENTIVE_PAYOUT + '</lebel></td><td><lebel placeholder="KPI Weightage"  type="text" id="kpiTable_' + firstIndex + '_kpiWeightageKpi" disabled><b>Weightage:</b> ' + kpiValue.WEIGHTAGE + '</lebel></td><td style="width: 400px;"><lebel placeholder="KPI Remarks"  type="text" id="kpiTable_' + firstIndex + '_kpiRemarksKpi" disabled><b>KPI Remarks:</b> ' + kpiValue.REMARKS + '</lebel></td></tr></<table>');

                //Bind Sub KPI DATA
                $.each(subKpi, function () {
                    var subKpiValue = this;
                    if (subKpiValue.PARENT_KPI_ID == kpiValue.KPI_ID) {
                        secondIndex += 1;
                        var subKpiDirective = '<tr style="magrin:2px" class="kpiSubKpi_' + firstIndex + ' SubKpi" id= "kpi_' + firstIndex + '_subkpi_' + secondIndex + '"><td></td><td><lebel  id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '"' + ' disabled ><b>SubKPI: </b>' + subKpiValue.KPI_NAME + '</lebel></td><td><lebel placeholder="Sub KPI Weightage"  type="text" id="kpiTable_' + firstIndex + '_subKpiWeightage_' + secondIndex + '"' + ' disabled><b>Weightage</b>(Sub KPI): ' + subKpiValue.WEIGHTAGE + '</lebel></td><td style="width: 400px;"><lebel placeholder="Sub KPI Remarks"  type="text" id="kpiTable_' + firstIndex + '_SubkpiRemarksKpi" disabled><b>KPI Remarks:</b> ' + subKpiValue.REMARKS + '</lebel></td></tr>';
                        $('#kpiTable_' + firstIndex).append(subKpiDirective);

                        ////Sub KPI dropdown bind
                        //for (i = 0; i < subKpiDropdown.length; i++) {
                        //    if (subKpiDropdown[i].ParentKpiId == kpiValue.KPI_ID) {
                        //        //Selected Value
                        //        if (subKpiValue.KPI_ID == subKpiDropdown[i].Kpi_id) {
                        //            var data = "<option value=" + subKpiDropdown[i].Kpi_id + " selected>" + subKpiDropdown[i].Kpi_Name + "</option>"
                        //            $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex).append(data);
                        //        } else {
                        //            var data = "<option value=" + subKpiDropdown[i].Kpi_id + ">" + subKpiDropdown[i].Kpi_Name + "</option>"
                        //            $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex).append(data);
                        //        }
                        //    }
                        //}
                        // secondIndex = 0;
                        thirdIndex = 0;
                        //Bind subKPI Conditon DATA
                        $.each(condition, function () {
                            var conditionValue = this;
                            if (subKpiValue.KPI_CONFIG_ID == conditionValue.KPI_CONFIG_ID) {
                               // secondIndex += 1;
                                thirdIndex += 1;
                                var conditionDirective = '<tr class="kpi_' + firstIndex + '_subKpiCondition_' + secondIndex + '" id = "kpi_' + firstIndex + '_subKpi_' + secondIndex + '_condition_' + thirdIndex + '"><td></td><td></td><td><b>Condition: </b> <lebel id ="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '_lbl"></lebel></td><td><b>Condition Remarks: </b> <lebel id ="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_conditionRemarks_' + thirdIndex + '_lbl"></lebel></td><td></td></tr>';
                             //   var conditionDirective = '<tr class="kpi_' + firstIndex + '_subKpiCondition_' + secondIndex + '" id = "kpi_' + firstIndex + '_subKpi_' + secondIndex + '_condition_' + thirdIndex + '"><td><button class="button color_red" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_removeCondition_' + thirdIndex + '" type="button" onclick="deleteSubKpiCondition(this.id)" >X</button></td><td></td><td></td><td><select class="W340" type="text" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '"' + ' ></select></td><td></td></tr>';

                              //var conditionDirective = '<tr class="kpiCondition_' + firstIndex + ' Condition" id="kpi_' + firstIndex + '_condition_' + secondIndex + '"><td></td><td></td><td><b>Condition: </b> <lebel id ="kpiTable_' + firstIndex + '_condition_' + secondIndex + '_lbl"></lebel></td></tr>';
                                $('#kpiTable_' + firstIndex).append(conditionDirective);

                                //subKPI dropdown bind
                                for (i = 0; i < conditionDropdown.length; i++) {
                                    if (conditionDropdown[i].SubKpi_id == subKpiValue.KPI_ID) {
                                      //  var data = "<option value=" + conditionDropdown[i].Condition_id + ">" + conditionDropdown[i].Condition_Name + "</option>"
                                       // $('#kpiTable_' + firstIndex + '_condition_' + secondIndex).append(data);
                                        if (conditionValue.CONDITION_ID == conditionDropdown[i].Condition_id) {
                                            $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '_lbl').text(conditionDropdown[i].Condition_Name);
                                            $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_conditionRemarks_' + thirdIndex + '_lbl').text(conditionDropdown[i].Remarks);
                                        }
                                    }
                                }
                                //<select disabled style="width:300px" type="text" id="kpiTable_' + firstIndex + '_condition_' + secondIndex + '"' + ' ></select>
                                ////subKPI selected value
                                //$('#kpiTable_' + firstIndex + '_condition_' + secondIndex).val(conditionValue.CONDITION_ID);
                                //$('#kpiTable_' + firstIndex + '_condition_' + secondIndex + '_lbl').text($('#kpiTable_' + firstIndex + '_condition_' + secondIndex + ' option:selected').text());
                                //$('#kpiTable_' + firstIndex + '_condition_' + secondIndex).hide();
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
                        var conditionDirective = '<tr class="kpiCondition_' + firstIndex + ' Condition" id="kpi_' + firstIndex + '_condition_' + secondIndex + '"><td></td><td></td><td><b>Condition: </b><lebel id ="kpiTable_' + firstIndex + '_condition_' + secondIndex + '_lbl"></lebel</td><td><b>Condition Remarks: </b><lebel id ="kpiTable_' + firstIndex + '_conditionRemarks_' + secondIndex + '_lbl"></lebel</td></tr>';
                        $('#kpiTable_' + firstIndex).append(conditionDirective);

                        //Main KPI dropdown bind
                        for (i = 0; i < conditionDropdown.length; i++) {
                            if (conditionDropdown[i].Kpi_id == kpiValue.KPI_ID) {
                                //var data = "<option value=" + conditionDropdown[i].Condition_id + ">" + conditionDropdown[i].Condition_Name + "</option>"
                                //$('#kpiTable_' + firstIndex + '_condition_' + secondIndex).append(data);
                                if (conditionValue.CONDITION_ID == conditionDropdown[i].Condition_id) {
                                    $('#kpiTable_' + firstIndex + '_condition_' + secondIndex + '_lbl').text(conditionDropdown[i].Condition_Name);
                                    $('#kpiTable_' + firstIndex + '_conditionRemarks_' + secondIndex + '_lbl').text(conditionDropdown[i].Remarks);
                                }
                            }
                        }
                        //<select disabled style="width:300px" type="text" id="kpiTable_' + firstIndex + '_condition_' + secondIndex + '"' + ' ></select>
                        //Sub kpi selected value
                       // $('#kpiTable_' + firstIndex + '_condition_' + secondIndex + 'lbl').html($('#kpiTable_' + firstIndex + '_condition_' + secondIndex + " :selected").text())
                        //$('#kpiTable_' + firstIndex + '_condition_' + secondIndex).val(conditionValue.CONDITION_ID);
                      
                        //$('#kpiTable_' + firstIndex + '_condition_' + secondIndex + '_lbl').text($('#kpiTable_' + firstIndex + '_condition_' + secondIndex + ' option:selected').text());
                        //$('#kpiTable_' + firstIndex + '_condition_' + secondIndex).hide();
                    }

                })
            });
        }
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



