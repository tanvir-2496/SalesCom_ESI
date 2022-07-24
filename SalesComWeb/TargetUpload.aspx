<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="TargetUpload.aspx.cs" Inherits="TargetUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        var validFilesTypes = ["xlsx", "xls"];
        function ValidateFile() {
            var label = document.getElementById("<%=lblResult.ClientID%>");

            label.style.color = "white";
            label.innerHTML = "";


            var totalSubKpi = $('#ddlSubKPI option').length;
            var subKPIValue = $('#ddlSubKPI').val();
            if (totalSubKpi > 1 && subKPIValue == 0)
            {
                label.style.color = "red";
                label.innerHTML = "Please select Sub KPI";
                return false;
            } else {
                var file = document.getElementById("<%=FileUpload1.ClientID%>");             
                var path = file.value;
                var ext = path.substring(path.lastIndexOf(".") + 1, path.length).toLowerCase();
                var isValidFile = false;
                for (var i = 0; i < validFilesTypes.length; i++) {
                    if (ext == validFilesTypes[i]) {
                        isValidFile = true;
                        break;
                    }
                }
                if (!isValidFile) {
                    label.style.color = "red";
                    label.innerHTML = "Invalid File, please upload file with extensions: " + validFilesTypes.join(" or ");
                }
                return isValidFile;
            }
          
            
        }

        function refreshWindow() {
            ModifyLeftpanel();
            document.getElementById('<%= btnRefresh.ClientID %>').click();
        }

        function ConfirmationDialog() {
            var actType = 'Make sure you uploaded update maping ...\nAre you want to continue?';
            var con = confirm(actType);

            if (con == false) {
                return false;
            }
            else {
                return true;
            }
        }
        function quarterChange(selEle) {
            var salesGroup = $('#' + '<%= ddlSalesGroup.ClientID %>').val();
            if (salesGroup <= 0) {
                selEle.value = 0;
                alert("Please select Sales Group!!");
            }
            

            //alert('Selected value : ' + selEle.value.toString() + '\nSelected item : ' + selEle.options[selEle.selectedIndex].innerHTML);
        }
    </script>
    <style>
           .contenttext {
            font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            margin: auto;
            margin-top: 0px !important;
            table-layout: fixed;
            border: 0px solid #fcdfcb !important;
        }

        .mainTable td, .mainTable th {
            padding: 1px !important;
        }
            .contenttext td, .contenttext th {
                /*border: 1px solid #ddd;*/
                padding: 5px;
            }
             
            .contenttext tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            .contenttext tr:hover {
                background-color: #ddd;
            }

            .contenttext th {
                padding-top: 7px;
                padding-bottom: 7px;
                text-align: left;
                background-color: #F37821;
                color: white;
            }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="leftPanel"></div>
    <div class="Content">

        <div style="text-align: right; margin-right: 20px">
            <asp:Button ID="btnDownloadSample" Style="height: 20px; width: 100px !important;" runat="server" SkinID="btnCommonSkin" Text="Sample File" OnClick="btnDownloadSample_Click" />
        </div>

        <%-- <div style="text-align: right;" >
            <asp:Button runat="server" ID="btnShowPreviousImportData" Text="Go Back to Traget View" SkinID="btnCommonSkinCustom" OnClick="btnShowPreviousImportData_Click" />
        </div>--%>
        <asp:UpdatePanel ID="upReportname" runat="server">
            <ContentTemplate>
                <table class="contenttext mainTable" style="width: 420px; float: left; border: #FCDCC5 0px solid !important;">

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
                            <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="true" SkinID="ddlCommonSkin" CssClass="required" ClientIDMode="Static" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
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
                            <asp:Label ID="lblTargetType" runat="server" Text="Target Type" SkinID="lblCommonSkin" mandatory="true"></asp:Label>
                            <asp:DropDownList ID="ddlTargetType" runat="server" SkinID="ddlCommonSkin" CssClass="required" ClientIDMode="Static">
                                <asp:ListItem Text="Count" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Percentage(%)" Value="2"></asp:ListItem>                               
                                <asp:ListItem Text="BDT" Value="3"></asp:ListItem>
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

                    <tr>
                        <td>
                            <asp:Panel ID="Panel1" runat="server">
                                <asp:Label ID="blb" runat="server" Text="Select File" SkinID="lblCommonSkin"> </asp:Label>
                                <asp:FileUpload ID="FileUpload1" runat="server" type="file" />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="" SkinID="lblCommonSkin"> </asp:Label>
                            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" OnClientClick="return ValidateFile()" SkinID="btnCommonSkin" />
                            <br />
                            <asp:Label ID="lblMessage" runat="server" Text="" SkinID="lblErrorMsgSkin" />
                        </td>
                    </tr>
                </table>
                <div class="contenttext" style="float: right; margin-right: 20px;">
                    <asp:ListView ID="lv_Target_Status" runat="server" ItemPlaceholderID="item">
                        <LayoutTemplate>
                            <table style="" class="contenttext">
                                <colgroup>
                                    <col />
                                    <col />
                                    <col />
                                    <col />
                                    <col />
                                </colgroup>
                                <thead>
                                    <tr class="listItem">
                                       <%-- <th style="width: 70px">Serial No</th>--%>
                                        <th style="width: 150px">KPI</th>
                                         <th style="width: 200px">SubKPI</th>
                                        <th style="width: 100px">Status</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr id="itemPlaceholder" runat="server" />
                                    <asp:PlaceHolder runat="server" ID="item"></asp:PlaceHolder>
                                </tbody>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr class='listItem'>
                                <%--<td style="align-items: flex-start">
                                    <%# Container.DataItemIndex +1  %>
                                </td>--%>
                                <td style="align-items: flex-start">
                                    <%#Eval("kpi_name")%>
                                </td>
                                 <td style="align-items: flex-start">
                                    <%#Eval("SUB_KPI_NAME")%>
                                </td>
                                <td style="align-items: flex-start">
                                    <%#Eval("status")%>
                                </td>
                                
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnUpload" />
            </Triggers>
        </asp:UpdatePanel>

        <table class="contenttext" style="width: 100%;">

            <tr>
                <asp:Panel ID="Panel2" runat="server" Visible="false">
                    <td>
                        <div>
                            <asp:Label ID="Label5" runat="server" Text="File Name" SkinID="lblCommonSkin" />

                            <asp:Label ID="lblFileName" runat="server" Text="" SkinID="lblCommonSkin" />
                        </div>
                        <br />
                        <div>
                            <asp:Label ID="Label2" runat="server" Text="Select Sheet" SkinID="lblCommonSkin" />
                            <asp:DropDownList ID="ddlSheets" runat="server" AppendDataBoundItems="true" SkinID="ddlCommonSkin" OnDataBound="ddlSheets_DataBound">
                            </asp:DropDownList>
                        </div>
                        <br />
                        <div>
                            <asp:Label ID="Label1" runat="server" Text="Has Header Row?" SkinID="lblCommonSkin" />
                            <asp:DropDownList ID="rbHDR" runat="server" SkinID="ddlSmallSkin">
                                <asp:ListItem Text="Yes" Value="Yes" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <br />
                        <div>
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="if (!ConfirmationDialog()){ return false }" SkinID="btnCommonSkin" UseSubmitBehavior="false" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" SkinID="btnCommonSkin" />
                            <asp:Button ID="btnUploadAnotherKPITarget" Style="width: 200px" runat="server" Text="Upload Another KPI Target" OnClick="btnCancel_Click" SkinID="btnCommonSkin" />
                        </div>
                    </td>
                </asp:Panel>
            </tr>
            <tr>
                <td style="background: #cbc7c7; color: #f00; font-weight: bolder">
                    <asp:Label ID="lblResult" runat="server" SkinID="lblErrorMsgSkin"></asp:Label>
                </td>
            </tr>
        </table>
        <div>
            <asp:UpdatePanel ID="lstpanel" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnRefresh" Style="display: none" runat="server" OnClick="btnRefresh_Click" />
                    <div class="ListViewStyle">
                        <asp:ListView ID="lv" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin">
                            <LayoutTemplate>
                                <table class="datatable" cellpadding="0" cellspacing="0" border="0px">
                                    <colgroup>
                                        <col />
                                        <col />

                                    </colgroup>
                                    <thead>
                                        <tr class="gridheader">
                                            <th>Row Number
                                            </th>
                                            <th>Error Text
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr id="itemPlaceholder1" runat="server" />
                                        <asp:PlaceHolder runat="server" ID="item"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr class='<%# Container.DataItemIndex % 2 == 0 ? "row" : "altrow" %>'>
                                    <td>
                                        <%#Eval("RowNumber")%>&nbsp;
                                    </td>
                                    <td>
                                        <%#Eval("ErrorText")%>&nbsp;
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                    <div class="footer">
                        <asp:Label ID="lblResults" CssClass="gridResults" runat="server" Text=""></asp:Label>
                        <div class="pager">
                            <asp:DataPager ID="pager" runat="server" PagedControlID="lv" PageSize="15" OnPreRender="pager_PreRender">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonCssClass="PagerButton" ShowFirstPageButton="true" ShowPreviousPageButton="true" ShowNextPageButton="false" ButtonType="Image" FirstPageImageUrl="~/App_Themes/Theme1/images/first.gif" RenderDisabledButtonsAsLabels="true" FirstPageText="" PreviousPageText="" PreviousPageImageUrl="~/App_Themes/Theme1/images/prev.gif" />
                                    <asp:NumericPagerField ButtonCount="5" CurrentPageLabelCssClass="pagerCurrent" NumericButtonCssClass="pagerNumeric" />
                                    <asp:NextPreviousPagerField ButtonCssClass="PagerButton" ShowLastPageButton="true" ShowNextPageButton="true" ShowPreviousPageButton="false" ButtonType="Image" NextPageImageUrl="~/App_Themes/Theme1/images/next.gif" LastPageImageUrl="~/App_Themes/Theme1/images/last.gif" LastPageText="" NextPageText="" RenderDisabledButtonsAsLabels="true" />
                                </Fields>
                            </asp:DataPager>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

