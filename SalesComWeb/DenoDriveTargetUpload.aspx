<%@ Page Title="Target Upload" Language="C#" MasterPageFile="~/MasterPages/default.master" AutoEventWireup="true" CodeFile="DenoDriveTargetUpload.aspx.cs" Inherits="DenoDriveTargetUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        var validFilesTypes = ["xlsx", "xls"];
        function ValidateFile() {
            var file = document.getElementById("<%=FileUpload1.ClientID%>");
            var label = document.getElementById("<%=lblResult.ClientID%>");
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
                label.innerHTML = "Invalid File, please upload file with extensions: " + validFilesTypes.join(" or ");
            }
            return isValidFile;
        }

        function refreshWindow() {
            ModifyLeftpanel();
            document.getElementById('<%= btnRefresh.ClientID %>').click();
        }

        function DenoTargetValidation() {
            $("span[id$=lblResult]").html("");
            return true;
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="leftPanel"></div>

    <div class="Content">
        <div style="text-align: right;margin-right:8px">
            <asp:button style="width: 100px" id="btnDownloadSample" runat="server" skinid="btnCommonSkin" text="Sample File" onclick="btnDownloadSample_Click" />
        </div>

        <asp:updatepanel id="upReportname" runat="server">
            <ContentTemplate>
                <table class="contenttext" style="width: 100%;">
                    <tr>
                            <td>

                                <asp:Label ID="lblReportName" runat="server" Text="Campaign Name" SkinID="lblCommonSkin"></asp:Label>

                                <asp:DropDownList ID="ddlReportName" runat="server" SkinID="ddlCommonSkin" CssClass="required"  AutoPostBack="true" AppendDataBoundItems="true" >
                                </asp:DropDownList>

                            </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:Panel ID="Panel1" runat="server">
                                <asp:Label ID="blb" runat="server" Text="Select File" SkinID="lblCommonSkin"> </asp:Label>
                                <asp:FileUpload ID="FileUpload1" runat="server" type="file" />
                            </asp:Panel>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Panel ID="Panel3" runat="server">
                            <asp:Button ID="btnUpload" runat="server" Text="Upload Target" OnClick="btnUpload_Click" OnClientClick="return ValidateFile()" SkinID="btnCommonSkin" style="width: auto;" />
                            <br />
                            <asp:Label ID="lblMessage" runat="server" Text="" SkinID="lblErrorMsgSkin" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnUpload" />
            </Triggers>
        </asp:updatepanel>

        <table class="contenttext" style="width: 100%;">
            <tr>
                <asp:panel id="Panel2" runat="server" visible="false">
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
                            <asp:Button ID="btnSave"  OnClientClick="return DenoTargetValidation();" runat="server" Text="Save" OnClick="btnSave_Click" SkinID="btnCommonSkin" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" SkinID="btnCommonSkin" />
                        </div>
                    </td>
                </asp:panel>
            </tr>
            <tr>
                <td style="background: #cbc7c7; color: #f00; font-weight: bolder">
                    <asp:label id="lblResult" runat="server" skinid="lblErrorMsgSkin"></asp:label>
                </td>
            </tr>
        </table>

        <div>
            <asp:updatepanel id="lstpanel" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnRefresh" Style="display: none" runat="server" OnClick="btnRefresh_Click" />
                    <div class="ListViewStyle">
                        <asp:ListView ID="lv" runat="server" ItemPlaceholderID="item" SkinID="ListviewSkin">
                            <LayoutTemplate>
                                <table class="datatable" cellpadding="0" cellspacing="0" border="0px">
                                    <colgroup>
                                        <col />
                                        <col />

                                    </colgroup>
                                    <thead>
                                        <tr class="gridheader">
                                            <th>Row Number
                                            </th>
                                            <th>Error Text
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr id="itemPlaceholder1" runat="server" />
                                        <asp:PlaceHolder runat="server" ID="item"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr class='<%# Container.DataItemIndex % 2 == 0 ? "row" : "altrow" %>'>
                                    <td>
                                        <%#Eval("RowNumber")%>&nbsp;
                                    </td>
                                    <td>
                                        <%#Eval("ErrorText")%>&nbsp;
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                    <div class="footer">
                        <asp:Label ID="lblResults" CssClass="gridResults" runat="server" Text=""></asp:Label>
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
            </asp:updatepanel>
        </div>
    </div>

</asp:Content>

