<%@ Page Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="InitiateClaimSubmit.aspx.cs" Inherits="InitiateClaimSubmit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        var validFilesTypes = ["xlsx", "xls"];
        function ValidateFile() {
            var file = document.getElementById("<%=fuExcelFiles.ClientID%>");
            var label = document.getElementById("<%=lblMessage.ClientID%>");
            var lblMessageBox = document.getElementById("<%=lblResult.ClientID%>")
            var path = file.value;
            var ext = path.substring(path.lastIndexOf(".") + 1, path.length).toLowerCase();
            var isValidFile = false;
            for (var i = 0; i < validFilesTypes.length; i++) {
                if (ext == validFilesTypes[i]) {
                    isValidFile = true;
                    break;
                }
            }

            debugger;

            if (path === '') {
                label.style.color = "red";
                label.innerHTML = "Please select a file with extension: " + validFilesTypes.join(" or ") + ".";
                lblMessageBox.innerHTML = "";
            }
            else if (!isValidFile) {
                label.style.color = "red";
                label.innerHTML = "Invalid file type, please select a file with extension: " + validFilesTypes.join(" or ") + ".";
                lblMessageBox.innerHTML = "";
            }
            
            return isValidFile;
        }

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:PlaceHolder ID="refresh_script" Visible="false" runat="server">
        <script type="text/javascript">
            parent.refreshWindow();

        </script>
    </asp:PlaceHolder>

    <div style="position: relative">
        <div style="right: 0; position: absolute; top: 0">
            <asp:Button ID="Button1" runat="server" SkinID="btnCommonSkin" Text="Template" OnClick="btnDownloadSample_Click" />
        </div>
        <table class="contenttext" style="width: 100%;">
            <tr>
                <th>
                    <asp:Label ID="lblReportName" runat="server" Text="Report Name :" SkinID="lblSmallSkin"> </asp:Label>
                    <asp:Label ID="lblSetReportName" runat="server" Font-Names="verdana" Font-Size="Small"> </asp:Label>
                </th>

            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblCommission" runat="server" Text="Commission :" SkinID="lblSmallSkin"> </asp:Label>
                    <asp:Label ID="lblCommissionAmount" runat="server" Font-Names="verdana" Font-Size="Small"> </asp:Label>
                </th>
            </tr>
        </table>
    </div>

    <asp:UpdatePanel ID="upControls" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
            <asp:PostBackTrigger ControlID="btnDuplicate" />
        </Triggers>
        <ContentTemplate>
            <div>
                <asp:Panel ID="plUpload" runat="server">
                    <table class="contenttext" style="width: 100%;">
                        <tr>
                            <th>
                                <asp:Label ID="blb" runat="server" Text="Select File" SkinID="lblSmallSkin"> </asp:Label>
                                <asp:FileUpload ID="fuExcelFiles" runat="server" type="file" Enabled="false" />
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="" SkinID="lblSmallSkin"> </asp:Label>
                                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" OnClientClick="return ValidateFile()" SkinID="btnCommonSkin" Enabled="false" />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="background: #cbc7c7; color: #f00; font-weight: bold">
                                <asp:Label ID="lblMessage" runat="server" Text="" SkinID="lblErrorMsgSkin" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>

            <div>
                <asp:Panel ID="plImport" runat="server" Visible="false">
                    <table class="contenttext" style="width: 100%;">
                        <tr>
                            <td>
                                <div>
                                    <asp:Label ID="Label5" runat="server" Text="File Name :" SkinID="lblCommonSkin" />
                                    <asp:Label ID="lblFileName" runat="server" Text="" Font-Names="verdana" Font-Size="Small" />
                                </div>
                            
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>

            <div>
                <asp:Panel ID="plClaimProcess" runat="server">
                    <table class="contenttext" style="width: 100%;">

                        <tr>
                            <th>
                                <asp:Label ID="lblHashInput" runat="server" Text="Has Discard List? :" SkinID="lblCommonSkin" />
                                <asp:CheckBox ID="chkHasInput" runat="server" Checked="false" OnCheckedChanged="chkHasInput_CheckedChanged" AutoPostBack="true" />
                            </th>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="lblOperation" runat="server" Text="Operations :" SkinID="lblCommonSkin" />
                                <asp:Button ID="btnLoad" runat="server" Text="Load" OnClick="btnLoad_Click" SkinID="btnCommonSkin" Visible="false" />
                                <asp:Button ID="btnSubmit" runat="server" Text="Initiate" OnClick="btnSubmit_Click" SkinID="btnCommonSkin"  OnClientClick="this.disabled=true;" UseSubmitBehavior="false"/>
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" SkinID="btnCommonSkin" Visible="false" />
                                <asp:Button ID="btnDuplicate" runat="server" Text="Duplicate" OnClick="btnDuplicate_Click" SkinID="btnCommonSkin" Visible="false" />
                            </th>
                        </tr>
                        <tr>
                            <td style="background: #cbc7c7; color: #f00; font-weight: bolder">
                                <asp:Label ID="lblResult" runat="server" SkinID="lblErrorMsgSkin"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>

            <div>
                <asp:Panel ID="plDataGrid" runat="server" Visible="false">
                    <table class="contenttext">
                        <tr>
                            <td style="width: 100%; padding: 10px 10px">
                                <asp:GridView runat="server" ID="gvLoadData" CellPadding="3" CellSpacing="2" ShowFooter="True" OnDataBound="gvLoadData_DataBound" AutoGenerateColumns="true">
                                    <AlternatingRowStyle BackColor="#FFF6E6" />
                                    <FooterStyle BackColor="#F37821" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="false" />
                                    <HeaderStyle BackColor="#F37821" Font-Bold="False" Font-Italic="False" Font-Names="Verdana" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

