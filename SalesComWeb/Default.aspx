<%@ Page Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Home" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function refreshWindow() {
            ModifyLeftpanel();
        }

    </script>


    <div class="leftPanel"></div>
    <div class="Content" style="margin: auto; width: 90%">
        <%--<div style="float: left; width: 45%">
            <asp:Chart ID="KPIChart" runat="server" Height="238px" Palette="EarthTones" Width="593px" BackColor="247, 247, 247">
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
       
            <div style="float: right; width: 100%; margin-bottom: 10px">
                <div style="float: left; margin-right: 20px">
                    <label for="ddlYear">Year </label>
                    <asp:DropDownList ID="ddlYear" runat="server" OnSelectedIndexChanged="ddl_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
                <div style="float: left; margin-right: 20px">
                    <label for="ddlQuarter">Quarter</label>
                    <asp:DropDownList ID="ddlQuarter" OnSelectedIndexChanged="ddl_SelectedIndexChanged" runat="server" AutoPostBack="true">
                        <asp:ListItem Text="---Select----" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Q1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Q2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Q3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Q4" Value="4"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div style="width: 100%;">
                <asp:ListView ID="ListViewTarget" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin">
                    <LayoutTemplate>
                        <table class="datatable" cellpadding="0" cellspacing="0" border="0px">
                            <caption><b>Target</b></caption>
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
                                    <th style="width: 20px">#</th>
                                    <th style="width: 200px; text-align: left">KPI Name</th>
                                    <th style="width: 100px">Month 1</th>
                                    <th style="width: 100px">Month 2</th>
                                    <th style="width: 100px">Month 3</th>
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
                                <%#Eval("KPIName")%>
                            </td>
                            <td>
                                <%# ((int) Eval("M1") < 1) ? "Not Set" :  Eval("M1") %>
                            </td>
                            <td>
                                <%# ((int) Eval("M2") < 1) ? "Not Set" :  Eval("M2") %>
                            </td>
                            <td>
                                <%# ((int) Eval("M3") < 1) ? "Not Set" :  Eval("M3") %>
                            </td>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>


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
                                <th style="width: 150px; text-align: left">KPI Name</th>
                                  <th style="width: 60px">Weightage</th>
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
                            <%#Eval("KPIName")%>
                        </td>
                          <td>
                            <%#Eval("Weightage")%>
                        </td>
                        <td>
                            <%# ((int) Eval("M1_TARGET") < 1) ? "Not Set" :  Eval("M1_TARGET") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M1_AMOUNT") < 1) ? "Pending.." :  Eval("M1_AMOUNT") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M1_ACH") < 1) ? "Pending.." :  Eval("M1_ACH") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M2_TARGET") < 1) ? "Not Set" :  Eval("M2_TARGET") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M2_AMOUNT") < 1) ? "Pending.." :  Eval("M2_AMOUNT") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M2_ACH") < 1) ? "Pending.." :  Eval("M2_ACH") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M3_TARGET") < 1) ? "Not Set" :  Eval("M3_TARGET") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M3_AMOUNT") < 1) ? "Pending.." :  Eval("M3_AMOUNT") %>
                        </td>
                        <td>
                            <%# ((int) Eval("M3_ACH") < 1) ? "Pending.." :  Eval("M3_ACH") %>
                        </td>
                        <td>
                            <%# ((int) Eval("TotalQuarterAchievement") < 1) ? "Pending.." :  Eval("TotalQuarterAchievement") %>
                           
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
                            <%# ((int) Eval("EligibleIncentiveAmount") < 1) ? "Pending.." :  Eval("EligibleIncentiveAmount") %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>

        </div>--%>
    </div>
</asp:Content>
