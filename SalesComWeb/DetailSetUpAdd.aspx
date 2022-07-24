<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="DetailSetUpAdd.aspx.cs" Inherits="DetailSetUpAdd" %>

<%@ Register Src="~/UserControl/datetimePicker/WebUserControl.ascx" TagName="WebUserControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link href="AutoComplete/CSS/auto-complete.css" rel="stylesheet" />
    <script type="text/javascript" src="AutoComplete/Scripts/auto-complete.min.js"></script>

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

         var ReportName = [];

         function GetReportNameList() {
            // var YearData = $.trim($("#<%=ddlYear.ClientID%>").val());
             var MonthData = $.trim($("#<%=ddlCommissionCycle.ClientID%>").val());

            
             var param = JSON.stringify({month: MonthData });

             $.ajax({
                 type: "POST",
                 contentType: "application/json; charset=utf-8",
                 url: "DetailSetUpAdd.aspx/GetReportName",
                 data: param,
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

         function AddTableValidation() {

             var actionLink = "<button type='button' class='btn' style='background-color: ff9933; margin-left: 5px;height: 18px !important;width: 42px;'  onclick='RemoveTableName(this)'><a class='fa fa-trash' style='font-size: 10px;font-style: normal !important;'>Delete</a></button></div>";
           
             
             var TableName = $.trim($("#<%=txtTableName.ClientID%>").val());
             var LevelName = $.trim($("#<%=txtLevelName.ClientID%>").val());

             if (TableName != "" && LevelName != "") {

                 var getLength = $(".line-item-table").find('tr').length;

                 for(var i = 0; i < getLength; i++){
                     var PreTableValue = $(".dummy_item_tableStart").children('input[name="TableInfo[' + i + '].tableStart"]').val();
                     var PreLevelValue = $(".dummy_item_levelStart").children('input[name="TableInfo[' + i + '].levelStart"]').val();

                     if ((PreTableValue == TableName) && (PreLevelValue == LevelName)) {
                         alert("Table and Level already added.");
                         return false;
                     }
                 }

              
                    var tableRow = "<tr class='dummy_row_line_item' id='deno_" + (rowSL + 1) + "'>";
                    var int = 0;
                    var status = parseInt(int);

                    tableRow = tableRow + "<td class='dummy_sl_no' style='display: none'> <span>" + (rowSL + 1) + " </span></td>";
                    tableRow = tableRow + "<td class='dummy_item_tableStart'><input type='hidden' name='TableInfo[" + (rowSL) + "].tableStart' value='" + TableName + "'> <span>" + TableName + "</span></td>";
                    tableRow = tableRow + "<td class='dummy_item_levelStart'><input type='hidden' name='TableInfo[" + (rowSL) + "].levelStart' value='" + LevelName + "'> <span>" + LevelName + "</span></td>";

                    tableRow = tableRow + "<td class='dummy_model_link'>" + actionLink + "</td>";
                    tableRow = tableRow + "</tr>";
                    $("#tblLineItemList").append(tableRow);

                    document.getElementById("<%=txtTableName.ClientID%>").value = "";
                            document.getElementById("<%=txtLevelName.ClientID%>").value = "";

                    rowSL++;
                 }
                                                                        
              else {
                 alert("Please enter table name & level name.");
             }

             return false;
         }


         function CheckTableInDB() {
             debugger;

             var getTableName = $.trim(document.getElementById("<%=txtTableName.ClientID%>").value);
            
             $.ajax({
                 type: "POST",
                 url: "DetailSetUpAdd.aspx/GetIsTableExist",
                 data: JSON.stringify({
                     table_name: getTableName
                 }),
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (data) {
                     if (data.d == true) {
                         AddTableValidation();
                         return false;
                     }
                     else {
                         alert("Table Name Not Found");
                         return false;
                     }
                     
                 },
                 error: function (result) {
                     alert('error');
                     return false;
                 }
             });
             return false;
         }


         function OperationalValidation() {
             debugger;
             var isValid = true;

             var reportName = $.trim($("#<%=txtReportName.ClientID%>").val());
             var mode = document.getElementById("<%=hdnEditMode.ClientID%>").value

             var monthName = $.trim($("#<%=ddlCommissionCycle.ClientID%>").val());


             debugger;
             if (monthName == null || monthName == "" || monthName == undefined || monthName == "0") {
                 isValid = false;
                 $("span[id$=lblMsg]").html("Please select month name.").css("color", "red");
                 return false;
             }

             if (reportName == null || reportName == "" || reportName == undefined) {
                 isValid = false;
                 $("span[id$=lblMsg]").html("Please enter report name.").css("color", "red");
                 return false;
             }

             var getLength = $(".line-item-table").find('tr').length;
             if (getLength < 2) {
                 isValid = false;
                 $("span[id$=lblMsg]").html("Please add at least one item.").css("color", "red");
                 return false;
             }

             if (isValid == true) {
                 var detailItem = [];

                 var masterItem = [];

                 var getItem = {};

                 
               
                 $(".dummy_row_line_item").each(function (index, value) {
                     var Item = {};
                     var thisRow = $(this);

                     var thistableStart = $(thisRow).find("td").children('input[name="TableInfo[' + index + '].tableStart"]').val();
                     var thislevelStart = $(thisRow).find("td").children('input[name="TableInfo[' + index + '].levelStart"]').val();

                     Item.TableName = thistableStart;
                     Item.LevelName = thislevelStart;

                     detailItem.push(Item);
    
                 })
                 var operationId = document.getElementById("<%=hdnOperationId.ClientID%>").value;

                 if (mode == "edit") {
                     getItem.Id = operationId
                     getItem.Mode = "EDIT";
                 } else {
                     getItem.Id = 0
                     getItem.Mode = "ADD";
                 }

                 getItem.ReportName = reportName;
                 getItem.CyCleId = monthName;

                 masterItem.push(getItem);

                 IsReportNameValidCheck(masterItem, detailItem);
             }

             return false;
         }


         function IsReportNameValidCheck(masterItem, detailItem) {

            
             var reportName = $.trim($("#<%=txtReportName.ClientID%>").val());


             var Data = JSON.stringify({ GetName: reportName });


             $.ajax({

                 url: "DetailSetUpAdd.aspx/IsReportNameValid",
                 data: Data,
                 type: "POST",
                 dataType: "json",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {

                     if (data.d == "SUCCESSFUL" || data.d == "SUCCE") {
                         DataSaveAjaxCall(masterItem, detailItem);
                         return false;
                     } else {
                         $("span[id$=lblMsg]").html("Please input valid report name").css("color", "red");
                         return false;
                     }
                 }
             });

         }

         function AllDataClear() {
                document.getElementById("<%=txtReportName.ClientID%>").value = "";
                $(".dummy_row_line_item").remove();
                rowSL = 0;
            }

         function DataSaveAjaxCall(masterItem, detailItem) {
             var Data = JSON.stringify({ masterItem: masterItem, detailItem: detailItem });

             $.ajax({

                 url: "DetailSetUpAdd.aspx/SaveMasterDetailData",
                 data: Data,
                 type: "POST",
                 dataType: "json",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {

                     if (data.d == "SUCCESSFUL" || data.d == "SUCCE") {
                         AllDataClear();

                         var mode = document.getElementById("<%=hdnEditMode.ClientID%>").value;
                         if (mode == "edit") {
                             $("span[id$=lblMsg]").html("<b>Detail data successfully update.</b><br>").css("color", "green");
                         } else {
                             document.getElementById("<%=btnSave.ClientID %>").disabled = false;
                             document.getElementById('<%= btnRefresh.ClientID %>').click();
                         }
                         return false;
                        
                     } else {
                         document.getElementById("<%=btnSave.ClientID %>").disabled = false;
                         $("span[id$=lblMsg]").html("<b>" + data.d + "</b><br>").css("color", "red");
                         return false;
                     }
                 }
             });
         }


         function EditModeDataEdit(mode) {

             if (mode == "edit") {

                 var tableData = $("#<%= divTableDataHtml.ClientID%>").html();
                 //console.log(tableData);

             }

         }

         function htmlDecode(string) {
             return $('<div/>').html(value).text();
         }



         function RemoveTableName(selector) {
           
             var currentrowSL = 0;
             rowSL = 0;
             $(selector).closest("td").parent("tr").remove();
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

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField runat="server" ID="hdnOperationId" />
    <asp:HiddenField runat="server" ID="hdnEditMode" />
    <asp:HiddenField runat="server" ID="hdnTableData" />
    <asp:HiddenField runat="server" ID="hdnRowId" />
    <div runat="server" id="divTableDataHtml" style="display: none;"></div>

    <asp:Button ID="btnRefresh" Style="display: none" runat="server" OnClick="btnRefresh_Click" />

    <uc2:WebUserControl ID="WebUserControl1" runat="server" />


                  <table class="contenttext" style="border: none; width: 100%;">

                      
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
                                <asp:Label ID="lblCommissionCycle" runat="server" Text="Month"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCommissionCycle" runat="server" OnSelectedIndexChanged="ddlCommissionCycle_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </td>
                        </tr>

        <tr>
            <td>
                <asp:Label ID="lblReortName" mandatory="true" runat="server" Text="Report Name"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtReportName" style="height: 25px !important; width: 400px !important;" CssClass="required" runat="server" SkinID="txtCommonSkin" placeholder="Report Name ..." ClientIDMode="Static">
                </asp:TextBox>
            </td>
        </tr>
        

        <tr>
            <td>
                <asp:Label ID="lblTableName" mandatory="true" runat="server" Text="Table Name"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTableName" style="height: 25px !important; width: 300px !important;" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeypress="return IsAlphaNumeric(event)">
                </asp:TextBox>                
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblLevelName" mandatory="true" runat="server" Text="Level Name"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLevelName" Style="height: 25px !important; width: 300px !important;" CssClass="required" runat="server" SkinID="txtCommonSkin" onkeypress="return IsAlphaNumeric(event)">
                </asp:TextBox>

            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblAddTable" runat="server" Text=" "> </asp:Label>
            </td>
            <td>
                <asp:Button ID="btnAddTable" OnClientClick="return CheckTableInDB();" Style="background-color: #FCDCC5 !important; width:140px !important;" runat="server" Text="Add Table & Level" SkinID="btnCommonSkin" />
            </td>
        </tr>
                      

    </table>

      

    <div class="col-lg-12 pb-4">
                    <div class="w-100" style="padding-top:15px !important;">
                        <div class="overflow-x-auto">
                                                       
                            <table style="width:100%" class="table display responsive nowrap table-bordered mg-b-0 bl-border line-item-table" id="tblLineItemList">
                          
                                <thead class="thead-colored">
                                    <tr>
                                        <th style="display: none">S.L.</th>
                                        <th style="width:50%;">Table Name</th>
                                        <th style="width:50%;">Level Name</th>
                                    </tr>
                                </thead>
                                <tbody runat="server" id="tbodyTable">

                                </tbody>
                                
                            </table>
                        </div>

                    </div>
                </div>

     <table class="contenttext" style="width: 100%;">
            <tr>

            <td class="tdSubmit" colspan="2">
                <asp:Button ID="btnSave" OnClientClick="return OperationalValidation();" runat="server" Text="Save" OnClick="btnSave_Click" SkinID="btnCommonSkin" />
                <%--<asp:Button ID="btnHiddenSave" runat="server" Text="Save" OnClick="btnHiddenSave_Click" SkinID="btnCommonSkin" />--%>
            </td>
        </tr>
    </table>

    <div class="msg">
        <asp:Label ID="lblMsg" runat="server">
    
        </asp:Label>
    </div>
              
  

     <script type="text/javascript">
         var rowSL = 0;
         
         $(document).ready(function () {
            
             var mode = document.getElementById("<%=hdnEditMode.ClientID%>").value;
             GetReportNameList();
            //Onload();
            
            EditModeDataEdit(mode);

            if (mode == "edit") {
                rowSL = document.getElementById("<%=hdnRowId.ClientID%>").value;
                rowSL++;
            }
        });
    </script>


</asp:Content>