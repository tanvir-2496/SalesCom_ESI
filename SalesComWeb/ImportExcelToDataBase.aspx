<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="ImportExcelToDataBase.aspx.cs" Inherits="ImportExcelToDataBase" Culture="en-GB" %>

<%@ Register Src="~/UserControl/datetimePicker/WebUserControl.ascx" TagName="WebUserControl"
    TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        var validFilesTypes = ["xlsx", "xls"];
        function ValidateFile() {
            var file = document.getElementById("<%=FileUpload1.ClientID%>");
            var label = document.getElementById("<%=lblMessage.ClientID%>");
            var path = file.value;
            var ext = path.substring(path.lastIndexOf(".") + 1, path.length).toLowerCase();
            var isValidFile = false;
            for (var i = 0; i < validFilesTypes.length; i++) {
                if (ext == validFilesTypes[i]) {
                    isValidFile = true;
                    break;
                }
            }
            if (!isValidFile) {
                label.style.color = "red";
                label.innerHTML = "Invalid File. Please upload a File with" + " extension:\n\n" + validFilesTypes.join(", ");
            }
            return isValidFile;
        }

        function refreshWindow() {
            ModifyLeftpanel();
            document.getElementById('<%= btnRefresh.ClientID %>').click();
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:WebUserControl ID="WebUserControl1" runat="server" />
    <div class="leftPanel"></div>
    <div class="Content">

        <table class="contenttext" style="width: 600px;">

            <tr>
                <td>
                    <asp:Label ID="lblImportDate" runat="server" Text="Import Date" SkinID="lblCommonSkin"> </asp:Label>
                    <asp:TextBox ID="txtImportDate" runat="server" SkinID="txtDate" CssClass="date required" ClientIDMode="Static">
                   
                    </asp:TextBox>

                    <a id="a2" runat="server">
                        <img src="UserControl/datetimePicker/themes/img.gif" id="btnLetterRefDate" style="cursor: hand;"
                            align="absmiddle" onmouseover="ShowDate(this);" /></a>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Panel ID="Panel1" runat="server">
                        <asp:FileUpload ID="FileUpload1" runat="server" type="file" />
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" OnClientClick="return ValidateFile()" SkinID="btnCommonSkin" />
                        <br />
                        <asp:Label ID="lblMessage" runat="server" Text="" SkinID="lblErrorMsgSkin" />
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <table class="contenttext" style="width: 600px;">

            <tr>
                <asp:Panel ID="Panel2" runat="server" Visible="false">
                    <td>
                        <div>
                            <asp:Label ID="Label5" runat="server" Text="File Name" SkinID="lblCommonSkin" />

                            <asp:Label ID="lblFileName" runat="server" Text="" SkinID="lblCommonSkin" />
                        </div>
                        <br />
                        <div>
                            <asp:Label ID="Label2" runat="server" Text="Select Sheet" SkinID="lblCommonSkin" />
                            <asp:DropDownList ID="ddlSheets" runat="server" AppendDataBoundItems="true" SkinID="ddlCommonSkin" OnDataBound="ddlSheets_DataBound">
                            </asp:DropDownList>
                        </div>
                        <br />
                        <div>
                            <asp:Label ID="Label1" runat="server" Text="Has Header Row?" SkinID="lblCommonSkin" />
                            <asp:DropDownList ID="rbHDR" runat="server" SkinID="ddlSmallSkin">
                                <asp:ListItem Text="Yes" Value="Yes" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <br />
                        <div>
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" SkinID="btnCommonSkin" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" SkinID="btnCommonSkin" />
                        </div>
                    </td>
                </asp:Panel>
            </tr>
            <tr>
                <td style="background: #cbc7c7; color: #f00; font-weight: bolder">
                    <asp:Label ID="lblResult" runat="server" SkinID="lblErrorMsgSkin"></asp:Label>
                </td>
            </tr>
        </table>

        <div>
            <asp:UpdatePanel ID="lstpanel" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnRefresh" Style="display: none" runat="server" OnClick="btnRefresh_Click" />
                    <div class="ListViewStyle">
                        <asp:ListView ID="lv" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin">
                            <LayoutTemplate>
                                <table class="datatable" cellpadding="0" cellspacing="0" border="0px">
                                    <colgroup>
                                        <col />
                                        <col />
                                        <col />
                                        <col />

                                    </colgroup>
                                    <thead>


                                        <tr class="gridheader">
                                            <th>Row Number
                                            </th>
                                            <th>Error Text
                                            </th>
                                            <th>Sim Number
                                            </th>
                                            <th>MSISDN
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
                                    <%-- <td style="text-align: center">
                                    <%# Container.DataItemIndex +1  %>
                                </td>--%>
                                    <td>
                                        <%#Eval("RowNumber")%>&nbsp;
                                    </td>
                                    <td>
                                        <%#Eval("ErrorText")%>&nbsp;
                                    </td>
                                    <td>
                                        <%#Eval("SimNo")%>&nbsp;
                                    </td>
                                    <td>
                                        <%#Eval("MSISDN")%>&nbsp;
                                    </td>


                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                    <div class="footer">
                        <asp:Label ID="lblResults" CssClass="gridResults" runat="server" Text="Label"></asp:Label>
                        <div class="pager">
                            <asp:DataPager ID="pager" runat="server" PagedControlID="lv" PageSize="15" OnPreRender="pager_PreRender">
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
    </div>



</asp:Content>

