<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="TargetApprovalAct.aspx.cs" Inherits="TargetApprovalAct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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

        function ConfirmationDialog(type) {
            var actType = 'Are you sure you want to ' + type + ' ?';
            var con = confirm(actType);

            if (con == false) {
                return false;
            }
            else {

                var btnApp = document.getElementById('<%=btnApprove.ClientID%>');
                var btnRej = document.getElementById('<%=btnReject.ClientID%>');
                if (btnApp) { btnApp.disabled = true; }
                if (btnRej) { btnRej.disabled = true; }
                if (type == 'approve') {
                    btnApp.value = 'Approving ...'
                }
                else {
                    btnRej.value = 'Rejecting ...'
                }
                return true;
            }
        };

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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

        <tr>
            <th>
                <asp:Label ID="lblComments" runat="server" Text="Comments"> </asp:Label>
            </th>
            <td>
                <asp:TextBox ID="txtComments" runat="server" MaxLength="300" onkeyDown="return checkTextAreaMaxLength(this,event,'300');" TextMode="MultiLine" Height="40" Width="385px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="lblImageTypeFileUpLoad" runat="server" Text="Attachment"> </asp:Label>
            </th>
            <td>
                <asp:FileUpload ID="ImageTypeFileUpLoad" runat="server" type="file" />
            </td>
        </tr>
    </table>

    <div id="wrapper">
        <div id="leftcolumn">
            <asp:Button ID="btnApprove" runat="server" Text="Approve" SkinID="btnMediumSkin" OnClick="btnApprove_Click" OnClientClick="if (!ConfirmationDialog('approve')){ return false }" UseSubmitBehavior="false" />
        </div>
        <div id="rightcolumn">
            <asp:Button ID="btnReject" runat="server" Text="Reject" SkinID="btnMediumSkin" OnClick="btnReject_Click" OnClientClick="if (!ConfirmationDialog('reject')){ return false }" UseSubmitBehavior="false" />
        </div>
    </div>


    <div style="max-height: 200px; overflow: auto; width: 100%">
        <asp:ListView ID="lv" runat="server" ItemPlaceholderID="item">
            <LayoutTemplate>
                <table>
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
                        <tr class="listItem">
                            <th style="width: 5%; align-items: flex-start">#</th>
                            <th style="width: 20%; align-items: flex-start">Level</th>
                            <th style="width: 20%; align-items: flex-start">Approver</th>
                            <th style="width: 12%; align-items: flex-start">Status</th>
                            <th style="width: 23%; align-items: flex-start">Comments</th>
                            <th style="width: 12%; align-items: flex-start">Date</th>
                            <th style="align-items: flex-start">File</th>
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
                    <td style="width: 20%; align-items: flex-start">
                        <%#Eval("APPROVALLEVELNAME")%>
                    </td>
                    <td style="width: 20%; align-items: flex-start">
                        <%#Eval("user_name")%>
                    </td>
                    <td style="width: 12%; align-items: flex-start">
                        <%#Eval("STATUS")%>
                    </td>
                    <td style="width: 23%; align-items: flex-start;">
                        <%#Eval("COMMENTS")%>
                    </td>
                    <td style="width: 12%; align-items: flex-start">
                        <%#Common.DateTimeFormat(Eval("CREATE_DATE")) %>
                    </td>
                    <%#Eval("FTYPE") != null ? String.Format("<td style='text-align:center'><a href='DownloadSRFile.aspx?id={0}&fileex={1}&Type=3' target='_blank'>Content</a></td>", Eval("approval_status_log_id"), Eval("FTYPE")) : "<td style='text-align:center'> No Content </td>"  %>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>

    <div style="background: #cbc7c7; color: #f00; font-weight: bolder; width: 100%; height: 16px; position: fixed; left: 0; bottom: 0">
        <asp:Label ID="lblResult" runat="server" SkinID="lblErrorMsgSkin"></asp:Label>
    </div>

    <div class="msg">
        <asp:Label ID="lblMsg" runat="server">
    
        </asp:Label>
    </div>

</asp:Content>

