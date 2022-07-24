<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="HaltKPIforArrear.aspx.cs" Inherits="TargetView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #wrapper {
            margin: 0 auto;
        }

        #leftcolumn, #rightcolumn {
            float: left;
            padding: 2px 5px;
        }

        td, th {
            padding: 5px 5px 5px 5px;
            font-family: Verdana;
        }

        tr.listItem td, tr.listItem th {
            border: 1px solid;
        }

        tr.listItem:nth-child(even) {
            background-color: #EEEEEE;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="contenttext" style="width: 100%">
        <tr>
            <th>
                <asp:Label ID="Label4" runat="server" Text="Report Name"></asp:Label>
            </th>
            <td>
                <asp:Label ID="lblReportName" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>

    <div style="max-height: 400px; overflow: auto; width: 100%" >
        <asp:ListView ID="lv" runat="server" ItemPlaceholderID="item" OnItemCommand="lv_ItemCommand" OnItemDataBound="lv_ItemDataBound">
            <LayoutTemplate>
                <table style="width: 100%; margin-top: 10px">
                    <colgroup>
                        <col />
                        <col />
                        <col />
                        <col />
                        <col />
                    </colgroup>
                    <thead>
                        <tr class="listItem">
                            <%--<th style="width: 5%; align-items: flex-start">#</th>--%>
                            <th style="width: 30%; align-items: flex-start">KPI Name</th>
                            <th style="width: 30%; align-items: flex-start">Sub KPI Name</th>
                            <th style="width: 10%; align-items: flex-start">Status</th>
                            <th style="width: 10%; align-items: flex-start">Halt For Arrear</th>
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
                    <%--<td style="width: 5%; align-items: flex-start">
                        <%# Container.DataItemIndex +1  %>
                    </td>--%>
                    <td style="width: 30%; align-items: flex-start">
                        <%#Eval("KPI_NAME")%>
                    </td>
                    <td style="width: 30%; align-items: flex-start">
                        <%#Eval("SUB_KPI_NAME")%>
                    </td>
                    <td style="width: 10%; align-items: flex-start">
                        <%#Eval("HALT_STATUS")%>
                    </td>
                    <td style="width: 10%; text-align: center; align-items: flex-start">
                        <asp:LinkButton ID="lbtnHaltKPIforArrear" runat="server" CommandName="HaltKPIforArrear" CommandArgument= '<%#Eval("KPI_ID")+","+ Eval("SUB_KPI_ID")%>' Text="Halt" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>

    

    <div style="background: #cbc7c7; color: #f00; font-weight: bolder; width: 100%; height: 16px; position: fixed; left: 0; bottom: 0">
        <asp:Label ID="lblResult" runat="server" SkinID="lblErrorMsgSkin"></asp:Label>
    </div>

</asp:Content>

