<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="KPITargetReplicate.aspx.cs" Inherits="SetupKpiTarget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        /*.kpiBackColor {
            background-color: #d9d9ff;
        }

        .subKpiBackColor {
            background-color: #e6e6ff;
        }

        .conBackColor {
            background-color: #f0f0ff;
        }*/

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


        /*.W90 {
            width: 100%;
        }*/
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
            width: 100%;
        }

        .wPayout {
            width: 20px;
        }

        .subKpiDropdown {
            width: 95% !important;
            float: right;
        }

        .conditionDropdown {
            width: 90% !important;
            float: right;
        }
        /*.footertext {
            display: none;
        }*/

        .Content {
            height: auto !important;
            min-height: 456px !important;
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

        /* Popup container - can be anything you want */
        .popup {
            position: relative;
            display: inline-block;
            cursor: pointer;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            width: 65%;
        }

        /* The actual popup */
        .popuptext {
            visibility: hidden;
            min-width: 160px;
            background-color: #555;
            color: #fff;
            text-align: center;
            border-radius: 6px;
            padding: 8px 0;
            position: absolute;
            z-index: 1;
            bottom: 125%;
            left: 50%;
            margin-left: -80px;
        }

            /* Popup arrow */
            .popuptext::after {
                content: "";
                position: absolute;
                top: 100%;
                left: 50%;
                margin-left: -5px;
                border-width: 5px;
                border-style: solid;
                border-color: #555 transparent transparent transparent;
            }

        /* Toggle this class - hide and show the popup */
        .show {
            visibility: visible;
            -webkit-animation: fadeIn 1s;
            animation: fadeIn 1s;
        }

        /* Add animation (fade in the popup) */
        @-webkit-keyframes fadeIn {
            from {
                opacity: 0;
            }

            to {
                opacity: 1;
            }
        }

        @keyframes fadeIn {
            from {
                opacity: 0;
            }

            to {
                opacity: 1;
            }
        }

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="leftPanel"></div>
    <div class="Content">
        <asp:UpdatePanel ID="lstpanel" runat="server">
            <ContentTemplate>
                <div>

                    <%--TUQuIFJBS0lCIEhBU0FO--%>
                    <div class="hideClass" style="float: left; margin-left: 2%">
                        <table>

                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Sales Group" SkinID="lblCommonSkin" mandatory="true"></asp:Label>

                                    <asp:DropDownList Style="width: 200px" ID="ddlSalesGroup" runat="server" AutoPostBack="true" SkinID="ddlCommonSkin" OnSelectedIndexChanged="ddlSalesGroup_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Year" SkinID="lblCommonSkin" mandatory="true"></asp:Label>

                                    <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Year_IndexChanged" SkinID="ddlCommonSkin" CssClass="required" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblQuarter" runat="server" Text="Quarter" SkinID="lblCommonSkin" mandatory="true"></asp:Label>
                                    <asp:DropDownList onchange="quarterChange(this)" ID="ddlQuarter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Quarter_IndexChanged" SkinID="ddlCommonSkin" CssClass="required" ClientIDMode="Static">
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
                                    <asp:Label ID="lblReportName" runat="server" Text="Sales Channel" SkinID="lblCommonSkin" mandatory="true"></asp:Label>
                                    <asp:DropDownList ID="ddlReportName" runat="server" SkinID="ddlCommonSkin" CssClass="required" OnSelectedIndexChanged="ddlReportName_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblMonth" runat="server" Text="Month" SkinID="lblCommonSkin" mandatory="true"></asp:Label>
                                    <asp:DropDownList ID="ddlMonth" runat="server" SkinID="ddlCommonSkin" CssClass="required" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblKPI" runat="server" Text="KPI" SkinID="lblCommonSkin" mandatory="true"></asp:Label>
                                    <asp:DropDownList ID="ddlKPI" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_KPI_IndexChanged" SkinID="ddlCommonSkin" CssClass="required" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSubKpi" runat="server" Text="Sub KPI" SkinID="lblCommonSkin"></asp:Label>
                                    <asp:DropDownList ID="ddlSubKPI" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_SubKPI_IndexChanged" SkinID="ddlCommonSkin" CssClass="required" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCondition" runat="server" Text="Condition" SkinID="lblCommonSkin"></asp:Label>
                                    <asp:DropDownList ID="ddlCondition" runat="server" AutoPostBack="true" SkinID="ddlCommonSkin" CssClass="required" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </td>
                            </tr>

                        </table>

                    </div>
                    <div class="hideClass" style="float: right; margin-right: 30px">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCloneReportType" SkinID="lblCommonSkin" runat="server" Text="Replicate Report Type"> </asp:Label>
                                    <asp:DropDownList ID="ddlCloneReportType" runat="server" SkinID="ddlCommonSkin">
                                        <asp:ListItem Text="Arrear_1" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Arrear_2" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="Arrear_3" Value="5"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCloneSalesGroup" runat="server" Text="Replicate Sales Group" SkinID="lblCommonSkin" mandatory="true"></asp:Label>

                                    <asp:DropDownList Style="width: 200px" ID="ddlCloneSalesGroup" runat="server" AutoPostBack="true" SkinID="ddlCommonSkin" OnSelectedIndexChanged="ddlCloneSalesGroup_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCloneYear" runat="server" Text="Replicate Year" SkinID="lblCommonSkin" mandatory="true"></asp:Label>

                                    <asp:DropDownList ID="ddlCloneYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Clone_Year_IndexChanged" SkinID="ddlCommonSkin" CssClass="required" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCloneQuarter" runat="server" Text="Replicate Quarter" SkinID="lblCommonSkin" mandatory="true"></asp:Label>
                                    <asp:DropDownList onchange="ClonequarterChange(this)" ID="ddlCloneQuarter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Clone_Quarter_IndexChanged" SkinID="ddlCommonSkin" CssClass="required" ClientIDMode="Static">
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
                                    <asp:Label ID="lblCloneReportName" runat="server" Text="Replicate Sales Channel" SkinID="lblCommonSkin" mandatory="true"></asp:Label>
                                    <asp:DropDownList ID="ddlCloneReportName" runat="server" SkinID="ddlCommonSkin" CssClass="required" OnSelectedIndexChanged="ddlCloneReportName_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCloneMonth" runat="server" Text="Replicate Month" SkinID="lblCommonSkin" mandatory="true"></asp:Label>
                                    <asp:DropDownList ID="ddlCloneMonth" runat="server" SkinID="ddlCommonSkin" CssClass="required" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCloneKPI" runat="server" Text="Replicate KPI" SkinID="lblCommonSkin" mandatory="true"></asp:Label>
                                    <asp:DropDownList ID="ddlCloneKPI" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Clone_KPI_IndexChanged" SkinID="ddlCommonSkin" CssClass="required" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCloneSubKpi" runat="server" Text="Replicate Sub KPI" SkinID="lblCommonSkin"></asp:Label>
                                    <asp:DropDownList ID="ddlCloneSubKPI" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Clone_SubKPI_IndexChanged" SkinID="ddlCommonSkin" CssClass="required" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCloneCondition" runat="server" Text="Replicate Condition" SkinID="lblCommonSkin"></asp:Label>
                                    <asp:DropDownList ID="ddlCloneCondition" runat="server" AutoPostBack="true" SkinID="ddlCommonSkin" CssClass="required" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </td>
                            </tr>


                        </table>

                    </div>
                    <div style="text-align: center; width: 100%; padding: 10px; font-size: 20px; color: #d49800">
                        <table style="padding-left: 400px !important; padding-top: 40px !important;">
                            <tr>

                                <td class="tdSubmit" colspan="2" style="width: 200px !important">
                                    <asp:Button ID="btnSave" Style="width: 150px !important;" OnClientClick="return OperationalValidation();" runat="server" Text="KPI Target Replicate" SkinID="btnCommonSkin" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="msg">

                        <asp:Label ID="lblMsg" runat="server">
    
                        </asp:Label>
                    </div>

                    <div style="text-align: center; width: 100%; padding: 10px; font-size: 20px; color: #d49800" id="successMessage">
                    </div>

                </div>


            </ContentTemplate>

        </asp:UpdatePanel>

    </div>

    <script type="text/javascript">

        function quarterChange(selEle) {
            var salesGroup = $('#' + '<%= ddlSalesGroup.ClientID %>').val();
            if (salesGroup <= 0) {
                selEle.value = 0;
                alert("Please select Sales Group!!");
            }


            //alert('Selected value : ' + selEle.value.toString() + '\nSelected item : ' + selEle.options[selEle.selectedIndex].innerHTML);
        }

        function ClonequarterChange(selEle) {
            var salesGroup = $('#' + '<%= ddlCloneSalesGroup.ClientID %>').val();
            if (salesGroup <= 0) {
                selEle.value = 0;
                alert("Please select  Replicate Sales Group!!");
            }


            //alert('Selected value : ' + selEle.value.toString() + '\nSelected item : ' + selEle.options[selEle.selectedIndex].innerHTML);
        }

        function OperationalValidation() {

            document.getElementById("<%=lblMsg.ClientID%>").innerHTML = "";
            $("span[id$=lblMsg]").html("<b>Please select Sub KPI</b><br>").css("color", "red");

            var isAllValid = true;

            document.getElementById("<%=lblMsg.ClientID%>").innerHTML = "";

            var SalesGroup = $('#<%=ddlSalesGroup.ClientID %> option:selected').val();
            var Year = $('#<%=ddlYear.ClientID %> option:selected').val();
            var Quarter = $('#<%=ddlQuarter.ClientID %> option:selected').val();
            var ReportName = $('#<%=ddlReportName.ClientID %> option:selected').val();
            var Month = $('#<%=ddlMonth.ClientID %> option:selected').val();
            var KPI = $('#<%=ddlKPI.ClientID %> option:selected').val();
            var SubKPI = $('#<%=ddlSubKPI.ClientID %> option:selected').val();
            var Condition = $('#<%=ddlCondition.ClientID %> option:selected').val();



            var CloneSalesGroup = $('#<%=ddlCloneSalesGroup.ClientID %> option:selected').val();
            var CloneYear = $('#<%=ddlCloneYear.ClientID %> option:selected').val();
            var CloneQuarter = $('#<%=ddlCloneQuarter.ClientID %> option:selected').val();
            var CloneReportName = $('#<%=ddlCloneReportName.ClientID %> option:selected').val();
            var CloneMonth = $('#<%=ddlCloneMonth.ClientID %> option:selected').val();
            var CloneKPI = $('#<%=ddlCloneKPI.ClientID %> option:selected').val();
            var CloneSubKPI = $('#<%=ddlCloneSubKPI.ClientID %> option:selected').val();
            var CloneCondition = $('#<%=ddlCloneCondition.ClientID %> option:selected').val();


            //Orginal Section Start//

            if (SalesGroup == "" || SalesGroup == "0") {
                $("span[id$=lblMsg]").html("<b>Please select sales group</b><br>").css("color", "red");
                isAllValid = false;
                return false;
            }


            if (Year == "" || Year == "0") {
                $("span[id$=lblMsg]").html("<b>Please select year</b><br>").css("color", "red");
                isAllValid = false;
                return false;
            }

            if (Quarter == "" || Quarter == "0") {
                $("span[id$=lblMsg]").html("<b>Please select quarter</b><br>").css("color", "red");
                isAllValid = false;
                return false;
            }

            if (ReportName == "" || ReportName == "0") {
                $("span[id$=lblMsg]").html("<b>Please select report name</b><br>").css("color", "red");
                isAllValid = false;
                return false;
            }

            if (Month == "") {
                $("span[id$=lblMsg]").html("<b>Please select month</b><br>").css("color", "red");
                isAllValid = false;
                return false;
            }

            if (KPI == "" || KPI == "0") {
                $("span[id$=lblMsg]").html("<b>Please select KPI</b><br>").css("color", "red");
                isAllValid = false;
                return false;
            }

            var totalSubKpi = $('#ddlSubKPI option').length;
            var subKPIValue = $('#ddlSubKPI').val();
            if (totalSubKpi > 1 && subKPIValue == 0) {
                $("span[id$=lblMsg]").html("<b>Please select sub KPI</b><br>").css("color", "red");
                isAllValid = false;
                return false;
            }

            //if (SubKPI == "" || SubKPI == "0") {
            //    $("span[id$=lblMsg]").html("<b>Please select sub KPI</b><br>").css("color", "red");
            //    isAllValid = false;
            //    return false;
            //}

            //if (Condition == "" || Condition == "0") {
            //    $("span[id$=lblMsg]").html("<b>Please select condition</b><br>").css("color", "red");
            //    isAllValid = false;
            //    return false;
            //}

            //Orginal Section End//


            //Replicate Section Start//

            if (CloneSalesGroup == "" || CloneSalesGroup == "0") {
                $("span[id$=lblMsg]").html("<b>Please select replicate sales group</b><br>").css("color", "red");
                isAllValid = false;
                return false;
            }


            if (CloneYear == "" || CloneYear == "0") {
                $("span[id$=lblMsg]").html("<b>Please select replicate year</b><br>").css("color", "red");
                isAllValid = false;
                return false;
            }

            if (CloneQuarter == "" || CloneQuarter == "0") {
                $("span[id$=lblMsg]").html("<b>Please select replicate quarter</b><br>").css("color", "red");
                isAllValid = false;
                return false;
            }

            if (CloneReportName == "" || CloneReportName == "0") {
                $("span[id$=lblMsg]").html("<b>Please select replicate report name</b><br>").css("color", "red");
                isAllValid = false;
                return false;
            }

            if (CloneMonth == "") {
                $("span[id$=lblMsg]").html("<b>Please select replicate month</b><br>").css("color", "red");
                isAllValid = false;
                return false;
            }

            if (CloneKPI == "" || CloneKPI == "0") {
                $("span[id$=lblMsg]").html("<b>Please select replicate KPI</b><br>").css("color", "red");
                isAllValid = false;
                return false;
            }

            if ((CloneSubKPI == "" || CloneSubKPI == "0")) {
                if ((SubKPI != "" && SubKPI != "0")) {
                    $("span[id$=lblMsg]").html("<b>Please select replicate sub KPI</b><br>").css("color", "red");
                    isAllValid = false;
                    return false;
                }
            }

            if ((CloneSubKPI != "" && CloneSubKPI != "0")) {
                if ((SubKPI == "" || SubKPI == "0")) {
                    $("span[id$=lblMsg]").html("<b>Please unselect replicate sub KPI</b><br>").css("color", "red");
                    isAllValid = false;
                    return false;
                }

            }

            if ((Condition != "" && Condition != "0")) {
                if (CloneCondition == "" || CloneCondition == "0") {
                    $("span[id$=lblMsg]").html("<b>Please select replicate condition</b><br>").css("color", "red");
                    isAllValid = false;
                    return false;
                }
            }


            if ((CloneCondition != "" && CloneCondition != "0") && (Condition == "" || Condition == "0")) {
                $("span[id$=lblMsg]").html("<b>Please unselect replicate condition</b><br>").css("color", "red");
                isAllValid = false;
                return false;
            }

            // After all validation done
            if (isAllValid) {

                dataFromItem = [];

                var getFromItem = {};

                getFromItem.FromSalesGroup = SalesGroup; //SalesGroup;
                getFromItem.FromYear = Year; //Year 
                getFromItem.FromQuarter = Quarter; //Quarter
                getFromItem.FromReportName = ReportName; //ReportName
                getFromItem.FromMonth = Month;  //Month
                getFromItem.FromKPI = KPI;  //KPI
                getFromItem.FromSubKPI = SubKPI;  //SubKPI
                getFromItem.FromCondition = Condition;  //Condition

                dataFromItem.push(getFromItem);


                var dataToItem = [];

                var getToItem = {};
                getToItem.ToCloneSalesGroup = CloneSalesGroup; //CloneSalesGroup;
                getToItem.ToCloneYear = CloneYear; //CloneYear 
                getToItem.ToCloneQuarter = CloneQuarter; //CloneQuarter
                getToItem.ToCloneReportName = CloneReportName; //CloneReportName
                getToItem.ToCloneMonth = CloneMonth;  //CloneMonth
                getToItem.ToCloneKPI = CloneKPI;  //CloneKPI
                getToItem.ToCloneSubKPI = CloneSubKPI;  //CloneSubKPI
                getToItem.ToCloneCondition = CloneCondition;  //CloneCondition

                dataToItem.push(getToItem);

                DataSaveAjaxCall(dataFromItem, dataToItem);
            }
            return false;
        }



        function DataSaveAjaxCall(dataFromItem, dataToItem) {
            var Data = JSON.stringify({ dataFromItem: dataFromItem, dataToItem: dataToItem });

            $.ajax({

                url: "KPITargetReplicate.aspx/SaveReplicateData",
                data: Data,
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    if (data.d == "SUCCESSFUL" || data.d == "SUCCE") {
                        $("span[id$=lblMsg]").html("<b>KPI Target data process successfully replicate.</b><br>").css("color", "green");
                        DataClear();
                        return false;
                    } else {
                        $("span[id$=lblMsg]").html("<b>" + data.d + "</b><br>").css("color", "red");
                        return false;
                    }
                }
            });
        }

        function DataClear() {

            //From Data
            $('#<%=ddlSalesGroup.ClientID %>').val(0);
            $('#<%=ddlYear.ClientID %>').val(2022);
            $('#<%=ddlQuarter.ClientID %>').val(0);
            $('#<%=ddlReportName.ClientID %>').empty();
            $('#ddlMonth').empty();
            $('#ddlKPI').empty();
            $('#ddlSubKPI').empty();
            $('#ddlCondition').empty();


            //To Data
            $('#<%=ddlCloneReportType.ClientID %>').val(3);
            $('#<%=ddlCloneSalesGroup.ClientID %>').val(0);
            $('#<%=ddlCloneYear.ClientID %>').val(2022);
            $('#<%=ddlCloneQuarter.ClientID %>').val(0);
            $('#<%=ddlCloneReportName.ClientID %>').empty();
            $('#ddlCloneMonth').empty();
            $('#ddlCloneKPI').empty();
            $('#ddlCloneSubKPI').empty();
            $('#ddlCloneCondition').empty();

        }

        function atActual(e, checkbox) {
            var amount = checkbox.parentElement.previousSibling.previousElementSibling.childNodes[1].children["0"];
            if ($(checkbox).is(':checked')) {
                amount.value = "";
                amount.style.display = "none";
            } else {
                amount.style.display = "block";
            }
        };
        function atActual2(e, checkbox) {
            var amount = checkbox.parentElement.previousElementSibling.childNodes[0].children["0"];
            if ($(checkbox).is(':checked')) {
                amount.value = "";
                amount.style.display = "none";
            } else {
                amount.style.display = "block";
            }
        };


        //$(".tOperator").change(function(){

        //    var selectedValue = $(this).val();
        //    var relationOperator = this.parentElement.parentElement.nextElementSibling.nextElementSibling.firstElementChild;
        //    var isLinear = this.parentElement.parentElement.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling.childNodes[1];

        //    relationOperator.textContent = "=";
        //    if(isLinear.checked)
        //    {
        //        relationOperator.textContent = selectedValue;
        //    }       
        //});

        function chOperator(e, checkbox) {
            var selectedValue = $(checkbox).val();
            var relationOperator = checkbox.parentElement.parentElement.nextElementSibling.nextElementSibling.firstElementChild;
            var isLinear = checkbox.parentElement.parentElement.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling.childNodes[1];

            relationOperator.textContent = "=";
            if (isLinear.checked) {
                relationOperator.textContent = selectedValue;
            }
        };

        function chOperator2(e, checkbox) {
            var selectedValue = $(checkbox).val();
            var relationOperator = checkbox.parentElement.parentElement.nextElementSibling.nextElementSibling.firstChild;
            var isLinear = checkbox.parentElement.parentElement.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling.childNodes[0];

            relationOperator.textContent = "=";
            if (isLinear.checked) {
                relationOperator.textContent = selectedValue;
            }
        };

        function isLinear(e, checkbox) {
            var amount = checkbox.parentElement.previousSibling.previousElementSibling.childNodes[1].children["0"];
            var relationOperator = checkbox.parentElement.previousElementSibling.previousElementSibling.previousElementSibling.previousElementSibling.childNodes[0];
            var selectedOperator = checkbox.parentElement.previousElementSibling.previousElementSibling.previousElementSibling.previousElementSibling.previousElementSibling.previousElementSibling.childNodes[1].childNodes[1];

            if ($(checkbox).is(':checked')) {
                amount.value = "";
                amount.style.display = "block";
                relationOperator.textContent = selectedOperator.value;
            } else {
                amount.value = "";
                amount.style.display = "none";
                relationOperator.textContent = "=";
            }
        };

        function isLinear2(e, checkbox) {
            var amount = checkbox.parentElement.previousElementSibling.childNodes[0].children["0"];
            var relationOperator = checkbox.parentElement.previousElementSibling.previousElementSibling.previousElementSibling.previousElementSibling;
            var selectedOperator = checkbox.parentElement.previousElementSibling.previousElementSibling.previousElementSibling.previousElementSibling.previousElementSibling.previousElementSibling.firstElementChild.firstElementChild;

            if ($(checkbox).is(':checked')) {
                amount.value = "";
                amount.style.display = "block";
                relationOperator.textContent = selectedOperator.value;
            } else {
                amount.value = "";
                amount.style.display = "none";
                relationOperator.textContent = "=";
            }
        };
        function IncentiveRowAdd() {
            $('#IncentiveTbody').append('<tr><td><center><select class="tOperator" onchange ="chOperator2(event,this)"><option value="=">=</option><option value="<"><</option><option value="<="><=</option><option value=">">></option><option value=">=">>=</option></select></center></td><td><center><input class="tThreshold" style="width: 50px" type="number" /></center></td><td><label class="tRelationOperator">=</label></td><td><center><input class="tAmount" style="width: 50px" type="number" /></center></td><td><input class="tAtActual" onclick="atActual2(event,this)"  type="checkbox" name="At Actual" value="Y" /></td><td><center><input class="tRatioAmount" style="width: 50px; display: none" type="number" /></center></td><td><input class="tIsLinear" onclick="isLinear2(event,this)" type="checkbox" name="Is Linear" value="Y" /></td><td><center><input class="color_red" OnClick="$(this).parent().parent().parent().remove();" type="button" value="X" /></center></td></tr>');
        }
        function IncentiveSave() {
            var data = $("#IncentiveTbody")[0].children;
            var thresholdViewId = $('#tKPIId').val();
            var thresholdValue = $('#tValueId').val();
            var stringIncentive = "[";
            var stringIncentiveShow = "";
            for (var i = 0; i < data.length; i++) {
                trData = data[i];
                var Operator = $(trData).find('.tOperator option:selected').val();
                var Threshold = $(trData).find('.tThreshold').val() != "" ? $(trData).find('.tThreshold').val() : "0";
                var Amount = $(trData).find('.tAmount').val() != "" ? $(trData).find('.tAmount').val() : "0";
                var RelationOperator = trData.children[2].textContent;
                var AtActual = $(trData).find('.tAtActual').is(':checked');
                var RatioAmount = $(trData).find('.tRatioAmount').val() != "" ? $(trData).find('.tRatioAmount').val() : "0";
                var IsLinear = $(trData).find('.tIsLinear').is(':checked');
                stringIncentive += JSON.stringify({ IOrder: i, IOperator: Operator, IThreshold: Threshold, IAmount: Amount, IAtActual: AtActual, IRatioAmount: RatioAmount, IIsLinear: IsLinear });
                if (i != data.length - 1) {
                    stringIncentive += ",";
                };
                //stringIncentiveShow += (i+1) +". "+ Operator +" " +Threshold+"=" + Amount +", "+ "At Actual: " + AtActual +"|| ";
                if (AtActual) {
                    stringIncentiveShow += Operator + Threshold + "=at actual";
                } else {
                    stringIncentiveShow += Operator + Threshold + RelationOperator + Amount;
                }

                if (IsLinear) {
                    stringIncentiveShow += "(L.R. per 1%: " + RatioAmount + "); ";
                } else {
                    stringIncentiveShow += "; ";
                }


            }
            stringIncentive += "]";
            var stringToJSON = JSON.parse(stringIncentive);
            $("#" + thresholdViewId).val(stringIncentiveShow);
            $("#" + thresholdValue).val(stringIncentive);
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
        function ModalShow(id, ValueId) {
            var modal = document.getElementById("myModal");
            modal.style.display = "block";
            $('#tKPIId').val(id);
            $('#tValueId').val(ValueId);
            return false;
        }
        function modalLoad() {
            // Get the modal
            var modal = document.getElementById("myModal");

            // Get the <span> element that closes the modal
            var span = document.getElementsByClassName("close")[0];

            // When the user clicks on <span> (x), close the modal
            span.onclick = function () {
                modalClose();
            }

            // When the user clicks anywhere outside of the modal, close it
            window.onclick = function (event) {
                if (event.target == modal) {
                    modal.style.display = "none";
                    $(".tThreshold").val(null);
                }
            }
        }
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


        $(document).ready(function () {
            //alert("Document");
            //modalLoad();

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
                var incentivePayoutJson = ids[i] + "_incentivePayoutKpi_Modal";
                var kpiWeightage = ids[i] + "_kpiWeightageKpi";

                var kpiIdValue = $("#" + kpiId).val();
                var incentivePayoutValue = $("#" + incentivePayout).val();
                var incentivePayoutJsonValue = $("#" + incentivePayoutJson).val();
                var kpiWeightageValue = $("#" + kpiWeightage).val();;

                kpiTable_id.push({ Kpi_id: kpiId, Incentive_Payout: incentivePayout, Incentive_Payout_Json: incentivePayoutJson, Weightage: kpiWeightage });
                KPI.push({ Kpi_id: kpiIdValue, Incentive_Payout: incentivePayoutValue, Incentive_Payout_Json: incentivePayoutJsonValue, Weightage: kpiWeightageValue });

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
            var d = { MainKPI: kpi, SubKPI: subKpi, Condition: condition, sChannelId: selectedSChannel, year: selectedYear, quarter: selectedQuarter, month: selectedMonth, reportType: selectedReportType };
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
                    var subkpiId = subKpi[j].Kpi_id;
                    var kpiWeightate = kpi[i].Weightage;
                    if (kpiId = subkpiId) {
                        var subKPIWeightage = subKpi[j].Weightage;
                        if (subKPIWeightage == "") {
                            msz = "SubKPI Weightage can not be empty!!";
                            isValid = false;
                        }
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
            selectedMonth = $('#<%=ddlMonth.ClientID %> option:selected').val();

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

            var subKpiDirective = '<tr class="kpiSubKpi_' + firstIndex + '" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '" ><td class="subKpiBackColor"><button class="button color_red " id="kpiTable_' + firstIndex + '_removeSubKpi_' + secondIndex + '" type="button" onclick="deleteSubKpi(this.id)" >X</button>  Sub KPI</td><td><select class="W240 subKpiDropdown" type="text" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_kpi" ></select></td><td><input class="W90" placeholder="Weightage" type="number" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_subKpiWeightage" /></td><td></td><td class="W205"><div style="float:right"><button class="button" style="margin-right: 5px;" id="addKpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition" type="button" onclick="generateSubKpiCondition(this.id)">Add Condition</button></div></td></tr>';
            $('#kpiTable_' + firstIndex).append(subKpiDirective);

            loadSubKPIbyKPI(firstIndex, secondIndex);
            $(".kpi_fields_wrap").scrollTop(350);
        }

        function generateKpiCondition(id) {
            var firstIndex = id.substring(12, 13);
            var numberIdArray = [];
            var secondIndex;
            if ($('.kpiCondition_' + firstIndex).length == 0) {
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
            var conditionDirective = '<tr class="kpiCondition_' + firstIndex + '" id="kpiTable_' + firstIndex + '_condition_' + secondIndex + '"><td class="conBackColor"><button class="button color_red" id="kpiTable_' + firstIndex + '_removeCondition_' + secondIndex + '" type="button" onclick="deleteKpiCondition(this.id)" >X</button> Condition</td><td><select class="W240 conditionDropdown"  type="text" id="kpiTable_' + firstIndex + '_condition_' + secondIndex + '_condition"' + ' ></select></td><td colspan="3"></td></tr>';

            $('#kpiTable_' + firstIndex).append(conditionDirective);
            var selectedKPI = $('#kpiTable_' + firstIndex + '_kpi').val();
            var parentTr = $('#' + id).parent().parent().parent()[0];
            loadConditionbySubKPI('#kpiTable_' + firstIndex + '_condition_' + secondIndex + '_condition', selectedKPI, parentTr, firstIndex, secondIndex);
        }
        function generateSubKpiCondition(id) {
            var firstIndex = id.substring(12, 13);

            var secondIndex = id.substring(26, 27);
            var numberIdArray = [];
            var thirdIndex;
            if ($('.kpi_' + firstIndex + '_subKpiCondition_' + secondIndex).length == 0) {
                thirdIndex = 1;
            }
            else {
                var ids = $('.kpi_' + firstIndex + '_subKpiCondition_' + secondIndex).map(function () {
                    var numberId = this.id.substring(this.id.lastIndexOf('_') + 1, this.id.length + 1);
                    numberIdArray.push(parseInt(numberId));
                    return this.id;
                }).get();
                thirdIndex = Math.max.apply(Math, numberIdArray) + 1;
            }
            var conditionDirective = '<tr class="kpi_' + firstIndex + '_subKpiCondition_' + secondIndex + '" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '"><td class="conBackColor"><button class="button color_red" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_removeCondition_' + thirdIndex + '" type="button" onclick="deleteSubKpiCondition(this.id)" >X</button> Condition</td><td><select class="W240 conditionDropdown"  type="text" id="kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '_condition" ></select></td><td colspan="3"></td></tr>';

            $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex).after(conditionDirective);

            var selectedKPI = $('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_kpi').val();

            var parentTr = $('#' + id).parent().parent().parent()[0];

            loadConditionbySubKPI('#kpiTable_' + firstIndex + '_subKpiTable_' + secondIndex + '_condition_' + thirdIndex + '_condition', selectedKPI, parentTr, firstIndex, secondIndex);
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

            var kpiId = id.substring(0, 10);
            $("#" + kpiId + "_kpi").attr("disabled", false);

            $('#' + id).parent().parent().remove();
            $(".kpi_" + firstIndex + "_subKpiCondition_" + secondIndex).remove();
            if ($('.kpiSubKpi_' + firstIndex).length == 0) {
                $('#addKpiTable_' + firstIndex + '_condition').show();
            }
        }
        function removeKpi(id) {
            $('#' + id).parent().parent().parent().parent().remove();
            var table = $(".contenttext").length;
            if (table <= 0) {
                $('#<%=ddlSalesGroup.ClientID %>').attr('disabled', false);
        }
    }
    function deleteKpiCondition(id) {
        var firstIndex = id.substring(9, 10); //kpiTable_1_removeCondition_1
        $('#' + id).parent().parent().remove();
        var kpiId = id.substring(0, 10);
        $("#" + kpiId + "_kpi").attr("disabled", false);
        if ($('.kpiCondition_' + firstIndex).length == 0) {
            $('#addKpiTable_' + firstIndex + '_subKpi').show();
        }
    }
    function deleteSubKpiCondition(id) {
        var kpiId = id.substring(0, 24);
        $("#" + kpiId + "_kpi").attr("disabled", false);
        $('#' + id).parent().parent().remove();
    }
    //Button Click Event End


    function loadSubKPIbyKPI(fIndex, sIndex) {
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
                    $(kpiId).attr('disabled', true);
                    $.each(mydata.d, function () {
                        $(htmlId).append("<option value=" + this.Kpi_id + ">" + this.Kpi_Name + "</option>");
                    });
                    hideCondition(fIndex, sIndex);
                }
                else {
                    $(htmlId).parent().parent().remove();
                    // hideSubKPI();
                    alert($("#" + kpiId + " option:selected").text() + " has no Sub KPI!");
                }
            }
        });
    }
    function loadConditionbySubKPI(id, selectKpi, ParentTr, fIndex, sIndex) {
        var htmlId = id;
        var SubKPIId = id.substring(0, 12);
        var kpiId = SubKPIId + "kpi";
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
                    $('#' + dropdownId).attr('disabled', true);
                    $.each(mydata.d, function () {
                        $(htmlId).append("<option value=" + this.Condition_id + ">" + this.Condition_Name + "</option>");
                    });
                    hideSubKPI(fIndex, sIndex);
                }
                else {
                    $(htmlId).parent().parent().remove();
                    alert($("#" + ParentTr.children[1].children[0].id + " option:selected").text() + " has no Condition!");
                }

            }
        });
    }
    //DropDown Data Load End
    //Threshold Popup
    function myPopup(valueId) {
        //var popupid = valueId.id.substring(0,10);
        //var popup = document.getElementById(popupid+"_popup");

        //var message = document.getElementById(valueId.id);
        //popup.innerText =message.value;
        //if (message.value != "") {
        //    popup.classList.toggle("show");
        //}
    }
    </script>
</asp:Content>




