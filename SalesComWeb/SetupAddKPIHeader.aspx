<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupAddKPIHeader.aspx.cs" Inherits="SetupAddKPIHeader" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript">
        function ValidateKPIHeader() {
            var kpiHeaderName = $.trim($("#<%=txtKpiName.ClientID%>").val());
            var salesGroupId = $.trim($("#<%=ddlSalesGroup.ClientID%>").val());
            var isOk = true;

            $("#ContentPlaceHolder1_ddlSalesGroup").css('border-color', '');
            $("#ContentPlaceHolder1_txtKpiName").css('border-color', '');

            if (salesGroupId == "0") {
                $("#ContentPlaceHolder1_ddlSalesGroup").css('border-color', 'red');
                isOk = false;
            }

            if (kpiHeaderName == "") {
                $("#ContentPlaceHolder1_txtKpiName").css('border-color', 'red');
                isOk = false;
            }
            return isOk;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
    <table class="contenttext" style="width:400px; ">

         <tr>
            <td>
                <asp:Label ID="lblSalesGroup" mandatory="true" runat="server" Text="Sales Group"> </asp:Label>
            </td>
            <td>
              <asp:DropDownList style="width:200px" ID="ddlSalesGroup" CssClass="required" runat="server" AutoPostBack="false" SkinID="ddlCommonSkin">
               </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblKpiName" mandatory="true" runat="server" Text="KPI Header Name"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtKpiName" CssClass="required" runat="server" SkinID="txtCommonSkin">
            </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdSubmit" colspan="2">
                <asp:Button ID="btnSave" OnClientClick ="return ValidateKPIHeader();" runat="server" Text="Save" OnClick="btnSave_Click" SkinID="btnCommonSkin"/>
            </td>
        </tr>
    </table>
    <div class="msg" >
        <asp:Label ID="lblMsg" runat="server">
    
        </asp:Label>
    </div>
        </center>
    <div style="text-align:left;width:90%;padding-top:10px">
        <ul>
            <li>Red asterisk(<b style="color:red">*</b>) sign means that filling in the field is mandatory in order to Add KPI Header.</li>
        </ul>
    </div>
        
</asp:Content>

