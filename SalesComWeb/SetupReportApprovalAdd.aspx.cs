using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;

public partial class SetupReportApprovalAdd : System.Web.UI.Page
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

            if (!string.IsNullOrEmpty(Request["mode"]))
            {
                if (!Permissions.ReportApprovalModify)
                {
                    MsgUtility.showNotPermittedMsg(this.Page);
                    return;
                }
                editMode = Request["mode"];
            }
            else
            {
                if (!Permissions.ReportApprovalAdd)
                {
                    MsgUtility.showNotPermittedMsg(this.Page);
                    return;
                }
                editMode = "add";
            }

            Id = -1;
            Common.PopulateChannelType(ddlChannelTypeId);
            Common.AddSelectOne(ddlChannelTypeId);
            Common.PopulatePeriodType(ddlPeriodType);
            Common.AddSelectOne(ddlPeriodType);
            Common.PopulateApprovalFlow(ddlApprovalFlow, "SR");
            Common.AddSelectOne(ddlApprovalFlow);

            //ddlSelectedDisburseTime
            Populate24Hours(ddlSelectedDisburseTime);
            Common.AddSelectOne(ddlSelectedDisburseTime);

            if (editMode == "edit")
            {
                Id = int.Parse(Request["Id"]);
                ReportApprovalEnt reportApprovalEnt = ReportApprovalDAL.GetItemList(Id)[0];
                txtReportName.Text = reportApprovalEnt.report_name;
                ddlChannelTypeId.SelectedValue = reportApprovalEnt.channel_type_id.ToString();
                txtMatureDate.Text = reportApprovalEnt.mature_date.ToString("dd-MM-yyyy");
                txtEffectiveDate.Text = reportApprovalEnt.effective_date.ToString("dd-MM-yyyy");
                txtExpiryDate.Text = reportApprovalEnt.expire_date.ToString("dd-MM-yyyy");
                ddlPeriodType.SelectedValue = reportApprovalEnt.period_type_id.ToString();
                ddlApprovalFlow.SelectedValue = reportApprovalEnt.approval_flow_id.ToString();
                chkPosUpload.Checked = reportApprovalEnt.upload_commission_at_pos == 'Y' ? true : false;
                chkDetailRequired.Checked = reportApprovalEnt.is_detail_required  == 'Y' ? true : false;

                // addition

                RadioDisburseByEVSystem.SelectedValue = reportApprovalEnt.DisburseByEv.ToString();
                //txtDisburseTime.Text = reportApprovalEnt.DisbursementTime != 0 ? reportApprovalEnt.DisbursementTime.ToString() : String.Empty;
                ddlSelectedDisburseTime.SelectedValue = reportApprovalEnt.DisbursementTime != 0 ? reportApprovalEnt.DisbursementTime.ToString() : String.Empty;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int ErrorCode = SaveData();
        MsgUtility.msg(editMode, ErrorCode, "Report Approval Information", this.Page, lblResult, txtReportName.Text);

        if (editMode == "add")
        {
            if (ErrorCode >= 0)
            {
                ClearData();
            }
            else if (ErrorCode == -1)
            {
                lblResult.Font.Bold = true;
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "Report Name is already exist!";
            }
        }
    }

    private void ClearData()
    {
        editMode = "add";
        Id = -1;
        txtReportName.Text = txtEffectiveDate.Text = txtExpiryDate.Text = txtMatureDate.Text = String.Empty;
        ddlChannelTypeId.SelectedIndex = -1;
        ddlApprovalFlow.SelectedIndex = -1;
        ddlPeriodType.SelectedIndex = -1;

        // addition
        //txtDisburseTime.Text = String.Empty;
        ddlSelectedDisburseTime.SelectedIndex = -1;
        RadioDisburseByEVSystem.SelectedValue = "0";
    }

    string FilePath;


    private int SaveData()
    {
        string ext = String.Empty;
        int result = 0;
        ReportApprovalEnt reportApproval = new ReportApprovalEnt();

        if (ImageTypeFileUpLoad.HasFile)
        {
            ext = System.IO.Path.GetExtension(ImageTypeFileUpLoad.PostedFile.FileName);
            reportApproval.filetype = ext.Replace(".", String.Empty);
            reportApproval.srcontent = ImageTypeFileUpLoad.FileBytes;
        }

        reportApproval.report_approval_id = Id;
        reportApproval.report_name = txtReportName.Text;
        reportApproval.channel_type_id = Int16.Parse(ddlChannelTypeId.SelectedValue);
        reportApproval.period_type_id = Int16.Parse(ddlPeriodType.SelectedValue);
        reportApproval.approval_flow_id = Int16.Parse(ddlApprovalFlow.SelectedValue);
        reportApproval.mature_date = String.IsNullOrEmpty(txtMatureDate.Text) ? default(DateTime) : DateTime.Parse(txtMatureDate.Text);
        reportApproval.effective_date = String.IsNullOrEmpty(txtEffectiveDate.Text) ? default(DateTime) : DateTime.Parse(txtEffectiveDate.Text);
        reportApproval.expire_date = String.IsNullOrEmpty(txtExpiryDate.Text) ? default(DateTime) : DateTime.Parse(txtExpiryDate.Text);
        reportApproval.upload_commission_at_pos = chkPosUpload.Checked == true ? 'Y' : 'N';
        reportApproval.is_detail_required = chkDetailRequired.Checked == true ? 'Y' : 'N';

        // addition
        reportApproval.DisburseByEv = Convert.ToInt16(RadioDisburseByEVSystem.SelectedValue);

        //if (!string.IsNullOrEmpty(txtDisburseTime.Text))
        //    reportApproval.DisbursementTime = Convert.ToInt16(txtDisburseTime.Text.Trim());

        if (ddlSelectedDisburseTime.SelectedIndex != -1)
        {
            reportApproval.DisbursementTime = Convert.ToInt16(ddlSelectedDisburseTime.SelectedValue);
        }

        bool isExistReport = ReportApprovalDAL.IsReportExist(reportApproval.report_name);

        if (editMode == "edit")
        {
            result = ReportApprovalDAL.SaveItemWithFile(reportApproval, "U", LoginInfo.Current.UserId, LoginInfo.Current.UserName);
        }
        else if (isExistReport == false)
        {
            result = ReportApprovalDAL.SaveItemWithFile(reportApproval, "I", LoginInfo.Current.UserId, LoginInfo.Current.UserName);
        }
        else if (isExistReport == true)
        {
            return -1; // if report already exist in database
        }

        return result;
    }

    private void Populate24Hours(ListControl control)
    {
        List<ListItem> hourList = new List<ListItem>();
        for (int i = 8; i < 24; i++)
        {
            hourList.Add(new ListItem()
            {
                Text = Convert.ToString(i),
                Value = Convert.ToString(i)
            });
        }
        control.DataSource = hourList;
        control.DataTextField = "Text";
        control.DataValueField = "Value";
        control.DataBind();
    }


}