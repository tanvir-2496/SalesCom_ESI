<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="ImportChannelEventData.aspx.cs" Inherits="SetupActivity" Culture="en-GB" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        var validFilesTypes = ["xlsx", "xls"];
        function ValidateFile() {
            var file = document.getElementById("<%=FileUpload1.ClientID%>");
            var label = document.getElementById("<%=lblResult.ClientID%>");
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
                label.innerHTML = "Invalid File. Please upload a File with" + " extension:\n\n" + validFilesTypes.join(", ");
            }
            return isValidFile;
        }

        function refreshWindow() {
            ModifyLeftpanel();
            document.getElementById('<%= btnRefresh.ClientID %>').click();
        }

        //function ReConfirm() {
        //    var confirm_value = document.createElement("INPUT");
        //    confirm_value.type = "hidden";
        //    confirm_value.name = "confirm_value";
        //    if (confirm("Same data already exists. Do you want to save data the again?")) {
        //        confirm_value.value = "Yes";
        //    } else {
        //        confirm_value.value = "No";
        //    }
        //    document.forms[0].appendChild(confirm_value);
        //}

        function ReConfirm() {
            debugger;
            if (confirm("Same data already exists. Do you want to save data the again?")) {
              <%--  //document.getElementById('<%= btnConfirm.ClientID %>').click();
                var elem = document.getElementById("btnConfirm");
                if (typeof elem.onclick == "function") {
                    elem.onclick.apply(elem);--%>

                document.getElementById('<%= btnConfirm.ClientID %>').click();

            }

            else {
                alert("You choose not to reinsert the data again");
            }
        }


        function ConfirmApproval(objMsg) {
            if (confirm(objMsg)) {
                $('#lblResult').fadeTo('slow', .6);
                return true;
            } else {

                $('#lblResult').fadeTo('slow', 1);
                return false;
            }

        }

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  

    <div class="leftPanel"></div>
    <div class="Content">

        <div style="text-align: right">
            <asp:Button runat="server" ID="btnShowPreviousImportData" Text="Go Back to Import List" SkinID="btnCommonSkinLarge" OnClick="btnShowPreviousImportData_Click" />
        </div>
        <asp:UpdatePanel ID="upReportname" runat="server">
            <ContentTemplate>
                <table class="contenttext" style="width: 100%;">


                    <tr>
                        <td>

                            <asp:Label ID="lblChannelType" runat="server" Text="Channel Type" SkinID="lblCommonSkin"> </asp:Label>
                            <asp:DropDownList ID="ddlChannelType" runat="server" SkinID="ddlCommonSkin" CssClass="required" ClientIDMode="Static">
                            </asp:DropDownList>

                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="lblReportName" runat="server" Text="Report Name" SkinID="lblCommonSkin"></asp:Label>
                            <asp:DropDownList ID="ddlReportName" runat="server" SkinID="ddlCommonSkin" CssClass="required" OnSelectedIndexChanged="ddlReportName_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true">
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td>

                            <asp:Label ID="lblChannelEventBatch" runat="server" Text="Channel Event Batch" SkinID="lblCommonSkin"> </asp:Label>
                            <asp:DropDownList ID="ddlChannelEventBatch" runat="server" SkinID="ddlCommonSkin" ClientIDMode="Static">
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td>

                            <asp:Label ID="lblReportCycle" runat="server" Text="Report Cycle" SkinID="lblCommonSkin"> </asp:Label>
                            <asp:DropDownList ID="ddlReportCycle" runat="server" SkinID="ddlCommonSkin" CssClass="required" ClientIDMode="Static">
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td>

                            <asp:Label ID="lblEventType" runat="server" Text="Event Type" SkinID="lblCommonSkin"> </asp:Label>
                            <asp:DropDownList ID="ddlEventType" runat="server" SkinID="ddlCommonSkin" CssClass="required" ClientIDMode="Static">
                            </asp:DropDownList>

                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="lblAmountType" runat="server" Text="Amount Type" SkinID="lblCommonSkin"> </asp:Label>
                            <asp:DropDownList ID="ddlAmountType" runat="server" SkinID="ddlCommonSkin" CssClass="required" ClientIDMode="Static">
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
                            <asp:DropDownList ID="rbHDR" runat="server" Style="width: 56px">
                                <asp:ListItem Text="Yes" Value="Yes" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <br />
                        <div>
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="if(!confirm('Do you really want to import the selected excel sheet data to Database?')){ return false; };" OnClick="btnSave_Click" SkinID="btnCommonSkin" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" SkinID="btnCommonSkin" />
                            <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Style="display: none" />

                        </div>
                        <div>
                            <asp:Button ID="btnSynchronize" runat="server" Text="Synchronize" OnClientClick="if(!confirm('Do you really want to Synchronize these data with main table?')){ return false; };" OnClick="btnSynchronize_Click" SkinID="btnMediumSkin" Visible="false" />
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

