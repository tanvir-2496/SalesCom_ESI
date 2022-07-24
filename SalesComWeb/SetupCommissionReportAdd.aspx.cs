using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Linq;



public partial class SetupActivityAdd : System.Web.UI.Page
{
    protected string editMode
    {
        get { return ViewState["editMode"].ToString();  }
        set { ViewState["editMode"] = value; }
    }
    protected int Id
    {
        get { return (int)ViewState["Id"]; }
        set { ViewState["Id"] = value; }
    }

    protected int ReportGeneTypeID
    {
        get { return Object.ReferenceEquals(null, ViewState["ReportGeneTypeID"]) ? 0 : (int)ViewState["ReportGeneTypeID"]; }
        set { ViewState["ReportGeneTypeID"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.CommissionReportAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            editMode = "add";
            Id = -1;

            PopolateListControlValues();


            // for edit 
            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                CommissionReportConciseEnt CommissionReportInfo = CommissionReportDAL.GetItemList(Id)[0];
                txtReportName.Text = CommissionReportInfo.ReportName;
                ddlReportType.SelectedValue = CommissionReportInfo.report_type_id.ToString();
                ddlChannelTypeId.SelectedValue = CommissionReportInfo.ChannelTypeId.ToString();
                chkIsActive.Checked = Convert.ToBoolean(CommissionReportInfo.IsActive);
                txtProvisioningDay.Text = CommissionReportInfo.ProvisioningDay.ToString();
                txtGenerationDay.Text = CommissionReportInfo.GenerationDay.ToString();
                ddlPeriod.SelectedValue = CommissionReportInfo.PeriodTypeID.ToString();
                ddlReportGentType.SelectedValue = CommissionReportInfo.ReportGenTypeId.ToString();
                ReportGeneTypeID = CommissionReportInfo.ReportGenTypeId;
                txtDelayDay.Text = CommissionReportInfo.DelayDay.ToString();
                ddlApprovalFlow.SelectedValue = CommissionReportInfo.ApprovalFlowId.ToString();
                ddlCliamApprovalFlow.SelectedValue = CommissionReportInfo.ClaimApprovalFlowId.ToString();
                ddlDisburseApprovalFlow.SelectedValue = CommissionReportInfo.DisburseApprovalFlowId.ToString();
                chkPosUpload.Checked = CommissionReportInfo.upload_commission_at_pos == 'Y' ? true : false;

                
                txtDisburseTime.Text = CommissionReportInfo.DisburseTime.ToString();

                // Addition
                ddlUpdatedReortName.Text = CommissionReportInfo.ReportName;

                lblUpdatedReortName.Visible = true;
                ddlUpdatedReortName.Visible = true;

                lblSetupReportId.Visible = false;
                ddlSetupReportId.Visible = false;

                List<ReportApprovalEnt> list = ReportApprovalDAL.GetItemList(Convert.ToInt32(CommissionReportInfo.SrfUploadId));
                ReportInformationSet(list[0]);

                if (CommissionReportInfo.disburseByEvSystem != null)
                {
                    RadioDisburseByEVSystem.SelectedValue = CommissionReportInfo.disburseByEvSystem.ToString();
                }

                txtSMSContent.Text = CommissionReportInfo.SMSContent;
                // end addition

                btnSave.Visible = Permissions.CommissionReportAdd;
                show_bind_event();
            }
            else
            {
                this.plEvent.Visible = false;
            }

            if (!string.IsNullOrEmpty(Request["mode"]))
            {
                editMode = Request["mode"];
            }
        }
    }

    private void PopolateListControlValues()
    {
        Common.PopulateReportType(ddlReportType);
        Common.AddSelectOne(ddlReportType);

        Common.PopulateChannelType(ddlChannelTypeId);
        Common.AddSelectOne(ddlChannelTypeId);

        Common.PopulateEvent(ddlEvent);
        Common.AddSelectOne(ddlEvent);

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
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int ErrorCode = SaveData();
        MsgUtility.msg(editMode, ErrorCode, "Report Particulars", this, lblResult, txtReportName.Text);
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
        txtReportName.Text = txtProvisioningDay.Text = txtGenerationDay.Text = String.Empty;
        ddlChannelTypeId.SelectedIndex = -1;
        ddlReportType.SelectedIndex = -1;
        ddlPeriod.SelectedIndex = -1;
        ddlReportGentType.SelectedIndex = -1;
        ddlApprovalFlow.SelectedIndex = -1;
        ddlCliamApprovalFlow.SelectedIndex = -1;
        ddlDisburseApprovalFlow.SelectedIndex = -1;
        chkIsActive.Checked = false;
        txtSMSContent.Text = String.Empty;
        txtDisburseTime.Text = String.Empty;
        txtDelayDay.Text = String.Empty;
        List<ReportApprovalEnt> list = ReportApprovalDAL.GetItemList(0);
        List<ReportApprovalEnt> sortedReportList = list.Where(item => item.IsSetupDone == 0).OrderByDescending(x => x.current_status_date).ToList();
        Common.PopulateSetupReportApproval(sortedReportList, ddlSetupReportId);
        Common.AddSelectOne(ddlSetupReportId);
    }

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
        CommissionReportInfo.IsActive = chkIsActive.Checked == true ? 1 : 0;
        CommissionReportInfo.Frequency = 0;

