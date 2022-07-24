<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupCommissionClaimAdd.aspx.cs" Inherits="SetupActivityAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        var validFilesTypes = ["xlsx", "xls"];
        function ValidateFile() {
            var file = document.getElementById("<%=fuComWithdrawal.ClientID%>");
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
            //  ModifyLeftpanel();
        }

        function closeWindow() {

            debugger;
            var userAgent = window.navigator.userAgent;
            var msie = userAgent.indexOf("MSIE ");
            var trident = userAgent.indexOf('Trident/');
            var edge = userAgent.indexOf('Edge/');
            if (msie > 0 || edge > 0 || trident > 0) {

                parent.tb_remove();
                mywindow = window.open("ClaimReport.aspx?reportId=<%=ReportId%>&cycleId=<%=CycleId%>", "ClaimReport", "location=1,status=1,scrollbars=1,  width=850,height=550");
                mywindow.moveTo(0, 0);
            }
            else {

                var p = parent;
                parent.tb_remove();
                p.tb_show("", "ClaimReport.aspx?reportId=<%=ReportId%>&cycleId=<%=CycleId%>&TB_iframe=true&height=550&width=850", "");
            }
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div style="text-align: right" id="btnSampleFile" runat="server" visible="true">
        <asp:Button ID="btnDownload" runat="server" Text="Sample File" OnClick="btnDownload_Click" SkinID="btnCommonSkin" />
    </div>

    <table class="contenttext" style="width: 100%;">
        <asp:UpdatePanel ID="upCommissionClaim" runat="server">
            <ContentTemplate>

                <tr>
                    <td>
                        <asp:Label ID="lblReportName" mandatory="true" runat="server" Text="Report Name" SkinID="lblCommonSkin" AdjustWidthComboBox_DropDown=""> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlReportName" CssClass="required" runat="server" SkinID="ddlCommonSkin" AutoPostBack="true" OnSelectedIndexChanged="ddlReportName_SelectedIndexChanged" Enabled="False">
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblCycle" runat="server" Text="Cycle" mandatory="true" SkinID="lblCommonSkin"> </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCycle" runat="server" SkinID="ddlCommonSkin" CssClass="required" Enabled="False">
                        </asp:DropDownList>
                    </td>
                </tr>
            </ContentTemplate>
        </asp:UpdatePanel>
        <tr>
            <td>
                <asp:Label ID="lblReferenceNumber" runat="server" Text="Reference Number" mandatory="true" SkinID="lblCommonSkin"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtReferenceNumber" runat="server" SkinID="txtCommonSkin" CssClass="required">
                </asp:TextBox>

            </td>
        </tr>
        <tr>

            <td>
                <asp:Label ID="lblCommissionCriterion" runat="server" Text="Commission Criterion" mandatory="true" SkinID="lblCommonSkin"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCommissionCriterion" runat="server" SkinID="txtCommonSkin" CssClass="required" TextMode="MultiLine">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblModeOfPayment" runat="server" Text="Mode of Payment" mandatory="true" SkinID="lblCommonSkin"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtModeOfPayment" runat="server" CssClass="required" SkinID="txtCommonSkin"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblHasWithdrawalList" runat="server" Text="Has Withdrawal List" SkinID="lblCommonSkin"> </asp:Label>
            </td>

            <td>
                <asp:DropDownList ID="ddlHasWithdrawalList" runat="server" SkinID="ddlCommonSkin" AutoPostBack="true" OnSelectedIndexChanged="ddlHasWithdrawalList_SelectedIndexChanged">
                    <asp:ListItem Text="No" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>

        </tr>

        <asp:Panel ID="pUpload" runat="server" Visible="false">

            <tr>
                <td>
                    <asp:Label ID="lblBrowse" runat="server" Text="Browse" SkinID="lblCommonSkin"> </asp:Label>
                </td>
                <td>

                    <asp:FileUpload ID="fuComWithdrawal" runat="server" type="file" />
                </td>

            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" OnClientClick="return ValidateFile()" SkinID="btnCommonSkin" />

                    <asp:Label ID="lblFileNameWithExt" runat="server" Text="" SkinID="lblCommonSkin"> </asp:Label>

                    <br />
                    <asp:Label ID="lblMessage" runat="server" Text="" SkinID="lblErrorMsgSkin" />
                </td>
            </tr>
        </asp:Panel>

    </table>
    <table class="contenttext" style="width: 100%;">

        <tr>
            <asp:Panel ID="pImport" runat="server" Visible="false">
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

                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Cancel" OnClick="btnCancel_Click" SkinID="btnCommonSkin" />
                </td>
            </asp:Panel>
        </tr>

    </table>

    <div style="margin-right: 54px">

        <asp:Button ID="btnSave" OnClientClick="return fnValidate();" runat="server" Text="Save" OnClick="btnSave_Click" SkinID="btnCommonSkin" />

    </div>

    <div runat="server" id="btnReport" visible="false" style="margin-right: 54px">

        <asp:Button runat="server" Text="Generate Report" OnClientClick="closeWindow()" SkinID="btnMediumSkin" />
    </div>

    <div class="msg">
        <asp:Label ID="lblResult" runat="server" Font-Bold="True"></asp:Label>
    </div>

    <div class="msg">
        <asp:Label ID="lblMsg" runat="server">
    
        </asp:Label>
    </div>

</asp:Content>

