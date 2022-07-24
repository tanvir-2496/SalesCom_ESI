
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="DenoCampaignDetailView.aspx.cs" Inherits="DenoCampaignDetailView" %>

<%@ Register Src="~/UserControl/datetimePicker/WebUserControl.ascx" TagName="WebUserControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

<style>

    /*.clsPercentage {
        background-color: #beb9b9;
    }*/

    .clsReadOnly {
        background-color: #beb9b9;
    }

    .clsMaxCap {
        background-color: #beb9b9;
    }

    .clsIncentive {
        background-color: #beb9b9;
    }

    .clsHitAmount {
        background-color: #beb9b9;
    }
    .table-bordered {
    border: 1px solid #dee2e6;
}

    .table-bordered th,
    .table-bordered td {
        border: 1px solid #dee2e6;
    }

    .table-bordered thead th,
    .table-bordered thead td {
        border-bottom-width: 2px;
    }

    .table .thead-colored > tr > th,
    .table .thead-colored > tr > td {
        font-weight: 500;
        color: black !important;
        border-color: rgba(255, 255, 255, 0.2);
        border-bottom-width: 0;
        border-top-width: 0;
    }

    .btn-eb-op {
        background: #F06625;
        color: #fff;
        box-shadow: 0px 4px 20px rgb(240 102 37 / 20%);
        border-radius: 10px;
        padding: 10px 25px;
        font-family: Roboto;
        font-style: normal;
        font-weight: 500;
        font-size: 15px;
        line-height: 18px;
        margin-bottom: 10px;
        transition: .3s;
        outline: none !important;
        border: none !important;
        cursor: pointer !important;
    }

        .btn-eb-op:hover {
            transition: .3s;
            background: #D64704;
            color: #fff;
        }

    .eb-border {
        border: 1px solid #f06625 !important;
        border-radius: 10px !important;
    }

    .dataTable thead tr, .line-item-table thead tr {
        background: #8E8E8E;
    }

        .dataTable thead tr th, .line-item-table thead tr th {
            color: #fff !important;
            font-size: 14px;
            padding-right: 20px;
        }

    select[readonly] {
        pointer-events: none;
    }
