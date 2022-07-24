<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="SetupCommissionReportSegmentsAdd.aspx.cs" Inherits="SetupLevelUserAdd20" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function Changed(textControl) {

            //SegmentChanged(textControl);

            debugger;

            var minParcentage = parseInt(document.getElementById("txtMinTarget").value);
            var maxParcentage = parseInt(document.getElementById("txtMaxTarget").value);

            var segmentAmount = parseInt(document.getElementById("txtSegmentAmount").value);
            var eventPercentage = parseInt(document.getElementById("txtEventPercentage").value);

            var txtBoxAmount = document.getElementById("txtAmount");
            var txtBoxMinAmount = document.getElementById("txtMinTargetAmount");
            var txtBoxMaxAmount = document.getElementById("txtMaxTargetAmount");

            var isMinExist = 1;
            var isMaxExist = 1;
            var isSegmentExist = 1;
            var isEventPercentageExist = 1;


            if (textControl.id == 'txtEventPercentage') {

                if (isNaN(segmentAmount) || isNaN(eventPercentage)) {

                    if (isNaN(textControl.id !== 'txtSegmentAmount')) {
                        isSegmentExist = 0;
                        alert('Segment Amount required!');
                        setTimeout(function () { document.getElementById("txtSegmentAmount").focus(); }, 1);
                    }
                    else if (textControl.id !== 'txtEventPercentage') {
                        isEventPercentageExist = 0;
                        alert('Event Percentage Required!');
                        setTimeout(function () { document.getElementById("txtEventPercentage").focus(); }, 1);
                    }
                }
            }

            if (isSegmentExist === 1 && isEventPercentageExist === 1) {

                var segment = parseInt(segmentAmount);
                var event = parseInt(eventPercentage);

                var Amount = ((segment * event) / 100).toString();

                if (!isNaN(Amount)) {
                    txtBoxAmount.value = Amount;
                }
            }


            if (textControl.id == 'txtMinTarget' || textControl.id == 'txtMaxTarget' || textControl.id == 'txtAmount') {
                if (isNaN(minParcentage) || isNaN(maxParcentage)) {

                    if (isNaN(minParcentage)) {
                        isMinExist = 0;
                        alert('Minimum Parcentage Required!');
                        setTimeout(function () { document.getElementById("txtMinTarget").focus(); }, 1);
                    }
                    else if (textControl.id !== 'txtMinTarget') {
                        isMaxExist = 0;
                        alert('Maximum Parcentage Required!');
                        setTimeout(function () { document.getElementById("txtMaxTarget").focus(); }, 1);
                    }
                }
            }

            if (isMinExist === 1 && isMaxExist === 1) {
                var amount = parseInt(txtBoxAmount.value);
                var minAmount = (amount * (minParcentage / 100)).toString();
                var maxAmount = (amount * (maxParcentage / 100)).toString();

                if (!isNaN(amount)) {
                    txtBoxMinAmount.value = minAmount;
                    txtBoxMaxAmount.value = maxAmount;
                }
            }
        }

    </script>

    <style type="text/css">
        .required {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <table class="contenttext" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblReportId" mandatory="true" runat="server" Text="Report Name" SkinID="lblCommonSkin"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlReportName" CssClass="required" runat="server" SkinID="ddlCommonSkin">
                </asp:DropDownList>
            </td>

        </tr>

        <tr>
            <td>
                <asp:Label ID="lblSegmentId" mandatory="true" runat="server" Text="Segment Name" SkinID="lblCommonSkin"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSegmentId" CssClass="required" runat="server" SkinID="ddlCommonSkin">
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="txtSegmentAmount" CssClass="required" runat="server" SkinID="txtAmmount" ClientIDMode="Static" onchange='javascript: Changed( this );'>
                </asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblEventTypeId" mandatory="true" runat="server" Text="Event Type" SkinID="lblCommonSkin"> </asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlEventTypeId" CssClass="required" runat="server" SkinID="ddlCommonSkin">
                </asp:DropDownList>
            </td>
            <td>

                <asp:TextBox ID="txtEventPercentage" CssClass="required" runat="server" SkinID="txtAmmount" ClientIDMode="Static" onchange='javascript: Changed( this );'>
                </asp:TextBox>

            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblMinimumTargent" mandatory="true" runat="server" Text="Min Target %" SkinID="lblCommonSkin"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMinTarget" CssClass="required" runat="server" SkinID="txtAmmount" ClientIDMode="Static" onchange='javascript: Changed( this );'>
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMaximumTarget" mandatory="true" runat="server" Text="Max Target %" SkinID="lblCommonSkin"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMaxTarget" CssClass="required" runat="server" SkinID="txtAmmount" ClientIDMode="Static" onchange='javascript: Changed( this );'>
                </asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblAmount" mandatory="true" runat="server" Text="Amount" SkinID="lblCommonSkin"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAmount" CssClass="required" runat="server" SkinID="txtAmmount" ClientIDMode="Static" onchange='javascript: Changed( this );'>
                </asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblMinTargetAmount" mandatory="true" runat="server" Text="Min Target Amount" SkinID="lblCommonSkin"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMinTargetAmount" CssClass="required" runat="server" SkinID="txtAmmount" ClientIDMode="Static">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMaxTargetAmount" mandatory="true" runat="server" Text="Max Target Amount" SkinID="lblCommonSkin"> </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMaxTargetAmount" CssClass="required" runat="server" SkinID="txtAmmount" ClientIDMode="Static">
                </asp:TextBox>
            </td>
        </tr>


        <tr>

            <td class="tdSubmit" colspan="5">
                <asp:Button ID="btnSave" OnClientClick="return fnValidate();" runat="server" Text="Save" OnClick="btnSave_Click" SkinID="btnCommonSkin" />

            </td>

        </tr>
    </table>

    <div class="msg">
        <asp:Label ID="lblMsg" runat="server">
    
        </asp:Label>
    </div>

</asp:Content>

