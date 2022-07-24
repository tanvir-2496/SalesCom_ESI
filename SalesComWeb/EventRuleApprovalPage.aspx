<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="EventRuleApprovalPage.aspx.cs" Inherits="SetupEventRule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <!-- This goes in the document HEAD so IE7 and IE8 don't cry -->
    <!--[if lt IE 9]>
	<style type="text/css">
		table.gradienttable th {
			filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#d5e3e4', endColorstr='#b3c8cc',GradientType=0 );
			position: relative;
			z-index: -1;
		}
		table.gradienttable td {
			filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#ebecda', endColorstr='#ceceb7',GradientType=0 );
			position: relative;
			z-index: -1;
		}
	</style>
	<![endif]-->
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div style="padding-top: 10px;">
        <table class="gradienttable">

            <tr>
              
            </tr>
            <tr>
                <th>
                    <p>Report	</p>
                </th>
                <td colspan="2">
                    <asp:Label ID="lblReportName" runat="server"></asp:Label>
                </td>

            </tr>

            <tr>
                <th>
                    <p>Event	</p>
                </th>
                <td colspan="2">
                    <asp:Label ID="lblEventName" runat="server"></asp:Label>
                </td>

            </tr>

        </table>

    </div>
    <br />

    <div>
        <table class="gradienttable" id="one">
            <tr>
                <th>
                    <p>Fields</p>
                </th>
                <td>Current Value
                </td>
                <td>Altered Value
                </td>
            </tr>



            <tr>
                <th>
                    <p>Event Rule Name</p>
                </th>
                <td>
                    <asp:Label ID="lblEventRuleName" runat="server"></asp:Label>
                    <asp:HiddenField runat="server" ID="hfEventRuleName" />
                </td>
                <td>
                    <asp:Label ID="lblEventRuleAltered" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <th>
                    <p>Segment	</p>
                </th>
                <td>
                    <asp:Label ID="lblSegment" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSegmentAltered" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <th>
                    <p>Min Amount	</p>
                </th>
                <td>
                    <asp:Label ID="lblMinAmount" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblMinAmountAltered" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    <p>Max Amount	</p>

                </th>
                <td>
                    <asp:Label ID="lblMaxAmount" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblMaxAmountAltered" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    <p>Amount Type	</p>
                </th>
                <td>
                    <asp:Label ID="lblAmountType" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAmountTypeAltered" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    <p>Commission Type	</p>
                </th>
                <td>
                    <asp:Label ID="lblCommissionType" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCommissionTypeAltered" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    <p>Commission Value	</p>
                </th>
                <td>
                    <asp:Label ID="lblCommissionValue" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCommissionValueAltered" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    <p>Max Com Percentage	</p>
                </th>
                <td>
                    <asp:Label ID="lblMaxComPercentage" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblMaxComPercentageAltered" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    <p>Rule Group	</p>
                </th>
                <td>
                    <asp:Label ID="lblRuleGroup" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblRuleGroupAltered" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    <p>Validation Rule	</p>
                </th>
                <td>
                    <asp:Label ID="lblValidationRule" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblValidationRuleAltered" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    <p>Approval Chain	</p>
                </th>
                <td>
                    <asp:Label ID="lblApprovalChain" runat="server"></asp:Label>
                    <asp:HiddenField runat="server" ID="hfFlowId" />
                </td>
                <td>
                    <asp:Label ID="lblApprovalChainAltered" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    <p>Current Level	</p>
                </th>
                <td>
                    <asp:Label ID="lblCurrentLevel" runat="server"></asp:Label>
                    <asp:HiddenField runat="server" ID="hfLevelId" />
                </td>
                <td>
                    <asp:Label ID="lblCurrentLevelAltered" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    <p>Comments</p>
                </th>
                <td>
                    <asp:Label ID="lblComments" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCommentsAltered" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>

                    <p>Comments:</p>
                </th>
                <td colspan="2">
                    <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine"></asp:TextBox>

                </td>
            </tr>


        </table>

    </div>


    <br />


    <table style="margin: 0px auto;">
        <tr>
            <td style="align-content: center">
                <asp:Button ID="btnAccept" runat="server" Text="Approve" CssClass="testbutton" OnClick="btnAccept_Click" Style="align-content: center" />
            </td>
            <td style="align-content: center">
                <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="testbutton" OnClick="btnReject_Click" Style="align-content: center" />
            </td>
        </tr>
    </table>

    <div>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>

</asp:Content>

