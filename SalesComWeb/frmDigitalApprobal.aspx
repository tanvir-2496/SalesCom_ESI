<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="frmDigitalApprobal.aspx.cs" Inherits="SetupActivity" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="leftPanel">
    </div>
    <div class="Content">
        <div>
            <asp:UpdatePanel ID="upReportname" runat="server">
                <ContentTemplate>
                    <div>
                        <table class="contenttext" style="width: 100%;">
                            <tr>
                                <td>

                                    <asp:Label ID="lblReportName" runat="server" Text="Report Name" SkinID="lblCommonSkin" mandatory="true"></asp:Label>

                                    <asp:DropDownList ID="ddlReportName" runat="server" SkinID="ddlCommonSkin" CssClass="required" OnSelectedIndexChanged="ddlReportName_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true">
                                    </asp:DropDownList>

                                </td>
                            </tr>

                            <tr>
                                <td>

                                    <asp:Label ID="lblReportCycle" runat="server" Text="Report Cycle" SkinID="lblCommonSkin" mandatory="true"> </asp:Label>
                                    <asp:DropDownList ID="ddlReportCycle" runat="server" SkinID="ddlCommonSkin" CssClass="required" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </td>
                            </tr>


                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <table class="contenttext" style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="lblCommissionreport" runat="server" Text="Commission Claim Report" SkinID="lblCommonSkin"> </asp:Label>
                    <%--<asp:Button ID="btnShowPreviousImportData" runat="server" Text="Show" OnClick="btnShowPreviousImportData_Click" SkinID="btnCommonSkin" />--%>
                    <asp:Button ID="btnReport" runat="server" OnClick="btnReport_Click" Text="Show" SkinID="btnCommonSkin" OnClientClick="refreshWindow();return fnValidate();" />

                </td>
            </tr>
        </table>



        <asp:Label ID="errorMessage" runat="server" SkinID="lblErrorMsgSkin"></asp:Label>
        <CR:CrystalReportViewer ID="crvDigitalApproval" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" BorderColor="#FF9900" BorderStyle="Ridge" BorderWidth="2px" GroupTreeStyle-ForeColor="Black" HasCrystalLogo="False" Height="50px" ToolbarStyle-BackColor="#FF9900" ToolbarStyle-BorderColor="#996600" ToolbarStyle-BorderStyle="Inset" ToolbarStyle-BorderWidth="3px" ToolPanelView="None" HasToggleGroupTreeButton="false" />
        <CR:CrystalReportSource ID="crsDigitalApproval" runat="server">
            <Report FileName="Reports/crDigitalApproval.rpt">
            </Report>
        </CR:CrystalReportSource>
    </div>




    <script type="text/javascript">

        //function refreshWindow() {
        //    $(".eventHeader").html('');
        //    $("div").removeClass("leftPanel").addClass("leftPanelM")


        //}

        $(window).load(function () {
            var changedHeight;
            var div = $("#ContentPlaceHolder1_crvDigitalApproval__UI");
            var heihgt = div.css('height');
            var suffix = heihgt.match(/\d+/)
            changedHeight = parseInt(suffix) + 200;
            changedHeight = changedHeight + "px";
            $("#masterContainer").css("height", changedHeight);
            $("[id ^=bobjid_][id $=_leftPanel]").css("display", "none");

        });
    </script>
</asp:Content>



