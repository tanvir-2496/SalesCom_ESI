using ESI.DAL;
using ESI.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class TargetView : System.Web.UI.Page
{
    protected Int32 Id
    {
        get { return (Int32)ViewState["Id"]; }
        set { ViewState["Id"] = value; }
    }

    protected bool ReprotEligibleForHaltKPI
    {
        get { return (bool)ViewState["ReprotEligibleForHaltKPI"]; }
        set { ViewState["ReprotEligibleForHaltKPI"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.ESIReportApproval)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            Id = -1;

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request.QueryString["ID"]);
                lblReportName.Text = Request.QueryString["RN"];
                int OrderId = int.Parse(Request.QueryString["ORDER_ID"]);
                string level = Request.QueryString["CURRENT_LEVEL"];
                
                int IsEligible = kpi_approval_dal.CheckReportElgibileForHalt(Id);
                ReprotEligibleForHaltKPI = true;
                if (IsEligible != 1 || OrderId != 1 || level.Contains("Report") == false)
                {
                    ReprotEligibleForHaltKPI = false;
                }

                GetKPI_SubKPIList(Id);
            }
        }

    }

    private void GetKPI_SubKPIList(int reportCycleId)
    {
        try
        {
            List<ReportKpiListForHalt> list = new List<ReportKpiListForHalt>();
            list = kpi_approval_dal.GetReportKpiListForHalt(reportCycleId, "ESI_GETRPT_FOR_HALTKPI");
            lv.DataSource = list;
            lv.DataBind();
        }
        catch (Exception ex)
        {
            this.lblResult.ForeColor = Color.Red;
            this.lblResult.Text = "Error Occured!!!";
        }
    }

    protected void lv_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        LinkButton _lbtnHaltKPIforArrear = (LinkButton)e.Item.FindControl("lbtnHaltKPIforArrear");
        
        if (!ReprotEligibleForHaltKPI || !Permissions.ESIKpiConfigure)
        {
            _lbtnHaltKPIforArrear.Visible = false;
            _lbtnHaltKPIforArrear.Enabled = false;
        }
    }

    protected void lv_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });

        int kpi_id = Convert.ToInt32(commandArgs[0]);
        int subkpi_id = Convert.ToInt32(commandArgs[1]);
        int reportCycleId = Id;

        try
        {
            int result = kpi_approval_dal.SetKPIforHalt(reportCycleId, kpi_id, subkpi_id, LoginInfo.Current.UserId);
            if (result >= 0)
            {
                this.lblResult.ForeColor = Color.Green;
                this.lblResult.Text = "Successfully updated";
                GetKPI_SubKPIList(reportCycleId);
            }
            else 
            {
                this.lblResult.ForeColor = Color.Red;
                this.lblResult.Text = "Error Occured!!!";
            }
        }
        catch (Exception ex)
        {
            this.lblResult.ForeColor = Color.Red;
            this.lblResult.Text = "Error Occured!!!";
        }

    }
}