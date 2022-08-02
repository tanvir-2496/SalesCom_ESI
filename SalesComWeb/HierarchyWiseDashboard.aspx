<%@ Page Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="HierarchyWiseDashboard.aspx.cs" Inherits="HierarchyWiseDashboard" Title="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .labelClass {
        width:200px;
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

    <div class="leftPanel"></div>
    <div class="Content" style="margin: auto; width: 90%">
        <div style="float: left; width: 45%">
            <asp:Chart ID="KPIChart" runat="server" Height="280px" Palette="EarthTones" Width="593px" BackColor="247, 247, 247" BackHatchStyle="BackwardDiagonal">
                <Series>
                    <asp:Series ChartType="Bar" Name="KpiAchievement" ChartArea="KPIName">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="KPIName">
                        <Area3DStyle Enable3D="True" LightStyle="Realistic" Rotation="10" />
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
        <div style="float: right; width: 45%">
            <div style="float: right; border: double 1px red; padding-bottom: 30px; padding-top: 10px;margin-bottom:5px;margin-right:5px; padding-left: 30px;padding-right: 30px">
                <div>
                    <div class="labelClass">    
                        <label for="ddlSalesChannel">Sales Channel</label>
                    </div>
                        <asp:DropDownList SkinID="ddlCommonSkin" ID="ddlSalesChannel" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                <div>
                    <div class="labelClass">
                        <label for="ddlYear">Year </label>
                    </div>
                    <asp:DropDownList SkinID="ddlCommonSkin" ID="ddlYear" runat="server" OnSelectedIndexChanged="ddl_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
                <div>
                    <div  class="labelClass">
                        <label for="ddlQuarter">Quarter</label>
                    </div>
                    <asp:DropDownList SkinID="ddlCommonSkin" ID="ddlQuarter" OnSelectedIndexChanged="ddl_SelectedIndexChanged" runat="server" AutoPostBack="true">
                        <asp:ListItem Text="---Select----" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Q1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Q2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Q3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Q4" Value="4"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div>
                    <div  class="labelClass">
                         <label for="ddlMonth">Month</label>
                    </div> 
                        <asp:DropDownList ID="ddlMonth" SkinID="ddlCommonSkin" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_SelectedIndexChanged">
                            <asp:ListItem Text="[Select One]" Value="0"></asp:ListItem>
                            <asp:ListItem Text="M1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="M2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="M3" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                   <div>
                    <div  class="labelClass">
                        <label id="lbl_ddl_CXO_Role"  runat="server" for="ddl_CXO_Role">Reportee</label>
                    </div>
                    <asp:DropDownList SkinID="ddlCommonSkin" ID="ddl_CXO_Role" runat="server" OnSelectedIndexChanged="ddl_CXO_RoleSelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
                <div>
                    <div  class="labelClass">
                        <label id="Div_HoDnDirectorRoles" runat="server" for="ddlClusterDirectors">Reportee</label>
                    </div>
                    <asp:DropDownList SkinID="ddlCommonSkin" ID="ddlHoDnDirectorRoles" runat="server" OnSelectedIndexChanged="ddl_HoDnDirectorRolesSelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
                <div>
                    <div  class="labelClass">
                        <label id="Div_RegionalHead"  runat="server" for="ddlRegionalHead">Reportee</label>
                    </div>
                    <asp:DropDownList ID="ddlRegionalHead" skinid="ddlCommonSkin" runat="server" OnSelectedIndexChanged="ddl_RegionalHeadSelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
               
                   <div>
                    <div  class="labelClass">
                        <label id="Div_Sales_Employee"  runat="server" for="ddlSalesEmployee">Reportee</label>
                    </div>
                    <asp:DropDownList ID="ddlSalesEmployee" skinid="ddlCommonSkin" runat="server" OnSelectedIndexChanged="ddl_SalesEmployeeSelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
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
                                <%--<th style="/*width: 30px*/">#</th>--%>
                                <th style="width: 150px; text-align: left">KPI Name</th>
                                <th style="width: 150px; text-align: left">KPI Type</th>
                                <th style="width: 80px">Month 1 Amount</th>
                                <th style="width: 100px">Month 1 Achievement(%)</th>
                                <th style="width: 80px">Month 2 Amount</th>
                                <th style="width: 100px">Month 2 Achievement(%)</th>
                                <th style="width: 80px">Month 3 Amount</th>
                                <th style="width: 100px">Month 3 Achievement(%)</th>
                                <th style="width: 100px">Total Quarterly Achievement(%)</th>
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
<%--                        <td style="text-align: center">
                            <%# Container.DataItemIndex +1  %>
                        </td>--%>
                        <td style="text-align:<%#(string)Eval("KPIType") == "KPI" ? "left;font-weight: bold;" : "right"%>">
                            <%#Eval("KPIName")%>
                        </td>
                        <td style="text-align:<%#(string)Eval("KPIType") == "KPI" ? "left" : "right"%>">
                            <%# Eval("KPIType")%>
                        </td>
                        <td>
                            <%#Eval("M1_AMOUNT")%>
                        </td>
                        <td>
                            <%#Eval("M1_ACH")%>
                        </td>
                        <td>
                            <%#Eval("M2_AMOUNT")%>
                        </td>
                        <td>
                            <%#Eval("M2_ACH")%>
                        </td>
                        <td>
                            <%#Eval("M3_AMOUNT")%>
                        </td>
                        <td>
                            <%#Eval("M3_ACH")%>
                        </td>
                        <td>
                            <%#Eval("TotalQuarterAchievement")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>

        </div>
        <br />
        <asp:Label ID="Arrear1lvl" skinid="ddlCommonSkin" runat ="server">Arrear 1 Report:</asp:Label>
        <br />
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
                                <%--<th style="width: 30px">#</th>--%>
                                <th style="width: 150px; text-align: left">KPI Name</th>
                                <th style="width: 150px; text-align: left">KPI Type</th>
                                <th style="width: 80px">Month 1 Amount</th>
                                <th style="width: 100px">Month 1 Achievement(%)</th>
                                <th style="width: 80px">Month 2 Amount</th>
                                <th style="width: 100px">Month 2 Achievement(%)</th>
                                <th style="width: 80px">Month 3 Amount</th>
                                <th style="width: 100px">Month 3 Achievement(%)</th>
                                <th style="width: 100px">Total Quarterly Achievement(%)</th>
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
<%--                        <td style="text-align: center">
                            <%# Container.DataItemIndex +1  %>
                        </td>--%>
                        <td style="text-align:<%#(string)Eval("KPIType") == "KPI" ? "left;font-weight: bold;" : "right"%>">
                            <%#Eval("KPIName")%>
                        </td>
                        <td style="text-align:<%#(string)Eval("KPIType") == "KPI" ? "left" : "right"%>">
                            <%# Eval("KPIType")%>
                        </td>
                        <td>
                            <%#Eval("M1_AMOUNT")%>
                        </td>
                        <td>
                            <%#Eval("M1_ACH")%>
                        </td>
                        <td>
                            <%#Eval("M2_AMOUNT")%>
                        </td>
                        <td>
                            <%#Eval("M2_ACH")%>
                        </td>
                        <td>
                            <%#Eval("M3_AMOUNT")%>
                        </td>
                        <td>
                            <%#Eval("M3_ACH")%>
                        </td>
                        <td>
                            <%#Eval("TotalQuarterAchievement")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>

        </div>
        <br />
        <asp:Label ID="Arrear2lvl" skinid="ddlCommonSkin" runat ="server">Arrear 2 Report:</asp:Label>
        <br />
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
                        </colgroup>
                        <thead>
                            <tr class="gridheader">
                                <%--<th style="width: 30px">#</th>--%>
                                <th style="width: 150px; text-align: left">KPI Name</th>
                                <th style="width: 150px; text-align: left">KPI Type</th>
                                <th style="width: 80px">Month 1 Amount</th>
                                <th style="width: 100px">Month 1 Achievement(%)</th>
                                <th style="width: 80px">Month 2 Amount</th>
                                <th style="width: 100px">Month 2 Achievement(%)</th>
                                <th style="width: 80px">Month 3 Amount</th>
                                <th style="width: 100px">Month 3 Achievement(%)</th>
                                <th style="width: 100px">Total Quarterly Achievement(%)</th>
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
 <%--                       <td style="text-align: center">
                            <%# Container.DataItemIndex +1  %>
                        </td>--%>
                        <td style="text-align:<%#(string)Eval("KPIType") == "KPI" ? "left;font-weight: bold;" : "right"%>">
                            <%#Eval("KPIName")%>
                        </td>
                        <td style="text-align:<%#(string)Eval("KPIType") == "KPI" ? "left" : "right"%>">
                            <%# Eval("KPIType")%>
                        </td>
                        <td>
                            <%#Eval("M1_AMOUNT")%>
                        </td>
                        <td>
                            <%#Eval("M1_ACH")%>
                        </td>
                        <td>
                            <%#Eval("M2_AMOUNT")%>
                        </td>
                        <td>
                            <%#Eval("M2_ACH")%>
                        </td>
                        <td>
                            <%#Eval("M3_AMOUNT")%>
                        </td>
                        <td>
                            <%#Eval("M3_ACH")%>
                        </td>
                        <td>
                            <%#Eval("TotalQuarterAchievement")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>

        </div>
        <br />
        <asp:Label ID="Arrear3lvl" skinid="ddlCommonSkin" runat ="server">Arrear 3 Report:</asp:Label>
        <br />
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
                                <th style="width: 150px; text-align: left">KPI Name</th>
                                <th style="width: 150px; text-align: left">KPI Type</th>
                                <th style="width: 80px">Month 1 Amount</th>
                                <th style="width: 100px">Month 1 Achievement(%)</th>
                                <th style="width: 80px">Month 2 Amount</th>
                                <th style="width: 100px">Month 2 Achievement(%)</th>
                                <th style="width: 80px">Month 3 Amount</th>
                                <th style="width: 100px">Month 3 Achievement(%)</th>
                                <th style="width: 100px">Total Quarterly Achievement(%)</th>
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
<%--                        <td style="text-align: center">
                            <%# Container.DataItemIndex +1  %>
                        </td>--%>
                        <td style="text-align:<%#(string)Eval("KPIType") == "KPI" ? "left;font-weight: bold;" : "right"%>">
                            <%#Eval("KPIName")%>
                        </td>
                        <td style="text-align:<%#(string)Eval("KPIType") == "KPI" ? "left" : "right"%>">
                            <%# Eval("KPIType")%>
                        </td>
                        <td>
                            <%#Eval("M1_AMOUNT")%>
                        </td>
                        <td>
                            <%#Eval("M1_ACH")%>
                        </td>
                        <td>
                            <%#Eval("M2_AMOUNT")%>
                        </td>
                        <td>
                            <%#Eval("M2_ACH")%>
                        </td>
                        <td>
                            <%#Eval("M3_AMOUNT")%>
                        </td>
                        <td>
                            <%#Eval("M3_ACH")%>
                        </td>
                        <td>
                            <%#Eval("TotalQuarterAchievement")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>

        </div>
         <div id="messageDiv">
            <p style="margin-top:20px;color:lightcoral"><b><i>**This Calculation is based on available data in the system at the moment!</i></b></p>
        </div>
    </div>
</asp:Content>