        CommissionReportInfo.ProvisioningDay = int.Parse(txtProvisioningDay.Text);
        CommissionReportInfo.GenerationDay = int.Parse(txtGenerationDay.Text);
        CommissionReportInfo.PeriodTypeID = int.Parse(ddlPeriod.SelectedValue);
        CommissionReportInfo.ReportGenTypeId = int.Parse(ddlReportGentType.SelectedValue) > 0 ? int.Parse(ddlReportGentType.SelectedValue) : ReportGeneTypeID;
        CommissionReportInfo.ApprovalFlowId = int.Parse(ddlApprovalFlow.SelectedValue);
        CommissionReportInfo.ClaimApprovalFlowId = int.Parse(ddlCliamApprovalFlow.SelectedValue);
        CommissionReportInfo.DisburseApprovalFlowId = int.Parse(ddlDisburseApprovalFlow.SelectedValue);
        CommissionReportInfo.report_type_id = int.Parse(ddlReportType.SelectedValue);
        CommissionReportInfo.DelayDay = int.Parse(txtDelayDay.Text);
        CommissionReportInfo.upload_commission_at_pos = chkPosUpload.Checked == true ? 'Y' : 'N';
        CommissionReportInfo.disburseByEvSystem = Convert.ToInt16(RadioDisburseByEVSystem.SelectedValue);
        CommissionReportInfo.SMSContent = txtSMSContent.Text;

        if(!string.IsNullOrEmpty(txtDisburseTime.Text))
            CommissionReportInfo.DisburseTime = decimal.Parse(txtDisburseTime.Text.Trim());

        // addition
        CommissionReportInfo.SrfUploadId = Convert.ToInt32(ddlSetupReportId.SelectedValue);
        // end addition

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


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Id < 1 || ddlEvent.SelectedIndex < 1)
            return;
        CommissionReportEventsEnt obj = new CommissionReportEventsEnt();
        obj.ReportID = Id;
        obj.EventID = int.Parse(ddlEvent.SelectedValue);

        int ErrorCode = CommissionReportEventsDAL.SaveItem(obj, "I");
        if (ErrorCode <= -1)
            lblMsg.Text = "Event bind unsuccessful!";
        else
        {
            lblMsg.Text = "Event bind successful";
            show_bind_event();
            ddlEvent.SelectedIndex = -1;
        }

    }
    protected void lvEOMaster_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (string.Equals(e.CommandName, "Del"))
        {
            int i = -1;
            string[] arguments = e.CommandArgument.ToString().Split('|');

            if (Id > -1)
            {
                CommissionReportEventsEnt obj = new CommissionReportEventsEnt();
                obj.EventID = int.Parse(arguments[0]);
                obj.ReportID = int.Parse(arguments[1]);
                i = CommissionReportEventsDAL.SaveItem(obj, "D");

                if (i <= -1)
                    lblMsg.Text = "Event deletion unsuccessful!";
                else
                {
                    lblMsg.Text = "Event deletion successful.";
                }
                show_bind_event();
            }
        }

    }
    protected void show_bind_event()
    {
        List<CommissionReportEventsEnt> list = CommissionReportEventsDAL.GetItemList(Id);
        lvEOMaster.DataSource = list;
        lvEOMaster.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        if (list.Count <= pager.PageSize)
        {
            pager.Visible = false;
        }
    }

    //

    protected void ddlGetReportInformation(object sender, EventArgs e)
    {
         ReportApprovalEnt reportSetupInfo = ReportApprovalDAL.GetItemList(Convert.ToInt32(ddlSetupReportId.SelectedValue))[0];
         ReportInformationSet(reportSetupInfo);
    }

    public void ReportInformationSet(ReportApprovalEnt reportSetupInfo)
    {
       // ddlChannelTypeId.SelectedIndex = reportSetupInfo.channel_type_id;
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

        Label4.Visible = true;
        RadioDisburseByEVSystem.Visible = true;

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