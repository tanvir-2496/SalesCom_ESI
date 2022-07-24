<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="RetailerTermination.aspx.cs" Inherits="PendingApproval" %>

<%@ Register Src="~/UserControl/MessageBox/MessageBoxUserControl.ascx" TagName="MessageBoxUserControl" TagPrefix="ucMB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">

        //function clearResult() {
        //    var result = document.getElementById("result");
        //    result.innerHTML = "";
        //}
    </script>

    <div class="leftPanel"></div>
    <div class="Content">


        <%if (Permissions.RetailerTerminationList)
          { %>

        <div style="text-align: right">
            <p>
                <asp:Button SkinID="btnCommonSkin" runat="server" ID="btnExport" Text="Export" OnClick="btnExport_Click"></asp:Button>
            </p>
        </div>
        <%} %>

        <asp:UpdatePanel ID="up1" runat="server">
            <ContentTemplate>

                <table class="contenttext" style="width: 400px;">

                    <tr>
                        <td>
                            <asp:Label ID="lblRetailerCode" mandatory="true" runat="server" Text="Retailer Code"> </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRetaileCode" CssClass="required" runat="server" Font-Bold="true" onkeyup="this.value=this.value.toUpperCase()">
                            </asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="lblComment" mandatory="true" runat="server" Text="Comment"> </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtComment" CssClass="required" runat="server" TextMode="MultiLine">
                            </asp:TextBox>
                        </td>
                    </tr>

                    <tr class="tdSubmit">
                        <td></td>
                        <td style="text-align: left; padding-left: 3px">
                            <asp:Button ID="btnSave" OnClientClick="return fnValidate();" runat="server" Text="Submit" OnClick="btnSubmit_Click" SkinID="btnCommonSkin" />
                        </td>
                    </tr>
                </table>
                <br />
                <div style="text-align: left; font-weight: bold; color: green">
                    <asp:Label ID="lblMsg" Font-Bold="true" ForeColor="Green" runat="server"> </asp:Label>
                    <ucMB:MessageBoxUserControl ID="mbc" runat="server" />
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
