<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="DisableKPISubKPICondition.aspx.cs" Inherits="DisableKPISubKPICondition" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <table class="contenttext" style="width: 400px;">
            <tr>
                <td>
                    <asp:Label ID="Label1" SkinID="lblCommonSkin" mandatory="true" runat="server" Text="Sales Group"> </asp:Label>
                </td>
                <td>
                    <asp:DropDownList Style="width: 200px" ID="ddlSalesGroup" runat="server" AutoPostBack="true" SkinID="ddlCommonSkin">
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="lblSearchType" SkinID="lblCommonSkin" runat="server" Text="Search Type" mandatory="true"> </asp:Label>
                </td>
                <td>          
                    <asp:RadioButtonList name="input" ID="rblSearchType"  runat="server">
                        <asp:ListItem  Value="1">KPI</asp:ListItem>
                        <asp:ListItem Value="2">Sub KPI</asp:ListItem>
                        <asp:ListItem Value="3">Condition</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSearchName" runat="server" Text="Name" SkinID="lblCommonSkin"> </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSeachName" runat="server" SkinID="txtCommonSkin">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdSubmit" colspan="2">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" SkinID="btnCommonSkin" />
                </td>
            </tr>
        </table>
        <div class="msg">
            <asp:Label ID="lblMsg" runat="server">
    
            </asp:Label>
        </div>
    </center>
<div class="ListViewStyle">
<asp:ListView ID="lvKPIView" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin">
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
                    <th>Serial</th>
                    <th>Sales Group</th>
                    <th>KPI Name</th>
                    <th>Display Name</th>
                    <th>KPI Remarks</th>
                    <th>Financial KPI</th>
                    <th>Status</th>
                    <th>Active</th>
                    <th>Deactive</th>
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
                <%#Eval("Sales_Group_Name")%>
            </td>
            <td>
                <%#Eval("Kpi_Name")%>
            </td>
            <td>
                <%#Eval("Display_Name")%>
            </td>
            <td>
                <%#Eval("Remarks")%>
            </td>
            <td>
                <%#Eval("IS_FINANCIAL")%>
            </td>
            <td>
                <%#Eval("Is_Active")%>
            </td>
            <td style="text-align: center">
                <asp:Button ID="btnActivateKPI" class="loadButtonEx" runat="server" Text="Active" OnClick="btnActivateKPI_Click" CommandArgument='<%#Eval("Kpi_id") %>' />
            </td>
            <td style="text-align: center">
                <asp:Button ID="btnDeactivateKPI" class="loadButtonEx" runat="server" Text="Deactive" OnClick="btnDeactivateKPI_Click" CommandArgument='<%#Eval("Kpi_id") %>' />
            </td>
        </tr>
    </ItemTemplate>
</asp:ListView>
</div>

<div class="ListViewStyle">
<asp:ListView ID="lvSubKPIView" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin">
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
                    <th>Serial</th>
                    <th>Sales Group</th>
                    <th>KPI Name</th>
                    <th>Sub KPI Name</th>
                    <th>Display Name</th>
                    <th>Sub KPI Remarks</th>
                    <th>Financial SubKPI</th>
                    <th>Status</th>
                    <th>Active</th>
                    <th>Deactive</th>
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
                <%#Eval("Sales_Group_Name")%>
            </td>
            <td>
                <%#Eval("kpi_name")%>
            </td>
            <td>
                <%#Eval("subkpi_name")%>
            </td>
            <td>
                <%#Eval("display_name")%>
            </td>
            <td>
                <%#Eval("remarks")%>
            </td>
            <td>
                <%#Eval("IS_FINANCIAL")%>
            </td>
            <td>
                <%#Eval("Is_Active")%>
            </td>
            <td style="text-align: center">
                <asp:Button ID="btnActivateSubKPI" class="loadButtonEx" runat="server" Text="Active" OnClick="btnActivateSubKPI_Click" CommandArgument='<%#Eval("subkpi_id") %>' />
            </td>
            <td style="text-align: center">
                <asp:Button ID="btnDeactivateSubKPI" class="loadButtonEx" runat="server" Text="Dactive" OnClick="btnDeactivateSubKPI_Click" CommandArgument='<%#Eval("subkpi_id") %>' />
            </td>
        </tr>
    </ItemTemplate>
</asp:ListView>
</div>

<div class="ListViewStyle">
<asp:ListView ID="lvConditionView" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin">
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
                    <th>Serial</th>
                    <th>Sales Group</th>
                    <th>KPI Name</th>
                    <th>Sub KPI Name</th>
                    <th>Condition Name</th>
                    <th>Display Name</th>
                    <th>Conditon Remarks</th>
                    <th>Status</th>
                    <th>Active</th>
                    <th>Deactive</th>
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
                <%#Eval("Sales_Group_Name")%>
            </td>
            <td>
                <%#Eval("kpi_name")%>
            </td>
            <td>
                <%#Eval("subkpi_name")%>
            </td>
            <td>
                <%#Eval("condition_name")%>
            </td>
            <td>
                <%#Eval("display_name")%>
            </td>
            <td>
                <%#Eval("remarks")%>
            </td>
            <td>
                <%#Eval("Is_Active")%>
            </td>
            <td style="text-align: center">
                <asp:Button ID="btnActivateCondition" class="loadButtonEx" runat="server" Text="Active"  OnClick="btnActivateCondition_Click" CommandArgument='<%#Eval("Condition_id") %>' />
            </td>
            <td style="text-align: center">
                <asp:Button ID="btnDeactivateCondition" class="loadButtonEx" runat="server" Text="Deactive"  OnClick="btnDeactivateCondition_Click" CommandArgument='<%#Eval("Condition_id") %>' />
            </td>
        </tr>
    </ItemTemplate>
</asp:ListView>
</div>
</asp:Content>


