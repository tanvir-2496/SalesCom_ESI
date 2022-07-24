<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="KpiConfigure2.aspx.cs" Inherits="SetupKpiConfigure" %>

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

            /*.hideClass {
            height: 320px;
        }*/

            /*.kpi_fields_wrap {
            height: 300px;
            overflow: auto;
        }*/

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
                <div>
                    <div class="hideClass" style="text-align: right; float: right; margin-right: 2%">
                        <input type="button" value="New KPI" alt="SetupKpiAdd.aspx?keepThis=false&TB_iframe=true&height=300&width=450"
                            class="thickbox" title="New KPI" />
                        <input type="button" value="New Sub KPI" alt="SetupSubKpiAdd.aspx?keepThis=false&TB_iframe=true&height=300&width=450"
                            class="thickbox" title="New Sub KPI" />
                        <input type="button" value="New Condition" alt="SetupConditionAdd.aspx?keepThis=false&TB_iframe=true&height=300&width=450"
                            class="thickbox" title="New Condition" />
                    </div>
                   <%-- TUQuIFJBS0lCIEhBU0FO--%>
                    <div class="hideClass" style="float: left; margin-left: 2%">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSalesGroup" SkinID="lblCommonSkin" runat="server" Text="Sales Group"> </asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSalesGroup" runat="server" SkinID="ddlCommonSkin">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <%-- //OnSelectedIndexChanged="ddl_SalesGroup_IndexChanged"--%>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSalesChannelName" SkinID="lblCommonSkin" runat="server" Text="Sales Channel"> </asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSalesChannelName" runat="server" SkinID="ddlCommonSkin">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblYear" SkinID="lblCommonSkin" runat="server" Text="Year"> </asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlYear" runat="server" SkinID="ddlCommonSkin">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblQuarter" SkinID="lblCommonSkin" runat="server" Text="Quarter"> </asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlQuarter" runat="server" SkinID="ddlCommonSkin">
                                        <asp:ListItem Text="[Select One]" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Q1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Q2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Q3" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Q4" Value="4"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblThresholdType" SkinID="lblCommonSkin" runat="server" Text="Threshold Type"> </asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlThresholdType" runat="server" SkinID="ddlCommonSkin">
                                        <asp:ListItem Text="Quarterly" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Monthly" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                            </tr>
                        </table>

                    </div>
                    <div style="text-align: center; width: 100%; padding: 10px; font-size: 20px; color: #d49800" id="successMessage"></div>
                    <%--<div style="text-align: center; padding: 10px; color: #d49700; display: none" class="showClass"><a href="KPIApproval.aspx">Approve from Here for further process.</a></div>--%>
                    <div class="SuccessDiv">
                        <div style="padding-top: 120px">
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
                        <div class="kpi_fields_wrap">
                        </div>
                        <div>
                            <button id="add_kpi" style="margin-left: 2%" class="add_more_kpi button" type="button">Add KPI</button>
                            <button style="float: right; margin-right: 2%" id="Submit" onclick="NewKPIConfigure()" class="button" type="button">Save</button>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <script type="text/javascript">
        ///--------------------Data----------------------
        var KPI = [];
        var SubKPI = [];
        var Condition = [];
        var kpiTable_id = [];
        var subKpiTable_id = [];
        var condition_id = [];
        var selectedYear = 0;
        var selectedQuarter = 0;
        var selectedSChannel = 0;
        ///---------------------------------------------
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
                maxValue = Math.max(...kpiIndex); //no error here!!
            }
            return maxValue +1;
        }

        $(document).ready(function () {
            $('#<%=ddlSalesGroup.ClientID %>').change(function(e){
                e.preventDefault();
                var sGroup = $('#<%=ddlSalesGroup.ClientID %> option:selected').val();
                if (sGroup == "0") {
                    alert("Please Select Sales Group");
                    return;
                }
                loadSalesChannelByGroup();
            })
          

            $('#add_kpi').click(function (e) {
                e.preventDefault();
                var sGroup = $('#<%=ddlSalesGroup.ClientID %> option:selected').val();
                if (sGroup == "0") {
                    alert("Please Select Sales Group");
                    return;
                }
                var firstIndex = getLastInsertedIndex('.kpi_fields_wrap table',9);

                $('.kpi_fields_wrap').append('<table style="margin: auto;" class="contenttext W95" id="kpiTable_' + firstIndex + '"><tr id="kpiTable_' + firstIndex+ '"><td class="W100"><button class="button color_red" id="kpiTable_' + firstIndex + '_kpiRemove"  type="button" onclick="removeKpi(this.id)"  >X</button>  KPI</td><td class="W250"><select class="W240" type="text" id="kpiTable_' + firstIndex + '_kpi"></select></td><td class="W100" ><input class="W90"  placeholder="Weightage" type="number" id="kpiTable_' + firstIndex + '_kpiWeightageKpi"/></td><td class="W350"><input class="W340" placeholder="Threshold" type="text" id="kpiTable_' + firstIndex + '_incentivePayoutKpi" /></td><td class="W205"><div style="float:right"><button style="margin-right: 5px;" id ="addKpiTable_' + firstIndex + '_subKpi" type="button" class="button" onclick="generateSubKpi(this.id)" >Add Sub KPI</button><button id="addKpiTable_' + firstIndex + '_condition" class="button" type="button" onclick="generateKpiCondition(this.id)">Add Condition</button></div></td></tr></<table>');
                loadKPIBySalesGroup('#kpiTable_' + firstIndex + '_kpi');
                // $(".kpi_fields_wrap").scrollTop(350);
                window.scrollTo(0,document.body.scrollHeight);
            });
        });

        //Save KPI Info Start
        function NewKPIConfigure() {

            window.scrollTo(0, 0);

            clearAllData();
            var isValid = validateKPIConfiguration();
            if (!isValid) {
                return;
            }
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
                            var subKpiId= rowIds[0].substring(0, 24);
                            var subKpiIdValue =$("#" + subKpiId+"_kpi").val();
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
            var d = { MainKPI: kpi, SubKPI: subKpi, Condition: condition, sChannelId: selectedSChannel, year: selectedYear, quarter: selectedQuarter, thresholdType: selectedThresholdType};
            var Data = Sys.Serialization.JavaScriptSerializer.serialize(d)

            $.ajax({
                url: "KpiConfigure.aspx/SaveKpiConfigurationData",
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
            if(kpi.length == 0)
            {
                str = "Add KPI to configure!!";
                alert(str);
                isValid = false;
                return;
            }
            for (var i = 0; i < kpi.length; i++) {
                var x = kpi[i];
                kpiWeightage += parseInt(x.Weightage);
                if (x.Incentive_Payout == "") {
                    isValid = false
                    msz = "Threshold can not be empty!!";
                };
                if (x.Weightage == "") {
                    isValid = false
                    msz = "Weightage can not be empty!!";
                };
                
                //subKPi weightage
                for (var j = 0; j < subKpi.length; j++) {
                    var kpiId = kpi[i].Kpi_id;
                    var subkpiId =subKpi[j].Kpi_id;
                    var kpiWeightate =kpi[i].Weightage;
                    if (kpiId = subkpiId) {
                        var subKPIWeightage = subKpi[j].Weightage;
                        if (subKPIWeightage == "") {
                            msz = "SubKPI Weightage can not be empty!!";
                            isValid = false;
                        }
                        //var totalWeightage =0;
                        //var totalWeightage =totalWeightage+ parseInt(subKPIWeightage);
                        //if (totalWeightage > parseInt(kpiWeightate)) {
                        //    msz = "SubKPI Weightage is not Valid!!";
                        //}
                    }
                }
            }
            if (kpiWeightage > 100) {
                msz = "KPI Weightage is not valid!!";
                isValid = false
            }
            if (!isValid) {
                alert(msz);
            }
            return isValid;
        };
        function validateKPIConfiguration() {
            selectedYear = $('#<%=ddlYear.ClientID %> option:selected').val();
            selectedQuarter = $('#<%=ddlQuarter.ClientID %> option:selected').val();
            selectedThresholdType = $('#<%=ddlThresholdType.ClientID %> option:selected').val();
            selectedSChannel = $('#<%=ddlSalesChannelName.ClientID %> option:selected').val();
            var isValid = true;
            var str = "";
            if (selectedSChannel <= 0) {
                str = "Please select Sales Channel!!";
                alert(str);
                isValid = false;
            } else if (selectedYear.length < 3) {
                str = "Please select Year!!";
                alert(str);
                isValid = false;
            } else if (selectedQuarter < 1) {
                str = "Please select Quarter!!";
                alert(str);
                isValid = false;
            }
            


            return isValid;
        }
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
        };
        function MessageShow(result) {
            if (parseInt(result.Type) == 1) {
                setTimeout(function(){
                    window.location.href="KPIApproval.aspx";
                    $('#successMessage').text("Redirect!!");
                }, 5000);
                $('.hideClass').hide();
                $('.SuccessDiv').hide();
                $('#successMessage').text(result.Message);
            }else {
                setTimeout(function(){
                    $('.hideClass').show(500);
                    $('#successMessage').text("");
                }, 3000);
                $('.hideClass').hide();
                $('#successMessage').text(result.Message);
            }
           
        }
        //Save KPI Info End
        //Button Click Event Start
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
            //var kpi = $('.kpi_fields_wrap table').length;
            //console.log($('#' + id));
            $('#' + id).parent().parent().parent().parent().remove();
            var table = $(".contenttext").length;
            if (table<=0) {
                $('#<%=ddlSalesGroup.ClientID %>').attr('disabled',false);
        }
    }
    function deleteKpiCondition(id) {
        var firstIndex = id.substring(9, 10); //kpiTable_1_removeCondition_1
        $('#' + id).parent().parent().remove();
        var kpiId =id.substring(0, 10);
        $("#"+kpiId+"_kpi").attr("disabled",false);
        if ($('.kpiCondition_' + firstIndex).length == 0) {
            $('#addKpiTable_' + firstIndex + '_subKpi').show();
        }
    }
    function deleteSubKpiCondition(id) {
        var kpiId =id.substring(0, 24);
        $("#"+kpiId+"_kpi").attr("disabled",false);
        $('#' + id).parent().parent().remove();
    }
    //Button Click Event End

    //DropDown Data Load Start
    function loadKPIBySalesGroup(id) {
        var sGroup = $('#<%=ddlSalesGroup.ClientID %> option:selected').val();
       if (sGroup == "0") {
           alert("Please Select Sales Group");
           return;
       }
       $('#<%=ddlSalesGroup.ClientID %>').attr('disabled',true);
            var Data = JSON.stringify({ SalesGroupId: sGroup });

            $.ajax({
                url: "KpiConfigure.aspx/GETKPIBYGROUPID",
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
        function loadSalesChannelByGroup() {
            var sGroup = $('#<%=ddlSalesGroup.ClientID %> option:selected').val();
            if (sGroup == "0") {
                alert("Please Select Sales Group");
                return;
            }
         
            var Data = JSON.stringify({ SalesGroupId: sGroup });
            $.ajax({
                url: "KpiConfigure.aspx/GETSalesChannelByGROUPID",
                data: Data,
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (mydata) {
                    $('#<%=ddlSalesChannelName.ClientID %>').empty();
                    $.each(mydata.d, function () {
                        $('#<%=ddlSalesChannelName.ClientID %>').append("<option value=" + this.Sales_Channel_Id + ">" + this.Sales_Channel_Name + "</option>");
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
                        alert($("#"+kpiId + " option:selected").text() + " has no Sub KPI!");
                    }
                }
            });
        }
        function loadConditionbySubKPI(id,selectKpi,ParentTr) {
            var htmlId = id;
            var SubKPIId = id.substring(0, 12); 
            var kpiId =  SubKPIId + "kpi";
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
                        alert($(kpiId + " option:selected").text() + " has no Condition!");
                        hideCondition();
                    }
                }
            });
        }
        //DropDown Data Load End
        
        //$(document).ready(function (){
        //    $("#Submit").click(function (){
        //        $('html, body').scrollTop( $(this).offset().top );
        //    });
        //});

    </script>
</asp:Content>

