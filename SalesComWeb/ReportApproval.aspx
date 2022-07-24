<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="ReportApproval.aspx.cs" Inherits="ReportApproval" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        select, label {
            display: block;
        }

        label {
            padding: 6px 0px;
            text-shadow: 1px 2px 2px rgba(255, 255, 255, 0.4);
        }
        a.disabled {
          pointer-events: none;
          cursor: default;
        }
        a.hidden {
            visibility: hidden;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function refreshWindow() {
            ModifyLeftpanel();
            document.getElementById('<%= btnRefresh.ClientID %>').click();
        }
    </script>

    <div class="leftPanel"></div>
    <div class="Content">

        <asp:UpdatePanel ID="upCycle" runat="server">
            <Triggers>
            </Triggers>

            <ContentTemplate>
                <div>
                    <div style="float: left; margin-right: 20px; width:250px">
                        <label for="ddlSalesGroup">Sales Group</label>
                        <asp:DropDownList style="width:200px" ID="ddlSalesGroup" runat="server" AutoPostBack="true" SkinID="ddlCommonSkin" OnSelectedIndexChanged="ddl_SalesGroup_IndexChanged">
                        <asp:ListItem Text="[Select One]" Value="0"></asp:ListItem>     
                        </asp:DropDownList>
                    </div>
                    <div style="float: left; margin-right: 20px; width:100px">
                        <label for="ddlReportType">Report Type</label>
                        <asp:DropDownList style="width:100px" ID="ddlReportType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_IndexChanged">
                            <asp:ListItem Text="[Select One]" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Quarterly" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Monthly" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Arrear_1" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Arrear_2" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Arrear_3" Value="5"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div style="float: left; margin-right: 20px; width:250px">
                        <label for="ddlSalesChannel">Sales Channel</label>
                        <asp:DropDownList style="width:200px" ID="ddlSalesChannel" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_IndexChanged">
                        <asp:ListItem Text="[Select One]" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div style="float: left; margin-right: 20px; width:100px">
                        <label for="ddlYear">Year </label>
                        <asp:DropDownList style="width:100px" ID="ddlYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_IndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div style="float: left; margin-right: 20px; width:100px">
                        <label for="ddlQuarter">Quarter</label>
                        <asp:DropDownList style="width:100px" ID="ddlQuarter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_IndexChanged">
                            <asp:ListItem Text="[Select One]" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Q1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Q2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Q3" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Q4" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div style="float: left; margin-right: 20px; width:100px">
                        <label for="ddlMonth">Month</label>
                        <asp:DropDownList style="width:100px" ID="ddlMonth" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_IndexChanged">
                            <asp:ListItem Text="[Select One]" Value="0"></asp:ListItem>
                            <asp:ListItem Text="M1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="M2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="M3" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </div> 
                </div>
                <br style="clear: both;" />
                <br />
                <hr />
                <br />
                <asp:Button ID="btnRefresh" Style="display: none" runat="server" OnClick="btnRefresh_Click" />
                <div class="ListViewStyle">
                    <%--<asp:ListView ID="lv" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin" OnItemCommand="lv_ItemCommand" OnItemDataBound="lv_ItemDataBound">--%>
                    <asp:ListView ID="lv" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin" OnItemCommand="lv_ItemCommand" OnItemDataBound="lv_ItemDataBound">    
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
                                        <th>#</th>
                                        <th style="text-align: left">Report Name</th>
                                        <th>Level</th>
                                        <th>Halt KPI for Arrear</th>
                                        <th>Approval</th>
                                        <th>View</th>
                                      <%--  <th>Edit(Month)</th>--%>
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
                                    <%#Eval("report_name")%>
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("current_level")%>
                                </td>
                                <%# Convert.ToInt32(Eval("order_id")) == 1 && CheckReportElgibileForHalt(Convert.ToInt32(Eval("report_cycle_id"))) == true && Permissions.ESIKpiConfigure == true && CheckLevelPermission(Convert.ToString(Eval("current_level"))) == true? String.Format("<td style='text-align: center'><a href='HaltKPIforArrear.aspx?ID={0}&RN={1}&ORDER_ID={2}&CURRENT_LEVEL={3}&TB_iframe=true&height=400&width=550' class='thickbox' title='Halt KPI for Arrear'>Action</a></td>", Eval("report_cycle_id"), Eval("report_name"), Eval("order_id"), Convert.ToString(Eval("current_level"))) : String.Format("<td style='text-align: center'><a href='HaltKPIforArrear.aspx?ID={0}&RN={1}&ORDER_ID={2}&CURRENT_LEVEL={3}&TB_iframe=true&height=400&width=550' class='thickbox' title='Halt KPI for Arrear'>View</a></td>", Eval("report_cycle_id"), Eval("report_name"), Eval("order_id"), Convert.ToString(Eval("current_level"))) %>

                                <%# Convert.ToInt32(Eval("order_id")) != 1 && CheckApprovalPermission(Convert.ToInt32(Eval("report_cycle_id"))) == true && Permissions.ESIReportApprovalAct == true && CheckLevelPermission(Convert.ToString(Eval("current_level"))) == true ? String.Format("<td style='text-align: center'><a href='ReportApprovalAct.aspx?ID={0}&RN={1}&ALN={2}&OI={3}&TB_iframe=true&height=400&width=550' class='thickbox' title='Target Approval Process'>Approve/Reject</a></td>", Eval("approval_status_id"), Eval("report_name"), Eval("current_level"), Eval("order_id")) : String.Format("<td style='text-align: center'><a href='ReportApprovalHistory.aspx?ID={0}&RN={1}&ALN={2}&TB_iframe=true&height=400&width=550' class='thickbox' title='Report Approval History'>View</a></td>", Eval("approval_status_id"), Eval("report_name"), Eval("current_level")) %>

                                <td style="text-align: center">
                                    <asp:LinkButton ID="lbtnDetailsAmount" runat="server" CommandName="DetailsAmount" CommandArgument='<%#Eval("report_cycle_id")%>' Text="Detail" />
                                </td>

                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
                <div class="footer">
                    <asp:Label ID="lblResults" CssClass="gridResults" runat="server" Text="Label"></asp:Label>
                    <div class="pager">
                        <asp:DataPager ID="pager" runat="server" PagedControlID="lv" PageSize="10" OnPreRender="pager_PreRender">
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
</asp:Content>