</style>

     <script type="text/javascript">

         function EditModeDataEdit(mode) {
             debugger;
             if (mode == "edit") {
                 $("#ContentPlaceHolder1_a1").css("display", "none");
                 $("#ContentPlaceHolder1_a2").css("display", "none");

                 document.getElementById("<%=ddlRecipientTypeId.ClientID%>").disabled = true;
                 document.getElementById("<%=ddlApprovalFlow.ClientID%>").disabled = true;
                 document.getElementById("<%=ddlModality.ClientID%>").disabled = true;

                 var modalityType = document.getElementById("<%=ddlModality.ClientID%>").value;
                 

                 if (modalityType != "" && modalityType != 0) {
                     if (modalityType == 1) {
                         $(".clsCondition").hide();
                         $(".clsSlab").show();

                         
                         var IsAchiveChecked = document.getElementById("<%=chkAchivement.ClientID%>").checked;
                         var IsHitChecked = document.getElementById("<%=chkHitTarget.ClientID%>").checked;

                         var IsHitAmountChecked = document.getElementById("<%=chkHitAmount.ClientID%>").checked;
                         var IsPlaneHitChecked =  document.getElementById("<%=chkPlaneHitAmount.ClientID%>").checked;
                         var IsMaxCapChecked = document.getElementById("<%=chkMaxCap.ClientID%>").checked;

                         var SlabData = document.getElementById("<%=hdnSlabData.ClientID%>").value;

                         $("#tblLineItemList").append(SlabData);

                         if (IsHitChecked)
                         {
                             $(".clsAchivement").show();
                            
                         }
                        
                         if (IsAchiveChecked) {
                             $(".clsAchivement").hide();
                               
                         }
                             

                 } else {
                     $(".clsSlab").hide();
                     $(".clsCondition").show();
                     if (modalityType == 2) {
                         $(".clsParticipation").hide();
                     }
                     Percentage();
                     Incentive();
                     }

                     MaxCap();
                     HitAmount();
                     if (modalityType == 2) {
                         $(".clsModalityParticipation").hide();
                     }
             } else {
                 $(".clsCondition").hide();
                 $(".clsSlab").hide();
                 }

                 document.getElementById("<%=txtCampainName.ClientID%>").readOnly = true;
                 document.getElementById("<%=txtCampainName.ClientID%>").classList.add("clsReadOnly");

                 document.getElementById("<%=ddlRecipientTypeId.ClientID%>").readOnly = true;
                 document.getElementById("<%=ddlRecipientTypeId.ClientID%>").classList.add("clsReadOnly");

                 document.getElementById("<%=ddlApprovalFlow.ClientID%>").readOnly = true;
                 document.getElementById("<%=ddlApprovalFlow.ClientID%>").classList.add("clsReadOnly");

                 document.getElementById("<%=ddlModality.ClientID%>").readOnly = true;
                 document.getElementById("<%=ddlModality.ClientID%>").classList.add("clsReadOnly");
                 

                 document.getElementById("<%=txtCampainStartDate.ClientID%>").readOnly = true;
                 document.getElementById("<%=txtCampainStartDate.ClientID%>").classList.add("clsReadOnly");

                 document.getElementById("<%=txtCampainEndDate.ClientID%>").readOnly = true;
                 document.getElementById("<%=txtCampainEndDate.ClientID%>").classList.add("clsReadOnly");

                 document.getElementById("<%=txtMaxCap.ClientID%>").readOnly = true;
                 document.getElementById("<%=txtMaxCap.ClientID%>").classList.add("clsReadOnly");

                 document.getElementById("<%=txtPercentage.ClientID%>").readOnly = true;
                 document.getElementById("<%=txtPercentage.ClientID%>").classList.add("clsReadOnly");

                 document.getElementById("<%=txtIncentive.ClientID%>").readOnly = true;
                 document.getElementById("<%=txtIncentive.ClientID%>").classList.add("clsReadOnly");

                 document.getElementById("<%=txtHitAmount.ClientID%>").readOnly = true;
                 document.getElementById("<%=txtHitAmount.ClientID%>").classList.add("clsReadOnly");

             }
         }

         function Onload() {
             $(".clsSlab").hide();
             $(".clsCondition").hide();
             $(".clsCommon").hide();
         }


      

         function DenoAddValidation() {

             var DenoAmount = document.getElementById("<%=txtAmount.ClientID%>").value;
             document.getElementById("<%=txtAmount.ClientID%>").value = "";
             var getDeno = document.getElementById("<%=txtDenoAmount.ClientID%>").value

             if (DenoAmount != "") {
                 if (getDeno != "") {

                     var isDuplicate = false;
                     var a = getDeno.split(",");

                     for (i = 0; i < a.length; i++) {

                         if (a[i] == DenoAmount) {
                             alert("Duplicate Data: " + DenoAmount);
                             isDuplicate = true;
                         }
                     }
                     if (isDuplicate == false) {
                         document.getElementById("<%=txtDenoAmount.ClientID%>").value = getDeno + "," + DenoAmount
                     }

                 } else {
                     document.getElementById("<%=txtDenoAmount.ClientID%>").value = DenoAmount;
                 }
             }

             return false;

         }

         function DenoClearValidation() {
             document.getElementById("<%=txtDenoAmount.ClientID%>").value = "";
             return false;
         }

         function AddDeno() {
           
             var actionLink = "<button type='button' class='btn' style='background-color: ff9933; margin-left: 5px;height: 18px !important;width: 42px;'  onclick='RemoveThisDenoItem(this)'><a class='fa fa-trash' style='font-size: 10px;font-style: normal !important;'>Delete</a></button></div>";
             var denoStart = document.getElementById("<%=txtSlabStart.ClientID%>").value;
             var denoEnd = document.getElementById("<%=txtSlabEnd.ClientID%>").value;
             var denoIncentive = document.getElementById("<%=txtSlabInceptive.ClientID%>").value;

             if (denoStart != "" && denoEnd != "" && denoIncentive != "") {
                 if (parseInt(denoEnd) > parseInt(denoStart)) {
                     //alert(rowSL);
                     var tableRow = "<tr class='dummy_row_line_item' id='deno_" + (rowSL + 1) + "'>";
                     tableRow = tableRow + "<td class='dummy_sl_no' style='display: none'> <span>" + (rowSL + 1) + " </span></td>";

                     tableRow = tableRow + "<td class='dummy_item_denostart'><input type='hidden' name='DenoInfo[" + (rowSL) + "].DenoStart' value='" + denoStart + "'> <span>" + denoStart + "</span></td>";
                     tableRow = tableRow + "<td class='dummy_item_denoend'><input type='hidden' name='DenoInfo[" + (rowSL) + "].DenoEnd' value='" + denoEnd + "'> <span>" + denoEnd + "</span></td>";
                     tableRow = tableRow + "<td class='dummy_item_incentive'><input type='hidden' name='DenoInfo[" + (rowSL) + "].DenoIncentive' value='" + denoIncentive + "'> <span>" + denoIncentive + "</span></td>";

                     tableRow = tableRow + "<td class='dummy_model_link'>" + actionLink + "</td>";
                     tableRow = tableRow + "</tr>";
                     $("#tblLineItemList").append(tableRow);

                     rowSL++;

                     document.getElementById("<%=txtSlabStart.ClientID%>").value = "";
                 document.getElementById("<%=txtSlabEnd.ClientID%>").value = "";
                     document.getElementById("<%=txtSlabInceptive.ClientID%>").value = "";
                 } else {
                     alert("End slab should be greater than Start slab.");
                 }

                 
             } else {
                 alert("Please enter slab range and incentive.");
             }

             return false;
         }

         function RemoveThisDenoItem(selector) {
            
             $(selector).closest("td").parent("tr").remove();
             var currentrowSL = 0;
             rowSL = 0;
             
             $(".dummy_row_line_item").each(function (index, value) {
               
                 var thisRow = $(this);
                 $(thisRow).find("td").each(function (iteration, tdItem) {

                     var lineItemRow = $(this).find("input[type='hidden']")

                     if (lineItemRow.length > 0) {

                         var nameSuffix = lineItemRow.attr('name').match(/\d+/);

                         var selectedElem = $(this).find("input[type='hidden']");
                         var oldItemName = $(selectedElem).attr('name');
                         var newItemName = oldItemName.replace('[' + nameSuffix + ']', '[' + (index) + ']');
                         $(selectedElem).attr('name', newItemName);
                     }
                 });
                 var slSelector = thisRow.find("td.dummy_sl_no").find("span");
                 slSelector.text(currentrowSL + 1);


                 if (currentrowSL == 0) {
                     currentrowSL++;
                     rowSL = currentrowSL;
                 } else {
                     currentrowSL++;
                     rowSL = currentrowSL;
                 }

               
             });
             //alert(rowSL);
         }

         

         function AllDataClear() {
             document.getElementById("<%=ddlRecipientTypeId.ClientID%>").value = 0;
             document.getElementById("<%=ddlApprovalFlow.ClientID%>").value = 0;
             document.getElementById("<%=ddlModality.ClientID%>").value = 0;
             document.getElementById("<%=txtCampainName.ClientID%>").value = "";
             document.getElementById("<%=txtCampainStartDate.ClientID%>").value = "";
             document.getElementById("<%=txtCampainEndDate.ClientID%>").value = "";
             DenoClearValidation();
             ModalityChange();
         }

         function HitTarget() {
             document.getElementById("<%=chkHitTarget.ClientID%>").checked = true;
             document.getElementById("<%=chkAchivement.ClientID%>").checked = false;
             AchivementBase(0);
         }

         function AchivementBase(getId) {

             //MaxCap related fields

             document.getElementById("<%=txtMaxCap.ClientID%>").readOnly = true;
             document.getElementById("<%=txtMaxCap.ClientID%>").value = "";
             document.getElementById("<%=txtMaxCap.ClientID%>").classList.add("clsMaxCap");
             document.getElementById("<%=chkMaxCap.ClientID%>").checked = false;
             //HitAmount related fields

             document.getElementById("<%=txtHitAmount.ClientID%>").readOnly = true;
             document.getElementById("<%=txtHitAmount.ClientID%>").value = "";
             document.getElementById("<%=txtHitAmount.ClientID%>").classList.add("clsHitAmount");
             document.getElementById("<%=chkHitAmount.ClientID%>").checked = false;

             //Plane HitAmount related fields

             document.getElementById("<%=chkPlaneHitAmount.ClientID%>").checked = false;

             if (getId == 1) {
                 $(".clsAchivement").hide();

             } else {
                 $(".clsAchivement").show();
             }
         }
         function HitAchivement() {

                 document.getElementById("<%=chkAchivement.ClientID%>").checked = true;
                 document.getElementById("<%=chkHitTarget.ClientID%>").checked = false;
                 AchivementBase(1);
         }

         function CleanData() {
             $(".clsCommon").hide();


             //Slab related fields
             document.getElementById("<%=txtSlabStart.ClientID%>").value = "";
             document.getElementById("<%=txtSlabEnd.ClientID%>").value = "";
             document.getElementById("<%=txtSlabInceptive.ClientID%>").value = "";

             $(".dummy_row_line_item").remove();

             document.getElementById("<%=chkHitTarget.ClientID%>").checked = false;
             document.getElementById("<%=chkAchivement.ClientID%>").checked = false;


             //Percentage related fields

             document.getElementById("<%=txtPercentage.ClientID%>").readOnly = false;
             document.getElementById("<%=txtPercentage.ClientID%>").value = "100";
            

             //MaxCap related fields

             document.getElementById("<%=txtMaxCap.ClientID%>").readOnly = true;
             document.getElementById("<%=txtMaxCap.ClientID%>").value = "";
             document.getElementById("<%=txtMaxCap.ClientID%>").classList.add("clsMaxCap");
             document.getElementById("<%=chkMaxCap.ClientID%>").checked = false;


             //Incentive related fields

             document.getElementById("<%=txtIncentive.ClientID%>").readOnly = true;
             document.getElementById("<%=txtIncentive.ClientID%>").value = "";
             document.getElementById("<%=txtIncentive.ClientID%>").classList.add("clsIncentive");
             document.getElementById("<%=chkIncentive.ClientID%>").checked = false;


             //HitAmount related fields

             document.getElementById("<%=txtHitAmount.ClientID%>").readOnly = true;
             document.getElementById("<%=txtHitAmount.ClientID%>").value = "";
             document.getElementById("<%=txtHitAmount.ClientID%>").classList.add("clsHitAmount");
             document.getElementById("<%=chkHitAmount.ClientID%>").checked = false;

             document.getElementById("<%=chkPlaneHitAmount.ClientID%>").checked = false;


         }

         function Percentage() {

             document.getElementById("<%=chkPercentage.ClientID%>").checked = true;
             document.getElementById("<%=txtPercentage.ClientID%>").readOnly = false;
         

         }

         function Incentive() {
             document.getElementById("<%=chkIncentive.ClientID%>").checked = true;
            
                 $(".rclsIncentive").show();
                 document.getElementById("<%=txtIncentive.ClientID%>").readOnly = false;
                 document.getElementById("<%=txtIncentive.ClientID%>").classList.remove("clsIncentive");


         }


         function MaxCap() {

             var isChecked = document.getElementById("<%=chkMaxCap.ClientID%>").checked;

             if (isChecked == true) {
                 $(".rclsMaxCap").show();
                 document.getElementById("<%=txtMaxCap.ClientID%>").readOnly = false;
                 document.getElementById("<%=txtMaxCap.ClientID%>").classList.remove("clsMaxCap");
             } else {
                 $(".rclsMaxCap").hide();
                 document.getElementById("<%=txtMaxCap.ClientID%>").readOnly = true;
                 document.getElementById("<%=txtMaxCap.ClientID%>").value = "";
                 document.getElementById("<%=txtMaxCap.ClientID%>").classList.add("clsMaxCap");
             }

         }

         function OverHitAmount() {
             var isChecked = document.getElementById("<%=chkHitAmount.ClientID%>").checked;
             if (isChecked) {
                 document.getElementById("<%=chkPlaneHitAmount.ClientID%>").checked = false;
             }
             
             HitAmount();
         }
         function PlaneHitAmount() {

             var isChecked = document.getElementById("<%=chkPlaneHitAmount.ClientID%>").checked;
             if (isChecked) {
                 document.getElementById("<%=chkHitAmount.ClientID%>").checked = false;
             }
             HitAmount();
             
         }


         function HitAmount() {

             var isChecked = document.getElementById("<%=chkHitAmount.ClientID%>").checked;
             var isPlaneChecked = document.getElementById("<%=chkPlaneHitAmount.ClientID%>").checked;

             if (isPlaneChecked) {
                 $(".clsPlaneIncentiveHit").hide();
                 $(".clsPlaneMaxHit").hide();
                 document.getElementById("<%=txtIncentive.ClientID%>").value = "";
                 document.getElementById("<%=txtMaxCap.ClientID%>").readOnly = true;
                 document.getElementById("<%=txtMaxCap.ClientID%>").value = "";
                 document.getElementById("<%=txtMaxCap.ClientID%>").classList.add("clsMaxCap");
                 document.getElementById("<%=chkMaxCap.ClientID%>").checked = false;
             } else {
                 var modality = document.getElementById("<%=ddlModality.ClientID%>").value;

                
                 $(".clsPlaneMaxHit").show();
                 if (modality != "1") {
                     $(".clsPlaneIncentiveHit").show();
                 } 
                 
             }
            

             if (isChecked == true || isPlaneChecked == true) {
                 $(".rclsHitAmount").show();
                 document.getElementById("<%=txtHitAmount.ClientID%>").readOnly = false;
                 document.getElementById("<%=txtHitAmount.ClientID%>").classList.remove("clsHitAmount");
             } else {
                 $(".rclsHitAmount").hide();
                 document.getElementById("<%=txtHitAmount.ClientID%>").readOnly = true;
                 document.getElementById("<%=txtHitAmount.ClientID%>").value = "";
                 document.getElementById("<%=txtHitAmount.ClientID%>").classList.add("clsHitAmount");
             }

         }

         function RemoveCSS() {
             document.getElementById("<%=lblMsg.ClientID%>").innerHTML = "";
             $("#ContentPlaceHolder1_ddlRecipientTypeId").css('border-color', '');
             $('#ContentPlaceHolder1_txtCampainStartDate').css('border-color', '');
             $('#ContentPlaceHolder1_txtCampainName').css('border-color', '');
             $('#ContentPlaceHolder1_txtCampainEndDate').css('border-color', '');
             $('#ContentPlaceHolder1_txtAmount').css('border-color', '');
             $("#ContentPlaceHolder1_ddlModality").css('border-color', '');
         }

         function OperationalValidation() {

             var isValid = true;
             RemoveCSS();


             var recipientType = document.getElementById("<%=ddlRecipientTypeId.ClientID%>").value;
             var campainName = document.getElementById("<%=txtCampainName.ClientID%>").value;
             var startDate = document.getElementById("<%=txtCampainStartDate.ClientID%>").value;
             var endDate = document.getElementById("<%=txtCampainEndDate.ClientID%>").value;
             var getDeno = document.getElementById("<%=txtDenoAmount.ClientID%>").value;
             var modality = document.getElementById("<%=ddlModality.ClientID%>").value;
             var approvalFlow = document.getElementById("<%=ddlApprovalFlow.ClientID%>").value;

             var mode = document.getElementById("<%=hdnEditMode.ClientID%>").value

             if (mode != "edit") {

                 if (recipientType == "" || recipientType == 0) {
                     isValid = false;
                     $('#ContentPlaceHolder1_ddlRecipientTypeId').css('border-color', 'red');
                     //$("span[id$=lblMsg]").html("<b>Please select recipient type.</b><br>").css("color", "red");
                 }

                 if (approvalFlow == "" || approvalFlow == 0) {
                     isValid = false;
                     $('#ContentPlaceHolder1_ddlApprovalFlow').css('border-color', 'red');
                 }

                 if (campainName == "") {
                     isValid = false;
                     $('#ContentPlaceHolder1_txtCampainName').css('border-color', 'red');
                     //$("span[id$=lblMsg]").html("<b>Campaign start date must be minimum today and onwards.</b><br>").css("color", "red");
                 }

                 if (startDate == "") {
                     isValid = false;
                     $('#ContentPlaceHolder1_txtCampainStartDate').css('border-color', 'red');
                     //$("span[id$=lblMsg]").html("<b>Campaign start date must be minimum today and onwards.</b><br>").css("color", "red");
                 } else {
                     var status = CheckAnyValidDate(startDate);
                     if (status == false) {
                         isValid = false;
                         $('#ContentPlaceHolder1_txtCampainStartDate').css('border-color', 'red');
                         $("span[id$=lblMsg]").html("<b>Please enter valid start date.</b><br>").css("color", "red");
                         return false;
                     } else {
                         var cValid = IsStartDateValid(startDate);

                         if (cValid == false) {
                             return false;
                         }
                     }
                 }

                 if (endDate == "") {
                     isValid = false;
                     $('#ContentPlaceHolder1_txtCampainEndDate').css('border-color', 'red');
                     //$("span[id$=lblMsg]").html("<b>Campaign start date must be minimum today and onwards.</b><br>").css("color", "red");
                 } else {
                     var status = CheckAnyValidDate(endDate);
                     if (status == false) {
                         isValid = false;
                         $('#ContentPlaceHolder1_txtCampainEndDate').css('border-color', 'red');
                         $("span[id$=lblMsg]").html("<b>Please enter valid end date.</b><br>").css("color", "red");
                         return false;
                     } else {

                         var cValid = IsEndDateValid(startDate, endDate);

                         if (cValid == false) {
                             return false;
                         }
                     }
                 }

             }

             if (getDeno == "") {
                 isValid = false;
                 $('#ContentPlaceHolder1_txtAmount').css('border-color', 'red');
             }

             if (modality == "" || modality == 0) {
                 isValid = false;
                 $('#ContentPlaceHolder1_ddlModality').css('border-color', 'red');
             }



             if (isValid == false) {
                 $("span[id$=lblMsg]").html("<b>Please select all required fields.</b><br>").css("color", "red");
             } else {
                 if (modality == "1") {
                     var getLength = $(".line-item-table").find('tr').length;
                     if (getLength < 2) {
                         isValid = false;
                         $("span[id$=lblMsg]").html("<b>Please add the slab list.</b><br>").css("color", "red");
                     }
                 }
             }

             if (isValid == true) {
                 var denoItem = [];

                 var dataItem = [];

                 var getItem = {};


                 getItem.IsSlab = "False";
                 if (modality == "1") {
                     getItem.IsSlab = "True";
                     $(".dummy_row_line_item").each(function (index, value) {
                         var Item = {};
                         var thisRow = $(this);
                        

                         var thisStart = $(thisRow).find("td").children('input[name="DenoInfo[' + index + '].DenoStart"]').val();
                         var thisEnd = $(thisRow).find("td").children('input[name="DenoInfo[' + index + '].DenoEnd"]').val();
                         var thisIncentive = $(thisRow).find("td").children('input[name="DenoInfo[' + index + '].DenoIncentive"]').val();

                         Item.DenoStart = thisStart;
                         Item.DenoEnd = thisEnd;
                         Item.DenoIncentive = thisIncentive;


                         denoItem.push(Item);
                         
                     });
                 }


                 var operationId = document.getElementById("<%=hdnOperationId.ClientID%>").value;
                 var approvalFlow = document.getElementById("<%=ddlApprovalFlow.ClientID%>").value;
                 var recipientType = document.getElementById("<%=ddlRecipientTypeId.ClientID%>").value;
                 var campainName = document.getElementById("<%=txtCampainName.ClientID%>").value;
                 var startDate = document.getElementById("<%=txtCampainStartDate.ClientID%>").value;
                 var endDate = document.getElementById("<%=txtCampainEndDate.ClientID%>").value;
                 var getDeno = document.getElementById("<%=txtDenoAmount.ClientID%>").value;
                 var modality = document.getElementById("<%=ddlModality.ClientID%>").value;

                 var hitPercentageText = document.getElementById("<%=txtPercentage.ClientID%>").value;
                 var isPercentageChecked = document.getElementById("<%=chkPercentage.ClientID%>").checked;

                 var hitIncentiveText = document.getElementById("<%=txtIncentive.ClientID%>").value;
                 var isIncentiveChecked = document.getElementById("<%=chkIncentive.ClientID%>").checked;

                 var hitMaxCapText = document.getElementById("<%=txtMaxCap.ClientID%>").value;
                 var isMaxChecked = document.getElementById("<%=chkMaxCap.ClientID%>").checked;

                 var hitAmountText = document.getElementById("<%=txtHitAmount.ClientID%>").value;
                 var isHitChecked = document.getElementById("<%=chkHitAmount.ClientID%>").checked;
                 var isPlaneHitChecked = document.getElementById("<%=chkPlaneHitAmount.ClientID%>").checked;

                 if (isPlaneHitChecked)
                 {
                     hitIncentiveText = "";
                     isIncentiveChecked = false;
                 }

                 var isTargetSlab = document.getElementById("<%=chkHitTarget.ClientID%>").checked;
                 var isAchivementSlab = document.getElementById("<%=chkAchivement.ClientID%>").checked;

                 if (isPercentageChecked == true) {
                     if (hitPercentageText == "") {
                         $("span[id$=lblMsg]").html("<b>Please enter target percentage.</b><br>").css("color", "red");
                         return false;
                     }
                 }

                 if (isIncentiveChecked == true && isPlaneHitChecked == false) {
                     if (hitIncentiveText == "") {
                         $("span[id$=lblMsg]").html("<b>Please enter incentive amount.</b><br>").css("color", "red");
                         return false;
                     }
                 }

                 if (isMaxChecked == true) {
                     if (hitMaxCapText == "") {
                         $("span[id$=lblMsg]").html("<b>Please enter max cap.</b><br>").css("color", "red");
                         return false;
                     }
                 }

                 if (isHitChecked == true) {
                     if (hitAmountText == "") {
                         $("span[id$=lblMsg]").html("<b>Please enter hit amount.</b><br>").css("color", "red");
                         return false;
                     }
                 }

                 if (isPlaneHitChecked == true) {
                     if (hitAmountText == "") {
                         $("span[id$=lblMsg]").html("<b>Please enter hit amount.</b><br>").css("color", "red");
                         return false;
                     }
                 }

                 

                 if (mode == "edit") {
                     getItem.Id = operationId
                     getItem.Mode = "EDIT";
                     }else{
                     getItem.Id = 0
                     getItem.Mode = "ADD";
                 }

                 getItem.RecipientTypeId = recipientType;
                 getItem.ApprovalFlowId = approvalFlow;
                 getItem.CamPaignName = campainName;
                 getItem.CamPaignStart = startDate;
                 getItem.CamPaignEnd = endDate;
                 getItem.ModalityId = modality;
                 getItem.DenoAmount = getDeno;

                 if (isPercentageChecked == true) {
                     getItem.HitPercentage = hitPercentageText
                     getItem.IsHitPercentage = "True";
                 } else {
                     getItem.HitPercentage = "";
                     getItem.IsHitPercentage = "False";
                 }
                
                 if (isIncentiveChecked == true) {
                     getItem.IncentiveAmount = hitIncentiveText
                     getItem.IsIncentiveAmount = "True";
                 } else {
                     getItem.IncentiveAmount = "";
                     getItem.IsIncentiveAmount = "False";
                 }

                 
                 if (isMaxChecked == true) {
                     getItem.MaxCap = hitMaxCapText
                     getItem.IsMaxCap = "True";
                 } else {
                     getItem.MaxCap = "";
                     getItem.IsMaxCap = "False";
                 }

                 if (isHitChecked == true) {
                     getItem.IsOverHit = "True";
                 } else {
                     getItem.OverHit = "";
                     getItem.IsOverHit = "False";
                 }

                 if (isPlaneHitChecked == true) {
                     
                     getItem.IsHitAmount = "True";
                 } else {
                     getItem.IsHitAmount = "False";
                 }
               
                 if (isHitChecked == true || isPlaneHitChecked == true) {
                     getItem.OverHit = hitAmountText
                 } else {
                     getItem.OverHit = "";
                 }


                 if (isTargetSlab == true) {
                     getItem.IsTargetSlab = "True";
                 } else {
                     getItem.IsTargetSlab = "False";
                 }

                 if (isAchivementSlab == true) {
                     getItem.IsAchivementSlab = "True";
                 } else {
                     getItem.IsAchivementSlab = "False";
                 }

                dataItem.push(getItem);
                DataSaveAjaxCall(dataItem,denoItem);
             }

             return false;
         }

         function DataSaveAjaxCall(dataItem, denoItem) {
             var Data = JSON.stringify({ dataItem: dataItem, denoItem: denoItem });

             $.ajax({

                 url: "CampaignDenoDriveSetupAdd.aspx/GETConditionBy",
                 data: Data,
                 type: "POST",
                 dataType: "json",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                   
                     if (data.d == "SUCCESSFUL" || data.d == "SUCCE") {
                        
                         AllDataClear();
                         $("span[id$=lblMsg]").html("<b>Campaign data process successfully done.</b><br>").css("color", "green");
                         
                         return false;
                     } else {
                         $("span[id$=lblMsg]").html("<b>" + data.d + "</b><br>").css("color", "red");
                         return false;
                     }
                 }
             });
         }


         function GetCheckBoxStatus() {

             

             var sbox = Array.from(document.getElementsByName("clsCheckbox"));
             sbox.forEach(function (v) {
                 var isChecked = document.getElementById("<%=chkHitAmount.ClientID%>").checked;                 
                 var get = $(this).find('input[type="checkbox"]:checked');
                
             });
             return false;
         }


         function IsStartDateValid(startDate) {

             if (startDate != "") {
                 var dateValid = true;
             
                 var dateSeperator = "-";
                 var dateArray = new Array(5);
                 dateArray = startDate.split("-");

                 var iDate = parseInt(dateArray[0], 10);
                 var iMonth = parseInt(dateArray[1], 10);
                 var iYear = parseInt(dateArray[2], 10);

                 var currentday = new Date().getDate();         // Return the day as a number (1-31)
                 var currentmonth = new Date().getMonth() + 1;           // Return current month (1-12)
                 var currentyear = new Date().getFullYear();



                 var cStartDate = currentyear + "-" + currentmonth + "-" + currentday;
                 var getStartDate = new Date(cStartDate);

                 var cEndDate = iYear + "-" + iMonth + "-" + iDate;
                 var getEndDate = new Date(cEndDate);

                 var diffInMs = getEndDate - getStartDate;
                 var diffInDays = diffInMs / (1000 * 60 * 60 * 24);


                 //checking for future date.
                 if (diffInDays >= 0) {
                     return true;
                 } else {
                     $("span[id$=lblMsg]").html("<b>Campaign start date must be minimum today and onwards.</b><br>").css("color", "red");
                     return false;
                 }
             }
         }

         function IsEndDateValid(startDate, endDate) {

             if (startDate != "" && endDate != "") {
                 var dateValid = true;
                 var dateSeperator = "-";
                 var dateArray = new Array(5);
                 dateArray = endDate.split("-");

                 var sdateArray = new Array(5);
                 sdateArray = startDate.split("-");

                 var iDate = parseInt(dateArray[0], 10);
                 var iMonth = parseInt(dateArray[1], 10);
                 var iYear = parseInt(dateArray[2], 10);

                 var currentday = parseInt(sdateArray[0], 10);
                 var currentmonth = parseInt(sdateArray[1], 10);
                 var currentyear = parseInt(sdateArray[2], 10);

                 var cStartDate = currentyear + "-" + currentmonth + "-" + currentday;
                 var getStartDate = new Date(cStartDate);

                 var cEndDate = iYear + "-" + iMonth + "-" + iDate;
                 var getEndDate = new Date(cEndDate);

                 var diffInMs = getEndDate - getStartDate;
                 var diffInDays = diffInMs / (1000 * 60 * 60 * 24);


                 //checking for future date.
                 if (diffInDays >= 0) {

                     if (diffInDays > 30)
                     {
                         $("span[id$=lblMsg]").html("<b>Max campaign duration is 30 days.</b><br>").css("color", "red");
                         return false;
                     }
                     return true;

                 } else {
                     $("span[id$=lblMsg]").html("<b>End date must be grater or equal from start date.</b><br>").css("color", "red");
                     return false;
                 }
             }

         }

         function RecipientTypeChange() {
            
             var recipientTypeId = $.trim($("#<%=ddlRecipientTypeId.ClientID%>").val());
             var modalityTypeDDL = $("#<%=ddlModality.ClientID%>");
             var value = 0;
             var text = '[Select One]';
             if (recipientTypeId != "" && recipientTypeId != 0) {
                 modalityTypeDDL.empty();
                 modalityTypeDDL.append("<option value='" + value + "'>" + text + "</option>");
                 ModalityChange();

                 var getValue =  recipientTypeId;

                 var Data = JSON.stringify({ currentData: getValue });

                

                 $.ajax({

                     url: "CampaignDenoDriveSetupAdd.aspx/GetModalityValue",
                     data: Data,
                     type: "POST",
                     dataType: "json",
                     contentType: "application/json; charset=utf-8",
                     success: function (data) {
                  
                         $(data.d).each(function (index, item) {
                             modalityTypeDDL.append("<option value='" + item.Value + "'>" + item.Text + "</option>");
                         });
                     },
                     error: function (er) {
                         //$("span[id$=lblMsg]").html("<b>Something is Wrong!</b><br>").css("color", "red");
                     }
                 });

             }
         }

         function ModalityChange() {
             var modalityType = document.getElementById("<%=ddlModality.ClientID%>").value;
             CleanData();
             if (modalityType != "" && modalityType != 0) {
                 if (modalityType == 1) {
                     $(".clsCondition").hide();
                     document.getElementById("<%=chkHitTarget.ClientID%>").checked = true;
                     $(".clsSlab").show();
                     HitTarget();

                 } else {
                     $(".clsSlab").hide();
                     $(".clsCondition").show();
                     if (modalityType == 2) {
                         $(".clsParticipation").hide();
                     }
                     document.getElementById("<%=chkIncentive.ClientID%>").checked = true;
                     Incentive();
                 }
             } else {
                 $(".clsCondition").hide();
                 $(".clsSlab").hide();
             }
             Percentage();
         }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField runat="server" ID="hdnOperationId" />
    <asp:HiddenField runat="server" ID="hdnEditMode" />
    <asp:HiddenField runat="server" ID="hdnSlabData" />
    <asp:HiddenField runat="server" ID="hdnRowId" />


    <uc2:WebUserControl ID="WebUserControl1" runat="server" />
        <asp:UpdatePanel ID="upCycle" runat="server">
            <ContentTemplate>
                  <table class="contenttext" style="border: none; width: 100%;">

         <tr>
            <td>
                <asp:Label ID="lblChannelTypeId" runat="server" Text="Recipient Type" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlRecipientTypeId" onchange="RecipientTypeChange()" runat="server" SkinID="ddlCommonSkin" CssClass="required"></asp:DropDownList>
            </td>
         </tr>


                         <tr>
            <td>
                <asp:Label ID="lblApprovalFlow" runat="server" Text="Approval Flow" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlApprovalFlow" runat="server" SkinID="ddlCommonSkin" CssClass="required"></asp:DropDownList>
            </td>
         </tr>

        <tr>
            <td>
                <asp:Label ID="lblCampainName" mandatory="true" runat="server" Text="Campaign Name"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCampainName" style="height: 22px !important; width: 246px !important;" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeypress="return IsAlphaNumeric(event)">
                </asp:TextBox>
            </td>
        </tr>
        

        <tr>
            <td>
                <asp:Label ID="lblCampainStartDate" runat="server" Text="Campaign Start Date" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCampainStartDate" style="height: 20px !important; width: 213px !important;" runat="server" SkinID="txtDate" CssClass="date required">
                </asp:TextBox>
                <a id="a2" runat="server">
                    <img src="UserControl/datetimePicker/themes/img.gif" id="btnLetterRefDate" style="cursor: hand;"
                        align="absmiddle" onmouseover="ShowDate(this);" /></a>
            </td>
        </tr>
        <tr>

            <td>
                <asp:Label ID="lblCampainEndDate" runat="server" Text="Campaign End Date" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCampainEndDate" style="height: 20px !important; width: 213px !important;" runat="server" SkinID="txtDate" CssClass="date required">
                </asp:TextBox>
                <a id="a1" runat="server">
                    <img src="UserControl/datetimePicker/themes/img.gif" id="Img1" style="cursor: hand;"
                        align="absmiddle" onmouseover="ShowDate(this);" /></a>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblAmount" mandatory="true" runat="server" Text="Deno Amount"> </asp:Label>
            </td>
            <td>
                <asp:TextBox   ID="txtAmount" style="display:none" CssClass="required" runat="server" SkinID="txtAmount" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);">
                </asp:TextBox>
                <%--<asp:Button ID="btnDenoAmount" OnClientClick="return DenoAddValidation();" style="background-color: #FCDCC5 !important;" runat="server" Text="Add" SkinID="btnCommonSkin" />--%>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblDenoAmount" runat="server" Text=" "> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDenoAmount" ReadOnly="true" CssClass="required" disabled="true" style="background-color: #E0E0E0 !important;" runat="server" SkinID="txtDenoAmount">
                </asp:TextBox>
                <%--<asp:Button ID="Button1" OnClientClick="return DenoClearValidation();" style="background-color: #FCDCC5 !important;" runat="server" Text="Clear" SkinID="btnCommonSkin" />--%>
              </td>
        </tr>
          
                      <tr>
            <td>
                <asp:Label ID="lblModality" runat="server" Text="Modality Type" mandatory="true"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlModality" runat="server" SkinID="ddlCommonSkin" CssClass="required clsReadOnly"></asp:DropDownList>

            </td>
         </tr>

          <tr class="clsSlab">
            <td>
                <asp:Label ID="lblHitTarget" runat="server" Text="Target Base Slab"> </asp:Label><span class="rclsHitTarget clsCommon" style="color:red;">*</span>
            </td>
             <td>
                <asp:CheckBox runat="server" name="clsCheckbox" ID="chkHitTarget"  Checked="false" />
            </td>
        </tr>

        <tr class="clsSlab">
            <td>
                <asp:Label ID="lblHitAchivement" runat="server" Text="Achivement Base Slab"> </asp:Label><span class="rclsAchivement clsCommon" style="color:red;">*</span>
            </td>
             <td>
                <asp:CheckBox runat="server" name="clsCheckbox" ID="chkAchivement"  Checked="false" />
            </td>
        </tr>

            <tr class="clsCondition">
            <td>
                <asp:Label ID="lblPercentage" runat="server" Text="Target Percentage"> </asp:Label><span class="" style="color:red;">*</span>
            </td>
            <td>
                <asp:CheckBox runat="server" ReadOnly="true"  name="clsCheckbox" ID="chkPercentage"  Checked="false" /><asp:TextBox ID="txtPercentage" style="height: 22px !important; width: 125px !important;" ReadOnly="true" CssClass="required clsPercentage clsReadOnly" runat="server" SkinID="txtCommonSkin" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);">
                </asp:TextBox> %
            </td>
        </tr>

        
              <tr class="clsCondition clsPlaneIncentiveHit">
            <td>
                <asp:Label ID="lblInceptive" runat="server" Text="Incentive Amount"> </asp:Label> <span class="" style="color:red;">*</span>
            </td>
            <td>
                <asp:CheckBox runat="server" name="clsCheckbox" ReadOnly="true"   ID="chkIncentive" Checked="false" /><asp:TextBox ID="txtIncentive" style="height: 22px !important; width: 125px !important;" ReadOnly="true" CssClass="required clsIncentive clsReadOnly" runat="server" SkinID="txtCommonSkin" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);">
                </asp:TextBox>
            </td>
        </tr>

              <tr class="clsCondition clsAchivement clsParticipation clsPlaneMaxHit clsModalityParticipation">
            <td>
                <asp:Label ID="lblMaxCap" runat="server" Text="Max Cap (Target)"> </asp:Label><span class="rclsMaxCap clsCommon" style="color:red;">*</span>
            </td>
            <td>
                <asp:CheckBox runat="server" name="clsCheckbox"  ID="chkMaxCap" Checked="false" /><asp:TextBox ID="txtMaxCap" style="height: 22px !important; width: 125px !important;" ReadOnly="true" CssClass="required clsMaxCap clsReadOnly" runat="server" SkinID="txtCommonSkin" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);">
                </asp:TextBox> %
            </td>
        </tr>


        <tr class="clsCondition clsAchivement clsParticipation">
            <td>
                <asp:Label ID="lblOverHit" runat="server" Text="Is Over Hit Amount"> </asp:Label>
            </td>

            <td>
               <asp:CheckBox runat="server"  ReadOnly="true"  name="clsCheckbox" ID="chkHitAmount" Checked="false" /> 
            </td>
        </tr>

       <tr class="clsCondition clsAchivement clsParticipation">
            <td>
                <asp:Label ID="Label2" runat="server" Text="Is Hit Amount"> </asp:Label>
            </td>

            <td>
               <asp:CheckBox runat="server" ReadOnly="true"  name="clsCheckbox"  ID="chkPlaneHitAmount" Checked="false" /> 
            </td>
        </tr>

     <tr class="clsCondition clsAchivement clsParticipation">
            <td>
                <asp:Label ID="lblHitAmount" runat="server" Text="Hit Amount"> </asp:Label><span class="rclsHitAmount clsCommon" style="color:red;">*</span>
            </td>
            <td>
               <asp:TextBox ID="txtHitAmount"  style="height: 22px !important; width: 125px !important;margin-left: 20px !important;" ReadOnly="true" CssClass="required clsHitAmount clsReadOnly"  runat="server" SkinID="txtCommonSkin" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);">
                </asp:TextBox>
            </td>
        </tr>

    </table>

      

    <div class="col-lg-12 pb-4 clsSlab">
                    <div class="w-100" style="padding-top:15px !important;">
                        <div class="overflow-x-auto">
                            <table style="display:none">
                                 <tr>
                                    <td>
                                        <asp:Label ID="lblSlabStart" runat="server" Text="Slab Start"> </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSlabStart" Style="height: 22px !important; width: 50px !important;" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);">
                                        </asp:TextBox>
                                    </td>
                                      <td>
                                        <asp:Label ID="lblSlabEnd" runat="server" Text="Slab End"> </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSlabEnd" Style="height: 22px !important; width: 50px !important;" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);">
                                        </asp:TextBox>
                                    </td>
                                      <td>
                                        <asp:Label ID="lblSlabInceptive" runat="server" Text="Inceptive Amount"> </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSlabInceptive" Style="height: 22px !important; width: 50px !important;" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);">
                                        </asp:TextBox>
                                    </td>
                                     <td>
                                     <%-- <asp:Button ID="Button2" OnClientClick="return AddDeno();" style="background-color: #FCDCC5 !important;" runat="server" Text="Add" SkinID="btnCommonSkin" />--%>
                                 </td>
                                 </tr>
                            </table>



                            <table style="margin-left: auto; margin-right: auto;" class="table display responsive nowrap table-bordered mg-b-0 bl-border line-item-table" id="tblLineItemList">
                          
                                <thead class="thead-colored">
                                    <tr>
                                        <th style="display: none">S.L.</th>
                                        <th>Slab start</th>
                                        <th>Slab End</th>
                                        <th>Incentive</th>
                                    </tr>
                                </thead>
                                
                            </table>
                        </div>

                    </div>
                </div>

     <table class="contenttext" style="width: 100%;">
            <tr>

           <%-- <td class="tdSubmit" colspan="2">
                <asp:Button ID="btnSave" OnClientClick="return OperationalValidation();" runat="server" Text="Save" OnClick="btnSave_Click" SkinID="btnCommonSkin" />

            </td>--%>
        </tr>
    </table>

    <div class="msg">
        <asp:Label ID="lblMsg" runat="server">
    
        </asp:Label>
    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
  

    <script type="text/javascript">
        var rowSL = 0;
        $(document).ready(function () {
            
            var mode = document.getElementById("<%=hdnEditMode.ClientID%>").value;
            Onload();
            EditModeDataEdit(mode);

            if (mode == "edit") {
                rowSL = document.getElementById("<%=hdnRowId.ClientID%>").value;
                rowSL++;
            }
        });
    </script>

</asp:Content>

