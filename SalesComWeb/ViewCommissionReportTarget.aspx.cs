using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;

public partial class SetupActivity : System.Web.UI.Page
{

    List<CommissionReportTargetsEnt> commissionReportTargets;

    protected void pager_PreRender(object sender, EventArgs e)
    {
        if (CheckInput())
        {
            BindGetData(Int32.Parse(ddlReportName.SelectedValue), Int32.Parse(ddlEventType.SelectedValue), int.Parse(ddlReportCycle.SelectedValue), false);
        }
        else
        {
            BindGetData(0, 0, 0, true);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.ImportCommissionTargetView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            Common.PopulateCommissionReportId(ddlReportName);
            Common.AddSelectOne(ddlReportName);
        }
    }

    private void BindGetData(int reportId, int eventId, int reportCycle, bool isBlank)
    {
        if (!isBlank)
        {
            commissionReportTargets = CommissionReportTargetsDAL.GetItemList(reportId, eventId, reportCycle);
            lvImportedData.Visible = true;
            lvImportedData.DataSource = commissionReportTargets;
            lvImportedData.DataBind();
            lblResult.Text = String.Format("Total results: {0}", commissionReportTargets.Count);
            dpImportedData.Visible = commissionReportTargets.Count > dpImportedData.PageSize;
        }
        else
        {
            commissionReportTargets = new List<CommissionReportTargetsEnt>();
            lvImportedData.Visible = false;
            lvImportedData.DataSource = commissionReportTargets;
            lvImportedData.DataBind();
            //lblResult.Text = String.Format("Total results: {0}", commissionReportTargets.Count);
            dpImportedData.Visible = false;
        }

    }

    protected void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.PopulateEventTypeByReportId(ddlEventType, int.Parse(ddlReportName.SelectedValue));
        Common.AddSelectOne(ddlEventType);
        Common.PopulateCommissionCycleByReportId(ddlReportCycle, int.Parse(ddlReportName.SelectedValue));
        Common.AddSelectOne(ddlReportCycle);
    }
    protected void btnShowPreviousImportData_Click(object sender, EventArgs e)
    {
        if (CheckInput())
        {
            BindGetData(int.Parse(ddlReportName.SelectedValue), int.Parse(ddlEventType.SelectedValue), int.Parse(ddlReportCycle.SelectedValue), false);
        }
        else
        {
            BindGetData(0, 0, 0, true);
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Redirect("ImportCommissionReportTarget.aspx", true);
    }

    private bool CheckInput()
    {

        if (ddlReportName.SelectedIndex == 0)
        {

            lblResult.Text = "Report Name Required!";
            this.ddlReportName.Focus();
            return false;

        }
        else if (ddlReportCycle.SelectedIndex == 0)
        {

            lblResult.Text = "Report Cycle Required!";
            this.ddlReportName.Focus();
            return false;

        }
        else if (ddlEventType.SelectedIndex == 0)
        {

            lblResult.Text = "Event Type Required!";
            this.ddlEventType.Focus();
            return false;

        }
        else
        {
            return true;
        }


    }

}