<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupPeriodAdd.aspx.cs" Inherits="SetupActivityAdd" %>

<%@ Register Src="~/UserControl/datetimePicker/WebUserControl.ascx" TagName="WebUserControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:WebUserControl ID="WebUserControl1" runat="server" />
    <table class="contenttext" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblPeriodTypeId" mandatory="true" runat="server" Text="Period Type"> </asp:Label>
            </td>
            <td>
                <%--   <asp:TextBox ID="txtPeriodTypeId" CssClass="required" runat="server" SkinID="txtCommonSkin">
                </asp:TextBox>--%>
                <asp:DropDownList ID="ddlPeriodTypeId" runat="server" SkinID="ddlCommonSkin" CssClass="required"></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblStartDate" runat="server" Text="Start Date" mandatory="true" > </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtStartDate" CssClass="date required" runat="server" SkinID="txtDate">
                </asp:TextBox>
                <a id="a1" runat="server">
                    <img src="UserControl/datetimePicker/themes/img.gif" id="Img1" style="cursor: hand;"
                        align="absmiddle" onmouseover="ShowDate(this);" /></a>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblEndDate" runat="server" Text="End Date" mandatory="true" > </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEndDate" runat="server" SkinID="txtDate" CssClass="date required">
                </asp:TextBox>
                <a id="a2" runat="server">
                    <img src="UserControl/datetimePicker/themes/img.gif" id="Img2" style="cursor: hand;"
                        align="absmiddle" onmouseover="ShowDate(this);" /></a>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblMonth" runat="server" Text="Month"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlMonth" runat="server">
                    <asp:ListItem Text="SELECT" Value="SELECT" Selected="True"></asp:ListItem>

                    <asp:ListItem Text="JAN" Value="JAN"></asp:ListItem>
                    <asp:ListItem Text="FEB" Value="FEB"></asp:ListItem>
                    <asp:ListItem Text="MAR" Value="MAR"></asp:ListItem>

                    <asp:ListItem Text="APR" Value="APR"></asp:ListItem>
                    <asp:ListItem Text="MAY" Value="MAY"></asp:ListItem>
                    <asp:ListItem Text="JUN" Value="JUN"></asp:ListItem>

                    <asp:ListItem Text="JUL" Value="JUL"></asp:ListItem>
                    <asp:ListItem Text="AUG" Value="AUG"></asp:ListItem>
                    <asp:ListItem Text="SEP" Value="SEP"></asp:ListItem>

                    <asp:ListItem Text="OCT" Value="OCT"></asp:ListItem>
                    <asp:ListItem Text="NOV" Value="NOV"></asp:ListItem>
                    <asp:ListItem Text="DEC" Value="DEC"></asp:ListItem>


                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblPeriodDate" runat="server" Text="Period Date" mandatory="true" > </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPeriodDate" CssClass="date required" runat="server" SkinID="txtDate">
                </asp:TextBox>
                <a id="a3" runat="server">
                    <img src="UserControl/datetimePicker/themes/img.gif" id="Img3" style="cursor: hand;"
                        align="absmiddle" onmouseover="ShowDate(this);" /></a>
            </td>
        </tr>

        <tr>

            <td class="tdSubmit" colspan="2">
                <asp:Button ID="btnSave" OnClientClick="return fnValidate();" runat="server" Text="Save" OnClick="btnSave_Click" SkinID="btnCommonSkin" />

            </td>
        </tr>
    </table>
    <div class="msg">
        <asp:Label ID="lblMsg" runat="server">
    
        </asp:Label>
    </div>
</asp:Content>

