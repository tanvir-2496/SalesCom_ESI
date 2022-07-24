using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Configuration;
using System.IO;

public partial class SetupActivityAdd : System.Web.UI.Page
{
    protected string editMode
    {
        get { return ViewState["editMode"].ToString(); }
        set { ViewState["editMode"] = value; }
    }

    protected int Id
    {
        get { return (int)ViewState["Id"]; }
        set { ViewState["Id"] = value; }
    }

    protected int IsActive
    {
        get { return Object.ReferenceEquals(null, ViewState["IsActive"]) ? 0 : (int)ViewState["IsActive"]; }
        set { ViewState["IsActive"] = value; }
    }
    protected int ProvisioningDay
    {
        get { return Object.ReferenceEquals(null, ViewState["ProvisioningDay"]) ? 0 : (int)ViewState["ProvisioningDay"]; }
        set { ViewState["ProvisioningDay"] = value; }
    }
    protected int GenerationDay
    {
        get { return Object.ReferenceEquals(null, ViewState["GenerationDay"]) ? 0 : (int)ViewState["GenerationDay"]; }
        set { ViewState["GenerationDay"] = value; }
    }
    protected int PeriodTypeId
    {
        get { return Object.ReferenceEquals(null, ViewState["PeriodTypeId"]) ? 0 : (int)ViewState["PeriodTypeId"]; }
        set { ViewState["PeriodTypeId"] = value; }
    }
    protected int ReportGenTypeId
    {
        get { return Object.ReferenceEquals(null, ViewState["ReportGenTypeId"]) ? 0 : (int)ViewState["ReportGenTypeId"]; }
        set { ViewState["ReportGenTypeId"] = value; }
    }

    protected int ApprovalFlowId
    {
        get { return Object.ReferenceEquals(null, ViewState["ApprovalFlowId"]) ? 0 : (int)ViewState["ApprovalFlowId"]; }
        set { ViewState["ApprovalFlowId"] = value; }
    }

    protected int ClaimFlowId
    {
        get { return Object.ReferenceEquals(null, ViewState["ClaimFlowId"]) ? 0 : (int)ViewState["ClaimFlowId"]; }
        set { ViewState["ClaimFlowId"] = value; }
    }

    protected int DisburselFlowId
    {
        get { return Object.ReferenceEquals(null, ViewState["DisburselFlowId"]) ? 0 : (int)ViewState["DisburselFlowId"]; }
        set { ViewState["DisburselFlowId"] = value; }
    }

    protected int ReportTypeId
    {
        get { return Object.ReferenceEquals(null, ViewState["ReportTypeId"]) ? 0 : (int)ViewState["ReportTypeId"]; }
        set { ViewState["ReportTypeId"] = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.CommissionReportConciseAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            editMode = "add";
            Id = -1;
            Common.PopulateChannelType(ddlChannelTypeId);
            Common.AddSelectOne(ddlChannelTypeId);

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                CommissionReportConciseEnt CommissionReportInfo = CommissionReportDAL.GetItemList(Id)[0];
                txtReportName.Text = CommissionReportInfo.ReportName;
                ddlChannelTypeId.SelectedValue = CommissionReportInfo.ChannelTypeId.ToString();
                txtEffectiveDate.Text = CommissionReportInfo.StartDate.ToString("dd-MM-yyyy");
                txtExpiryDate.Text = CommissionReportInfo.EndDate.ToString("dd-MM-yyyy");
                IsActive = CommissionReportInfo.IsActive;
                ProvisioningDay = CommissionReportInfo.ProvisioningDay;
                GenerationDay = CommissionReportInfo.GenerationDay;
                PeriodTypeId = CommissionReportInfo.PeriodTypeID;
                ReportGenTypeId = CommissionReportInfo.ReportGenTypeId;
                ApprovalFlowId = CommissionReportInfo.ApprovalFlowId;
                ClaimFlowId = CommissionReportInfo.ClaimApprovalFlowId;
                DisburselFlowId = CommissionReportInfo.DisburseApprovalFlowId;
                ReportTypeId = CommissionReportInfo.report_type_id;
            }

            if (!string.IsNullOrEmpty(Request["mode"]))
            {
                editMode = Request["mode"];
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int ErrorCode = SaveData();
        MsgUtility.msg(editMode, ErrorCode, "Report's Concise Particulars", this, lblResult, txtReportName.Text);
        if (editMode == "add")
        {
            if (ErrorCode >= 0)
            {
                ClearData();
            }
        }
    }

    private void ClearData()
    {
        editMode = "add";
        Id = -1;
        txtReportName.Text = txtEffectiveDate.Text = txtExpiryDate.Text = String.Empty;
        ddlChannelTypeId.SelectedIndex = -1;
    }

    string FilePath;


    private int SaveData()
    {
        string ext = String.Empty;
        int result = 0;
        CommissionReportConciseEnt CommissionReportInfo = new CommissionReportConciseEnt();

        if (ImageTypeFileUpLoad.HasFile)
        {
            ext = System.IO.Path.GetExtension(ImageTypeFileUpLoad.PostedFile.FileName);
            CommissionReportInfo.FileType = ext.Replace(".", String.Empty);
            CommissionReportInfo.SRContent = ImageTypeFileUpLoad.FileBytes;
        }

        CommissionReportInfo.ReportId = Id;
        CommissionReportInfo.ReportName = txtReportName.Text;
        CommissionReportInfo.ChannelTypeId = int.Parse(ddlChannelTypeId.SelectedValue);
        CommissionReportInfo.Frequency = 0;
        CommissionReportInfo.StartDate = String.IsNullOrEmpty(txtEffectiveDate.Text) ? default(DateTime) : DateTime.Parse(txtEffectiveDate.Text);
        CommissionReportInfo.EndDate = String.IsNullOrEmpty(txtExpiryDate.Text) ? default(DateTime) : DateTime.Parse(txtExpiryDate.Text);
        CommissionReportInfo.IsActive = IsActive;
        CommissionReportInfo.ProvisioningDay = ProvisioningDay;
        CommissionReportInfo.GenerationDay = GenerationDay;
        CommissionReportInfo.PeriodTypeID = PeriodTypeId;
        CommissionReportInfo.ReportGenTypeId = ReportGenTypeId;
        CommissionReportInfo.ApprovalFlowId = ApprovalFlowId;
        CommissionReportInfo.ClaimApprovalFlowId = ClaimFlowId;
        CommissionReportInfo.DisburseApprovalFlowId = DisburselFlowId;
        CommissionReportInfo.report_type_id = ReportTypeId;

        if (editMode == "edit")
        {
            CommissionReportInfo.UpdateBy = LoginInfo.Current.UserId;
            result = CommissionReportDAL.SaveItemWithFile(CommissionReportInfo, "U", LoginInfo.Current.UserId);
        }
        else
        {
            CommissionReportInfo.CreateBy = LoginInfo.Current.UserId;
            result = CommissionReportDAL.SaveItemWithFile(CommissionReportInfo, "I", LoginInfo.Current.UserId);
        }

        return result;
    }

}