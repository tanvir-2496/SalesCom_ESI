<%@ Page Title="Campaign Setup" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="SetupDailyDenoCampain.aspx.cs" Inherits="SetupDailyDenoCampain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function refreshWindow() {
            debugger;
            ModifyLeftpanel();
            document.getElementById('<%= btnRefresh.ClientID %>').click();
        }


        function sortTable(table, col, reverse) {
           
            var tb = table.tBodies[0],
                tr = Array.prototype.slice.call(tb.rows, 0),
                i;
            reverse = -((+reverse) || -1);
            tr = tr.sort(function (a, b) {

                if (a.cells.length > 0) {

                    return reverse
                        * (a.cells[col].textContent.trim()
                            .localeCompare(b.cells[col].textContent.trim())
                           );
                }
            });
            for (i = 0; i < tr.length; ++i) tb.appendChild(tr[i]);
        }

        function makeSortable(table) {
            var th = table.tHead;
            var i;
            th = th && (th = th.rows[0]) && (th = th.cells);
            if (th) i = th.length;
            else return;
            while (--i >= 0) (function (i) {
                var dir = 1;
                th[i].addEventListener('click', function () { sortTable(table, i, (dir = 1 - dir)) });
            }(i));
        }

        function makeAllSortable() {
            debugger;
            parent = document.body;
            var t = parent.getElementsByClassName('datatable'), i = t.length;
            while (--i >= 0) makeSortable(t[i]);
        }
        //   window.onload = function () { makeAllSortable(); };
        $(window).load(function () { makeAllSortable(); });

    </script>

    <div class="leftPanel"></div>
    <div class="Content">


        <% if (Permissions.DailyCampaignAdd)
           { %>
        <div style="text-align: right">
            <input type="button" value="Add New" alt="SetupDailyDenoCampainAdd.aspx?keepThis=false&TB_iframe=true&height=300&width=450"
                class="thickbox" title="Daily Deno Campaign Add" />
        </div>
        <%          }%>


        <asp:UpdatePanel ID="lstpanel" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnRefresh" Style="display: none" runat="server" OnClick="btnRefresh_Click" />
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
                                    <col />
                                    <col />
                                </colgroup>
                                <thead>


                                    <tr class="gridheader">
                                        <th>#
                                        </th>
                                        <th>Campaign Name
                                        </th>
                                        <th>Campaign Start Date
                                        </th>
                                        <th>Campaign End Date
                                        </th>
                                         <th>Upper Cap
                                        </th>
                                        <th>Is Stop
                                        </th>
                                       <th>User Action
                                       </th>
                                        <th>Upload Target
                                       </th>
                                        <th>Download Target
                                       </th>
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
                                    <%#Eval("CampaignName")%>
                                </td>
                                <td style="text-align: center">
                                    <%#Convert.ToDateTime(Eval("CampaignStartDate")).ToString("dd-MMM-yyyy")%>
                                </td>
                                <td style="text-align: center">
                                    <%#Convert.ToDateTime(Eval("CampaignEndDate")).ToString("dd-MMM-yyyy")%>
                                </td>
                                 <td style="text-align: center">
                                    <%#Eval("UpperCap")%>
                                </td>
                                <td style="text-align: center">
                                    <%#Eval("IsActive")%>
                                </td>
                               <td style="text-align: center"> 
                                   <span onclick="return confirm('Are you sure to Stop?')">
                                        <asp:Button ID="btnStop" runat="server" Text="Stop"  OnClick="btnStop_Click" CommandArgument='<%#Eval("CampaignID")%>' />
                                   </span>
                               </td>
                                <td style="text-align: center">
                                    <a  style="<%# ((Convert.ToDateTime(Convert.ToString(Eval("CampaignEndDate"))) >= DateTime.Now.Date)&&(Convert.ToString(Eval("IsActive")) == "N")&&(Permissions.DailyCampaignUpdate == true))? "" : "display:none"%> "  href="DailyDenoDriveTargetUpload.aspx?CampaignID=<%#Eval("CampaignID")%>">Upload</a>
                                </td>
                                 <td style="text-align: center">
                                    <asp:LinkButton ID="lbtnDownloadTarget" runat="server" CommandName="DownloadTarget" CommandArgument='<%#Eval("CampaignID")%>' Text="Download" />
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
                
                <div>
                    <tr>
                        <td style="background: #cbc7c7; color: #f00; font-weight: bolder">
                            <asp:label id="lblMessage" runat="server" skinid="lblErrorMsgSkin"></asp:label>
                        </td>
                      </tr>
                </div>


            </ContentTemplate>

        </asp:UpdatePanel>
    </div>

</asp:Content>

