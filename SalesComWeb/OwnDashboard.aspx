<%@ Page Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="OwnDashboard.aspx.cs" Inherits="OwnDashboard" Title="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .labelClass {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function refreshWindow() {
            ModifyLeftpanel();
        }
        $(document).ready(function () {
            var data = $('.datatable').length;
            if (data <= 0) {
                $('#messageDiv').hide();
            }
        })
    </script>
    <script type="text/javascript">
        function openInNewTab() {
            window.document.forms[0].target = '_blank';
            setTimeout(function () { window.document.forms[0].target = ''; }, 0);
        }
    </script>

    <div class="leftPanel"></div>
    <div class="Content" style="margin: auto; width: 90%">
        <div style="float: left; width: 45%">
            <asp:Chart ID="KPIChart" runat="server" Height="280px" Palette="EarthTones" Width="593px" BackColor="247, 247, 247">
                <Series>
                    <asp:Series ChartType="Bar" Name="KpiAchievement" ChartArea="KPIName">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="KPIName">
                        <Area3DStyle Enable3D="True" Rotation="10" />
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
        <div style="float: right; width: 45%">
            <%--  //dropdown--%>

            <div style="float: right; width: 45%">
                <div style="float: right; border: double 1px red; padding-bottom: 30px; padding-top: 10px; padding-left: 30px; padding-right: 30px">
                    <div>
                        <div class="labelClass">
                            <label for="ddlYear">Year </label>
                        </div>
                        <asp:DropDownList ID="ddlYear" SkinID="ddlCommonSkin" runat="server" OnSelectedIndexChanged="ddl_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                    <div>
                        <div class="labelClass">
                            <label for="ddlQuarter">Quarter</label>
                        </div>
                        <asp:DropDownList ID="ddlQuarter" SkinID="ddlCommonSkin" OnSelectedIndexChanged="ddl_SelectedIndexChanged" runat="server" AutoPostBack="true">
                            <asp:ListItem Text="---Select----" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Q1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Q2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Q3" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Q4" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div style="float: left; margin-right: 20px; width: 100px">
                        <div class="labelClass">
                            <label for="ddlMonth">Month</label>
                        </div>
                        <asp:DropDownList ID="ddlMonth" SkinID="ddlCommonSkin" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_SelectedIndexChanged">
                            <asp:ListItem Text="[Select One]" Value="0"></asp:ListItem>
                            <asp:ListItem Text="M1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="M2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="M3" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>



        </div>


        <br />
        <br />
        <div class="ListViewStyle">
            <asp:ListView ID="lv" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin">
                <LayoutTemplate>
                    <table class="datatable" cellpadding="0" cellspacing="0" border="0px">
                        <colgroup>
                            <col />
                            <col />
                            <col />
                            <col />
                            <col />
                            <col />
                            <col />
                            <col />
                        </colgroup>
                        <thead>
                            <tr class="gridheader">
                                <th style="width: 30px">#</th>
                                <th style="width: 150px; text-align: left">KPI Type</th>
                                <th style="width: 150px; text-align: left">KPI Name</th>
                                <%--  <th style="width: 60px">Weightage</th>--%>
                                <th style="width: 80px">Month 1 Target</th>
                                <th style="width: 80px">Month 1 Amount</th>
                                <th style="width: 100px">Month 1 Achievement(%)</th>
                                <th style="width: 80px">Month 2 Target</th>
                                <th style="width: 80px">Month 2 Amount</th>
                                <th style="width: 100px">Month 2 Achievement(%)</th>
                                <th style="width: 80px">Month 3 Target</th>
                                <th style="width: 80px">Month 3 Amount</th>
                                <th style="width: 100px">Month 3 Achievement(%)</th>

                                <th style="width: 100px">Total Quarterly Achievement(%)</th>
                                <th style="width: 80px">Quarterly Achievement Thresholds</th>
                                <th style="width: 100px">Incentive Entitlement(%)</th>
                                <th style="width: 100px">Eligible months of Incentive as per Conditions</th>
                                <th style="width: 100px">Eligible Incentive Amount</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr id="itemPlaceholder" runat="server" />
                            <asp:PlaceHolder runat="server" ID="item"></asp:PlaceHolder>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr class='<%# Container.DataItemIndex % 2 == 0 ? "row" : "altrow" %>'>
                        <td style="text-align: center">
                            <%# Container.DataItemIndex +1  %>
                        </td>
                        <td>
                            <%#Eval("KPIType")%>
                        </td>
                        <td>
                            <%# (string)Eval("KPIType") =="KPI" ? Eval("KPIName") :""+Eval("KPIName")%>  
                        </td>
                        <td>
                            <%# ((int) Eval("M1_TARGET") < 0) ? "Not Set" :  Eval("M1_TARGET") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M1_AMOUNT") < 1) ? "00" :  Eval("M1_AMOUNT") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M1_ACH") < 1) ? "00" :  Eval("M1_ACH") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M2_TARGET") < 0) ? "Not Set" :  Eval("M2_TARGET") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M2_AMOUNT") < 1) ? "00" :  Eval("M2_AMOUNT") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M2_ACH") < 1) ? "00" :  Eval("M2_ACH") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M3_TARGET") < 0) ? "Not Set" :  Eval("M3_TARGET") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M3_AMOUNT") < 1) ? "00" :  Eval("M3_AMOUNT") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M3_ACH") < 1) ? "00" :  Eval("M3_ACH") %>
                        </td>
                        <td>
                            <%# ((int) Eval("TotalQuarterAchievement") < 1) ? "00" :  Eval("TotalQuarterAchievement") %>
                           
                        </td>
                        <td style="text-align: center">
                            <%#Eval("QuarterlyAchievementThresholds")%>
                        </td>
                        <td style="text-align: center">
                            <%#Eval("IncentiveEntitlement")%>
                        </td>

                        <td style="text-align: center">
                            <%#Eval("EligibleAsPerConditions")%>
                        </td>
                        <td style="text-align: center">
                            <%# ((int) Eval("EligibleIncentiveAmount") < 1) ? "00" :  Eval("EligibleIncentiveAmount") %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div>
            <div style="margin-top: 10px;">
                <asp:Button ID="DownloadReport" runat="server" Text="Download Achievement" SkinID="btnMediumSkin" OnClick="btnDownloadReport_Click" Style="float: right" />
                <asp:Button ID="DownloadScoreCard" OnClientClick="openInNewTab();" runat="server" Text="Download Scorecard" SkinID="btnMediumSkin" Style="float: left" OnClick="DownloadScoreCard_Click" />
            </div>
        </div>
        <div style="margin-top: 50px;">
            <asp:Label ID="Arrear1lvl" SkinID="ddlCommonSkin" runat="server">Arrear 1 Report:</asp:Label>
        </div>
        <div class="ListViewStyle">
            <asp:ListView ID="Arrear1lv" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin">
                <LayoutTemplate>
                    <table class="datatable" cellpadding="0" cellspacing="0" border="0px">
                        <colgroup>
                            <col />
                            <col />
                            <col />
                            <col />
                            <col />
                            <col />
                            <col />
                            <col />
                        </colgroup>
                        <thead>
                            <tr class="gridheader">
                                <th style="width: 30px">#</th>
                                <th style="width: 200px; text-align: left">KPI Type</th>
                                <th style="width: 150px; text-align: left">KPI Name</th>
                                <%--  <th style="width: 60px">Weightage</th>--%>
                                <th style="width: 80px">Month 1 Target</th>
                                <th style="width: 80px">Month 1 Amount</th>
                                <th style="width: 100px">Month 1 Achievement(%)</th>
                                <th style="width: 80px">Month 2 Target</th>
                                <th style="width: 80px">Month 2 Amount</th>
                                <th style="width: 100px">Month 2 Achievement(%)</th>
                                <th style="width: 80px">Month 3 Target</th>
                                <th style="width: 80px">Month 3 Amount</th>
                                <th style="width: 100px">Month 3 Achievement(%)</th>

                                <th style="width: 100px">Total Quarterly Achievement(%)</th>
                                <th style="width: 80px">Quarterly Achievement Thresholds</th>
                                <th style="width: 100px">Incentive Entitlement(%)</th>
                                <th style="width: 100px">Eligible months of Incentive as per Conditions</th>
                                <th style="width: 100px">Eligible Incentive Amount</th>
                                <th style="width: 100px">Original Report Incentive Amount</th>
                                <th style="width: 100px">Adjustment Incentive Amount</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr id="itemPlaceholder" runat="server" />
                            <asp:PlaceHolder runat="server" ID="item"></asp:PlaceHolder>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr class='<%# Container.DataItemIndex % 2 == 0 ? "row" : "altrow" %>'>
                        <td style="text-align: center">
                            <%# Container.DataItemIndex +1  %>
                        </td>
                        <td>
                            <%#Eval("KPIType")%>
                        </td>
                        <td>
                          <%# (string)Eval("KPIType") =="KPI" ? Eval("KPIName") :""+Eval("KPIName")%>
                        </td>
                        <td>
                            <%# ((int) Eval("M1_TARGET") < 0) ? "Not Set" :  Eval("M1_TARGET") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M1_AMOUNT") < 1) ? "00" :  Eval("M1_AMOUNT") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M1_ACH") < 1) ? "00" :  Eval("M1_ACH") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M2_TARGET") < 0) ? "Not Set" :  Eval("M2_TARGET") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M2_AMOUNT") < 1) ? "00" :  Eval("M2_AMOUNT") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M2_ACH") < 1) ? "00" :  Eval("M2_ACH") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M3_TARGET") < 0) ? "Not Set" :  Eval("M3_TARGET") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M3_AMOUNT") < 1) ? "00" :  Eval("M3_AMOUNT") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M3_ACH") < 1) ? "00" :  Eval("M3_ACH") %>
                        </td>
                        <td>
                            <%# ((int) Eval("TotalQuarterAchievement") < 1) ? "00" :  Eval("TotalQuarterAchievement") %>
                           
                        </td>
                        <td style="text-align: center">
                            <%#Eval("QuarterlyAchievementThresholds")%>
                        </td>
                        <td style="text-align: center">
                            <%#Eval("IncentiveEntitlement")%>
                        </td>

                        <td style="text-align: center">
                            <%#Eval("EligibleAsPerConditions")%>
                        </td>
                        <td style="text-align: center">
                            <%# ((int) Eval("EligibleIncentiveAmount") < 1) ? "00" :  Eval("EligibleIncentiveAmount") %>
                        </td>
                        <td style="text-align: center">
                            <%# ((int) Eval("PreviousIncentiveAmount") < 1) ? "00" :  Eval("PreviousIncentiveAmount") %>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("AdjustIncentiveAmount") %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div style="margin-top: 10px;">
            <asp:Button ID="btnDownloadReportArrear1" runat="server" Text="Download Achievement" SkinID="btnMediumSkin" OnClick="btnDownloadReportArrear1_Click" Style="float: right" />
            <p style="text-indent: 5em;"></p>
            <asp:Button ID="btnDownloadScoreCardArrear1" OnClientClick="openInNewTab();" runat="server" Text="Download Scorecard" SkinID="btnMediumSkin" Style="float: left" OnClick="btnDownloadScoreCardArrear1_Click" />
        </div>
        <div style="margin-top: 50px;">
            <asp:Label ID="Arrear2lvl" SkinID="ddlCommonSkin" runat="server">Arrear 2 Report:</asp:Label>
        </div>
        <div class="ListViewStyle">
            <asp:ListView ID="Arrear2lv" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin">
                <LayoutTemplate>
                    <table class="datatable" cellpadding="0" cellspacing="0" border="0px">
                        <colgroup>
                            <col />
                            <col />
                            <col />
                            <col />
                            <col />
                            <col />
                            <col />
                            <col />
                        </colgroup>
                        <thead>
                            <tr class="gridheader">
                                <th style="width: 30px">#</th>
                                <th style="width: 150px; text-align: left">KPI Type</th>
                                <th style="width: 150px; text-align: left">KPI Name</th>
                                <%--  <th style="width: 60px">Weightage</th>--%>
                                <th style="width: 80px">Month 1 Target</th>
                                <th style="width: 80px">Month 1 Amount</th>
                                <th style="width: 100px">Month 1 Achievement(%)</th>
                                <th style="width: 80px">Month 2 Target</th>
                                <th style="width: 80px">Month 2 Amount</th>
                                <th style="width: 100px">Month 2 Achievement(%)</th>
                                <th style="width: 80px">Month 3 Target</th>
                                <th style="width: 80px">Month 3 Amount</th>
                                <th style="width: 100px">Month 3 Achievement(%)</th>

                                <th style="width: 100px">Total Quarterly Achievement(%)</th>
                                <th style="width: 80px">Quarterly Achievement Thresholds</th>
                                <th style="width: 100px">Incentive Entitlement(%)</th>
                                <th style="width: 100px">Eligible months of Incentive as per Conditions</th>
                                <th style="width: 100px">Eligible Incentive Amount</th>
                                <th style="width: 100px">Arrear1 Report Incentive Amount</th>
                                <th style="width: 100px">Adjustment Incentive Amount</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr id="itemPlaceholder" runat="server" />
                            <asp:PlaceHolder runat="server" ID="item"></asp:PlaceHolder>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr class='<%# Container.DataItemIndex % 2 == 0 ? "row" : "altrow" %>'>
                        <td style="text-align: center">
                            <%# Container.DataItemIndex +1  %>
                        </td>
                         <td>
                            <%#Eval("KPIType")%>
                        </td>
                        <td>
                         <%# (string)Eval("KPIType") =="KPI" ? Eval("KPIName") :""+Eval("KPIName")%> 
                        </td>
                        <td>
                            <%# ((int) Eval("M1_TARGET") < 0) ? "Not Set" :  Eval("M1_TARGET") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M1_AMOUNT") < 1) ? "00" :  Eval("M1_AMOUNT") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M1_ACH") < 1) ? "00" :  Eval("M1_ACH") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M2_TARGET") < 0) ? "Not Set" :  Eval("M2_TARGET") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M2_AMOUNT") < 1) ? "00" :  Eval("M2_AMOUNT") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M2_ACH") < 1) ? "00" :  Eval("M2_ACH") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M3_TARGET") < 0) ? "Not Set" :  Eval("M3_TARGET") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M3_AMOUNT") < 1) ? "00" :  Eval("M3_AMOUNT") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M3_ACH") < 1) ? "00" :  Eval("M3_ACH") %>
                        </td>
                        <td>
                            <%# ((int) Eval("TotalQuarterAchievement") < 1) ? "00" :  Eval("TotalQuarterAchievement") %>
                           
                        </td>
                        <td style="text-align: center">
                            <%#Eval("QuarterlyAchievementThresholds")%>
                        </td>
                        <td style="text-align: center">
                            <%#Eval("IncentiveEntitlement")%>
                        </td>

                        <td style="text-align: center">
                            <%#Eval("EligibleAsPerConditions")%>
                        </td>
                        <td style="text-align: center">
                            <%# ((int) Eval("EligibleIncentiveAmount") < 1) ? "00" :  Eval("EligibleIncentiveAmount") %>
                        </td>
                        <td style="text-align: center">
                            <%# ((int) Eval("PreviousIncentiveAmount") < 1) ? "00" :  Eval("PreviousIncentiveAmount") %>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("AdjustIncentiveAmount") %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div style="margin-top: 10px;">
            <asp:Button ID="btnDownloadReportArrear2" runat="server" Text="Download Achievement" SkinID="btnMediumSkin" OnClick="btnDownloadReportArrear2_Click" Style="float: right" />
            <p style="text-indent: 5em;"></p>
            <asp:Button ID="btnDownloadScoreCardArrear2" OnClientClick="openInNewTab();" runat="server" Text="Download Scorecard" SkinID="btnMediumSkin" Style="float: left" OnClick="btnDownloadScoreCardArrear2_Click" />
        </div>
        <div style="margin-top: 50px;">
            <asp:Label ID="Arrear3lvl" SkinID="ddlCommonSkin" runat="server">Arrear 1 Report:</asp:Label>
        </div>
        <div class="ListViewStyle">
            <asp:ListView ID="Arrear3lv" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin">
                <LayoutTemplate>
                    <table class="datatable" cellpadding="0" cellspacing="0" border="0px">
                        <colgroup>
                            <col />
                            <col />
                            <col />
                            <col />
                            <col />
                            <col />
                            <col />
                            <col />
                        </colgroup>
                        <thead>
                            <tr class="gridheader">
                                <th style="width: 30px">#</th>
                                <th style="width: 150px; text-align: left">KPI Type</th>
                                <th style="width: 150px; text-align: left">KPI Name</th>
                                <%--  <th style="width: 60px">Weightage</th>--%>
                                <th style="width: 80px">Month 1 Target</th>
                                <th style="width: 80px">Month 1 Amount</th>
                                <th style="width: 100px">Month 1 Achievement(%)</th>
                                <th style="width: 80px">Month 2 Target</th>
                                <th style="width: 80px">Month 2 Amount</th>
                                <th style="width: 100px">Month 2 Achievement(%)</th>
                                <th style="width: 80px">Month 3 Target</th>
                                <th style="width: 80px">Month 3 Amount</th>
                                <th style="width: 100px">Month 3 Achievement(%)</th>

                                <th style="width: 100px">Total Quarterly Achievement(%)</th>
                                <th style="width: 80px">Quarterly Achievement Thresholds</th>
                                <th style="width: 100px">Incentive Entitlement(%)</th>
                                <th style="width: 100px">Eligible months of Incentive as per Conditions</th>
                                <th style="width: 100px">Eligible Incentive Amount</th>
                                <th style="width: 100px">Arrear2 Report Incentive Amount</th>
                                <th style="width: 100px">Adjustment Incentive Amount</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr id="itemPlaceholder" runat="server" />
                            <asp:PlaceHolder runat="server" ID="item"></asp:PlaceHolder>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr class='<%# Container.DataItemIndex % 2 == 0 ? "row" : "altrow" %>'>
                        <td style="text-align: center">
                            <%# Container.DataItemIndex +1  %>
                        </td>
                         <td>
                            <%#Eval("KPIType")%>
                        </td>
                        <td>
                          <%# (string)Eval("KPIType") =="KPI" ? Eval("KPIName") :""+Eval("KPIName")%> 
                        </td>
                        <td>
                            <%# ((int) Eval("M1_TARGET") < 0) ? "Not Set" :  Eval("M1_TARGET") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M1_AMOUNT") < 1) ? "00" :  Eval("M1_AMOUNT") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M1_ACH") < 1) ? "00" :  Eval("M1_ACH") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M2_TARGET") < 0) ? "Not Set" :  Eval("M2_TARGET") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M2_AMOUNT") < 1) ? "00" :  Eval("M2_AMOUNT") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M2_ACH") < 1) ? "00" :  Eval("M2_ACH") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M3_TARGET") < 0) ? "Not Set" :  Eval("M3_TARGET") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M3_AMOUNT") < 1) ? "00" :  Eval("M3_AMOUNT") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M3_ACH") < 1) ? "00" :  Eval("M3_ACH") %>
                        </td>
                        <td>
                            <%# ((int) Eval("TotalQuarterAchievement") < 1) ? "00" :  Eval("TotalQuarterAchievement") %>
                           
                        </td>
                        <td style="text-align: center">
                            <%#Eval("QuarterlyAchievementThresholds")%>
                        </td>
                        <td style="text-align: center">
                            <%#Eval("IncentiveEntitlement")%>
                        </td>

                        <td style="text-align: center">
                            <%#Eval("EligibleAsPerConditions")%>
                        </td>
                        <td style="text-align: center">
                            <%# ((int) Eval("EligibleIncentiveAmount") < 1) ? "00" :  Eval("EligibleIncentiveAmount") %>
                        </td>
                        <td style="text-align: center">
                            <%# ((int) Eval("PreviousIncentiveAmount") < 1) ? "00" :  Eval("PreviousIncentiveAmount") %>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("AdjustIncentiveAmount") %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div style="margin-top: 10px;">
            <asp:Button ID="btnDownloadReportArrear3" runat="server" Text="Download Achievement" SkinID="btnMediumSkin" OnClick="btnDownloadReportArrear3_Click" Style="float: right" />
            <p style="text-indent: 5em;"></p>
            <asp:Button ID="btnDownloadScoreCardArrear3" OnClientClick="openInNewTab();" runat="server" Text="Download Scorecard" SkinID="btnMediumSkin" Style="float: left" OnClick="btnDownloadScoreCardArrear3_Click" />
        </div>
        <div id="messageDiv">
            <p style="margin-top: 20px; color: lightcoral"><b><i>**This Calculation is based on available data in the system at the moment!</i></b></p>
        </div>

    </div>
</asp:Content>
