<%@ Page Title="Claim Report" Language="C#" MasterPageFile="~/MasterPages/Modal.master" AutoEventWireup="true" CodeFile="ClaimReport.aspx.cs" Inherits="SetupActivity" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Label ID="errorMessage" runat="server" SkinID="lblErrorMsgSkin"></asp:Label>
    <CR:CrystalReportViewer ID="crvDigitalApproval" runat="server"
        AutoDataBind="true"
        BorderColor="#FF9900"
        BorderStyle="Ridge"
        BorderWidth="2px"
        HasCrystalLogo="False"
        Height="50px"
        ToolbarStyle-BackColor="#FF9900"
        ToolbarStyle-BorderColor="#996600"
        ToolbarStyle-BorderStyle="Inset"
        ToolbarStyle-BorderWidth="3px"
        EnableTheming="False"
        EnableToolTips="False"
        Width="350px" />
    <CR:CrystalReportSource ID="crsDigitalApproval" runat="server">
        <Report FileName="Reports/crDigitalApproval.rpt">
        </Report>
    </CR:CrystalReportSource>

</asp:Content>



