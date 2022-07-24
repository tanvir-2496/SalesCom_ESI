<%@ Page Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="RedisburseApprovalAction.aspx.cs" Inherits="RedisburseApprovalAction" %>


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
            /*font-size:smaller;*/
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
         }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="contenttext" style="width: 100%">
        <tr>
            <th>
                <asp:Label ID="Label4" runat="server" Text="Report:"></asp:Label>
            </th>
            <td>
                <asp:Label ID="lblReportName" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="Label5" runat="server" Text="Duration:"></asp:Label>
            </th>
            <td>
                <asp:Label ID="lblReportDuration" runat="server" Text=""></asp:Label>
            </td>
        </tr>

        <tr>
            <th>
                <asp:Label ID="Label2" runat="server" Text="Level:"></asp:Label>
            </th>
            <td>
                <asp:Label ID="lblApprovalLevelName" runat="server" Text=""></asp:Label>
            </td>
        </tr>

         <tr>
            <th>
                <asp:Label ID="lblWithheld" runat="server" Text="Withheld:"></asp:Label>
            </th>
            <td>
                <asp:Label ID="lblWithheldAmount" runat="server" Text=""></asp:Label>
            </td>
        </tr>

         <tr>
            <th>
                <asp:Label ID="lblRedisburse" runat="server" Text="Re-disburse:"></asp:Label>
            </th>
            <td>
                <asp:Label ID="lblRedisburseAmount" runat="server" Text=""></asp:Label>
            </td>
        </tr>

        <tr>
            <th>
                <asp:Label ID="lblComments" runat="server" Text="Comments:"> </asp:Label>
            </th>
            <td>
                <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Height="60" Width="300px" BorderStyle="Double"></asp:TextBox>
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
                    </colgroup>
                    <thead>
                        <tr class="listItem">
                            <th style="width: 5%; align-items: flex-start">#</th>
                            <th style="width: 20%; align-items: flex-start">Level</th>
                            <th style="width: 20%; align-items: flex-start">Approver</th>
                            <th style="width: 12%; align-items: flex-start">Status</th>
                            <th style="width: 23%; align-items: flex-start">Comments</th>
                            <th style="width: 12%; align-items: flex-start">Date</th>
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

                </tr>
            </ItemTemplate>
        </asp:ListView>

    </div>

    <div class="msg">
        <asp:Label ID="lblMsg" runat="server">
    
        </asp:Label>
    </div>
</asp:Content>


