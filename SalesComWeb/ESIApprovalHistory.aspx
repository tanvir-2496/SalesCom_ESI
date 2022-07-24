<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="ESIApprovalHistory.aspx.cs" Inherits="ESIApprovalHistory" %>

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

    <script type="text/javascript">

    </script>

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

        <tr>
            <th>
                <asp:Label ID="Label2" runat="server" Text="Approval Level"></asp:Label>
            </th>
            <td>
                <asp:Label ID="lblApprovalLevelName" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>

    <div style="max-height: 100%; overflow: auto; width: 100%">
        <asp:ListView ID="lv" runat="server" ItemPlaceholderID="item">
            <LayoutTemplate>
                <table style="margin-top: 10px">
                    <colgroup>
                        <col />
                        <col />
                        <col />
                        <col />
                        <col />
                        <col />
                    </colgroup>
                    <thead>
                        <tr class="listItem">
                            <th style="width: 5%; align-items: flex-start">#</th>
                            <th style="width: 15%; align-items: flex-start">Previous Level</th>
                            <th style="width: 15%; align-items: flex-start">Current Level</th>
                            <th style="width: 15%; align-items: flex-start">Next Level</th>
                            <th style="width: 10%; align-items: flex-start">Approver</th>
                            <th style="width: 10%; align-items: flex-start">Status</th>
                            <th style="width: 15%; align-items: flex-start">Comments</th>
                            <th style="width: 15%; align-items: flex-start">Date</th>
                            <%--<th style="align-items: flex-start">File</th>--%>
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
                    <td style="width: 5%; align-items: flex-start">
                        <%# Container.DataItemIndex +1  %>
                    </td>
                    <td style="width: 15%; align-items: flex-start">

                    </td>
                    <td style="width: 15%; align-items: flex-start">
                        <%#Eval("APPROVALLEVELNAME")%>
                    </td>
                    <td style="width: 15%; align-items: flex-start">

                    </td>
                    <td style="width: 10%; align-items: flex-start">
                        <%#Eval("user_name")%>
                    </td>
                    <td style="width: 10%; align-items: flex-start">
                        <%#Eval("STATUS")%>
                    </td>
                    <td style="width: 15%; align-items: flex-start;">
                        <%#Eval("COMMENTS")%>
                    </td>
                    <td style="width: 15%; align-items: flex-start">
                        <%#Common.DateTimeFormat(Eval("CREATE_DATE")) %>
                    </td>
                    <%-- <%#Eval("FTYPE") != null ? String.Format("<td style='text-align:center'><a href='DownloadSRFile.aspx?id={0}&fileex={1}&Type=3' target='_blank'>Content</a></td>", Eval("approval_status_log_id"), Eval("FTYPE")) : "<td style='text-align:center'> No Content </td>"  %> --%>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>




    <div class="msg">
        <asp:Label ID="lblMsg" runat="server">
    
        </asp:Label>
    </div>

</asp:Content>
