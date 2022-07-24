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

    protected DateTime StartDate
    {
        get { return (DateTime)ViewState["StartDate"]; }
        set { ViewState["StartDate"] = value; }
    }

    protected DateTime EndDate
    {
        get { return (DateTime)ViewState["EndDate"]; }
        set { ViewState["EndDate"] = value; }
    }


    protected Int32 CycleId { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.CommissionReportCopyAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            Common.PopulatePeriodType(ddlPeridType);
            Common.AddSelectOne(ddlPeridType);

            editMode = "add";
            Id = -1;


            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                CommissionReportConciseEnt CommissionReportInfo = CommissionReportDAL.GetItemList(Id)[0];
                txtReportName.Text = CommissionReportInfo.ReportName;
                txtEffectiveDate.Text = DateTime.Compare(CommissionReportInfo.StartDate, default(DateTime)) == 0 ? String.Empty : CommissionReportInfo.StartDate.ToString("dd-MM-yyyy");
                StartDate = CommissionReportInfo.StartDate;
                txtExpiryDate.Text = DateTime.Compare(CommissionReportInfo.EndDate, default(DateTime)) == 0 ? String.Empty : CommissionReportInfo.EndDate.ToString("dd-MM-yyyy");
                EndDate = CommissionReportInfo.EndDate;
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
        MsgUtility.msg(editMode, ErrorCode, "Commission Report Information", this, lblResult, txtReportName.Text);
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
    }


    private int SaveData()
    {

        CommissionReportConciseEnt CommissionReportInfo = new CommissionReportConciseEnt();

        CommissionReportInfo.ReportId = Id;
        CommissionReportInfo.StartDate = String.IsNullOrEmpty(txtEffectiveDate.Text) ? Convert.ToDateTime(StartDate) : DateTime.Parse(txtEffectiveDate.Text);
        CommissionReportInfo.EndDate = String.IsNullOrEmpty(txtExpiryDate.Text) ? Convert.ToDateTime(EndDate) : DateTime.Parse(txtExpiryDate.Text);
        CommissionReportInfo.ReportName = this.txtNewReportName.Text;
        CycleId = int.Parse(ddlCommissionCycle.SelectedValue);

        CommissionReportInfo.CreateBy = LoginInfo.Current.UserId;
        return CommissionReportDAL.CreateReportReplication(CommissionReportInfo, "I", CycleId);
    }



    protected void ddlPeridType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPeridType.SelectedIndex > 0)
        {
            Common.PopulateCommissionCycleId(ddlCommissionCycle, int.Parse(ddlPeridType.SelectedValue));
            Common.AddSelectOne(ddlCommissionCycle);
        }
        else
        {
            ddlCommissionCycle.Items.Clear();
        }
    }



}