<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="AdHocSummaryReport.aspx.cs" Inherits="PendingApproval" %>

<%@ Register Src="~/UserControl/datetimePicker/WebUserControl.ascx" TagName="WebUserControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:WebUserControl ID="WebUserControl1" runat="server" />
    <script type="text/javascript">
        function refreshWindow() {
            ModifyLeftpanel();
        }

    </script>

    <div class="leftPanel"></div>
    <div class="Content">

        <asp:UpdatePanel ID="upCycle" runat="server">
            <ContentTemplate>
                <table style="width: 350px;">

                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Report Name" mandatory="true" SkinID="lblCommonSkin"> </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlReportName" runat="server" CssClass="required" SkinID="ddlLargeSkin">
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="lblStarGererationDate" runat="server" Text="Report Between" mandatory="true" SkinID="lblCommonSkin"> </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtDate" CssClass="date required">
                            </asp:TextBox>
                            <a id="a2" runat="server">
                                <img src="UserControl/datetimePicker/themes/img.gif" id="btnLetterRefDate" style="cursor: hand;"
                                    align="absmiddle" onmouseover="ShowDate(this);" /></a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEndGenerationdate" runat="server" Text="And " mandatory="true" SkinID="lblCommonSkin"> </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtToDate" runat="server" SkinID="txtDate" CssClass="date required">
                            </asp:TextBox>
                            <a id="a1" runat="server">
                                <img src="UserControl/datetimePicker/themes/img.gif" id="Img1" style="cursor: hand;"
                                    align="absmiddle" onmouseover="ShowDate(this);" /></a>
                        </td>



                    </tr>
                    <tr>
                        <td>
                            <td align="left">
                                <asp:Button ID="btnShow" OnClientClick="return fnValidate();" runat="server" Text="Show" OnClick="btnShow_Click" SkinID="btnCommonSkin" ValidationGroup="Date" ClientIDMode="Static" />
                            </td>
                        </td>
                    </tr>

                </table>

                <br />
                <hr />
                <br />

                <div class="ListViewStyle">
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

                                </colgroup>
                                <thead>
                                    <tr class="gridheader">
                                        <th>#</th>
                                        <th style="text-align: left; padding-left: 4px;">Report Date(s)</th>
                                        <th>Commission Amount</th>
                                        <th>AIT</th>
                                        <th>Disburse Amount</th>
                                        <th>Details</th>
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
                                    <%#Eval("REPORT_DURATION")%>
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("COMMISSION_AMOUNT")%>
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("AIT") %>
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("DISBURSE_AMOUNT")%>
                                </td>

                                <td style="text-align: center">
                                    <asp:LinkButton ID="lbtnDetailsAmount" runat="server" CommandName="DetailsAmount" Text="Detail" />
                                </td>

                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </div>


            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div>
        <asp:Label ID="lblResults" CssClass="gridResults" runat="server" Text="Label"></asp:Label>
    </div>

</asp:Content>
