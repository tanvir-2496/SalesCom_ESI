using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web.UI.WebControls;
using System.Linq;

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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.AdhocReportAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            editMode = "add";
            Id = -1;

            PopolateListControlValues();

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                AdHocReportEnt adHocReportEnt = AdHocReportDAL.GetItemList(Id)[0];
                txtReportName.Text = adHocReportEnt.report_name;
                ddlChannelTypeId.SelectedValue = adHocReportEnt.channel_type_id.ToString();
                chkIsActive.Checked = Convert.ToBoolean(adHocReportEnt.is_active);
                ddlPeriod.SelectedValue = adHocReportEnt.period_type_id.ToString();
                ddlReportGentType.SelectedValue = adHocReportEnt.report_gen_type.ToString();
                ddlApprovalFlow.SelectedValue = adHocReportEnt.report_flow_id.ToString();
                ddlCliamApprovalFlow.SelectedValue = adHocReportEnt.claim_flow_id.ToString();
                ddlDisburseApprovalFlow.SelectedValue = adHocReportEnt.disburse_flow_id.ToString();

                txtSMSContent.Text = adHocReportEnt.SMSContent;
                txtDisburseTime.Text = adHocReportEnt.DisburseTime.ToString();


                // Addition
                ddlUpdatedReortName.Text = adHocReportEnt.report_name;

                lblUpdatedReortName.Visible = true;
                ddlUpdatedReortName.Visible = true;

                lblSetupReportId.Visible = false;
                ddlSetupReportId.Visible = false;

                List<ReportApprovalEnt> list = ReportApprovalDAL.GetItemList(Convert.ToInt32(adHocReportEnt.SrfUploadId));
                ReportInformationSet(list[0]);

                if (adHocReportEnt.disburseByEvSystem != null)
                {
                    RadioDisburseByEVSystem.SelectedValue = adHocReportEnt.disburseByEvSystem.ToString();
                }

                txtSMSContent.Text = adHocReportEnt.SMSContent;
                // end addition

                btnSave.Visible = Permissions.AdhocReportAdd;

            }

            if (!string.IsNullOrEmpty(Request["mode"]))
            {
                editMode = Request["mode"];
            }
        }
    }
    private void PopolateListControlValues()
    {
        Common.PopulateChannelType(ddlChannelTypeId);
        Common.AddSelectOne(ddlChannelTypeId);

        Common.PopulatePeriodType(ddlPeriod);

        Common.AddSelectOne(ddlPeriod);

        Common.PopulateReportGenType(ddlReportGentType);
        Common.AddSelectOne(ddlReportGentType);

        List<ApprovalFlowEnt> flow = ApprovalFlowDAL.GetApprovalFlowList(0, String.Empty);

        Common.PopulateFlow(flow, ddlApprovalFlow);
        Common.AddSelectOne(ddlApprovalFlow);

        Common.PopulateFlow(flow, ddlCliamApprovalFlow);
        Common.AddSelectOne(ddlCliamApprovalFlow);

        Common.PopulateFlow(flow, ddlDisburseApprovalFlow);
        Common.AddSelectOne(ddlDisburseApprovalFlow);

        // addition

        List<ReportApprovalEnt> list = ReportApprovalDAL.GetItemList(0);
        List<ReportApprovalEnt> sortedReportList = list.Where(item => item.IsSetupDone == 0).OrderByDescending(x => x.current_status_date).ToList();
        Common.PopulateSetupReportApproval(sortedReportList, ddlSetupReportId);
        Common.AddSelectOne(ddlSetupReportId);
        ReportInformationSet(sortedReportList[0]);
        // end addition
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int ErrorCode = SaveData();
        MsgUtility.msg(editMode, ErrorCode, "Ad Hoc Report Information", this, lblResult, txtReportName.Text);
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
        txtReportName.Text = String.Empty;
        ddlChannelTypeId.SelectedIndex = -1;
        ddlReportGentType.SelectedIndex = -1;
        ddlApprovalFlow.SelectedIndex = -1;
        ddlCliamApprovalFlow.SelectedIndex = -1;
        ddlDisburseApprovalFlow.SelectedIndex = -1;
        chkIsActive.Checked = false;
        txtSMSContent.Text = String.Empty;
        txtDisburseTime.Text = String.Empty;
        PopolateListControlValues();
    }

    private int SaveData()
    {
        string ext = String.Empty;
        int result = 0;
        AdHocReportEnt adHocReportEnt = new AdHocReportEnt();

        if (ImageTypeFileUpLoad.HasFile)
        {
            ext = System.IO.Path.GetExtension(ImageTypeFileUpLoad.PostedFile.FileName);
            adHocReportEnt.file_type = ext.Replace(".", String.Empty);
            adHocReportEnt.sr_content = ImageTypeFileUpLoad.FileBytes;
        }

        adHocReportEnt.ad_hoc_report_id = Id;
        adHocReportEnt.report_name = txtReportName.Text;
        adHocReportEnt.channel_type_id = Int16.Parse(ddlChannelTypeId.SelectedValue);
        adHocReportEnt.is_active = chkIsActive.Checked == true ? (Int16)1 : (Int16)0;

        adHocReportEnt.period_type_id = Int16.Parse(ddlPeriod.SelectedValue);
        adHocReportEnt.report_gen_type = Int16.Parse(ddlReportGentType.SelectedValue);
        adHocReportEnt.report_flow_id = Int16.Parse(ddlApprovalFlow.SelectedValue);
        adHocReportEnt.claim_flow_id = Int16.Parse(ddlCliamApprovalFlow.SelectedValue);
        adHocReportEnt.disburse_flow_id = Int16.Parse(ddlDisburseApprovalFlow.SelectedValue);

        adHocReportEnt.disburseByEvSystem = Convert.ToInt16(RadioDisburseByEVSystem.SelectedValue);

        adHocReportEnt.SMSContent = txtSMSContent.Text;
      //  adHocReportEnt.DisburseTime = decimal.Parse(txtDisburseTime.Text);

        if (!string.IsNullOrEmpty(txtDisburseTime.Text))
            adHocReportEnt.DisburseTime = decimal.Parse(txtDisburseTime.Text.Trim());

        // addition
        adHocReportEnt.SrfUploadId = Convert.ToInt32(ddlSetupReportId.SelectedValue);
        // end addition

        if (editMode == "edit")
        {
            adHocReportEnt.update_by = LoginInfo.Current.UserId;
            result = AdHocReportDAL.SaveItemWithFile(adHocReportEnt, "U", LoginInfo.Current.UserId);
        }
        else
        {
            adHocReportEnt.create_by = LoginInfo.Current.UserId;
            result = AdHocReportDAL.SaveItemWithFile(adHocReportEnt, "I", LoginInfo.Current.UserId);
        }

        return result;
    }

    protected void ddlGetReportInformation(object sender, EventArgs e)
    {
        ReportApprovalEnt reportSetupInfo = ReportApprovalDAL.GetItemList(Convert.ToInt32(ddlSetupReportId.SelectedValue))[0];
        ReportInformationSet(reportSetupInfo);
    }

    public void ReportInformationSet(ReportApprovalEnt reportSetupInfo)
    {
        //ddlChannelTypeId.SelectedIndex = reportSetupInfo.channel_type_id;
        txtDisburseTime.Text = reportSetupInfo.DisbursementTime.ToString();
        RadioDisburseByEVSystem.SelectedValue = reportSetupInfo.DisburseByEv.ToString();

        txtReportName.Text = reportSetupInfo.report_name.ToString();

        if (string.IsNullOrEmpty(Request["Id"]))
        {
            lblUpdatedReortName.Visible = false;
            ddlUpdatedReortName.Visible = false;
        }

        lblReportName.Visible = false;
        txtReportName.Visible = false;

        lblDisbursTime.Visible = true;
        txtDisburseTime.Visible = true;
        txtDisburseTime.Enabled = false;


        RadioDisburseByEVSystem.Enabled = false;

        lblSMSContent.Visible = false;
        txtSMSContent.Visible = false;
        txtSMSContent.Text = String.Empty;
        txtSMSContent.ReadOnly = true;

        if (reportSetupInfo.DisburseByEv == 1)
        {
            lblSMSContent.Visible = true;
            txtSMSContent.Visible = true;
            txtSMSContent.Text = String.Empty;
            txtSMSContent.ReadOnly = false;
        }

    }




}